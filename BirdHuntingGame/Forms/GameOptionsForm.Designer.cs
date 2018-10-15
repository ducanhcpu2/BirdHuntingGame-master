namespace BirdHuntingGame.Forms
{
	partial class ImgControlBackground
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
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
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImgControlBackground));
            this.nameGame = new System.Windows.Forms.Label();
            this.imageChooseBird = new System.Windows.Forms.PictureBox();
            this.textChooseBird = new System.Windows.Forms.Label();
            this.ListBird = new System.Windows.Forms.ComboBox();
            this.imageChooseGun = new System.Windows.Forms.PictureBox();
            this.textChooseGun = new System.Windows.Forms.Label();
            this.ListGun = new System.Windows.Forms.ComboBox();
            this.btnStartGame = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.imageChooseBird)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageChooseGun)).BeginInit();
            this.SuspendLayout();
            // 
            // nameGame
            // 
            this.nameGame.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.nameGame.BackColor = System.Drawing.Color.Transparent;
            this.nameGame.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.nameGame.Font = new System.Drawing.Font("Lucida Calligraphy", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameGame.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.nameGame.Location = new System.Drawing.Point(55, 9);
            this.nameGame.Name = "nameGame";
            this.nameGame.Size = new System.Drawing.Size(544, 50);
            this.nameGame.TabIndex = 2;
            this.nameGame.Text = "How many bird you can hunt?";
            this.nameGame.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // imageChooseBird
            // 
            this.imageChooseBird.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.imageChooseBird.BackColor = System.Drawing.Color.Transparent;
            this.imageChooseBird.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.imageChooseBird.Image = ((System.Drawing.Image)(resources.GetObject("imageChooseBird.Image")));
            this.imageChooseBird.Location = new System.Drawing.Point(187, 446);
            this.imageChooseBird.Name = "imageChooseBird";
            this.imageChooseBird.Padding = new System.Windows.Forms.Padding(20);
            this.imageChooseBird.Size = new System.Drawing.Size(262, 77);
            this.imageChooseBird.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imageChooseBird.TabIndex = 11;
            this.imageChooseBird.TabStop = false;
            // 
            // textChooseBird
            // 
            this.textChooseBird.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textChooseBird.AutoSize = true;
            this.textChooseBird.BackColor = System.Drawing.Color.Transparent;
            this.textChooseBird.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.textChooseBird.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.textChooseBird.Location = new System.Drawing.Point(263, 390);
            this.textChooseBird.Name = "textChooseBird";
            this.textChooseBird.Size = new System.Drawing.Size(106, 25);
            this.textChooseBird.TabIndex = 9;
            this.textChooseBird.Text = "Select Bird";
            // 
            // ListBird
            // 
            this.ListBird.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ListBird.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ListBird.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ListBird.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ListBird.FormattingEnabled = true;
            this.ListBird.Items.AddRange(new object[] {
            "Bronze V",
            "Bronze IV",
            "Bronze III",
            "Bronze II",
            "Bronze I",
            "Silver V"});
            this.ListBird.Location = new System.Drawing.Point(187, 418);
            this.ListBird.Name = "ListBird";
            this.ListBird.Size = new System.Drawing.Size(262, 33);
            this.ListBird.TabIndex = 10;
            this.ListBird.SelectedIndexChanged += new System.EventHandler(this.cmbBird_SelectedIndexChanged);
            // 
            // imageChooseGun
            // 
            this.imageChooseGun.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.imageChooseGun.BackColor = System.Drawing.Color.Transparent;
            this.imageChooseGun.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.imageChooseGun.Image = global::BirdHuntingGame.Properties.Resources.Gun00;
            this.imageChooseGun.Location = new System.Drawing.Point(187, 316);
            this.imageChooseGun.Name = "imageChooseGun";
            this.imageChooseGun.Padding = new System.Windows.Forms.Padding(20);
            this.imageChooseGun.Size = new System.Drawing.Size(262, 71);
            this.imageChooseGun.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imageChooseGun.TabIndex = 8;
            this.imageChooseGun.TabStop = false;
            // 
            // textChooseGun
            // 
            this.textChooseGun.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textChooseGun.AutoSize = true;
            this.textChooseGun.BackColor = System.Drawing.Color.Transparent;
            this.textChooseGun.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.textChooseGun.Location = new System.Drawing.Point(263, 249);
            this.textChooseGun.Name = "textChooseGun";
            this.textChooseGun.Size = new System.Drawing.Size(107, 25);
            this.textChooseGun.TabIndex = 6;
            this.textChooseGun.Text = "Select Gun";
            // 
            // ListGun
            // 
            this.ListGun.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ListGun.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ListGun.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ListGun.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ListGun.FormattingEnabled = true;
            this.ListGun.Items.AddRange(new object[] {
            "Bronze V",
            "Bronze IV",
            "Bronze III",
            "Bronze II",
            "Bronze I",
            "Silver V",
            "Silver IV",
            "Silver III",
            "Silver II"});
            this.ListGun.Location = new System.Drawing.Point(187, 277);
            this.ListGun.Name = "ListGun";
            this.ListGun.Size = new System.Drawing.Size(262, 33);
            this.ListGun.TabIndex = 7;
            this.ListGun.SelectedIndexChanged += new System.EventHandler(this.cmbGun_SelectedIndexChanged);
            // 
            // btnStartGame
            // 
            this.btnStartGame.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnStartGame.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnStartGame.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStartGame.FlatAppearance.BorderSize = 0;
            this.btnStartGame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStartGame.Location = new System.Drawing.Point(144, 529);
            this.btnStartGame.Name = "btnStartGame";
            this.btnStartGame.Size = new System.Drawing.Size(343, 58);
            this.btnStartGame.TabIndex = 12;
            this.btnStartGame.Text = "Let\'s go !!!";
            this.btnStartGame.UseVisualStyleBackColor = true;
            this.btnStartGame.Click += new System.EventHandler(this.btnStartGame_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.BackgroundImage = global::BirdHuntingGame.Properties.Resources.Control_Close;
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(588, 9);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(50, 50);
            this.btnClose.TabIndex = 13;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ImgControlBackground
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = global::BirdHuntingGame.Properties.Resources.BackGround03;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(650, 606);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnStartGame);
            this.Controls.Add(this.imageChooseBird);
            this.Controls.Add(this.textChooseBird);
            this.Controls.Add(this.ListBird);
            this.Controls.Add(this.imageChooseGun);
            this.Controls.Add(this.textChooseGun);
            this.Controls.Add(this.ListGun);
            this.Controls.Add(this.nameGame);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ImgControlBackground";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GameOptionsForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.GameOptionsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imageChooseBird)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageChooseGun)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Label nameGame;
		private System.Windows.Forms.PictureBox imageChooseBird;
		private System.Windows.Forms.Label textChooseBird;
		private System.Windows.Forms.PictureBox imageChooseGun;
		private System.Windows.Forms.Label textChooseGun;
		private System.Windows.Forms.Button btnStartGame;
		private System.Windows.Forms.ComboBox ListBird;
		private System.Windows.Forms.ComboBox ListGun;
		private System.Windows.Forms.Button btnClose;
	}
}