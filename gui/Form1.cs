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
		List<string> files = new List<string>();

		public Repack()
		{
			InitializeComponent();
		}

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
						files.AddRange(Directory.EnumerateFiles(new string(coFolderPath), "*.lvl", SearchOption.AllDirectories));

						lvlsList.BeginUpdate();

						foreach (var v in files) lvlsList.Items.Add(v);

						lvlsList.EndUpdate();

						repackButton.Enabled = true;
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

		private async void repackButton_Click(object sender, EventArgs e)
		{

			await Parallel.ForEachAsync(files, async (file, cancel) =>
			{
				string repackArgs = preferCompressedTextures.Checked ? $"{file} prefer_compessed_textures" : $"{file}";

				ProcessStartInfo startInfo = new ProcessStartInfo(".\\repack.exe", repackArgs);

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
						message = await process.StandardOutput.ReadToEndAsync();
					}
					else
					{
						message = await process.StandardError.ReadToEndAsync();
					}
				}

				if (outputDisplay.InvokeRequired)
				{
					outputDisplay.Invoke(() => outputDisplay.AppendText(message));
				}
				else
				{
					outputDisplay.AppendText(file);
				}
			});
		}
	}
}
