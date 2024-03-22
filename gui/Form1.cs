using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using System.Threading.Tasks;

namespace gui
{
	public partial class RepackForm : Form
	{
		public RepackForm()
		{
			InitializeComponent();
			var tip = new System.Windows.Forms.ToolTip();
			tip.SetToolTip(lvlsList, 
				"Choose 'Pick Folder' or drag and drop .lvl files\n"+
				"and/or folders containing .lvls onto the list."
				);
		}

		private void pickFolder_Click(object sender, EventArgs e)
		{
			String folderPath = null;
			FolderBrowserDialog pickDialog = new FolderBrowserDialog();
			pickDialog.Description = "Pick Folder";
			if (pickDialog.ShowDialog() == DialogResult.OK)
			{
				folderPath = pickDialog.SelectedPath;
			}
			pickDialog.Dispose();

			AddPath( folderPath);
		}

		private void AddPath( string path)
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


		private void repackButton_Click(object sender, EventArgs e)
		{
			List<string> files = new List<string>();
			foreach (var v in lvlsList.Items)
				files.Add(v.ToString());
			repackProgress.Enabled = true;
			repackProgress.Minimum = 0;
			repackProgress.Maximum = files.Count;
			bool compressTextures = preferCompressedTextures.Checked;

			Parallel.ForEach(files, async (file, cancel) =>
			{
				string repackArgs = compressTextures ? $"\"{file}\" prefer_compessed_textures" : $"\"{file}\"";
				long sizeBefore = new FileInfo(file).Length;

				ProcessStartInfo startInfo = new ProcessStartInfo(".\\repack.exe", repackArgs);

				startInfo.RedirectStandardOutput = true;
				startInfo.RedirectStandardError = true;
				startInfo.UseShellExecute = false;
				startInfo.CreateNoWindow = true;
				Process process = Process.Start(startInfo);

				string message = "";

				if (process == null)
				{
					message = $"Failed to launch repack for {file}";
				}
				else
				{
					process.WaitForExit();

					if (process.ExitCode == 0)
					{
						string output = await process.StandardOutput.ReadToEndAsync();
						long sizeAfter = new FileInfo(file).Length;
						double sizeReduced = (1.0 * sizeBefore - sizeAfter) / (1024.0 * 1024.0);
						message = string.Format("[Reduced by {0:F2} MB] {1}", sizeReduced,output);
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

		private void clearFilesMenuItem_Click(object sender, EventArgs e)
		{
			lvlsList.Items.Clear();
			outputDisplay.Clear();
			repackProgress.Value = 0;
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void aboutLvlpackToolStripMenuItem_Click(object sender, EventArgs e)
		{
			MessageBox.Show(
				"lvl-repack lets you shrink the size of your Battlefront 1 and 2 .lvl\n"+
				"files by reducing space taken by textures.\n"+
				"Click 'Pick Folder' or\n"+
				"drag and drop files and folders onto the lvl files list."
				,"About lvl-repack");
		}

		private void lvlpackOnGitHubToolStripMenuItem_Click(object sender, EventArgs e)
		{
			string url = "https://github.com/PrismaticFlower/lvl-repack";
			Process.Start(url); // open GitHub link in default browser.
		}

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

		private void removeSelectedToolStripMenuItem_Click(object sender, EventArgs e)
		{
			for(int i = lvlsList.SelectedIndices.Count - 1; i >= 0; i--)
			{
				lvlsList.Items.RemoveAt(lvlsList.SelectedIndices[i]);
			}
		}
	}
}
