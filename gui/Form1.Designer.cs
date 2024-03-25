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
			components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Repack));
			lvlsList = new ListBox();
			contextMenu_lvlFiles = new ContextMenuStrip(components);
			clearItemsToolStripMenuItem = new ToolStripMenuItem();
			removeSelectedItemToolStripMenuItem = new ToolStripMenuItem();
			pickFolderToolStripMenuItem = new ToolStripMenuItem();
			label1 = new Label();
			outputDisplay = new TextBox();
			pickFolder = new Button();
			repackButton = new Button();
			preferCompressedTextures = new CheckBox();
			repackProgress = new ProgressBar();
			splitContainer1 = new SplitContainer();
			menuStrip1 = new MenuStrip();
			fileToolStripMenuItem = new ToolStripMenuItem();
			clearItemsToolStripMenuItem1 = new ToolStripMenuItem();
			removeSelectedToolStripMenuItem = new ToolStripMenuItem();
			pickFolderToolStripMenuItem1 = new ToolStripMenuItem();
			exitToolStripMenuItem = new ToolStripMenuItem();
			aboutToolStripMenuItem = new ToolStripMenuItem();
			gitHubRepoToolStripMenuItem = new ToolStripMenuItem();
			aboutToolStripMenuItem1 = new ToolStripMenuItem();
			contextMenu_lvlFiles.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
			splitContainer1.Panel1.SuspendLayout();
			splitContainer1.Panel2.SuspendLayout();
			splitContainer1.SuspendLayout();
			menuStrip1.SuspendLayout();
			SuspendLayout();
			// 
			// lvlsList
			// 
			lvlsList.AllowDrop = true;
			lvlsList.ContextMenuStrip = contextMenu_lvlFiles;
			lvlsList.Dock = DockStyle.Fill;
			lvlsList.FormattingEnabled = true;
			lvlsList.ItemHeight = 25;
			lvlsList.Location = new Point(0, 0);
			lvlsList.Margin = new Padding(4, 5, 4, 5);
			lvlsList.Name = "lvlsList";
			lvlsList.SelectionMode = SelectionMode.MultiSimple;
			lvlsList.Size = new Size(386, 360);
			lvlsList.TabIndex = 0;
			lvlsList.DragDrop += lvlsList_DragDrop;
			lvlsList.DragEnter += lvlsList_DragEnter;
			// 
			// contextMenu_lvlFiles
			// 
			contextMenu_lvlFiles.ImageScalingSize = new Size(24, 24);
			contextMenu_lvlFiles.Items.AddRange(new ToolStripItem[] { clearItemsToolStripMenuItem, removeSelectedItemToolStripMenuItem, pickFolderToolStripMenuItem });
			contextMenu_lvlFiles.Name = "contextMenu_lvlFiles";
			contextMenu_lvlFiles.Size = new Size(266, 100);
			// 
			// clearItemsToolStripMenuItem
			// 
			clearItemsToolStripMenuItem.Name = "clearItemsToolStripMenuItem";
			clearItemsToolStripMenuItem.Size = new Size(265, 32);
			clearItemsToolStripMenuItem.Text = "&Clear Items";
			clearItemsToolStripMenuItem.Click += clearItemsToolStripMenuItem_Click;
			// 
			// removeSelectedItemToolStripMenuItem
			// 
			removeSelectedItemToolStripMenuItem.Name = "removeSelectedItemToolStripMenuItem";
			removeSelectedItemToolStripMenuItem.Size = new Size(265, 32);
			removeSelectedItemToolStripMenuItem.Text = "&Remove selected items";
			removeSelectedItemToolStripMenuItem.Click += removeSelectedItemToolStripMenuItem_Click;
			// 
			// pickFolderToolStripMenuItem
			// 
			pickFolderToolStripMenuItem.Name = "pickFolderToolStripMenuItem";
			pickFolderToolStripMenuItem.Size = new Size(265, 32);
			pickFolderToolStripMenuItem.Text = "&Pick Folder";
			pickFolderToolStripMenuItem.Click += pickFolder_Click;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new Font("Segoe UI", 11F);
			label1.Location = new Point(17, 46);
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
			outputDisplay.Size = new Size(432, 360);
			outputDisplay.TabIndex = 2;
			// 
			// pickFolder
			// 
			pickFolder.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			pickFolder.Location = new Point(17, 447);
			pickFolder.Margin = new Padding(4, 5, 4, 5);
			pickFolder.Name = "pickFolder";
			pickFolder.Size = new Size(107, 38);
			pickFolder.TabIndex = 3;
			pickFolder.Text = "Pick Folder";
			pickFolder.UseVisualStyleBackColor = true;
			pickFolder.Click += pickFolder_Click;
			// 
			// repackButton
			// 
			repackButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			repackButton.Enabled = false;
			repackButton.Location = new Point(133, 447);
			repackButton.Margin = new Padding(4, 5, 4, 5);
			repackButton.Name = "repackButton";
			repackButton.Size = new Size(107, 38);
			repackButton.TabIndex = 4;
			repackButton.Text = "Repack";
			repackButton.UseVisualStyleBackColor = true;
			repackButton.Click += repackButton_Click;
			// 
			// preferCompressedTextures
			// 
			preferCompressedTextures.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			preferCompressedTextures.AutoSize = true;
			preferCompressedTextures.Checked = true;
			preferCompressedTextures.CheckState = CheckState.Checked;
			preferCompressedTextures.Location = new Point(249, 452);
			preferCompressedTextures.Margin = new Padding(4, 5, 4, 5);
			preferCompressedTextures.Name = "preferCompressedTextures";
			preferCompressedTextures.Size = new Size(257, 29);
			preferCompressedTextures.TabIndex = 5;
			preferCompressedTextures.Text = "Prefer Compressed Textures";
			preferCompressedTextures.UseVisualStyleBackColor = true;
			// 
			// repackProgress
			// 
			repackProgress.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			repackProgress.Location = new Point(519, 452);
			repackProgress.Margin = new Padding(4, 5, 4, 5);
			repackProgress.Name = "repackProgress";
			repackProgress.Size = new Size(320, 38);
			repackProgress.TabIndex = 6;
			// 
			// splitContainer1
			// 
			splitContainer1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			splitContainer1.Location = new Point(17, 79);
			splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			splitContainer1.Panel1.Controls.Add(lvlsList);
			// 
			// splitContainer1.Panel2
			// 
			splitContainer1.Panel2.Controls.Add(outputDisplay);
			splitContainer1.Size = new Size(822, 360);
			splitContainer1.SplitterDistance = 386;
			splitContainer1.TabIndex = 7;
			// 
			// menuStrip1
			// 
			menuStrip1.ImageScalingSize = new Size(24, 24);
			menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, aboutToolStripMenuItem });
			menuStrip1.Location = new Point(0, 0);
			menuStrip1.Name = "menuStrip1";
			menuStrip1.Size = new Size(856, 33);
			menuStrip1.TabIndex = 8;
			menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { clearItemsToolStripMenuItem1, removeSelectedToolStripMenuItem, pickFolderToolStripMenuItem1, exitToolStripMenuItem });
			fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			fileToolStripMenuItem.Size = new Size(54, 29);
			fileToolStripMenuItem.Text = "&File";
			// 
			// clearItemsToolStripMenuItem1
			// 
			clearItemsToolStripMenuItem1.Name = "clearItemsToolStripMenuItem1";
			clearItemsToolStripMenuItem1.Size = new Size(249, 34);
			clearItemsToolStripMenuItem1.Text = "&Clear Items";
			clearItemsToolStripMenuItem1.Click += clearItemsToolStripMenuItem_Click;
			// 
			// removeSelectedToolStripMenuItem
			// 
			removeSelectedToolStripMenuItem.Name = "removeSelectedToolStripMenuItem";
			removeSelectedToolStripMenuItem.Size = new Size(249, 34);
			removeSelectedToolStripMenuItem.Text = "&Remove Selected";
			removeSelectedToolStripMenuItem.Click += removeSelectedItemToolStripMenuItem_Click;
			// 
			// pickFolderToolStripMenuItem1
			// 
			pickFolderToolStripMenuItem1.Name = "pickFolderToolStripMenuItem1";
			pickFolderToolStripMenuItem1.Size = new Size(249, 34);
			pickFolderToolStripMenuItem1.Text = "&Pick Folder";
			pickFolderToolStripMenuItem1.Click += pickFolder_Click;
			// 
			// exitToolStripMenuItem
			// 
			exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			exitToolStripMenuItem.Size = new Size(249, 34);
			exitToolStripMenuItem.Text = "E&xit";
			exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
			// 
			// aboutToolStripMenuItem
			// 
			aboutToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { gitHubRepoToolStripMenuItem, aboutToolStripMenuItem1 });
			aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
			aboutToolStripMenuItem.Size = new Size(78, 29);
			aboutToolStripMenuItem.Text = "&About";
			// 
			// gitHubRepoToolStripMenuItem
			// 
			gitHubRepoToolStripMenuItem.Name = "gitHubRepoToolStripMenuItem";
			gitHubRepoToolStripMenuItem.Size = new Size(216, 34);
			gitHubRepoToolStripMenuItem.Text = "&GitHub Repo";
			gitHubRepoToolStripMenuItem.Click += gitHubRepoToolStripMenuItem_Click;
			// 
			// aboutToolStripMenuItem1
			// 
			aboutToolStripMenuItem1.Name = "aboutToolStripMenuItem1";
			aboutToolStripMenuItem1.Size = new Size(216, 34);
			aboutToolStripMenuItem1.Text = "A&bout";
			aboutToolStripMenuItem1.Click += aboutToolStripMenuItem1_Click;
			// 
			// Repack
			// 
			AutoScaleDimensions = new SizeF(10F, 25F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(856, 505);
			Controls.Add(splitContainer1);
			Controls.Add(menuStrip1);
			Controls.Add(repackProgress);
			Controls.Add(preferCompressedTextures);
			Controls.Add(repackButton);
			Controls.Add(pickFolder);
			Controls.Add(label1);
			Icon = (Icon)resources.GetObject("$this.Icon");
			MainMenuStrip = menuStrip1;
			Margin = new Padding(4, 5, 4, 5);
			Name = "Repack";
			Text = "lvl-repack";
			contextMenu_lvlFiles.ResumeLayout(false);
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
		private ContextMenuStrip contextMenu_lvlFiles;
		private ToolStripMenuItem clearItemsToolStripMenuItem;
		private ToolStripMenuItem removeSelectedItemToolStripMenuItem;
		private ToolStripMenuItem pickFolderToolStripMenuItem;
		private SplitContainer splitContainer1;
		private MenuStrip menuStrip1;
		private ToolStripMenuItem fileToolStripMenuItem;
		private ToolStripMenuItem clearItemsToolStripMenuItem1;
		private ToolStripMenuItem removeSelectedToolStripMenuItem;
		private ToolStripMenuItem pickFolderToolStripMenuItem1;
		private ToolStripMenuItem exitToolStripMenuItem;
		private ToolStripMenuItem aboutToolStripMenuItem;
		private ToolStripMenuItem gitHubRepoToolStripMenuItem;
		private ToolStripMenuItem aboutToolStripMenuItem1;
	}
}
