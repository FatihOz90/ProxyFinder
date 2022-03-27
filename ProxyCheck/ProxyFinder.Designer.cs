
namespace ProxyCheck
{
    partial class ProxyFinder
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_GetProxyIP = new System.Windows.Forms.Button();
            this.TB_Sources = new System.Windows.Forms.TextBox();
            this.LB_Logs = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.BtnCheckProxy = new System.Windows.Forms.Button();
            this.btnExportTxt = new System.Windows.Forms.Button();
            this.btnNotWorkingDelete = new System.Windows.Forms.Button();
            this.DGV_PROXYLIST = new System.Windows.Forms.DataGridView();
            this.IP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ConnectTest = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PngTest = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Webtest = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnLoadText = new System.Windows.Forms.Button();
            this.btnGethttpProxy = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_PROXYLIST)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_GetProxyIP
            // 
            this.btn_GetProxyIP.Location = new System.Drawing.Point(12, 555);
            this.btn_GetProxyIP.Name = "btn_GetProxyIP";
            this.btn_GetProxyIP.Size = new System.Drawing.Size(88, 40);
            this.btn_GetProxyIP.TabIndex = 2;
            this.btn_GetProxyIP.Text = "1. Get Proxy IP";
            this.btn_GetProxyIP.UseVisualStyleBackColor = true;
            this.btn_GetProxyIP.Click += new System.EventHandler(this.btn_GetProxyIP_Click);
            // 
            // TB_Sources
            // 
            this.TB_Sources.Location = new System.Drawing.Point(867, 41);
            this.TB_Sources.Multiline = true;
            this.TB_Sources.Name = "TB_Sources";
            this.TB_Sources.Size = new System.Drawing.Size(291, 508);
            this.TB_Sources.TabIndex = 3;
            // 
            // LB_Logs
            // 
            this.LB_Logs.FormattingEnabled = true;
            this.LB_Logs.Location = new System.Drawing.Point(441, 41);
            this.LB_Logs.Name = "LB_Logs";
            this.LB_Logs.Size = new System.Drawing.Size(420, 511);
            this.LB_Logs.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(337, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Checked Proxy List";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(831, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Logs";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1080, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Proxy Web List";
            // 
            // BtnCheckProxy
            // 
            this.BtnCheckProxy.Location = new System.Drawing.Point(106, 555);
            this.BtnCheckProxy.Name = "BtnCheckProxy";
            this.BtnCheckProxy.Size = new System.Drawing.Size(93, 40);
            this.BtnCheckProxy.TabIndex = 11;
            this.BtnCheckProxy.Text = "2. Check Proxy";
            this.BtnCheckProxy.UseVisualStyleBackColor = true;
            this.BtnCheckProxy.Click += new System.EventHandler(this.BtnCheckProxy_Click);
            // 
            // btnExportTxt
            // 
            this.btnExportTxt.Location = new System.Drawing.Point(335, 555);
            this.btnExportTxt.Name = "btnExportTxt";
            this.btnExportTxt.Size = new System.Drawing.Size(100, 40);
            this.btnExportTxt.TabIndex = 14;
            this.btnExportTxt.Text = "4. Export TXT";
            this.btnExportTxt.UseVisualStyleBackColor = true;
            this.btnExportTxt.Click += new System.EventHandler(this.btnExportTxt_Click);
            // 
            // btnNotWorkingDelete
            // 
            this.btnNotWorkingDelete.Location = new System.Drawing.Point(205, 555);
            this.btnNotWorkingDelete.Name = "btnNotWorkingDelete";
            this.btnNotWorkingDelete.Size = new System.Drawing.Size(124, 40);
            this.btnNotWorkingDelete.TabIndex = 16;
            this.btnNotWorkingDelete.Text = "3. Delete Not Working ";
            this.btnNotWorkingDelete.UseVisualStyleBackColor = true;
            this.btnNotWorkingDelete.Click += new System.EventHandler(this.btnNotWorkingDelete_Click);
            // 
            // DGV_PROXYLIST
            // 
            this.DGV_PROXYLIST.AllowUserToAddRows = false;
            this.DGV_PROXYLIST.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_PROXYLIST.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IP,
            this.ConnectTest,
            this.PngTest,
            this.Webtest});
            this.DGV_PROXYLIST.Location = new System.Drawing.Point(12, 41);
            this.DGV_PROXYLIST.Name = "DGV_PROXYLIST";
            this.DGV_PROXYLIST.ReadOnly = true;
            this.DGV_PROXYLIST.Size = new System.Drawing.Size(423, 508);
            this.DGV_PROXYLIST.TabIndex = 17;
            // 
            // IP
            // 
            this.IP.HeaderText = "IP";
            this.IP.Name = "IP";
            this.IP.ReadOnly = true;
            this.IP.Width = 170;
            // 
            // ConnectTest
            // 
            this.ConnectTest.HeaderText = "ConnectTest";
            this.ConnectTest.Name = "ConnectTest";
            this.ConnectTest.ReadOnly = true;
            this.ConnectTest.Width = 70;
            // 
            // PngTest
            // 
            this.PngTest.HeaderText = "PngTest";
            this.PngTest.Name = "PngTest";
            this.PngTest.ReadOnly = true;
            this.PngTest.Width = 70;
            // 
            // Webtest
            // 
            this.Webtest.HeaderText = "Webtest";
            this.Webtest.Name = "Webtest";
            this.Webtest.ReadOnly = true;
            this.Webtest.Width = 70;
            // 
            // btnLoadText
            // 
            this.btnLoadText.Location = new System.Drawing.Point(12, 15);
            this.btnLoadText.Name = "btnLoadText";
            this.btnLoadText.Size = new System.Drawing.Size(162, 23);
            this.btnLoadText.TabIndex = 19;
            this.btnLoadText.Text = "Load Checked Proxy List";
            this.btnLoadText.UseVisualStyleBackColor = true;
            this.btnLoadText.Click += new System.EventHandler(this.btnLoadText_Click);
            // 
            // btnGethttpProxy
            // 
            this.btnGethttpProxy.Location = new System.Drawing.Point(867, 555);
            this.btnGethttpProxy.Name = "btnGethttpProxy";
            this.btnGethttpProxy.Size = new System.Drawing.Size(107, 23);
            this.btnGethttpProxy.TabIndex = 22;
            this.btnGethttpProxy.Text = "Get  Http Proxy List";
            this.btnGethttpProxy.UseVisualStyleBackColor = true;
            this.btnGethttpProxy.Click += new System.EventHandler(this.btnGethttpProxy_Click);
            // 
            // ProxyFinder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1170, 605);
            this.Controls.Add(this.btnGethttpProxy);
            this.Controls.Add(this.btnLoadText);
            this.Controls.Add(this.DGV_PROXYLIST);
            this.Controls.Add(this.btnNotWorkingDelete);
            this.Controls.Add(this.btnExportTxt);
            this.Controls.Add(this.BtnCheckProxy);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LB_Logs);
            this.Controls.Add(this.TB_Sources);
            this.Controls.Add(this.btn_GetProxyIP);
            this.MaximizeBox = false;
            this.Name = "ProxyFinder";
            this.Text = "Proxy Finder";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_PROXYLIST)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox TB_Sources;
        public System.Windows.Forms.Button btn_GetProxyIP;
        private System.Windows.Forms.ListBox LB_Logs;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button BtnCheckProxy;
        private System.Windows.Forms.Button btnExportTxt;
        private System.Windows.Forms.Button btnNotWorkingDelete;
        private System.Windows.Forms.DataGridView DGV_PROXYLIST;
        private System.Windows.Forms.DataGridViewTextBoxColumn IP;
        private System.Windows.Forms.DataGridViewTextBoxColumn ConnectTest;
        private System.Windows.Forms.DataGridViewTextBoxColumn PngTest;
        private System.Windows.Forms.DataGridViewTextBoxColumn Webtest;
        private System.Windows.Forms.Button btnLoadText;
        private System.Windows.Forms.Button btnGethttpProxy;
    }
}

