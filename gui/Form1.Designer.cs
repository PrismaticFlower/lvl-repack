namespace gui
{
	partial class Repack
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			lvlsList = new ListBox();
			label1 = new Label();
			outputDisplay = new TextBox();
			pickFolder = new Button();
			repackButton = new Button();
			preferCompressedTextures = new CheckBox();
			repackProgress = new ProgressBar();
			splitContainer1 = new SplitContainer();
			menuStrip1 = new MenuStrip();
			fileToolStripMenuItem = new ToolStripMenuItem();
			pickFolderToolStripMenuItem = new ToolStripMenuItem();
			clearFilesToolStripMenuItem = new ToolStripMenuItem();
			exitToolStripMenuItem = new ToolStripMenuItem();
			((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
			splitContainer1.Panel1.SuspendLayout();
			splitContainer1.Panel2.SuspendLayout();
			splitContainer1.SuspendLayout();
			menuStrip1.SuspendLayout();
			SuspendLayout();
			// 
			// lvlsList
			// 
			lvlsList.Dock = DockStyle.Fill;
			lvlsList.FormattingEnabled = true;
			lvlsList.ItemHeight = 25;
			lvlsList.Location = new Point(0, 0);
			lvlsList.Margin = new Padding(4, 5, 4, 5);
			lvlsList.Name = "lvlsList";
			lvlsList.Size = new Size(499, 609);
			lvlsList.TabIndex = 0;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
			label1.Location = new Point(17, 41);
			label1.Margin = new Padding(4, 0, 4, 0);
			label1.Name = "label1";
			label1.Size = new Size(149, 30);
			label1.TabIndex = 1;
			label1.Text = ".lvls to Repack";
			// 
			// outputDisplay
			// 
			outputDisplay.Dock = DockStyle.Fill;
			outputDisplay.Location = new Point(0, 0);
			outputDisplay.Margin = new Padding(4, 5, 4, 5);
			outputDisplay.Multiline = true;
			outputDisplay.Name = "outputDisplay";
			outputDisplay.ReadOnly = true;
			outputDisplay.Size = new Size(606, 609);
			outputDisplay.TabIndex = 2;
			// 
			// pickFolder
			// 
			pickFolder.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			pickFolder.Location = new Point(17, 705);
			pickFolder.Margin = new Padding(4, 5, 4, 5);
			pickFolder.Name = "pickFolder";
			pickFolder.Size = new Size(107, 38);
			pickFolder.TabIndex = 3;
			pickFolder.Text = "&Pick Folder";
			pickFolder.UseVisualStyleBackColor = true;
			pickFolder.Click += pickFolder_Click;
			// 
			// repackButton
			// 
			repackButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			repackButton.Enabled = false;
			repackButton.Location = new Point(133, 705);
			repackButton.Margin = new Padding(4, 5, 4, 5);
			repackButton.Name = "repackButton";
			repackButton.Size = new Size(107, 38);
			repackButton.TabIndex = 4;
			repackButton.Text = "&Repack";
			repackButton.UseVisualStyleBackColor = true;
			repackButton.Click += repackButton_Click;
			// 
			// preferCompressedTextures
			// 
			preferCompressedTextures.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			preferCompressedTextures.AutoSize = true;
			preferCompressedTextures.Checked = true;
			preferCompressedTextures.CheckState = CheckState.Checked;
			preferCompressedTextures.Location = new Point(249, 710);
			preferCompressedTextures.Margin = new Padding(4, 5, 4, 5);
			preferCompressedTextures.Name = "preferCompressedTextures";
			preferCompressedTextures.Size = new Size(257, 29);
			preferCompressedTextures.TabIndex = 5;
			preferCompressedTextures.Text = "&Prefer Compressed Textures";
			preferCompressedTextures.UseVisualStyleBackColor = true;
			// 
			// repackProgress
			// 
			repackProgress.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			repackProgress.Location = new Point(520, 710);
			repackProgress.Margin = new Padding(4, 5, 4, 5);
			repackProgress.Name = "repackProgress";
			repackProgress.Size = new Size(606, 38);
			repackProgress.TabIndex = 6;
			// 
			// splitContainer1
			// 
			splitContainer1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			splitContainer1.Location = new Point(17, 76);
			splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			splitContainer1.Panel1.Controls.Add(lvlsList);
			// 
			// splitContainer1.Panel2
			// 
			splitContainer1.Panel2.Controls.Add(outputDisplay);
			splitContainer1.Size = new Size(1109, 609);
			splitContainer1.SplitterDistance = 499;
			splitContainer1.TabIndex = 7;
			// 
			// menuStrip1
			// 
			menuStrip1.ImageScalingSize = new Size(24, 24);
			menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem });
			menuStrip1.Location = new Point(0, 0);
			menuStrip1.Name = "menuStrip1";
			menuStrip1.Size = new Size(1143, 33);
			menuStrip1.TabIndex = 8;
			menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { pickFolderToolStripMenuItem, clearFilesToolStripMenuItem, exitToolStripMenuItem });
			fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			fileToolStripMenuItem.Size = new Size(54, 29);
			fileToolStripMenuItem.Text = "File";
			// 
			// pickFolderToolStripMenuItem
			// 
			pickFolderToolStripMenuItem.Name = "pickFolderToolStripMenuItem";
			pickFolderToolStripMenuItem.Size = new Size(270, 34);
			pickFolderToolStripMenuItem.Text = "&Pick Folder";
			pickFolderToolStripMenuItem.Click += pickFolder_Click;
			// 
			// clearFilesToolStripMenuItem
			// 
			clearFilesToolStripMenuItem.Name = "clearFilesToolStripMenuItem";
			clearFilesToolStripMenuItem.Size = new Size(270, 34);
			clearFilesToolStripMenuItem.Text = "&Clear files";
			clearFilesToolStripMenuItem.Click += clearFilesMenuItem_Click;
			// 
			// exitToolStripMenuItem
			// 
			exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			exitToolStripMenuItem.Size = new Size(270, 34);
			exitToolStripMenuItem.Text = "E&xit";
			exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
			// 
			// Repack
			// 
			AutoScaleDimensions = new SizeF(10F, 25F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1143, 763);
			Controls.Add(splitContainer1);
			Controls.Add(repackProgress);
			Controls.Add(preferCompressedTextures);
			Controls.Add(repackButton);
			Controls.Add(pickFolder);
			Controls.Add(label1);
			Controls.Add(menuStrip1);
			MainMenuStrip = menuStrip1;
			Margin = new Padding(4, 5, 4, 5);
			Name = "Repack";
			Text = "lvl-repack";
			splitContainer1.Panel1.ResumeLayout(false);
			splitContainer1.Panel2.ResumeLayout(false);
			splitContainer1.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
			splitContainer1.ResumeLayout(false);
			menuStrip1.ResumeLayout(false);
			menuStrip1.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private ListBox lvlsList;
		private Label label1;
		private TextBox outputDisplay;
		private Button pickFolder;
		private Button repackButton;
		private CheckBox preferCompressedTextures;
		private ProgressBar repackProgress;
		private SplitContainer splitContainer1;
		private MenuStrip menuStrip1;
		private ToolStripMenuItem fileToolStripMenuItem;
		private ToolStripMenuItem pickFolderToolStripMenuItem;
		private ToolStripMenuItem clearFilesToolStripMenuItem;
		private ToolStripMenuItem exitToolStripMenuItem;
	}
}
