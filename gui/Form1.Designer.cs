using System;
using System.Windows.Forms;
using System.Drawing;

namespace gui
{
	partial class RepackForm
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RepackForm));
			this.lvlsList = new System.Windows.Forms.ListBox();
			this.contextMenu_lvlList = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.pickFolderToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.removeSelectedToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.clearItemsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.label1 = new System.Windows.Forms.Label();
			this.outputDisplay = new System.Windows.Forms.TextBox();
			this.pickFolder = new System.Windows.Forms.Button();
			this.repackButton = new System.Windows.Forms.Button();
			this.preferCompressedTextures = new System.Windows.Forms.CheckBox();
			this.repackProgress = new System.Windows.Forms.ProgressBar();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.pickFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.removeSelectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.clearFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.lvlpackOnGitHubToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.aboutLvlpackToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.fileToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.pickFolderToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
			this.removeSelectedToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
			this.clearItemsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.exitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.aboutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.gitHubRepoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.aboutLvlrepackToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.contextMenu_lvlList.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// lvlsList
			// 
			this.lvlsList.AllowDrop = true;
			this.lvlsList.ContextMenuStrip = this.contextMenu_lvlList;
			this.lvlsList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lvlsList.FormattingEnabled = true;
			this.lvlsList.ItemHeight = 20;
			this.lvlsList.Location = new System.Drawing.Point(0, 0);
			this.lvlsList.Margin = new System.Windows.Forms.Padding(4);
			this.lvlsList.Name = "lvlsList";
			this.lvlsList.Size = new System.Drawing.Size(462, 484);
			this.lvlsList.TabIndex = 0;
			this.lvlsList.DragDrop += new System.Windows.Forms.DragEventHandler(this.lvlsList_DragDrop);
			this.lvlsList.DragEnter += new System.Windows.Forms.DragEventHandler(this.lvlsList_DragEnter);
			// 
			// contextMenu_lvlList
			// 
			this.contextMenu_lvlList.ImageScalingSize = new System.Drawing.Size(24, 24);
			this.contextMenu_lvlList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pickFolderToolStripMenuItem1,
            this.removeSelectedToolStripMenuItem1,
            this.clearItemsToolStripMenuItem});
			this.contextMenu_lvlList.Name = "contextMenu_lvlList";
			this.contextMenu_lvlList.Size = new System.Drawing.Size(220, 100);
			// 
			// pickFolderToolStripMenuItem1
			// 
			this.pickFolderToolStripMenuItem1.Name = "pickFolderToolStripMenuItem1";
			this.pickFolderToolStripMenuItem1.Size = new System.Drawing.Size(219, 32);
			this.pickFolderToolStripMenuItem1.Text = "&Pick Folder";
			this.pickFolderToolStripMenuItem1.Click += new System.EventHandler(this.pickFolder_Click);
			// 
			// removeSelectedToolStripMenuItem1
			// 
			this.removeSelectedToolStripMenuItem1.Name = "removeSelectedToolStripMenuItem1";
			this.removeSelectedToolStripMenuItem1.Size = new System.Drawing.Size(219, 32);
			this.removeSelectedToolStripMenuItem1.Text = "&Remove Selected";
			this.removeSelectedToolStripMenuItem1.Click += new System.EventHandler(this.removeSelectedToolStripMenuItem_Click);
			// 
			// clearItemsToolStripMenuItem
			// 
			this.clearItemsToolStripMenuItem.Name = "clearItemsToolStripMenuItem";
			this.clearItemsToolStripMenuItem.Size = new System.Drawing.Size(219, 32);
			this.clearItemsToolStripMenuItem.Text = "&Clear Items";
			this.clearItemsToolStripMenuItem.Click += new System.EventHandler(this.clearFilesMenuItem_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(15, 33);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(341, 20);
			this.label1.TabIndex = 1;
			this.label1.Text = ".lvls to Repack (drag && drop files. folders below)";
			// 
			// outputDisplay
			// 
			this.outputDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
			this.outputDisplay.Location = new System.Drawing.Point(0, 0);
			this.outputDisplay.Margin = new System.Windows.Forms.Padding(4);
			this.outputDisplay.Multiline = true;
			this.outputDisplay.Name = "outputDisplay";
			this.outputDisplay.ReadOnly = true;
			this.outputDisplay.Size = new System.Drawing.Size(562, 484);
			this.outputDisplay.TabIndex = 2;
			// 
			// pickFolder
			// 
			this.pickFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.pickFolder.Location = new System.Drawing.Point(15, 564);
			this.pickFolder.Margin = new System.Windows.Forms.Padding(4);
			this.pickFolder.Name = "pickFolder";
			this.pickFolder.Size = new System.Drawing.Size(110, 42);
			this.pickFolder.TabIndex = 3;
			this.pickFolder.Text = "&Pick Folder";
			this.pickFolder.UseVisualStyleBackColor = true;
			this.pickFolder.Click += new System.EventHandler(this.pickFolder_Click);
			// 
			// repackButton
			// 
			this.repackButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.repackButton.Enabled = false;
			this.repackButton.Location = new System.Drawing.Point(133, 564);
			this.repackButton.Margin = new System.Windows.Forms.Padding(4);
			this.repackButton.Name = "repackButton";
			this.repackButton.Size = new System.Drawing.Size(95, 42);
			this.repackButton.TabIndex = 4;
			this.repackButton.Text = "&Repack";
			this.repackButton.UseVisualStyleBackColor = true;
			this.repackButton.Click += new System.EventHandler(this.repackButton_Click);
			// 
			// preferCompressedTextures
			// 
			this.preferCompressedTextures.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.preferCompressedTextures.AutoSize = true;
			this.preferCompressedTextures.Checked = true;
			this.preferCompressedTextures.CheckState = System.Windows.Forms.CheckState.Checked;
			this.preferCompressedTextures.Location = new System.Drawing.Point(236, 574);
			this.preferCompressedTextures.Margin = new System.Windows.Forms.Padding(4);
			this.preferCompressedTextures.Name = "preferCompressedTextures";
			this.preferCompressedTextures.Size = new System.Drawing.Size(237, 24);
			this.preferCompressedTextures.TabIndex = 5;
			this.preferCompressedTextures.Text = "&Prefer Compressed Textures";
			this.preferCompressedTextures.UseVisualStyleBackColor = true;
			// 
			// repackProgress
			// 
			this.repackProgress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.repackProgress.Location = new System.Drawing.Point(481, 574);
			this.repackProgress.Margin = new System.Windows.Forms.Padding(4);
			this.repackProgress.Name = "repackProgress";
			this.repackProgress.Size = new System.Drawing.Size(563, 30);
			this.repackProgress.TabIndex = 6;
			// 
			// splitContainer1
			// 
			this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.splitContainer1.Location = new System.Drawing.Point(15, 61);
			this.splitContainer1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.lvlsList);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.outputDisplay);
			this.splitContainer1.Size = new System.Drawing.Size(1028, 484);
			this.splitContainer1.SplitterDistance = 462;
			this.splitContainer1.TabIndex = 7;
			// 
			// menuStrip1
			// 
			this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
			this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem1,
            this.aboutToolStripMenuItem1});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
			this.menuStrip1.Size = new System.Drawing.Size(1059, 33);
			this.menuStrip1.TabIndex = 8;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pickFolderToolStripMenuItem,
            this.removeSelectedToolStripMenuItem,
            this.clearFilesToolStripMenuItem,
            this.exitToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(54, 32);
			this.fileToolStripMenuItem.Text = "File";
			// 
			// pickFolderToolStripMenuItem
			// 
			this.pickFolderToolStripMenuItem.Name = "pickFolderToolStripMenuItem";
			this.pickFolderToolStripMenuItem.Size = new System.Drawing.Size(249, 34);
			this.pickFolderToolStripMenuItem.Text = "&Pick Folder";
			this.pickFolderToolStripMenuItem.Click += new System.EventHandler(this.pickFolder_Click);
			// 
			// removeSelectedToolStripMenuItem
			// 
			this.removeSelectedToolStripMenuItem.Name = "removeSelectedToolStripMenuItem";
			this.removeSelectedToolStripMenuItem.Size = new System.Drawing.Size(249, 34);
			this.removeSelectedToolStripMenuItem.Text = "&Remove Selected";
			this.removeSelectedToolStripMenuItem.Click += new System.EventHandler(this.removeSelectedToolStripMenuItem_Click);
			// 
			// clearFilesToolStripMenuItem
			// 
			this.clearFilesToolStripMenuItem.Name = "clearFilesToolStripMenuItem";
			this.clearFilesToolStripMenuItem.Size = new System.Drawing.Size(249, 34);
			this.clearFilesToolStripMenuItem.Text = "&Clear files";
			this.clearFilesToolStripMenuItem.Click += new System.EventHandler(this.clearFilesMenuItem_Click);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(249, 34);
			this.exitToolStripMenuItem.Text = "E&xit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
			// 
			// aboutToolStripMenuItem
			// 
			this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lvlpackOnGitHubToolStripMenuItem,
            this.aboutLvlpackToolStripMenuItem});
			this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
			this.aboutToolStripMenuItem.Size = new System.Drawing.Size(78, 32);
			this.aboutToolStripMenuItem.Text = "&About";
			// 
			// lvlpackOnGitHubToolStripMenuItem
			// 
			this.lvlpackOnGitHubToolStripMenuItem.Name = "lvlpackOnGitHubToolStripMenuItem";
			this.lvlpackOnGitHubToolStripMenuItem.Size = new System.Drawing.Size(262, 34);
			this.lvlpackOnGitHubToolStripMenuItem.Text = "lvl-pack on GitHub";
			this.lvlpackOnGitHubToolStripMenuItem.Click += new System.EventHandler(this.lvlpackOnGitHubToolStripMenuItem_Click);
			// 
			// aboutLvlpackToolStripMenuItem
			// 
			this.aboutLvlpackToolStripMenuItem.Name = "aboutLvlpackToolStripMenuItem";
			this.aboutLvlpackToolStripMenuItem.Size = new System.Drawing.Size(262, 34);
			this.aboutLvlpackToolStripMenuItem.Text = "About lvl-pack";
			this.aboutLvlpackToolStripMenuItem.Click += new System.EventHandler(this.aboutLvlpackToolStripMenuItem_Click);
			// 
			// fileToolStripMenuItem1
			// 
			this.fileToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pickFolderToolStripMenuItem2,
            this.removeSelectedToolStripMenuItem2,
            this.clearItemsToolStripMenuItem1,
            this.exitToolStripMenuItem1});
			this.fileToolStripMenuItem1.Name = "fileToolStripMenuItem1";
			this.fileToolStripMenuItem1.Size = new System.Drawing.Size(54, 29);
			this.fileToolStripMenuItem1.Text = "File";
			// 
			// pickFolderToolStripMenuItem2
			// 
			this.pickFolderToolStripMenuItem2.Name = "pickFolderToolStripMenuItem2";
			this.pickFolderToolStripMenuItem2.Size = new System.Drawing.Size(270, 34);
			this.pickFolderToolStripMenuItem2.Text = "Pick Folder";
			this.pickFolderToolStripMenuItem2.Click += new System.EventHandler(this.pickFolder_Click);
			// 
			// removeSelectedToolStripMenuItem2
			// 
			this.removeSelectedToolStripMenuItem2.Name = "removeSelectedToolStripMenuItem2";
			this.removeSelectedToolStripMenuItem2.Size = new System.Drawing.Size(270, 34);
			this.removeSelectedToolStripMenuItem2.Text = "&Remove Selected";
			this.removeSelectedToolStripMenuItem2.Click += new System.EventHandler(this.removeSelectedToolStripMenuItem_Click);
			// 
			// clearItemsToolStripMenuItem1
			// 
			this.clearItemsToolStripMenuItem1.Name = "clearItemsToolStripMenuItem1";
			this.clearItemsToolStripMenuItem1.Size = new System.Drawing.Size(270, 34);
			this.clearItemsToolStripMenuItem1.Text = "&Clear Items";
			this.clearItemsToolStripMenuItem1.Click += new System.EventHandler(this.clearFilesMenuItem_Click);
			// 
			// exitToolStripMenuItem1
			// 
			this.exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
			this.exitToolStripMenuItem1.Size = new System.Drawing.Size(270, 34);
			this.exitToolStripMenuItem1.Text = "E&xit";
			this.exitToolStripMenuItem1.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
			// 
			// aboutToolStripMenuItem1
			// 
			this.aboutToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gitHubRepoToolStripMenuItem,
            this.aboutLvlrepackToolStripMenuItem});
			this.aboutToolStripMenuItem1.Name = "aboutToolStripMenuItem1";
			this.aboutToolStripMenuItem1.Size = new System.Drawing.Size(78, 29);
			this.aboutToolStripMenuItem1.Text = "About";
			// 
			// gitHubRepoToolStripMenuItem
			// 
			this.gitHubRepoToolStripMenuItem.Name = "gitHubRepoToolStripMenuItem";
			this.gitHubRepoToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
			this.gitHubRepoToolStripMenuItem.Text = "GitHub Repo";
			this.gitHubRepoToolStripMenuItem.Click += new System.EventHandler(this.lvlpackOnGitHubToolStripMenuItem_Click);
			// 
			// aboutLvlrepackToolStripMenuItem
			// 
			this.aboutLvlrepackToolStripMenuItem.Name = "aboutLvlrepackToolStripMenuItem";
			this.aboutLvlrepackToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
			this.aboutLvlrepackToolStripMenuItem.Text = "&About lvl-repack";
			this.aboutLvlrepackToolStripMenuItem.Click += new System.EventHandler(this.aboutLvlpackToolStripMenuItem_Click);
			// 
			// RepackForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1059, 622);
			this.Controls.Add(this.splitContainer1);
			this.Controls.Add(this.repackProgress);
			this.Controls.Add(this.preferCompressedTextures);
			this.Controls.Add(this.repackButton);
			this.Controls.Add(this.pickFolder);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.menuStrip1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip1;
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "RepackForm";
			this.Text = "lvl-repack";
			this.contextMenu_lvlList.ResumeLayout(false);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

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
		private ToolStripMenuItem aboutToolStripMenuItem;
		private ToolStripMenuItem lvlpackOnGitHubToolStripMenuItem;
		private ToolStripMenuItem aboutLvlpackToolStripMenuItem;
		private ToolStripMenuItem removeSelectedToolStripMenuItem;
		private ContextMenuStrip contextMenu_lvlList;
		private ToolStripMenuItem pickFolderToolStripMenuItem1;
		private ToolStripMenuItem removeSelectedToolStripMenuItem1;
		private ToolStripMenuItem clearItemsToolStripMenuItem;
		private ToolStripMenuItem fileToolStripMenuItem1;
		private ToolStripMenuItem pickFolderToolStripMenuItem2;
		private ToolStripMenuItem removeSelectedToolStripMenuItem2;
		private ToolStripMenuItem clearItemsToolStripMenuItem1;
		private ToolStripMenuItem exitToolStripMenuItem1;
		private ToolStripMenuItem aboutToolStripMenuItem1;
		private ToolStripMenuItem gitHubRepoToolStripMenuItem;
		private ToolStripMenuItem aboutLvlrepackToolStripMenuItem;
	}
}
