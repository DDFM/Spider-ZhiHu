namespace SpiderZhiHu
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
            this.tb_question = new System.Windows.Forms.TextBox();
            this.bt_spider = new System.Windows.Forms.Button();
            this.lb_msg = new System.Windows.Forms.Label();
            this.pb_img = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tb_postion = new System.Windows.Forms.TextBox();
            this.bt_postion = new System.Windows.Forms.Button();
            this.bt_refreshImg = new System.Windows.Forms.Button();
            this.bt_final = new System.Windows.Forms.Button();
            this.bt_saveCookie = new System.Windows.Forms.Button();
            this.tb_userName = new System.Windows.Forms.TextBox();
            this.tb_password = new System.Windows.Forms.TextBox();
            this.bt_verification = new System.Windows.Forms.Button();
            this.rtb_msg = new System.Windows.Forms.RichTextBox();
            this.bt_down = new System.Windows.Forms.Button();
            this.rtb_getImgUrl = new System.Windows.Forms.RichTextBox();
            this.rtb_downImg = new System.Windows.Forms.RichTextBox();
            this.rtb_errorMsg = new System.Windows.Forms.RichTextBox();
            this.bt_quitService = new System.Windows.Forms.Button();
            this.bt_threadDispose = new System.Windows.Forms.Button();
            this.cb_isClassify = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pb_img)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tb_question
            // 
            this.tb_question.Location = new System.Drawing.Point(17, 60);
            this.tb_question.Name = "tb_question";
            this.tb_question.Size = new System.Drawing.Size(75, 25);
            this.tb_question.TabIndex = 0;
            // 
            // bt_spider
            // 
            this.bt_spider.Location = new System.Drawing.Point(17, 110);
            this.bt_spider.Name = "bt_spider";
            this.bt_spider.Size = new System.Drawing.Size(75, 23);
            this.bt_spider.TabIndex = 2;
            this.bt_spider.Text = "start";
            this.bt_spider.UseVisualStyleBackColor = true;
            this.bt_spider.Click += new System.EventHandler(this.bt_spider_Click);
            // 
            // lb_msg
            // 
            this.lb_msg.AutoSize = true;
            this.lb_msg.ForeColor = System.Drawing.Color.Red;
            this.lb_msg.Location = new System.Drawing.Point(12, 480);
            this.lb_msg.Name = "lb_msg";
            this.lb_msg.Size = new System.Drawing.Size(55, 15);
            this.lb_msg.TabIndex = 3;
            this.lb_msg.Text = "label2";
            // 
            // pb_img
            // 
            this.pb_img.Location = new System.Drawing.Point(3, 3);
            this.pb_img.Name = "pb_img";
            this.pb_img.Size = new System.Drawing.Size(1086, 102);
            this.pb_img.TabIndex = 4;
            this.pb_img.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.pb_img);
            this.panel1.Location = new System.Drawing.Point(223, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1092, 120);
            this.panel1.TabIndex = 5;
            // 
            // tb_postion
            // 
            this.tb_postion.Location = new System.Drawing.Point(17, 170);
            this.tb_postion.Name = "tb_postion";
            this.tb_postion.Size = new System.Drawing.Size(75, 25);
            this.tb_postion.TabIndex = 6;
            // 
            // bt_postion
            // 
            this.bt_postion.Location = new System.Drawing.Point(17, 218);
            this.bt_postion.Name = "bt_postion";
            this.bt_postion.Size = new System.Drawing.Size(75, 23);
            this.bt_postion.TabIndex = 7;
            this.bt_postion.Text = "postion";
            this.bt_postion.UseVisualStyleBackColor = true;
            this.bt_postion.Click += new System.EventHandler(this.bt_postion_Click);
            // 
            // bt_refreshImg
            // 
            this.bt_refreshImg.Location = new System.Drawing.Point(115, 110);
            this.bt_refreshImg.Name = "bt_refreshImg";
            this.bt_refreshImg.Size = new System.Drawing.Size(75, 23);
            this.bt_refreshImg.TabIndex = 8;
            this.bt_refreshImg.Text = "refreshImg";
            this.bt_refreshImg.UseVisualStyleBackColor = true;
            this.bt_refreshImg.Click += new System.EventHandler(this.bt_refreshImg_Click);
            // 
            // bt_final
            // 
            this.bt_final.Location = new System.Drawing.Point(115, 217);
            this.bt_final.Name = "bt_final";
            this.bt_final.Size = new System.Drawing.Size(75, 23);
            this.bt_final.TabIndex = 9;
            this.bt_final.Text = "final";
            this.bt_final.UseVisualStyleBackColor = true;
            this.bt_final.Click += new System.EventHandler(this.bt_final_Click);
            // 
            // bt_saveCookie
            // 
            this.bt_saveCookie.Location = new System.Drawing.Point(17, 261);
            this.bt_saveCookie.Name = "bt_saveCookie";
            this.bt_saveCookie.Size = new System.Drawing.Size(173, 23);
            this.bt_saveCookie.TabIndex = 10;
            this.bt_saveCookie.Text = "saveCookie";
            this.bt_saveCookie.UseVisualStyleBackColor = true;
            this.bt_saveCookie.Click += new System.EventHandler(this.bt_saveCookie_Click);
            // 
            // tb_userName
            // 
            this.tb_userName.Location = new System.Drawing.Point(17, 13);
            this.tb_userName.Name = "tb_userName";
            this.tb_userName.Size = new System.Drawing.Size(75, 25);
            this.tb_userName.TabIndex = 11;
            // 
            // tb_password
            // 
            this.tb_password.Location = new System.Drawing.Point(115, 12);
            this.tb_password.Name = "tb_password";
            this.tb_password.PasswordChar = '*';
            this.tb_password.Size = new System.Drawing.Size(75, 25);
            this.tb_password.TabIndex = 12;
            // 
            // bt_verification
            // 
            this.bt_verification.Location = new System.Drawing.Point(17, 301);
            this.bt_verification.Name = "bt_verification";
            this.bt_verification.Size = new System.Drawing.Size(173, 23);
            this.bt_verification.TabIndex = 13;
            this.bt_verification.Text = "verification";
            this.bt_verification.UseVisualStyleBackColor = true;
            this.bt_verification.Click += new System.EventHandler(this.bt_verification_Click);
            // 
            // rtb_msg
            // 
            this.rtb_msg.Location = new System.Drawing.Point(223, 139);
            this.rtb_msg.Name = "rtb_msg";
            this.rtb_msg.Size = new System.Drawing.Size(1092, 173);
            this.rtb_msg.TabIndex = 14;
            this.rtb_msg.Text = "";
            // 
            // bt_down
            // 
            this.bt_down.Location = new System.Drawing.Point(17, 386);
            this.bt_down.Name = "bt_down";
            this.bt_down.Size = new System.Drawing.Size(173, 23);
            this.bt_down.TabIndex = 15;
            this.bt_down.Text = "down";
            this.bt_down.UseVisualStyleBackColor = true;
            this.bt_down.Click += new System.EventHandler(this.bt_down_Click);
            // 
            // rtb_getImgUrl
            // 
            this.rtb_getImgUrl.Location = new System.Drawing.Point(223, 318);
            this.rtb_getImgUrl.Name = "rtb_getImgUrl";
            this.rtb_getImgUrl.Size = new System.Drawing.Size(1092, 177);
            this.rtb_getImgUrl.TabIndex = 16;
            this.rtb_getImgUrl.Text = "";
            // 
            // rtb_downImg
            // 
            this.rtb_downImg.Location = new System.Drawing.Point(223, 501);
            this.rtb_downImg.Name = "rtb_downImg";
            this.rtb_downImg.Size = new System.Drawing.Size(1092, 179);
            this.rtb_downImg.TabIndex = 17;
            this.rtb_downImg.Text = "";
            // 
            // rtb_errorMsg
            // 
            this.rtb_errorMsg.Location = new System.Drawing.Point(13, 501);
            this.rtb_errorMsg.Name = "rtb_errorMsg";
            this.rtb_errorMsg.Size = new System.Drawing.Size(177, 179);
            this.rtb_errorMsg.TabIndex = 18;
            this.rtb_errorMsg.Text = "";
            // 
            // bt_quitService
            // 
            this.bt_quitService.Location = new System.Drawing.Point(17, 344);
            this.bt_quitService.Name = "bt_quitService";
            this.bt_quitService.Size = new System.Drawing.Size(173, 23);
            this.bt_quitService.TabIndex = 19;
            this.bt_quitService.Text = "quitService";
            this.bt_quitService.UseVisualStyleBackColor = true;
            this.bt_quitService.Click += new System.EventHandler(this.bt_quitService_Click);
            // 
            // bt_threadDispose
            // 
            this.bt_threadDispose.Location = new System.Drawing.Point(17, 432);
            this.bt_threadDispose.Name = "bt_threadDispose";
            this.bt_threadDispose.Size = new System.Drawing.Size(173, 23);
            this.bt_threadDispose.TabIndex = 20;
            this.bt_threadDispose.Text = "stop";
            this.bt_threadDispose.UseVisualStyleBackColor = true;
            this.bt_threadDispose.Click += new System.EventHandler(this.bt_threadDispose_Click);
            // 
            // cb_isClassify
            // 
            this.cb_isClassify.AutoSize = true;
            this.cb_isClassify.Location = new System.Drawing.Point(115, 65);
            this.cb_isClassify.Name = "cb_isClassify";
            this.cb_isClassify.Size = new System.Drawing.Size(93, 19);
            this.cb_isClassify.TabIndex = 21;
            this.cb_isClassify.Text = "classify";
            this.cb_isClassify.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1327, 718);
            this.Controls.Add(this.cb_isClassify);
            this.Controls.Add(this.bt_threadDispose);
            this.Controls.Add(this.bt_quitService);
            this.Controls.Add(this.rtb_errorMsg);
            this.Controls.Add(this.rtb_downImg);
            this.Controls.Add(this.rtb_getImgUrl);
            this.Controls.Add(this.bt_down);
            this.Controls.Add(this.rtb_msg);
            this.Controls.Add(this.bt_verification);
            this.Controls.Add(this.tb_password);
            this.Controls.Add(this.tb_userName);
            this.Controls.Add(this.bt_saveCookie);
            this.Controls.Add(this.bt_final);
            this.Controls.Add(this.bt_refreshImg);
            this.Controls.Add(this.bt_postion);
            this.Controls.Add(this.tb_postion);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lb_msg);
            this.Controls.Add(this.bt_spider);
            this.Controls.Add(this.tb_question);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1345, 765);
            this.MinimumSize = new System.Drawing.Size(1345, 765);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ZhiHuSpider";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.pb_img)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_question;
        private System.Windows.Forms.Button bt_spider;
        private System.Windows.Forms.Label lb_msg;
        private System.Windows.Forms.PictureBox pb_img;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox tb_postion;
        private System.Windows.Forms.Button bt_postion;
        private System.Windows.Forms.Button bt_refreshImg;
        private System.Windows.Forms.Button bt_final;
        private System.Windows.Forms.Button bt_saveCookie;
        private System.Windows.Forms.TextBox tb_userName;
        private System.Windows.Forms.TextBox tb_password;
        private System.Windows.Forms.Button bt_verification;
        private System.Windows.Forms.RichTextBox rtb_msg;
        private System.Windows.Forms.Button bt_down;
        private System.Windows.Forms.RichTextBox rtb_getImgUrl;
        private System.Windows.Forms.RichTextBox rtb_downImg;
        private System.Windows.Forms.RichTextBox rtb_errorMsg;
        private System.Windows.Forms.Button bt_quitService;
        private System.Windows.Forms.Button bt_threadDispose;
        private System.Windows.Forms.CheckBox cb_isClassify;
    }
}

