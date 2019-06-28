namespace USBDefender
{
    partial class Storage_box_Form
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Storage_box_Form));
            this.listView1 = new System.Windows.Forms.ListView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.restorage_btn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.Color.Silver;
            this.listView1.LargeImageList = this.imageList1;
            this.listView1.Location = new System.Drawing.Point(1, 1);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(492, 225);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseDoubleClick);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "hard_drive_windows_2.ico");
            this.imageList1.Images.SetKeyName(1, "hard_drive.ico");
            this.imageList1.Images.SetKeyName(2, "folderopened_yellow.ico");
            this.imageList1.Images.SetKeyName(3, "opened_folder.ico");
            this.imageList1.Images.SetKeyName(4, "Hopstarter-Sleek-Xp-Basic-Document-Blank.ico");
            // 
            // restorage_btn
            // 
            this.restorage_btn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.restorage_btn.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.restorage_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.restorage_btn.Font = new System.Drawing.Font("굴림", 20F, System.Drawing.FontStyle.Bold);
            this.restorage_btn.Location = new System.Drawing.Point(12, 245);
            this.restorage_btn.Name = "restorage_btn";
            this.restorage_btn.Size = new System.Drawing.Size(494, 43);
            this.restorage_btn.TabIndex = 1;
            this.restorage_btn.Text = "복          원";
            this.restorage_btn.UseVisualStyleBackColor = true;
            this.restorage_btn.Click += new System.EventHandler(this.restorage_btn_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Red;
            this.panel1.Controls.Add(this.listView1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(494, 227);
            this.panel1.TabIndex = 2;
            // 
            // Storage_box_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(518, 296);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.restorage_btn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Storage_box_Form";
            this.Text = "USB Defender";
            this.Load += new System.EventHandler(this.Storage_box_Form_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button restorage_btn;
        private System.Windows.Forms.Panel panel1;
    }
}