namespace USBDefender
{
    partial class State_Form
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Button button1;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(State_Form));
            this.Unregister_btn = new System.Windows.Forms.Button();
            this.storage_box_btn = new System.Windows.Forms.Button();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.열기 = new System.Windows.Forms.ToolStripMenuItem();
            this.종료 = new System.Windows.Forms.ToolStripMenuItem();
            this.Register_btn = new System.Windows.Forms.Button();
            this.Device_List = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            button1 = new System.Windows.Forms.Button();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            button1.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            button1.Font = new System.Drawing.Font("굴림", 12F);
            button1.Location = new System.Drawing.Point(287, 133);
            button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(117, 53);
            button1.TabIndex = 6;
            button1.Text = "새로고침";
            button1.UseVisualStyleBackColor = true;
            button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // Unregister_btn
            // 
            this.Unregister_btn.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.Unregister_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Unregister_btn.Font = new System.Drawing.Font("굴림", 12F);
            this.Unregister_btn.Location = new System.Drawing.Point(287, 73);
            this.Unregister_btn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Unregister_btn.Name = "Unregister_btn";
            this.Unregister_btn.Size = new System.Drawing.Size(117, 52);
            this.Unregister_btn.TabIndex = 1;
            this.Unregister_btn.Text = "등록 해제";
            this.Unregister_btn.UseVisualStyleBackColor = true;
            this.Unregister_btn.Click += new System.EventHandler(this.Unregister_btn_Click);
            // 
            // storage_box_btn
            // 
            this.storage_box_btn.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.storage_box_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.storage_box_btn.Font = new System.Drawing.Font("굴림", 12F);
            this.storage_box_btn.Location = new System.Drawing.Point(287, 194);
            this.storage_box_btn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.storage_box_btn.Name = "storage_box_btn";
            this.storage_box_btn.Size = new System.Drawing.Size(117, 51);
            this.storage_box_btn.TabIndex = 2;
            this.storage_box_btn.Text = "보관함";
            this.storage_box_btn.UseVisualStyleBackColor = true;
            this.storage_box_btn.Click += new System.EventHandler(this.storage_box_btn_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "USB Defender";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.열기,
            this.종료});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(109, 52);
            // 
            // 열기
            // 
            this.열기.Name = "열기";
            this.열기.Size = new System.Drawing.Size(108, 24);
            this.열기.Text = "열기";
            this.열기.Click += new System.EventHandler(this.onContextClick);
            // 
            // 종료
            // 
            this.종료.Name = "종료";
            this.종료.Size = new System.Drawing.Size(108, 24);
            this.종료.Text = "종료";
            this.종료.Click += new System.EventHandler(this.onContextClick);
            // 
            // Register_btn
            // 
            this.Register_btn.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.Register_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Register_btn.Font = new System.Drawing.Font("굴림", 12F);
            this.Register_btn.Location = new System.Drawing.Point(287, 22);
            this.Register_btn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Register_btn.Name = "Register_btn";
            this.Register_btn.Size = new System.Drawing.Size(117, 43);
            this.Register_btn.TabIndex = 4;
            this.Register_btn.Text = "장치 등록";
            this.Register_btn.UseVisualStyleBackColor = true;
            this.Register_btn.Click += new System.EventHandler(this.Register_btn_Click);
            // 
            // Device_List
            // 
            this.Device_List.BackColor = System.Drawing.Color.Silver;
            this.Device_List.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Device_List.Cursor = System.Windows.Forms.Cursors.Default;
            this.Device_List.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.Device_List.FormattingEnabled = true;
            this.Device_List.Location = new System.Drawing.Point(18, 24);
            this.Device_List.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Device_List.Name = "Device_List";
            this.Device_List.Size = new System.Drawing.Size(254, 221);
            this.Device_List.TabIndex = 0;
            this.Device_List.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.List_DrawItem);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Red;
            this.panel1.Location = new System.Drawing.Point(17, 22);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(256, 223);
            this.panel1.TabIndex = 5;
            // 
            // State_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(418, 268);
            this.Controls.Add(button1);
            this.Controls.Add(this.Device_List);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Register_btn);
            this.Controls.Add(this.storage_box_btn);
            this.Controls.Add(this.Unregister_btn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "State_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "USB Defender";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.State_Form_FormClosing);
            this.Load += new System.EventHandler(this.State_Form_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button Unregister_btn;
        private System.Windows.Forms.Button storage_box_btn;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 열기;
        private System.Windows.Forms.ToolStripMenuItem 종료;
        private System.Windows.Forms.Button Register_btn;
        private System.Windows.Forms.ListBox Device_List;
        private System.Windows.Forms.Panel panel1;
    }
}

