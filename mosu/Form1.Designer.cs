namespace mosu
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnIncreaseOut = new System.Windows.Forms.Button();
            this.btnDecreaseOut = new System.Windows.Forms.Button();
            this.btnIncreaseIn1 = new System.Windows.Forms.Button();
            this.btnDecreaseIn1 = new System.Windows.Forms.Button();
            this.btnMode = new System.Windows.Forms.Button();
            this.lblMode = new System.Windows.Forms.Label();
            this.btnGauss = new System.Windows.Forms.Button();
            this.lblGauss = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, -5);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1069, 561);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btnIncreaseOut
            // 
            this.btnIncreaseOut.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnIncreaseOut.Location = new System.Drawing.Point(702, 513);
            this.btnIncreaseOut.Margin = new System.Windows.Forms.Padding(4);
            this.btnIncreaseOut.Name = "btnIncreaseOut";
            this.btnIncreaseOut.Size = new System.Drawing.Size(43, 28);
            this.btnIncreaseOut.TabIndex = 1;
            this.btnIncreaseOut.Text = "+";
            this.btnIncreaseOut.UseVisualStyleBackColor = false;
            this.btnIncreaseOut.Click += new System.EventHandler(this.btnIncreaseOut_Click);
            // 
            // btnDecreaseOut
            // 
            this.btnDecreaseOut.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnDecreaseOut.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnDecreaseOut.Location = new System.Drawing.Point(617, 513);
            this.btnDecreaseOut.Margin = new System.Windows.Forms.Padding(4);
            this.btnDecreaseOut.Name = "btnDecreaseOut";
            this.btnDecreaseOut.Size = new System.Drawing.Size(40, 28);
            this.btnDecreaseOut.TabIndex = 2;
            this.btnDecreaseOut.Text = "-";
            this.btnDecreaseOut.UseVisualStyleBackColor = false;
            this.btnDecreaseOut.Click += new System.EventHandler(this.btnDecreaseOut_Click);
            // 
            // btnIncreaseIn1
            // 
            this.btnIncreaseIn1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnIncreaseIn1.Location = new System.Drawing.Point(351, 13);
            this.btnIncreaseIn1.Margin = new System.Windows.Forms.Padding(4);
            this.btnIncreaseIn1.Name = "btnIncreaseIn1";
            this.btnIncreaseIn1.Size = new System.Drawing.Size(41, 28);
            this.btnIncreaseIn1.TabIndex = 5;
            this.btnIncreaseIn1.Text = "+";
            this.btnIncreaseIn1.UseVisualStyleBackColor = false;
            this.btnIncreaseIn1.Click += new System.EventHandler(this.btnIncreaseIn1_Click);
            // 
            // btnDecreaseIn1
            // 
            this.btnDecreaseIn1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnDecreaseIn1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnDecreaseIn1.Location = new System.Drawing.Point(274, 13);
            this.btnDecreaseIn1.Margin = new System.Windows.Forms.Padding(4);
            this.btnDecreaseIn1.Name = "btnDecreaseIn1";
            this.btnDecreaseIn1.Size = new System.Drawing.Size(40, 28);
            this.btnDecreaseIn1.TabIndex = 6;
            this.btnDecreaseIn1.Text = "-";
            this.btnDecreaseIn1.UseVisualStyleBackColor = false;
            this.btnDecreaseIn1.Click += new System.EventHandler(this.btnDecreaseIn1_Click);
            // 
            // btnMode
            // 
            this.btnMode.Location = new System.Drawing.Point(768, 55);
            this.btnMode.Name = "btnMode";
            this.btnMode.Size = new System.Drawing.Size(75, 23);
            this.btnMode.TabIndex = 7;
            this.btnMode.Text = "Mode";
            this.btnMode.UseVisualStyleBackColor = true;
            this.btnMode.Click += new System.EventHandler(this.btnMode_Click);
            // 
            // lblMode
            // 
            this.lblMode.AutoSize = true;
            this.lblMode.Location = new System.Drawing.Point(849, 58);
            this.lblMode.Name = "lblMode";
            this.lblMode.Size = new System.Drawing.Size(105, 16);
            this.lblMode.TabIndex = 8;
            this.lblMode.Text = "Режим: Ручний";
            // 
            // btnGauss
            // 
            this.btnGauss.Location = new System.Drawing.Point(768, 119);
            this.btnGauss.Name = "btnGauss";
            this.btnGauss.Size = new System.Drawing.Size(75, 23);
            this.btnGauss.TabIndex = 9;
            this.btnGauss.Text = "Optimize";
            this.btnGauss.UseVisualStyleBackColor = true;
            this.btnGauss.Click += new System.EventHandler(this.btnGauss_Click);
            // 
            // lblGauss
            // 
            this.lblGauss.AutoSize = true;
            this.lblGauss.Location = new System.Drawing.Point(849, 122);
            this.lblGauss.Name = "lblGauss";
            this.lblGauss.Size = new System.Drawing.Size(0, 16);
            this.lblGauss.TabIndex = 10;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.lblGauss);
            this.Controls.Add(this.btnGauss);
            this.Controls.Add(this.lblMode);
            this.Controls.Add(this.btnMode);
            this.Controls.Add(this.btnDecreaseIn1);
            this.Controls.Add(this.btnIncreaseIn1);
            this.Controls.Add(this.btnDecreaseOut);
            this.Controls.Add(this.btnIncreaseOut);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnIncreaseOut;
        private System.Windows.Forms.Button btnDecreaseOut;
        private System.Windows.Forms.Button btnIncreaseIn1;
        private System.Windows.Forms.Button btnDecreaseIn1;
        private System.Windows.Forms.Button btnMode;
        private System.Windows.Forms.Label lblMode;
        private System.Windows.Forms.Button btnGauss;
        private System.Windows.Forms.Label lblGauss;
    }
}

