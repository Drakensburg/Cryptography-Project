
namespace Encryptor
{
    partial class frmCryptor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCryptor));
            this.btnExit = new System.Windows.Forms.Button();
            this.btndecrypt = new System.Windows.Forms.Button();
            this.btnEncrypt = new System.Windows.Forms.Button();
            this.btnSelect = new System.Windows.Forms.Button();
            this.tbFPath = new System.Windows.Forms.TextBox();
            this.rtbDataView = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(854, 654);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(109, 50);
            this.btnExit.TabIndex = 0;
            this.btnExit.Text = "EXIT";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btndecrypt
            // 
            this.btndecrypt.Location = new System.Drawing.Point(656, 654);
            this.btndecrypt.Name = "btndecrypt";
            this.btndecrypt.Size = new System.Drawing.Size(192, 50);
            this.btndecrypt.TabIndex = 1;
            this.btndecrypt.Text = "DECRYPT";
            this.btndecrypt.UseVisualStyleBackColor = true;
            // 
            // btnEncrypt
            // 
            this.btnEncrypt.Location = new System.Drawing.Point(457, 654);
            this.btnEncrypt.Name = "btnEncrypt";
            this.btnEncrypt.Size = new System.Drawing.Size(192, 50);
            this.btnEncrypt.TabIndex = 2;
            this.btnEncrypt.Text = "ENCRYPT";
            this.btnEncrypt.UseVisualStyleBackColor = true;
            // 
            // btnSelect
            // 
            this.btnSelect.BackColor = System.Drawing.SystemColors.Control;
            this.btnSelect.Location = new System.Drawing.Point(13, 13);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(146, 50);
            this.btnSelect.TabIndex = 3;
            this.btnSelect.Text = "SELECT FILE";
            this.btnSelect.UseVisualStyleBackColor = false;
            // 
            // tbFPath
            // 
            this.tbFPath.Location = new System.Drawing.Point(179, 24);
            this.tbFPath.Name = "tbFPath";
            this.tbFPath.Size = new System.Drawing.Size(784, 29);
            this.tbFPath.TabIndex = 4;
            // 
            // rtbDataView
            // 
            this.rtbDataView.Location = new System.Drawing.Point(13, 84);
            this.rtbDataView.Name = "rtbDataView";
            this.rtbDataView.Size = new System.Drawing.Size(950, 550);
            this.rtbDataView.TabIndex = 5;
            this.rtbDataView.Text = "";
            // 
            // frmCryptor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(978, 717);
            this.Controls.Add(this.rtbDataView);
            this.Controls.Add(this.tbFPath);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.btnEncrypt);
            this.Controls.Add(this.btndecrypt);
            this.Controls.Add(this.btnExit);
            this.Font = new System.Drawing.Font("Microsoft YaHei", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCryptor";
            this.Text = "CRYPTOR";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btndecrypt;
        private System.Windows.Forms.Button btnEncrypt;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.TextBox tbFPath;
        private System.Windows.Forms.RichTextBox rtbDataView;
    }
}

