namespace MSAL_SLC_CAE
{
    partial class Form1
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
            panel1 = new Panel();
            materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            panel2 = new Panel();
            btnCallResource = new MaterialSkin.Controls.MaterialRaisedButton();
            btnFetchToken = new MaterialSkin.Controls.MaterialRaisedButton();
            btnExit = new MaterialSkin.Controls.MaterialRaisedButton();
            materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            testOption2 = new MaterialSkin.Controls.MaterialRadioButton();
            testOption3 = new MaterialSkin.Controls.MaterialRadioButton();
            vanillaMSI = new MaterialSkin.Controls.MaterialRadioButton();
            pictureBox1 = new PictureBox();
            panel3 = new Panel();
            txtTenantId = new MaterialSkin.Controls.MaterialSingleLineTextField();
            materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            txtBoxLogs = new TextBox();
            progressBar1 = new ProgressBar();
            panel4 = new Panel();
            msalLogs = new TextBox();
            materialLabel8 = new MaterialSkin.Controls.MaterialLabel();
            materialSingleLineTextField5 = new MaterialSkin.Controls.MaterialSingleLineTextField();
            materialLabel7 = new MaterialSkin.Controls.MaterialLabel();
            materialSingleLineTextField4 = new MaterialSkin.Controls.MaterialSingleLineTextField();
            materialLabel6 = new MaterialSkin.Controls.MaterialLabel();
            materialSingleLineTextField3 = new MaterialSkin.Controls.MaterialSingleLineTextField();
            materialLabel5 = new MaterialSkin.Controls.MaterialLabel();
            txtResource = new MaterialSkin.Controls.MaterialSingleLineTextField();
            materialLabel4 = new MaterialSkin.Controls.MaterialLabel();
            txtClientId = new MaterialSkin.Controls.MaterialSingleLineTextField();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel4.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.PaleGoldenrod;
            panel1.Controls.Add(materialLabel2);
            panel1.Dock = DockStyle.Top;
            panel1.ForeColor = Color.White;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(5);
            panel1.Size = new Size(1680, 67);
            panel1.TabIndex = 0;
            // 
            // materialLabel2
            // 
            materialLabel2.AutoSize = true;
            materialLabel2.Depth = 0;
            materialLabel2.Font = new Font("Roboto", 11F, FontStyle.Regular, GraphicsUnit.Point);
            materialLabel2.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialLabel2.Location = new Point(693, 25);
            materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel2.Name = "materialLabel2";
            materialLabel2.Size = new Size(246, 19);
            materialLabel2.TabIndex = 0;
            materialLabel2.Text = "Demo App for SLC CAE with MSAL ";
            // 
            // panel2
            // 
            panel2.BackColor = Color.PaleGoldenrod;
            panel2.Controls.Add(btnCallResource);
            panel2.Controls.Add(btnFetchToken);
            panel2.Controls.Add(btnExit);
            panel2.Controls.Add(materialLabel1);
            panel2.Controls.Add(testOption2);
            panel2.Controls.Add(testOption3);
            panel2.Controls.Add(vanillaMSI);
            panel2.Controls.Add(pictureBox1);
            panel2.Controls.Add(panel3);
            panel2.Dock = DockStyle.Left;
            panel2.Location = new Point(0, 67);
            panel2.Name = "panel2";
            panel2.Size = new Size(227, 862);
            panel2.TabIndex = 1;
            // 
            // btnCallResource
            // 
            btnCallResource.Depth = 0;
            btnCallResource.Location = new Point(12, 462);
            btnCallResource.MouseState = MaterialSkin.MouseState.HOVER;
            btnCallResource.Name = "btnCallResource";
            btnCallResource.Primary = true;
            btnCallResource.Size = new Size(200, 74);
            btnCallResource.TabIndex = 9;
            btnCallResource.Text = "CALL RESOURCE";
            btnCallResource.UseVisualStyleBackColor = true;
            // 
            // btnFetchToken
            // 
            btnFetchToken.Depth = 0;
            btnFetchToken.Location = new Point(12, 361);
            btnFetchToken.MouseState = MaterialSkin.MouseState.HOVER;
            btnFetchToken.Name = "btnFetchToken";
            btnFetchToken.Primary = true;
            btnFetchToken.Size = new Size(200, 74);
            btnFetchToken.TabIndex = 8;
            btnFetchToken.Text = "Fetch Token";
            btnFetchToken.UseVisualStyleBackColor = true;
            btnFetchToken.Click += btnFetchToken_Click;
            // 
            // btnExit
            // 
            btnExit.Depth = 0;
            btnExit.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnExit.Location = new Point(12, 561);
            btnExit.MouseState = MaterialSkin.MouseState.HOVER;
            btnExit.Name = "btnExit";
            btnExit.Primary = true;
            btnExit.Size = new Size(200, 74);
            btnExit.TabIndex = 7;
            btnExit.Text = "EXIT TEST APP";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += materialRaisedButton1_Click;
            // 
            // materialLabel1
            // 
            materialLabel1.AutoSize = true;
            materialLabel1.Depth = 0;
            materialLabel1.Font = new Font("Roboto", 11F, FontStyle.Regular, GraphicsUnit.Point);
            materialLabel1.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialLabel1.Location = new Point(12, 65);
            materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel1.Name = "materialLabel1";
            materialLabel1.Size = new Size(128, 19);
            materialLabel1.TabIndex = 6;
            materialLabel1.Text = "CAE Test Options";
            // 
            // testOption2
            // 
            testOption2.AutoSize = true;
            testOption2.Depth = 0;
            testOption2.Font = new Font("Roboto", 10F, FontStyle.Regular, GraphicsUnit.Point);
            testOption2.Location = new Point(21, 179);
            testOption2.Margin = new Padding(0);
            testOption2.MouseLocation = new Point(-1, -1);
            testOption2.MouseState = MaterialSkin.MouseState.HOVER;
            testOption2.Name = "testOption2";
            testOption2.Ripple = true;
            testOption2.Size = new Size(87, 30);
            testOption2.TabIndex = 5;
            testOption2.TabStop = true;
            testOption2.Text = "Plain MSI";
            testOption2.UseVisualStyleBackColor = true;
            // 
            // testOption3
            // 
            testOption3.AutoSize = true;
            testOption3.Depth = 0;
            testOption3.Font = new Font("Roboto", 10F, FontStyle.Regular, GraphicsUnit.Point);
            testOption3.Location = new Point(21, 235);
            testOption3.Margin = new Padding(0);
            testOption3.MouseLocation = new Point(-1, -1);
            testOption3.MouseState = MaterialSkin.MouseState.HOVER;
            testOption3.Name = "testOption3";
            testOption3.Ripple = true;
            testOption3.Size = new Size(106, 30);
            testOption3.TabIndex = 4;
            testOption3.TabStop = true;
            testOption3.Text = "FIC MSI CAE";
            testOption3.UseVisualStyleBackColor = true;
            // 
            // vanillaMSI
            // 
            vanillaMSI.AutoSize = true;
            vanillaMSI.Depth = 0;
            vanillaMSI.Font = new Font("Roboto", 10F, FontStyle.Regular, GraphicsUnit.Point);
            vanillaMSI.Location = new Point(21, 122);
            vanillaMSI.Margin = new Padding(0);
            vanillaMSI.MouseLocation = new Point(-1, -1);
            vanillaMSI.MouseState = MaterialSkin.MouseState.HOVER;
            vanillaMSI.Name = "vanillaMSI";
            vanillaMSI.Ripple = true;
            vanillaMSI.Size = new Size(98, 30);
            vanillaMSI.TabIndex = 3;
            vanillaMSI.TabStop = true;
            vanillaMSI.Text = "Vanilla MSI";
            vanillaMSI.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.a575a214fd997ef93e6d046a77508269__leprechaun_clip_art_is_cute_leprechaun_clipart_904_982;
            pictureBox1.Location = new Point(21, 672);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(171, 178);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // panel3
            // 
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Location = new Point(7, 26);
            panel3.Name = "panel3";
            panel3.Size = new Size(205, 309);
            panel3.TabIndex = 10;
            // 
            // txtTenantId
            // 
            txtTenantId.BackColor = Color.FromArgb(224, 224, 224);
            txtTenantId.Depth = 0;
            txtTenantId.ForeColor = SystemColors.ActiveCaption;
            txtTenantId.Hint = "";
            txtTenantId.Location = new Point(364, 109);
            txtTenantId.MouseState = MaterialSkin.MouseState.HOVER;
            txtTenantId.Name = "txtTenantId";
            txtTenantId.PasswordChar = '\0';
            txtTenantId.SelectedText = "";
            txtTenantId.SelectionLength = 0;
            txtTenantId.SelectionStart = 0;
            txtTenantId.Size = new Size(388, 23);
            txtTenantId.TabIndex = 2;
            txtTenantId.UseSystemPasswordChar = false;
            // 
            // materialLabel3
            // 
            materialLabel3.AutoSize = true;
            materialLabel3.BackColor = Color.Transparent;
            materialLabel3.Depth = 0;
            materialLabel3.Font = new Font("Roboto", 11F, FontStyle.Regular, GraphicsUnit.Point);
            materialLabel3.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialLabel3.Location = new Point(256, 109);
            materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel3.Name = "materialLabel3";
            materialLabel3.Size = new Size(73, 19);
            materialLabel3.TabIndex = 3;
            materialLabel3.Text = "Tenant ID";
            // 
            // txtBoxLogs
            // 
            txtBoxLogs.BackColor = Color.Cornsilk;
            txtBoxLogs.Location = new Point(244, 420);
            txtBoxLogs.Multiline = true;
            txtBoxLogs.Name = "txtBoxLogs";
            txtBoxLogs.Size = new Size(1424, 478);
            txtBoxLogs.TabIndex = 4;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(244, 902);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(1424, 23);
            progressBar1.TabIndex = 5;
            // 
            // panel4
            // 
            panel4.BorderStyle = BorderStyle.FixedSingle;
            panel4.Controls.Add(msalLogs);
            panel4.Controls.Add(materialLabel8);
            panel4.Controls.Add(materialSingleLineTextField5);
            panel4.Controls.Add(materialLabel7);
            panel4.Controls.Add(materialSingleLineTextField4);
            panel4.Controls.Add(materialLabel6);
            panel4.Controls.Add(materialSingleLineTextField3);
            panel4.Controls.Add(materialLabel5);
            panel4.Controls.Add(txtResource);
            panel4.Controls.Add(materialLabel4);
            panel4.Controls.Add(txtClientId);
            panel4.Location = new Point(244, 93);
            panel4.Name = "panel4";
            panel4.Size = new Size(1424, 309);
            panel4.TabIndex = 6;
            // 
            // msalLogs
            // 
            msalLogs.BackColor = Color.Cornsilk;
            msalLogs.Location = new Point(535, 15);
            msalLogs.Multiline = true;
            msalLogs.Name = "msalLogs";
            msalLogs.Size = new Size(875, 277);
            msalLogs.TabIndex = 7;
            // 
            // materialLabel8
            // 
            materialLabel8.AutoSize = true;
            materialLabel8.BackColor = Color.Transparent;
            materialLabel8.Depth = 0;
            materialLabel8.Font = new Font("Roboto", 11F, FontStyle.Regular, GraphicsUnit.Point);
            materialLabel8.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialLabel8.Location = new Point(11, 246);
            materialLabel8.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel8.Name = "materialLabel8";
            materialLabel8.Size = new Size(102, 19);
            materialLabel8.TabIndex = 16;
            materialLabel8.Text = "Token Source";
            // 
            // materialSingleLineTextField5
            // 
            materialSingleLineTextField5.BackColor = Color.FromArgb(224, 224, 224);
            materialSingleLineTextField5.Depth = 0;
            materialSingleLineTextField5.ForeColor = SystemColors.ActiveCaption;
            materialSingleLineTextField5.Hint = "";
            materialSingleLineTextField5.Location = new Point(119, 246);
            materialSingleLineTextField5.MouseState = MaterialSkin.MouseState.HOVER;
            materialSingleLineTextField5.Name = "materialSingleLineTextField5";
            materialSingleLineTextField5.PasswordChar = '\0';
            materialSingleLineTextField5.SelectedText = "";
            materialSingleLineTextField5.SelectionLength = 0;
            materialSingleLineTextField5.SelectionStart = 0;
            materialSingleLineTextField5.Size = new Size(388, 23);
            materialSingleLineTextField5.TabIndex = 15;
            materialSingleLineTextField5.UseSystemPasswordChar = false;
            // 
            // materialLabel7
            // 
            materialLabel7.AutoSize = true;
            materialLabel7.BackColor = Color.Transparent;
            materialLabel7.Depth = 0;
            materialLabel7.Font = new Font("Roboto", 11F, FontStyle.Regular, GraphicsUnit.Point);
            materialLabel7.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialLabel7.Location = new Point(11, 193);
            materialLabel7.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel7.Name = "materialLabel7";
            materialLabel7.Size = new Size(102, 19);
            materialLabel7.TabIndex = 14;
            materialLabel7.Text = "Token Source";
            // 
            // materialSingleLineTextField4
            // 
            materialSingleLineTextField4.BackColor = Color.FromArgb(224, 224, 224);
            materialSingleLineTextField4.Depth = 0;
            materialSingleLineTextField4.ForeColor = SystemColors.ActiveCaption;
            materialSingleLineTextField4.Hint = "";
            materialSingleLineTextField4.Location = new Point(119, 193);
            materialSingleLineTextField4.MouseState = MaterialSkin.MouseState.HOVER;
            materialSingleLineTextField4.Name = "materialSingleLineTextField4";
            materialSingleLineTextField4.PasswordChar = '\0';
            materialSingleLineTextField4.SelectedText = "";
            materialSingleLineTextField4.SelectionLength = 0;
            materialSingleLineTextField4.SelectionStart = 0;
            materialSingleLineTextField4.Size = new Size(388, 23);
            materialSingleLineTextField4.TabIndex = 13;
            materialSingleLineTextField4.UseSystemPasswordChar = false;
            // 
            // materialLabel6
            // 
            materialLabel6.AutoSize = true;
            materialLabel6.BackColor = Color.Transparent;
            materialLabel6.Depth = 0;
            materialLabel6.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point);
            materialLabel6.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialLabel6.Location = new Point(11, 152);
            materialLabel6.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel6.Name = "materialLabel6";
            materialLabel6.Size = new Size(78, 18);
            materialLabel6.TabIndex = 12;
            materialLabel6.Text = "FIC App ID";
            // 
            // materialSingleLineTextField3
            // 
            materialSingleLineTextField3.BackColor = Color.FromArgb(224, 224, 224);
            materialSingleLineTextField3.Depth = 0;
            materialSingleLineTextField3.ForeColor = SystemColors.ActiveCaption;
            materialSingleLineTextField3.Hint = "";
            materialSingleLineTextField3.Location = new Point(119, 152);
            materialSingleLineTextField3.MouseState = MaterialSkin.MouseState.HOVER;
            materialSingleLineTextField3.Name = "materialSingleLineTextField3";
            materialSingleLineTextField3.PasswordChar = '\0';
            materialSingleLineTextField3.SelectedText = "";
            materialSingleLineTextField3.SelectionLength = 0;
            materialSingleLineTextField3.SelectionStart = 0;
            materialSingleLineTextField3.Size = new Size(388, 23);
            materialSingleLineTextField3.TabIndex = 11;
            materialSingleLineTextField3.UseSystemPasswordChar = false;
            // 
            // materialLabel5
            // 
            materialLabel5.AutoSize = true;
            materialLabel5.BackColor = Color.Transparent;
            materialLabel5.Depth = 0;
            materialLabel5.Font = new Font("Roboto", 11F, FontStyle.Regular, GraphicsUnit.Point);
            materialLabel5.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialLabel5.Location = new Point(11, 106);
            materialLabel5.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel5.Name = "materialLabel5";
            materialLabel5.Size = new Size(72, 19);
            materialLabel5.TabIndex = 10;
            materialLabel5.Text = "Resource";
            // 
            // txtResource
            // 
            txtResource.BackColor = Color.FromArgb(224, 224, 224);
            txtResource.Depth = 0;
            txtResource.ForeColor = SystemColors.ActiveCaption;
            txtResource.Hint = "";
            txtResource.Location = new Point(119, 106);
            txtResource.MouseState = MaterialSkin.MouseState.HOVER;
            txtResource.Name = "txtResource";
            txtResource.PasswordChar = '\0';
            txtResource.SelectedText = "";
            txtResource.SelectionLength = 0;
            txtResource.SelectionStart = 0;
            txtResource.Size = new Size(388, 23);
            txtResource.TabIndex = 9;
            txtResource.UseSystemPasswordChar = false;
            // 
            // materialLabel4
            // 
            materialLabel4.AutoSize = true;
            materialLabel4.BackColor = Color.Transparent;
            materialLabel4.Depth = 0;
            materialLabel4.Font = new Font("Roboto", 11F, FontStyle.Regular, GraphicsUnit.Point);
            materialLabel4.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialLabel4.Location = new Point(11, 62);
            materialLabel4.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel4.Name = "materialLabel4";
            materialLabel4.Size = new Size(66, 19);
            materialLabel4.TabIndex = 8;
            materialLabel4.Text = "Client ID";
            // 
            // txtClientId
            // 
            txtClientId.BackColor = Color.FromArgb(224, 224, 224);
            txtClientId.Depth = 0;
            txtClientId.ForeColor = SystemColors.ActiveCaption;
            txtClientId.Hint = "";
            txtClientId.Location = new Point(119, 62);
            txtClientId.MouseState = MaterialSkin.MouseState.HOVER;
            txtClientId.Name = "txtClientId";
            txtClientId.PasswordChar = '\0';
            txtClientId.SelectedText = "";
            txtClientId.SelectionLength = 0;
            txtClientId.SelectionStart = 0;
            txtClientId.Size = new Size(388, 23);
            txtClientId.TabIndex = 7;
            txtClientId.UseSystemPasswordChar = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Beige;
            ClientSize = new Size(1680, 929);
            Controls.Add(progressBar1);
            Controls.Add(txtBoxLogs);
            Controls.Add(materialLabel3);
            Controls.Add(txtTenantId);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(panel4);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Form1";
            Text = "SLC CAE MSAL Demo App";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private PictureBox pictureBox1;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialRaisedButton btnCallResource;
        private MaterialSkin.Controls.MaterialRaisedButton btnFetchToken;
        private MaterialSkin.Controls.MaterialRaisedButton btnExit;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialRadioButton testOption2;
        private MaterialSkin.Controls.MaterialRadioButton testOption3;
        private MaterialSkin.Controls.MaterialRadioButton vanillaMSI;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtTenantId;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private TextBox txtBoxLogs;
        private Panel panel3;
        private ProgressBar progressBar1;
        private Panel panel4;
        private MaterialSkin.Controls.MaterialLabel materialLabel8;
        private MaterialSkin.Controls.MaterialSingleLineTextField materialSingleLineTextField5;
        private MaterialSkin.Controls.MaterialLabel materialLabel7;
        private MaterialSkin.Controls.MaterialSingleLineTextField materialSingleLineTextField4;
        private MaterialSkin.Controls.MaterialLabel materialLabel6;
        private MaterialSkin.Controls.MaterialSingleLineTextField materialSingleLineTextField3;
        private MaterialSkin.Controls.MaterialLabel materialLabel5;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtResource;
        private MaterialSkin.Controls.MaterialLabel materialLabel4;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtClientId;
        private TextBox msalLogs;
    }
}