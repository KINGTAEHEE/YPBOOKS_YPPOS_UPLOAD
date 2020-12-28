namespace YPPOS_UPLOAD
{
    partial class Form1
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
            this.buttonUploadFile = new System.Windows.Forms.Button();
            this.listViewFileList = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonAllCancel = new System.Windows.Forms.Button();
            this.buttonAllSelect = new System.Windows.Forms.Button();
            this.buttonUploadStart = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonUploadFile
            // 
            this.buttonUploadFile.Location = new System.Drawing.Point(12, 11);
            this.buttonUploadFile.Name = "buttonUploadFile";
            this.buttonUploadFile.Size = new System.Drawing.Size(130, 42);
            this.buttonUploadFile.TabIndex = 1;
            this.buttonUploadFile.Text = "업로드 파일 선택";
            this.buttonUploadFile.UseVisualStyleBackColor = true;
            this.buttonUploadFile.Click += new System.EventHandler(this.buttonUploadFile_Click);
            // 
            // listViewFileList
            // 
            this.listViewFileList.FormattingEnabled = true;
            this.listViewFileList.ItemHeight = 12;
            this.listViewFileList.Location = new System.Drawing.Point(148, 12);
            this.listViewFileList.Name = "listViewFileList";
            this.listViewFileList.Size = new System.Drawing.Size(424, 40);
            this.listViewFileList.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonAllCancel);
            this.groupBox1.Controls.Add(this.buttonAllSelect);
            this.groupBox1.Location = new System.Drawing.Point(12, 58);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(559, 415);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "대상 지점";
            // 
            // buttonAllCancel
            // 
            this.buttonAllCancel.Location = new System.Drawing.Point(473, 367);
            this.buttonAllCancel.Name = "buttonAllCancel";
            this.buttonAllCancel.Size = new System.Drawing.Size(80, 40);
            this.buttonAllCancel.TabIndex = 1;
            this.buttonAllCancel.Text = "전체해제";
            this.buttonAllCancel.UseVisualStyleBackColor = true;
            this.buttonAllCancel.Click += new System.EventHandler(this.buttonAllCancel_Click);
            // 
            // buttonAllSelect
            // 
            this.buttonAllSelect.Location = new System.Drawing.Point(387, 367);
            this.buttonAllSelect.Name = "buttonAllSelect";
            this.buttonAllSelect.Size = new System.Drawing.Size(80, 40);
            this.buttonAllSelect.TabIndex = 0;
            this.buttonAllSelect.Text = "전체선택";
            this.buttonAllSelect.UseVisualStyleBackColor = true;
            this.buttonAllSelect.Click += new System.EventHandler(this.buttonAllSelect_Click);
            // 
            // buttonUploadStart
            // 
            this.buttonUploadStart.Location = new System.Drawing.Point(235, 483);
            this.buttonUploadStart.Name = "buttonUploadStart";
            this.buttonUploadStart.Size = new System.Drawing.Size(130, 40);
            this.buttonUploadStart.TabIndex = 4;
            this.buttonUploadStart.Text = "업로드 시작";
            this.buttonUploadStart.UseVisualStyleBackColor = true;
            this.buttonUploadStart.Click += new System.EventHandler(this.buttonUploadStart_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(13, 533);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(558, 16);
            this.progressBar1.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 561);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.buttonUploadStart);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.listViewFileList);
            this.Controls.Add(this.buttonUploadFile);
            this.Name = "Form1";
            this.Text = "YPPOS_UPLOAD";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonUploadFile;
        private System.Windows.Forms.ListBox listViewFileList;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonAllCancel;
        private System.Windows.Forms.Button buttonAllSelect;
        private System.Windows.Forms.Button buttonUploadStart;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}

