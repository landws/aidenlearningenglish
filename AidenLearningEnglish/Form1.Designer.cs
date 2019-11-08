namespace AidenLearningEnglish
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.comboBox_recitewords = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.tabPage_recitecontrol = new System.Windows.Forms.TabPage();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.button_skipit = new System.Windows.Forms.Button();
            this.button_forget = new System.Windows.Forms.Button();
            this.button_remember = new System.Windows.Forms.Button();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.webBrowser2 = new System.Windows.Forms.WebBrowser();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.webBrowser3 = new System.Windows.Forms.WebBrowser();
            this.tabPage_recite = new System.Windows.Forms.TabPage();
            this.label_recitesource = new System.Windows.Forms.Label();
            this.textBox_reciteword = new System.Windows.Forms.TextBox();
            this.button_nextword = new System.Windows.Forms.Button();
            this.button_preword = new System.Windows.Forms.Button();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.button1 = new System.Windows.Forms.Button();
            this.button_dropdown = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage_recitecontrol.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.tabControl2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage_recite.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox1.Location = new System.Drawing.Point(119, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(669, 41);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage_recitecontrol);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(269, 434);
            this.tabControl1.TabIndex = 1;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.webBrowser1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(261, 408);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Explain";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.Location = new System.Drawing.Point(3, 3);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(255, 402);
            this.webBrowser1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.comboBox_recitewords);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.comboBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(261, 408);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Configuration";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // comboBox_recitewords
            // 
            this.comboBox_recitewords.FormattingEnabled = true;
            this.comboBox_recitewords.Location = new System.Drawing.Point(89, 47);
            this.comboBox_recitewords.Name = "comboBox_recitewords";
            this.comboBox_recitewords.Size = new System.Drawing.Size(133, 20);
            this.comboBox_recitewords.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "Recite Words";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "Render Style";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(89, 7);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(133, 20);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // tabPage_recitecontrol
            // 
            this.tabPage_recitecontrol.Controls.Add(this.pictureBox2);
            this.tabPage_recitecontrol.Controls.Add(this.button_skipit);
            this.tabPage_recitecontrol.Controls.Add(this.button_forget);
            this.tabPage_recitecontrol.Controls.Add(this.button_remember);
            this.tabPage_recitecontrol.Location = new System.Drawing.Point(4, 22);
            this.tabPage_recitecontrol.Name = "tabPage_recitecontrol";
            this.tabPage_recitecontrol.Size = new System.Drawing.Size(261, 408);
            this.tabPage_recitecontrol.TabIndex = 2;
            this.tabPage_recitecontrol.Text = "Recite Control";
            this.tabPage_recitecontrol.UseVisualStyleBackColor = true;
            this.tabPage_recitecontrol.Resize += new System.EventHandler(this.tabPage7_Resize);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(13, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(235, 184);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // button_skipit
            // 
            this.button_skipit.BackColor = System.Drawing.Color.White;
            this.button_skipit.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_skipit.Location = new System.Drawing.Point(49, 333);
            this.button_skipit.Name = "button_skipit";
            this.button_skipit.Size = new System.Drawing.Size(161, 52);
            this.button_skipit.TabIndex = 0;
            this.button_skipit.Text = "&Skip it!";
            this.button_skipit.UseVisualStyleBackColor = false;
            this.button_skipit.Click += new System.EventHandler(this.button_skipit_Click);
            // 
            // button_forget
            // 
            this.button_forget.BackColor = System.Drawing.Color.Khaki;
            this.button_forget.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_forget.Location = new System.Drawing.Point(49, 270);
            this.button_forget.Name = "button_forget";
            this.button_forget.Size = new System.Drawing.Size(161, 52);
            this.button_forget.TabIndex = 0;
            this.button_forget.Text = "↑ Forget";
            this.button_forget.UseVisualStyleBackColor = false;
            this.button_forget.Click += new System.EventHandler(this.button_forget_Click);
            // 
            // button_remember
            // 
            this.button_remember.BackColor = System.Drawing.Color.PaleGreen;
            this.button_remember.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_remember.Location = new System.Drawing.Point(49, 207);
            this.button_remember.Name = "button_remember";
            this.button_remember.Size = new System.Drawing.Size(161, 52);
            this.button_remember.TabIndex = 0;
            this.button_remember.Text = "↓ Remember";
            this.button_remember.UseVisualStyleBackColor = false;
            this.button_remember.Click += new System.EventHandler(this.button_remember_Click);
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage3);
            this.tabControl2.Controls.Add(this.tabPage4);
            this.tabControl2.Controls.Add(this.tabPage5);
            this.tabControl2.Controls.Add(this.tabPage_recite);
            this.tabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl2.Location = new System.Drawing.Point(0, 0);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(503, 434);
            this.tabControl2.TabIndex = 2;
            this.tabControl2.SelectedIndexChanged += new System.EventHandler(this.tabControl2_SelectedIndexChanged);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.panel1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(495, 408);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "Composite";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(489, 402);
            this.panel1.TabIndex = 1;
            this.panel1.SizeChanged += new System.EventHandler(this.panel1_SizeChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(3, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(337, 195);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.webBrowser2);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(495, 408);
            this.tabPage4.TabIndex = 1;
            this.tabPage4.Text = "Interaction";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // webBrowser2
            // 
            this.webBrowser2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser2.Location = new System.Drawing.Point(3, 3);
            this.webBrowser2.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser2.Name = "webBrowser2";
            this.webBrowser2.Size = new System.Drawing.Size(489, 402);
            this.webBrowser2.TabIndex = 0;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.webBrowser3);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(495, 408);
            this.tabPage5.TabIndex = 2;
            this.tabPage5.Text = "thesaurus";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // webBrowser3
            // 
            this.webBrowser3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser3.Location = new System.Drawing.Point(0, 0);
            this.webBrowser3.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser3.Name = "webBrowser3";
            this.webBrowser3.Size = new System.Drawing.Size(495, 408);
            this.webBrowser3.TabIndex = 0;
            // 
            // tabPage_recite
            // 
            this.tabPage_recite.Controls.Add(this.label_recitesource);
            this.tabPage_recite.Controls.Add(this.textBox_reciteword);
            this.tabPage_recite.Controls.Add(this.button_nextword);
            this.tabPage_recite.Controls.Add(this.button_preword);
            this.tabPage_recite.Controls.Add(this.checkedListBox1);
            this.tabPage_recite.Location = new System.Drawing.Point(4, 22);
            this.tabPage_recite.Name = "tabPage_recite";
            this.tabPage_recite.Size = new System.Drawing.Size(495, 408);
            this.tabPage_recite.TabIndex = 3;
            this.tabPage_recite.Text = "Recite of related";
            this.tabPage_recite.UseVisualStyleBackColor = true;
            // 
            // label_recitesource
            // 
            this.label_recitesource.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label_recitesource.AutoSize = true;
            this.label_recitesource.Location = new System.Drawing.Point(20, 373);
            this.label_recitesource.Name = "label_recitesource";
            this.label_recitesource.Size = new System.Drawing.Size(59, 12);
            this.label_recitesource.TabIndex = 3;
            this.label_recitesource.Text = "Reciting ";
            // 
            // textBox_reciteword
            // 
            this.textBox_reciteword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_reciteword.Font = new System.Drawing.Font("宋体", 21.75F);
            this.textBox_reciteword.Location = new System.Drawing.Point(22, 21);
            this.textBox_reciteword.Name = "textBox_reciteword";
            this.textBox_reciteword.Size = new System.Drawing.Size(448, 41);
            this.textBox_reciteword.TabIndex = 2;
            this.textBox_reciteword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button_nextword
            // 
            this.button_nextword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_nextword.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_nextword.Location = new System.Drawing.Point(394, 153);
            this.button_nextword.Name = "button_nextword";
            this.button_nextword.Size = new System.Drawing.Size(75, 75);
            this.button_nextword.TabIndex = 1;
            this.button_nextword.Text = ">";
            this.button_nextword.UseVisualStyleBackColor = true;
            this.button_nextword.Click += new System.EventHandler(this.button_nextword_Click);
            // 
            // button_preword
            // 
            this.button_preword.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_preword.Location = new System.Drawing.Point(22, 153);
            this.button_preword.Name = "button_preword";
            this.button_preword.Size = new System.Drawing.Size(75, 75);
            this.button_preword.TabIndex = 1;
            this.button_preword.Text = "<";
            this.button_preword.UseVisualStyleBackColor = true;
            this.button_preword.Click += new System.EventHandler(this.button_preword_Click);
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkedListBox1.CheckOnClick = true;
            this.checkedListBox1.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.IntegralHeight = false;
            this.checkedListBox1.Location = new System.Drawing.Point(117, 88);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(257, 260);
            this.checkedListBox1.TabIndex = 0;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(12, 59);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tabControl2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer1.Size = new System.Drawing.Size(776, 434);
            this.splitContainer1.SplitterDistance = 503;
            this.splitContainer1.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 41);
            this.button1.TabIndex = 4;
            this.button1.Text = "Back";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button_dropdown
            // 
            this.button_dropdown.Location = new System.Drawing.Point(86, 12);
            this.button_dropdown.Name = "button_dropdown";
            this.button_dropdown.Size = new System.Drawing.Size(27, 41);
            this.button_dropdown.TabIndex = 5;
            this.button_dropdown.Text = "🔻";
            this.button_dropdown.UseVisualStyleBackColor = true;
            this.button_dropdown.Click += new System.EventHandler(this.button_dropdown_Click);
            // 
            // listBox1
            // 
            this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox1.Font = new System.Drawing.Font("宋体", 21.75F);
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 29;
            this.listBox1.Location = new System.Drawing.Point(119, 53);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(669, 120);
            this.listBox1.TabIndex = 6;
            this.listBox1.Visible = false;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            this.listBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.listBox1_KeyPress);
            this.listBox1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBox1_MouseDoubleClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 505);
            this.Controls.Add(this.button_dropdown);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.listBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Aiden Learning English v1.2.1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage_recitecontrol.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.tabControl2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.tabPage_recite.ResumeLayout(false);
            this.tabPage_recite.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.WebBrowser webBrowser2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.WebBrowser webBrowser3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button_dropdown;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.TabPage tabPage_recitecontrol;
        private System.Windows.Forms.TabPage tabPage_recite;
        private System.Windows.Forms.Button button_forget;
        private System.Windows.Forms.Button button_remember;
        private System.Windows.Forms.Button button_skipit;
        private System.Windows.Forms.Button button_nextword;
        private System.Windows.Forms.Button button_preword;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.TextBox textBox_reciteword;
        private System.Windows.Forms.ComboBox comboBox_recitewords;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label_recitesource;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}

