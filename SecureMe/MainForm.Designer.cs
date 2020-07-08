namespace SecureMe
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.lsbRules = new System.Windows.Forms.ListBox();
            this.btnScan = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lsbRules
            // 
            this.lsbRules.FormattingEnabled = true;
            this.lsbRules.ItemHeight = 15;
            this.lsbRules.Location = new System.Drawing.Point(12, 12);
            this.lsbRules.Name = "lsbRules";
            this.lsbRules.Size = new System.Drawing.Size(607, 424);
            this.lsbRules.TabIndex = 0;
            // 
            // btnScan
            // 
            this.btnScan.Location = new System.Drawing.Point(640, 12);
            this.btnScan.Name = "btnScan";
            this.btnScan.Size = new System.Drawing.Size(75, 32);
            this.btnScan.TabIndex = 1;
            this.btnScan.Text = "扫描";
            this.btnScan.UseVisualStyleBackColor = true;
            this.btnScan.Click += new System.EventHandler(this.btnScan_Click);
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(640, 50);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(75, 32);
            this.btnApply.TabIndex = 1;
            this.btnApply.Text = "设置";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.btnScan);
            this.Controls.Add(this.lsbRules);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lsbRules;
        private System.Windows.Forms.Button btnScan;
        private System.Windows.Forms.Button btnApply;
    }
}

