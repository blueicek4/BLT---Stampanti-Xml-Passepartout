namespace Stampanti_Xml_Passepartout
{
    partial class StampantiXml
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.gridStampanti = new System.Windows.Forms.DataGridView();
            this.selectAll = new System.Windows.Forms.CheckBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.openFile = new System.Windows.Forms.Button();
            this.txtOpenFile = new System.Windows.Forms.TextBox();
            this.BtnWrite = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridStampanti)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(1033, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(40, 37);
            this.button1.TabIndex = 0;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(865, 13);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(162, 37);
            this.button2.TabIndex = 1;
            this.button2.Text = "Cerca Stampanti";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // gridStampanti
            // 
            this.gridStampanti.AllowDrop = true;
            this.gridStampanti.AllowUserToAddRows = false;
            this.gridStampanti.AllowUserToDeleteRows = false;
            this.gridStampanti.AllowUserToResizeRows = false;
            this.gridStampanti.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridStampanti.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridStampanti.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridStampanti.Location = new System.Drawing.Point(12, 68);
            this.gridStampanti.Name = "gridStampanti";
            this.gridStampanti.RowHeadersWidth = 62;
            this.gridStampanti.RowTemplate.Height = 31;
            this.gridStampanti.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridStampanti.Size = new System.Drawing.Size(1060, 412);
            this.gridStampanti.TabIndex = 2;
            // 
            // selectAll
            // 
            this.selectAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.selectAll.AutoSize = true;
            this.selectAll.Location = new System.Drawing.Point(12, 486);
            this.selectAll.Name = "selectAll";
            this.selectAll.Size = new System.Drawing.Size(166, 28);
            this.selectAll.TabIndex = 3;
            this.selectAll.Text = "Seleziona Tutte";
            this.selectAll.UseVisualStyleBackColor = true;
            this.selectAll.CheckedChanged += new System.EventHandler(this.SelectAll_CheckedChanged);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // openFile
            // 
            this.openFile.Location = new System.Drawing.Point(12, 13);
            this.openFile.Name = "openFile";
            this.openFile.Size = new System.Drawing.Size(106, 37);
            this.openFile.TabIndex = 4;
            this.openFile.Text = "Apri File";
            this.openFile.UseVisualStyleBackColor = true;
            this.openFile.Click += new System.EventHandler(this.OpenFile_Click);
            // 
            // txtOpenFile
            // 
            this.txtOpenFile.Location = new System.Drawing.Point(124, 16);
            this.txtOpenFile.Name = "txtOpenFile";
            this.txtOpenFile.Size = new System.Drawing.Size(450, 29);
            this.txtOpenFile.TabIndex = 5;
            // 
            // BtnWrite
            // 
            this.BtnWrite.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnWrite.Location = new System.Drawing.Point(827, 520);
            this.BtnWrite.Name = "BtnWrite";
            this.BtnWrite.Size = new System.Drawing.Size(246, 35);
            this.BtnWrite.TabIndex = 6;
            this.BtnWrite.Text = "Aggiorna Selezionate";
            this.BtnWrite.UseVisualStyleBackColor = true;
            this.BtnWrite.Click += new System.EventHandler(this.Button3_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdate.Location = new System.Drawing.Point(575, 520);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(246, 35);
            this.btnUpdate.TabIndex = 7;
            this.btnUpdate.Text = "Aggiorna Stesso Nome";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.BtnUpdate_Click);
            // 
            // StampantiXml
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1085, 567);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.BtnWrite);
            this.Controls.Add(this.txtOpenFile);
            this.Controls.Add(this.openFile);
            this.Controls.Add(this.selectAll);
            this.Controls.Add(this.gridStampanti);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "StampantiXml";
            this.Text = "Gestione Stampanti XML";
            ((System.ComponentModel.ISupportInitialize)(this.gridStampanti)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView gridStampanti;
        private System.Windows.Forms.CheckBox selectAll;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button openFile;
        private System.Windows.Forms.TextBox txtOpenFile;
        private System.Windows.Forms.Button BtnWrite;
        private System.Windows.Forms.Button btnUpdate;
    }
}

