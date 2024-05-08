using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Windows.Win32;
using Windows.Win32.Foundation;
using Windows.Win32.UI.Shell;
using static System.Windows.Forms.Design.AxImporter;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace gui
{
	public partial class Repack : Form
	{

		public Repack()
		{
			InitializeComponent();
			var tip = new System.Windows.Forms.ToolTip();
			tip.SetToolTip(lvlsList,
				"Choose 'Pick Folder' or drag and drop .lvl files\n" +
				"and/or folders containing .lvls onto the list."
				);
		}

		// Add a file or folder to the lvls to process.
		// if path is a folder, all .lvls found under the folder will be added.
		private void AddPath(string path)
		{
			if (path != null)
			{
				if (Directory.Exists(path))
				{
					List<string> files = new List<string>();
					files.AddRange(Directory.EnumerateFiles(path, "*.lvl", SearchOption.AllDirectories));
					lvlsList.BeginUpdate();
					foreach (var v in files)
						lvlsList.Items.Add(v);
					lvlsList.EndUpdate();
				}
				else if (File.Exists(path) && path.EndsWith(".lvl", StringComparison.InvariantCultureIgnoreCase))
				{
					lvlsList.Items.Add(path);
				}
			}
			repackButton.Enabled = lvlsList.Items.Count > 0;
		}

		private void IncrementProgress()
		{
			if (this.InvokeRequired)
			{
				this.Invoke(new Action(() => IncrementProgress()));
			}
			else
			{
				repackProgress.Value++;
			}
		}

		private void AddOutputMessage(string msg)
		{
			if (outputDisplay.InvokeRequired)
			{
				outputDisplay.BeginInvoke((MethodInvoker)delegate
				{
					AddOutputMessage(msg);
				});
			}
			else
			{
				outputDisplay.AppendText(msg);
			}
		}

		#region Drag/Drop handlers
		// For drag/drop the control's 'AllowDrop' property needs to be set to true
		private void lvlsList_DragEnter(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.FileDrop))
				e.Effect = DragDropEffects.Copy; // Show copy cursor
			else
				e.Effect = DragDropEffects.None; // Show no-drop cursor
		}

		private void lvlsList_DragDrop(object sender, DragEventArgs e)
		{
			string[] files = (string[])e.Data.GetData(DataFormats.FileDrop, false);

			// Process the dropped files/folders here
			foreach (string file in files)
			{
				AddPath(file);
			}
		}
		#endregion Drag/Drop handlers


		private void pickFolder_Click(object sender, EventArgs e)
		{
			PInvoke.CoCreateInstance(
				 typeof(FileOpenDialog).GUID,
			null,
			Windows.Win32.System.Com.CLSCTX.CLSCTX_INPROC_SERVER,
				 out IFileOpenDialog pickDialog).ThrowOnFailure();

			pickDialog.SetOptions(FILEOPENDIALOGOPTIONS.FOS_PATHMUSTEXIST | FILEOPENDIALOGOPTIONS.FOS_FILEMUSTEXIST | FILEOPENDIALOGOPTIONS.FOS_NOCHANGEDIR | FILEOPENDIALOGOPTIONS.FOS_PICKFOLDERS);
			pickDialog.SetTitle("Pick Folder");
			pickDialog.SetOkButtonLabel("Pick");

			try
			{
				pickDialog.Show((HWND)pickFolder.Handle);
				pickDialog.GetResult(out IShellItem selectedFolder);

				unsafe
				{
					selectedFolder.GetDisplayName(SIGDN.SIGDN_FILESYSPATH, out PWSTR coFolderPath);

					try
					{
						string path = new string(coFolderPath);
						AddPath(path);
					}
					finally
					{
						PInvoke.CoTaskMemFree(coFolderPath);
					}
				}
			}
			catch (COMException exception)
			{
			}
		}

		private void repackButton_Click(object sender, EventArgs e)
		{
			string repackExe = ".\\repack.exe";
			if (!File.Exists(repackExe))
			{
				MessageBox.Show("'Repack.exe' not found!\nPlace 'repack.exe' in the same folder as 'lvl-repack.exe'.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			List<string> files = new List<string>();
			foreach (var v in lvlsList.Items)
				files.Add(v.ToString());

			repackProgress.Enabled = true;
			repackProgress.Minimum = 0;
			repackProgress.Value = 0;
			repackProgress.Maximum = files.Count;
			totalReduced = 0;
			bool compressTextures = preferCompressedTextures.Checked;
			Task.Run(() => RepackFiles(files, compressTextures)); // dispatch the task to keep ui responsive.
		}

		long totalReduced = 0;

		private async Task RepackFiles(List<string> files, bool compressTextures)
		{
			string repackExe = ".\\repack.exe";

			await Parallel.ForEachAsync(files, async (file, cancel) =>
			{
				string repackArgs = compressTextures ? $"\"{file}\" prefer_compessed_textures" : $"\"{file}\"";
				long sizeBefore = new FileInfo(file).Length;

				string debugStr = $".\\repack.exe {repackArgs}";
				System.Diagnostics.Debug.WriteLine(debugStr);
				ProcessStartInfo startInfo = new ProcessStartInfo(repackExe, repackArgs);

				startInfo.RedirectStandardOutput = true;
				startInfo.RedirectStandardError = true;
				startInfo.UseShellExecute = false;
				startInfo.CreateNoWindow = true;
				Process? process = Process.Start(startInfo);

				string message = "";

				if (process == null)
				{
					message = $"Failed to launch repack for {file}";

				}
				else
				{
					await process.WaitForExitAsync();

					if (process.ExitCode == 0)
					{
						string output = await process.StandardOutput.ReadToEndAsync();
						long sizeAfter = new FileInfo(file).Length;
						double sizeReduced = (1.0 * sizeBefore - sizeAfter) / (1024.0 * 1024.0);
						Interlocked.Add(ref totalReduced, (sizeBefore - sizeAfter));
						message = string.Format("<Total Reduced: {0:F2} MB> [File Reduced {1:F2} MB] {2}", totalReduced / (1024.0 * 1024.0),
							sizeReduced, output);
					}
					else
					{
						message = await process.StandardError.ReadToEndAsync();
					}
				}

				IncrementProgress();
				AddOutputMessage(message);
			});
		}

		private void clearItemsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			lvlsList.Items.Clear();
			outputDisplay.Clear();
			repackProgress.Value = 0;
		}

		private void removeSelectedItemToolStripMenuItem_Click(object sender, EventArgs e)
		{
			for (int i = lvlsList.SelectedIndices.Count - 1; i >= 0; i--)
			{
				lvlsList.Items.RemoveAt(lvlsList.SelectedIndices[i]);
			}
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void gitHubRepoToolStripMenuItem_Click(object sender, EventArgs e)
		{
			string url = "https://github.com/PrismaticFlower/lvl-repack";
			try
			{
				ProcessStartInfo psi = new ProcessStartInfo { FileName = url, UseShellExecute = true };
				Process.Start(psi);
			}
			catch
			{
				MessageBox.Show("Error while opening: " + url);
			}
		}

		private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			MessageBox.Show(
				"lvl-repack lets you shrink the size of your Battlefront 1 and 2 .lvl\n" +
				"files by reducing space taken by textures.\n" +
				"Click 'Pick Folder' or\n" +
				"drag and drop files and folders onto the lvl files list."
				, "About lvl-repack");
		}
	}
}
