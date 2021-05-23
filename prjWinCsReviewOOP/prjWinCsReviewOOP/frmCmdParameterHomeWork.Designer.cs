namespace prjWinCsReviewOOP
{
    partial class frmCmdParameterHomeWork
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
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkGender = new System.Windows.Forms.CheckBox();
            this.chkAverage = new System.Windows.Forms.CheckBox();
            this.cboGender = new System.Windows.Forms.ComboBox();
            this.cboAverage = new System.Windows.Forms.ComboBox();
            this.btnFindAllStudents = new System.Windows.Forms.Button();
            this.gridReader = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridReader)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(200, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(395, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "THE PARAMETER OBJECT OF THE COMMAND\r\n";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cboAverage);
            this.groupBox1.Controls.Add(this.cboGender);
            this.groupBox1.Controls.Add(this.chkAverage);
            this.groupBox1.Controls.Add(this.chkGender);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(44, 84);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(389, 105);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "SEARCH CRITERIA FOR STUDENTS";
            // 
            // chkGender
            // 
            this.chkGender.AutoSize = true;
            this.chkGender.Location = new System.Drawing.Point(15, 32);
            this.chkGender.Name = "chkGender";
            this.chkGender.Size = new System.Drawing.Size(92, 19);
            this.chkGender.TabIndex = 0;
            this.chkGender.Text = "By Gender";
            this.chkGender.UseVisualStyleBackColor = true;
            // 
            // chkAverage
            // 
            this.chkAverage.AutoSize = true;
            this.chkAverage.Location = new System.Drawing.Point(15, 68);
            this.chkAverage.Name = "chkAverage";
            this.chkAverage.Size = new System.Drawing.Size(152, 19);
            this.chkAverage.TabIndex = 1;
            this.chkAverage.Text = "By Minimal Average";
            this.chkAverage.UseVisualStyleBackColor = true;
            // 
            // cboGender
            // 
            this.cboGender.FormattingEnabled = true;
            this.cboGender.Location = new System.Drawing.Point(181, 29);
            this.cboGender.Name = "cboGender";
            this.cboGender.Size = new System.Drawing.Size(121, 23);
            this.cboGender.TabIndex = 2;
            // 
            // cboAverage
            // 
            this.cboAverage.FormattingEnabled = true;
            this.cboAverage.Location = new System.Drawing.Point(181, 68);
            this.cboAverage.Name = "cboAverage";
            this.cboAverage.Size = new System.Drawing.Size(121, 23);
            this.cboAverage.TabIndex = 3;
            // 
            // btnFindAllStudents
            // 
            this.btnFindAllStudents.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFindAllStudents.Location = new System.Drawing.Point(463, 118);
            this.btnFindAllStudents.Name = "btnFindAllStudents";
            this.btnFindAllStudents.Size = new System.Drawing.Size(169, 57);
            this.btnFindAllStudents.TabIndex = 2;
            this.btnFindAllStudents.Text = "FIND ALL STUDENTS";
            this.btnFindAllStudents.UseVisualStyleBackColor = true;
            this.btnFindAllStudents.Click += new System.EventHandler(this.btnFindAllStudents_Click);
            // 
            // gridReader
            // 
            this.gridReader.AllowUserToAddRows = false;
            this.gridReader.AllowUserToDeleteRows = false;
            this.gridReader.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridReader.Location = new System.Drawing.Point(44, 228);
            this.gridReader.Name = "gridReader";
            this.gridReader.ReadOnly = true;
            this.gridReader.Size = new System.Drawing.Size(588, 210);
            this.gridReader.TabIndex = 3;
            // 
            // frmCmdParameterHomeWork
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(690, 450);
            this.Controls.Add(this.gridReader);
            this.Controls.Add(this.btnFindAllStudents);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Name = "frmCmdParameterHomeWork";
            this.Text = "frmCmdParameterHomeWork";
            this.Load += new System.EventHandler(this.frmCmdParameterHomeWork_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridReader)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cboAverage;
        private System.Windows.Forms.ComboBox cboGender;
        private System.Windows.Forms.CheckBox chkAverage;
        private System.Windows.Forms.CheckBox chkGender;
        private System.Windows.Forms.Button btnFindAllStudents;
        private System.Windows.Forms.DataGridView gridReader;
    }
}