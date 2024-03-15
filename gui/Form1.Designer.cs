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
			SuspendLayout();
			// 
			// lvlsList
			// 
			lvlsList.FormattingEnabled = true;
			lvlsList.ItemHeight = 15;
			lvlsList.Location = new Point(12, 29);
			lvlsList.Name = "lvlsList";
			lvlsList.Size = new Size(345, 379);
			lvlsList.TabIndex = 0;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new Font("Segoe UI", 11F);
			label1.Location = new Point(12, 9);
			label1.Name = "label1";
			label1.Size = new Size(103, 20);
			label1.TabIndex = 1;
			label1.Text = ".lvls to Repack";
			// 
			// outputDisplay
			// 
			outputDisplay.Location = new Point(363, 29);
			outputDisplay.Multiline = true;
			outputDisplay.Name = "outputDisplay";
			outputDisplay.ReadOnly = true;
			outputDisplay.Size = new Size(425, 379);
			outputDisplay.TabIndex = 2;
			// 
			// pickFolder
			// 
			pickFolder.Location = new Point(12, 415);
			pickFolder.Name = "pickFolder";
			pickFolder.Size = new Size(75, 23);
			pickFolder.TabIndex = 3;
			pickFolder.Text = "Pick Folder";
			pickFolder.UseVisualStyleBackColor = true;
			pickFolder.Click += pickFolder_Click;
			// 
			// repackButton
			// 
			repackButton.Enabled = false;
			repackButton.Location = new Point(93, 415);
			repackButton.Name = "repackButton";
			repackButton.Size = new Size(75, 23);
			repackButton.TabIndex = 4;
			repackButton.Text = "Repack";
			repackButton.UseVisualStyleBackColor = true;
			repackButton.Click += repackButton_Click;
			// 
			// preferCompressedTextures
			// 
			preferCompressedTextures.AutoSize = true;
			preferCompressedTextures.Location = new Point(174, 418);
			preferCompressedTextures.Name = "preferCompressedTextures";
			preferCompressedTextures.Size = new Size(172, 19);
			preferCompressedTextures.TabIndex = 5;
			preferCompressedTextures.Text = "Prefer Compressed Textures";
			preferCompressedTextures.UseVisualStyleBackColor = true;
			// 
			// repackProgress
			// 
			repackProgress.Location = new Point(363, 418);
			repackProgress.Name = "repackProgress";
			repackProgress.Size = new Size(425, 23);
			repackProgress.TabIndex = 6;
			// 
			// Repack
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(800, 450);
			Controls.Add(repackProgress);
			Controls.Add(preferCompressedTextures);
			Controls.Add(repackButton);
			Controls.Add(pickFolder);
			Controls.Add(outputDisplay);
			Controls.Add(label1);
			Controls.Add(lvlsList);
			Name = "Repack";
			Text = "lvl-repack";
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
	}
}
