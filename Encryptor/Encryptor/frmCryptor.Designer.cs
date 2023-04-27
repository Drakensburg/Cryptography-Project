
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
            this.gbMethods = new System.Windows.Forms.GroupBox();
            this.cbViganere = new System.Windows.Forms.CheckBox();
            this.cbVernom = new System.Windows.Forms.CheckBox();
            this.cbTransposition = new System.Windows.Forms.CheckBox();
            this.cbUnique = new System.Windows.Forms.CheckBox();
            this.btnConstraints = new System.Windows.Forms.Button();
            this.gbConstraints = new System.Windows.Forms.GroupBox();
            this.tbKey = new System.Windows.Forms.TextBox();
            this.lblKey = new System.Windows.Forms.Label();
            this.lblTransposition = new System.Windows.Forms.Label();
            this.sbColumn = new System.Windows.Forms.HScrollBar();
            this.sbRow = new System.Windows.Forms.HScrollBar();
            this.lblColumn = new System.Windows.Forms.Label();
            this.lblRow = new System.Windows.Forms.Label();
            this.gbMethods.SuspendLayout();
            this.gbConstraints.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(711, 598);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(252, 50);
            this.btnExit.TabIndex = 0;
            this.btnExit.Text = "EXIT";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btndecrypt
            // 
            this.btndecrypt.Location = new System.Drawing.Point(711, 542);
            this.btndecrypt.Name = "btndecrypt";
            this.btndecrypt.Size = new System.Drawing.Size(252, 50);
            this.btndecrypt.TabIndex = 1;
            this.btndecrypt.Text = "DECRYPT";
            this.btndecrypt.UseVisualStyleBackColor = true;
            // 
            // btnEncrypt
            // 
            this.btnEncrypt.Location = new System.Drawing.Point(711, 486);
            this.btnEncrypt.Name = "btnEncrypt";
            this.btnEncrypt.Size = new System.Drawing.Size(252, 50);
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
            this.rtbDataView.Location = new System.Drawing.Point(13, 69);
            this.rtbDataView.Name = "rtbDataView";
            this.rtbDataView.Size = new System.Drawing.Size(692, 579);
            this.rtbDataView.TabIndex = 5;
            this.rtbDataView.Text = "";
            // 
            // gbMethods
            // 
            this.gbMethods.Controls.Add(this.cbUnique);
            this.gbMethods.Controls.Add(this.cbTransposition);
            this.gbMethods.Controls.Add(this.cbVernom);
            this.gbMethods.Controls.Add(this.cbViganere);
            this.gbMethods.Location = new System.Drawing.Point(711, 69);
            this.gbMethods.Name = "gbMethods";
            this.gbMethods.Size = new System.Drawing.Size(252, 159);
            this.gbMethods.TabIndex = 6;
            this.gbMethods.TabStop = false;
            this.gbMethods.Text = "METHODS";
            // 
            // cbViganere
            // 
            this.cbViganere.AutoSize = true;
            this.cbViganere.Location = new System.Drawing.Point(6, 59);
            this.cbViganere.Name = "cbViganere";
            this.cbViganere.Size = new System.Drawing.Size(116, 25);
            this.cbViganere.TabIndex = 0;
            this.cbViganere.Text = "VIGANERE";
            this.cbViganere.UseVisualStyleBackColor = true;
            // 
            // cbVernom
            // 
            this.cbVernom.AutoSize = true;
            this.cbVernom.Location = new System.Drawing.Point(6, 90);
            this.cbVernom.Name = "cbVernom";
            this.cbVernom.Size = new System.Drawing.Size(108, 25);
            this.cbVernom.TabIndex = 1;
            this.cbVernom.Text = "VERNOM";
            this.cbVernom.UseVisualStyleBackColor = true;
            // 
            // cbTransposition
            // 
            this.cbTransposition.AutoSize = true;
            this.cbTransposition.Location = new System.Drawing.Point(6, 28);
            this.cbTransposition.Name = "cbTransposition";
            this.cbTransposition.Size = new System.Drawing.Size(165, 25);
            this.cbTransposition.TabIndex = 2;
            this.cbTransposition.Text = "TRANSPOSITION";
            this.cbTransposition.UseVisualStyleBackColor = true;
            // 
            // cbUnique
            // 
            this.cbUnique.AutoSize = true;
            this.cbUnique.Location = new System.Drawing.Point(6, 121);
            this.cbUnique.Name = "cbUnique";
            this.cbUnique.Size = new System.Drawing.Size(100, 25);
            this.cbUnique.TabIndex = 3;
            this.cbUnique.Text = "UNIQUE";
            this.cbUnique.UseVisualStyleBackColor = true;
            // 
            // btnConstraints
            // 
            this.btnConstraints.Location = new System.Drawing.Point(6, 190);
            this.btnConstraints.Name = "btnConstraints";
            this.btnConstraints.Size = new System.Drawing.Size(240, 50);
            this.btnConstraints.TabIndex = 7;
            this.btnConstraints.Text = "SET CONSTRAINTS";
            this.btnConstraints.UseVisualStyleBackColor = true;
            // 
            // gbConstraints
            // 
            this.gbConstraints.Controls.Add(this.lblRow);
            this.gbConstraints.Controls.Add(this.lblColumn);
            this.gbConstraints.Controls.Add(this.sbRow);
            this.gbConstraints.Controls.Add(this.sbColumn);
            this.gbConstraints.Controls.Add(this.lblTransposition);
            this.gbConstraints.Controls.Add(this.lblKey);
            this.gbConstraints.Controls.Add(this.tbKey);
            this.gbConstraints.Controls.Add(this.btnConstraints);
            this.gbConstraints.Location = new System.Drawing.Point(711, 234);
            this.gbConstraints.Name = "gbConstraints";
            this.gbConstraints.Size = new System.Drawing.Size(252, 246);
            this.gbConstraints.TabIndex = 8;
            this.gbConstraints.TabStop = false;
            this.gbConstraints.Text = "CONSTRAINTS";
            // 
            // tbKey
            // 
            this.tbKey.Location = new System.Drawing.Point(6, 49);
            this.tbKey.Name = "tbKey";
            this.tbKey.Size = new System.Drawing.Size(240, 29);
            this.tbKey.TabIndex = 8;
            this.tbKey.Text = "EncryptionKey";
            // 
            // lblKey
            // 
            this.lblKey.AutoSize = true;
            this.lblKey.Location = new System.Drawing.Point(6, 25);
            this.lblKey.Name = "lblKey";
            this.lblKey.Size = new System.Drawing.Size(39, 21);
            this.lblKey.TabIndex = 9;
            this.lblKey.Text = "KEY";
            // 
            // lblTransposition
            // 
            this.lblTransposition.AutoSize = true;
            this.lblTransposition.Location = new System.Drawing.Point(6, 95);
            this.lblTransposition.Name = "lblTransposition";
            this.lblTransposition.Size = new System.Drawing.Size(165, 21);
            this.lblTransposition.TabIndex = 10;
            this.lblTransposition.Text = "Transpositional Shift";
            // 
            // sbColumn
            // 
            this.sbColumn.Location = new System.Drawing.Point(10, 116);
            this.sbColumn.Minimum = 1;
            this.sbColumn.Name = "sbColumn";
            this.sbColumn.Size = new System.Drawing.Size(161, 26);
            this.sbColumn.TabIndex = 11;
            this.sbColumn.Value = 1;
            // 
            // sbRow
            // 
            this.sbRow.Location = new System.Drawing.Point(10, 152);
            this.sbRow.Minimum = 1;
            this.sbRow.Name = "sbRow";
            this.sbRow.Size = new System.Drawing.Size(161, 26);
            this.sbRow.TabIndex = 12;
            this.sbRow.Value = 1;
            // 
            // lblColumn
            // 
            this.lblColumn.AutoSize = true;
            this.lblColumn.Location = new System.Drawing.Point(174, 121);
            this.lblColumn.Name = "lblColumn";
            this.lblColumn.Size = new System.Drawing.Size(39, 21);
            this.lblColumn.TabIndex = 13;
            this.lblColumn.Text = "C: 1";
            // 
            // lblRow
            // 
            this.lblRow.AutoSize = true;
            this.lblRow.Location = new System.Drawing.Point(174, 157);
            this.lblRow.Name = "lblRow";
            this.lblRow.Size = new System.Drawing.Size(38, 21);
            this.lblRow.TabIndex = 14;
            this.lblRow.Text = "R: 1";
            // 
            // frmCryptor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(977, 665);
            this.Controls.Add(this.gbConstraints);
            this.Controls.Add(this.gbMethods);
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
            this.gbMethods.ResumeLayout(false);
            this.gbMethods.PerformLayout();
            this.gbConstraints.ResumeLayout(false);
            this.gbConstraints.PerformLayout();
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
        private System.Windows.Forms.GroupBox gbMethods;
        private System.Windows.Forms.CheckBox cbUnique;
        private System.Windows.Forms.CheckBox cbTransposition;
        private System.Windows.Forms.CheckBox cbVernom;
        private System.Windows.Forms.CheckBox cbViganere;
        private System.Windows.Forms.Button btnConstraints;
        private System.Windows.Forms.GroupBox gbConstraints;
        private System.Windows.Forms.Label lblRow;
        private System.Windows.Forms.Label lblColumn;
        private System.Windows.Forms.HScrollBar sbRow;
        private System.Windows.Forms.HScrollBar sbColumn;
        private System.Windows.Forms.Label lblTransposition;
        private System.Windows.Forms.Label lblKey;
        private System.Windows.Forms.TextBox tbKey;
    }
}

