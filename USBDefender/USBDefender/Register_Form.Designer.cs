namespace USBDefender
{
    partial class Register_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Register_Form));
            this.Name_TextBox = new System.Windows.Forms.TextBox();
            this.Name_Label = new System.Windows.Forms.Label();
            this.Position_Label = new System.Windows.Forms.Label();
            this.Department_Label = new System.Windows.Forms.Label();
            this.Register_btn = new System.Windows.Forms.Button();
            this.Department_ComboBox = new System.Windows.Forms.ComboBox();
            this.Position_ComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // Name_TextBox
            // 
            this.Name_TextBox.BackColor = System.Drawing.Color.Silver;
            this.Name_TextBox.Font = new System.Drawing.Font("굴림", 12F);
            this.Name_TextBox.Location = new System.Drawing.Point(46, 89);
            this.Name_TextBox.Name = "Name_TextBox";
            this.Name_TextBox.Size = new System.Drawing.Size(101, 26);
            this.Name_TextBox.TabIndex = 3;
            this.Name_TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Name_Label
            // 
            this.Name_Label.AutoSize = true;
            this.Name_Label.BackColor = System.Drawing.Color.Transparent;
            this.Name_Label.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold);
            this.Name_Label.Location = new System.Drawing.Point(3, 95);
            this.Name_Label.Name = "Name_Label";
            this.Name_Label.Size = new System.Drawing.Size(42, 16);
            this.Name_Label.TabIndex = 10;
            this.Name_Label.Text = "이름";
            this.Name_Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Position_Label
            // 
            this.Position_Label.AutoSize = true;
            this.Position_Label.BackColor = System.Drawing.Color.Transparent;
            this.Position_Label.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold);
            this.Position_Label.Location = new System.Drawing.Point(3, 53);
            this.Position_Label.Name = "Position_Label";
            this.Position_Label.Size = new System.Drawing.Size(42, 16);
            this.Position_Label.TabIndex = 9;
            this.Position_Label.Text = "직책";
            this.Position_Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Department_Label
            // 
            this.Department_Label.AutoSize = true;
            this.Department_Label.BackColor = System.Drawing.Color.Transparent;
            this.Department_Label.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold);
            this.Department_Label.Location = new System.Drawing.Point(3, 16);
            this.Department_Label.Name = "Department_Label";
            this.Department_Label.Size = new System.Drawing.Size(42, 16);
            this.Department_Label.TabIndex = 8;
            this.Department_Label.Text = "부서";
            this.Department_Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Register_btn
            // 
            this.Register_btn.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.Register_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Register_btn.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold);
            this.Register_btn.Location = new System.Drawing.Point(153, 13);
            this.Register_btn.Name = "Register_btn";
            this.Register_btn.Size = new System.Drawing.Size(61, 102);
            this.Register_btn.TabIndex = 4;
            this.Register_btn.Text = "등 록";
            this.Register_btn.UseVisualStyleBackColor = true;
            this.Register_btn.Click += new System.EventHandler(this.Register_btn_Click);
            // 
            // Department_ComboBox
            // 
            this.Department_ComboBox.BackColor = System.Drawing.Color.Silver;
            this.Department_ComboBox.Font = new System.Drawing.Font("굴림", 12F);
            this.Department_ComboBox.FormattingEnabled = true;
            this.Department_ComboBox.Location = new System.Drawing.Point(46, 13);
            this.Department_ComboBox.Name = "Department_ComboBox";
            this.Department_ComboBox.Size = new System.Drawing.Size(101, 24);
            this.Department_ComboBox.TabIndex = 1;
            // 
            // Position_ComboBox
            // 
            this.Position_ComboBox.BackColor = System.Drawing.Color.Silver;
            this.Position_ComboBox.Font = new System.Drawing.Font("굴림", 12F);
            this.Position_ComboBox.FormattingEnabled = true;
            this.Position_ComboBox.Location = new System.Drawing.Point(46, 50);
            this.Position_ComboBox.Name = "Position_ComboBox";
            this.Position_ComboBox.Size = new System.Drawing.Size(101, 24);
            this.Position_ComboBox.TabIndex = 2;
            // 
            // Register_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(225, 124);
            this.Controls.Add(this.Position_ComboBox);
            this.Controls.Add(this.Department_ComboBox);
            this.Controls.Add(this.Register_btn);
            this.Controls.Add(this.Name_TextBox);
            this.Controls.Add(this.Name_Label);
            this.Controls.Add(this.Position_Label);
            this.Controls.Add(this.Department_Label);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Register_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "USB Defender";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Register_Form_FormClosing);
            this.Load += new System.EventHandler(this.Register_Form_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Name_TextBox;
        private System.Windows.Forms.Label Name_Label;
        private System.Windows.Forms.Label Position_Label;
        private System.Windows.Forms.Label Department_Label;
        private System.Windows.Forms.Button Register_btn;
        private System.Windows.Forms.ComboBox Department_ComboBox;
        private System.Windows.Forms.ComboBox Position_ComboBox;
    }
}