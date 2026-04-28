namespace HomeAffairsDigitalidentityProcessor
{
    partial class Form1
    {
        /// <summary>
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txtName = new TextBox();
            txtID = new TextBox();
            btnValidate = new Button();
            btnGenerateProfile = new Button();
            richTextBox1 = new RichTextBox();
            cmbCitizen = new ComboBox();
            label4 = new Label();
            label5 = new Label();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(477, 65);
            label1.Name = "label1";
            label1.Size = new Size(117, 20);
            label1.TabIndex = 0;
            label1.Text = "Enter your name";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(477, 110);
            label2.Name = "label2";
            label2.Size = new Size(95, 20);
            label2.TabIndex = 1;
            label2.Text = "Enter your ID";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(477, 165);
            label3.Name = "label3";
            label3.Size = new Size(134, 20);
            label3.TabIndex = 2;
            label3.Text = "Choose your citzen";
            label3.Click += label3_Click;
            // 
            // txtName
            // 
            txtName.Location = new Point(624, 45);
            txtName.Name = "txtName";
            txtName.Size = new Size(151, 27);
            txtName.TabIndex = 3;
            // 
            // txtID
            // 
            txtID.Location = new Point(624, 103);
            txtID.Name = "txtID";
            txtID.Size = new Size(151, 27);
            txtID.TabIndex = 4;
            txtID.TextChanged += txtID_TextChanged;
            // 
            // btnValidate
            // 
            btnValidate.BackColor = Color.Green;
            btnValidate.Location = new Point(519, 214);
            btnValidate.Name = "btnValidate";
            btnValidate.Size = new Size(185, 29);
            btnValidate.TabIndex = 6;
            btnValidate.Text = "Validate ID";
            btnValidate.UseVisualStyleBackColor = false;
            // 
            // btnGenerateProfile
            // 
            btnGenerateProfile.BackColor = Color.Green;
            btnGenerateProfile.Location = new Point(519, 409);
            btnGenerateProfile.Name = "btnGenerateProfile";
            btnGenerateProfile.Size = new Size(185, 29);
            btnGenerateProfile.TabIndex = 7;
            btnGenerateProfile.Text = "Generate Profile";
            btnGenerateProfile.UseVisualStyleBackColor = false;
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(519, 283);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(185, 120);
            richTextBox1.TabIndex = 8;
            richTextBox1.Text = "";
            // 
            // cmbCitizen
            // 
            cmbCitizen.FormattingEnabled = true;
            cmbCitizen.Location = new Point(624, 157);
            cmbCitizen.Name = "cmbCitizen";
            cmbCitizen.Size = new Size(151, 28);
            cmbCitizen.TabIndex = 9;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 15F);
            label4.ForeColor = Color.DarkGreen;
            label4.Location = new Point(329, 7);
            label4.Name = "label4";
            label4.Size = new Size(446, 35);
            label4.TabIndex = 10;
            label4.Text = "Home Affairs Digital Identity Processor";
            label4.Click += label4_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(522, 252);
            label5.Name = "label5";
            label5.Size = new Size(0, 20);
            label5.TabIndex = 11;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Orange;
            pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
            pictureBox1.BackgroundImageLayout = ImageLayout.Center;
            pictureBox1.Location = new Point(38, 74);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(195, 259);
            pictureBox1.TabIndex = 12;
            pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkOrange;
            ClientSize = new Size(800, 450);
            Controls.Add(pictureBox1);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(cmbCitizen);
            Controls.Add(richTextBox1);
            Controls.Add(btnGenerateProfile);
            Controls.Add(btnValidate);
            Controls.Add(txtID);
            Controls.Add(txtName);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Welcome to the Digital Identity Processor!");
        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {

            if (!System.Text.RegularExpressions.Regex.IsMatch(txtID.Text, @"^\d*$"))
            {
                MessageBox.Show("Please enter only numbers for ID.");
                txtID.Text = string.Empty;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This is the ID label.");
        }

        private void label3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Choose your citizenship from the dropdown.");
        }


        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtName;
        private TextBox txtID;
        private Button btnValidate;
        private Button btnGenerateProfile;
        private RichTextBox richTextBox1;
        private ComboBox cmbCitizen;
        private Label label4;
        private Label label5;
        private PictureBox pictureBox1;
    }
}
