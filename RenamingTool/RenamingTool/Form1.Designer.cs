namespace RenamingTool
{
    partial class Form1
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
            this.btn_SelectInputFolder = new System.Windows.Forms.Button();
            this.lb_InputFolderPath = new System.Windows.Forms.Label();
            this.lb_OutputFolderPath = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lb_Progress = new System.Windows.Forms.Label();
            this.btn_Start = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btn_SelectOutputFolder = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.txt_Prefix = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_SelectInputFolder
            // 
            this.btn_SelectInputFolder.Location = new System.Drawing.Point(12, 12);
            this.btn_SelectInputFolder.Name = "btn_SelectInputFolder";
            this.btn_SelectInputFolder.Size = new System.Drawing.Size(144, 21);
            this.btn_SelectInputFolder.TabIndex = 0;
            this.btn_SelectInputFolder.Text = "Select Input Folder";
            this.btn_SelectInputFolder.UseVisualStyleBackColor = true;
            this.btn_SelectInputFolder.Click += new System.EventHandler(this.btn_SelectInputFolder_Click);
            // 
            // lb_InputFolderPath
            // 
            this.lb_InputFolderPath.AutoSize = true;
            this.lb_InputFolderPath.Location = new System.Drawing.Point(162, 16);
            this.lb_InputFolderPath.Name = "lb_InputFolderPath";
            this.lb_InputFolderPath.Size = new System.Drawing.Size(0, 13);
            this.lb_InputFolderPath.TabIndex = 1;
            // 
            // lb_OutputFolderPath
            // 
            this.lb_OutputFolderPath.AutoSize = true;
            this.lb_OutputFolderPath.Location = new System.Drawing.Point(162, 43);
            this.lb_OutputFolderPath.Name = "lb_OutputFolderPath";
            this.lb_OutputFolderPath.Size = new System.Drawing.Size(0, 13);
            this.lb_OutputFolderPath.TabIndex = 1;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 189);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(594, 23);
            this.progressBar1.TabIndex = 2;
            // 
            // lb_Progress
            // 
            this.lb_Progress.AutoSize = true;
            this.lb_Progress.Location = new System.Drawing.Point(12, 173);
            this.lb_Progress.Name = "lb_Progress";
            this.lb_Progress.Size = new System.Drawing.Size(27, 13);
            this.lb_Progress.TabIndex = 1;
            this.lb_Progress.Text = "N/A";
            // 
            // btn_Start
            // 
            this.btn_Start.Location = new System.Drawing.Point(273, 98);
            this.btn_Start.Name = "btn_Start";
            this.btn_Start.Size = new System.Drawing.Size(144, 47);
            this.btn_Start.TabIndex = 3;
            this.btn_Start.Text = "Start";
            this.btn_Start.UseVisualStyleBackColor = true;
            this.btn_Start.Click += new System.EventHandler(this.btn_Start_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(15, 218);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(591, 377);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // btn_SelectOutputFolder
            // 
            this.btn_SelectOutputFolder.Location = new System.Drawing.Point(12, 39);
            this.btn_SelectOutputFolder.Name = "btn_SelectOutputFolder";
            this.btn_SelectOutputFolder.Size = new System.Drawing.Size(144, 21);
            this.btn_SelectOutputFolder.TabIndex = 0;
            this.btn_SelectOutputFolder.Text = "Select Output Folder";
            this.btn_SelectOutputFolder.UseVisualStyleBackColor = true;
            this.btn_SelectOutputFolder.Click += new System.EventHandler(this.Btn_SelectOutputFolder_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(423, 98);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(183, 47);
            this.textBox1.TabIndex = 5;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(12, 82);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(100, 17);
            this.checkBox1.TabIndex = 6;
            this.checkBox1.Text = "Ask Every Time";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(12, 105);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(52, 17);
            this.checkBox2.TabIndex = 7;
            this.checkBox2.Text = "Prefix";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(12, 128);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(71, 17);
            this.checkBox3.TabIndex = 8;
            this.checkBox3.Text = "Add Date";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // txt_Prefix
            // 
            this.txt_Prefix.Location = new System.Drawing.Point(89, 103);
            this.txt_Prefix.Name = "txt_Prefix";
            this.txt_Prefix.Size = new System.Drawing.Size(151, 20);
            this.txt_Prefix.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(618, 607);
            this.Controls.Add(this.txt_Prefix);
            this.Controls.Add(this.checkBox3);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btn_SelectInputFolder);
            this.Controls.Add(this.btn_SelectOutputFolder);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btn_Start);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.lb_Progress);
            this.Controls.Add(this.lb_OutputFolderPath);
            this.Controls.Add(this.lb_InputFolderPath);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Renaming Tool";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_SelectInputFolder;
        private System.Windows.Forms.Label lb_InputFolderPath;
        private System.Windows.Forms.Label lb_OutputFolderPath;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label lb_Progress;
        private System.Windows.Forms.Button btn_Start;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btn_SelectOutputFolder;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.TextBox txt_Prefix;
    }
}

