
namespace myCrmSMSWhatsapp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblUser = new System.Windows.Forms.Label();
            this.lbPassword = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.lbMensaje = new System.Windows.Forms.Label();
            this.btnSend = new System.Windows.Forms.Button();
            this.grdMessages = new System.Windows.Forms.DataGridView();
            this.colDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFrom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBody = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colImage = new System.Windows.Forms.DataGridViewImageColumn();
            this.colAck = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.lbFileName = new System.Windows.Forms.Label();
            this.picFile = new System.Windows.Forms.PictureBox();
            this.lbMimeType = new System.Windows.Forms.Label();
            this.btnSearchFile = new System.Windows.Forms.Button();
            this.txtMimeType = new System.Windows.Forms.TextBox();
            this.dgvChats = new System.Windows.Forms.DataGridView();
            this.colContactPhotoProfile = new System.Windows.Forms.DataGridViewImageColumn();
            this.colContactName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUnRead = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnRemoveFile = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grdMessages)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChats)).BeginInit();
            this.SuspendLayout();
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Location = new System.Drawing.Point(23, 21);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(59, 20);
            this.lblUser.TabIndex = 0;
            this.lblUser.Text = "Usuario";
            // 
            // lbPassword
            // 
            this.lbPassword.AutoSize = true;
            this.lbPassword.Location = new System.Drawing.Point(23, 54);
            this.lbPassword.Name = "lbPassword";
            this.lbPassword.Size = new System.Drawing.Size(83, 20);
            this.lbPassword.TabIndex = 1;
            this.lbPassword.Text = "Contraseña";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(112, 21);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(293, 27);
            this.txtUsername.TabIndex = 2;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(112, 54);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(293, 27);
            this.txtPassword.TabIndex = 3;
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(112, 87);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(293, 29);
            this.btnLogin.TabIndex = 4;
            this.btnLogin.Text = "Iniciar sesión";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // txtMessage
            // 
            this.txtMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMessage.Enabled = false;
            this.txtMessage.Location = new System.Drawing.Point(512, 361);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(415, 27);
            this.txtMessage.TabIndex = 8;
            // 
            // lbMensaje
            // 
            this.lbMensaje.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbMensaje.AutoSize = true;
            this.lbMensaje.Location = new System.Drawing.Point(422, 364);
            this.lbMensaje.Name = "lbMensaje";
            this.lbMensaje.Size = new System.Drawing.Size(64, 20);
            this.lbMensaje.TabIndex = 6;
            this.lbMensaje.Text = "Mensaje";
            // 
            // btnSend
            // 
            this.btnSend.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSend.Enabled = false;
            this.btnSend.Location = new System.Drawing.Point(512, 465);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(210, 29);
            this.btnSend.TabIndex = 9;
            this.btnSend.Text = "Enviar mensaje";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // grdMessages
            // 
            this.grdMessages.AllowUserToAddRows = false;
            this.grdMessages.AllowUserToDeleteRows = false;
            this.grdMessages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdMessages.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdMessages.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDate,
            this.colType,
            this.colFrom,
            this.colBody,
            this.colImage,
            this.colAck});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdMessages.DefaultCellStyle = dataGridViewCellStyle1;
            this.grdMessages.Location = new System.Drawing.Point(427, 28);
            this.grdMessages.Name = "grdMessages";
            this.grdMessages.RowHeadersVisible = false;
            this.grdMessages.RowHeadersWidth = 51;
            this.grdMessages.RowTemplate.Height = 100;
            this.grdMessages.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdMessages.Size = new System.Drawing.Size(682, 320);
            this.grdMessages.TabIndex = 10;
            this.grdMessages.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdMessages_CellClick);
            // 
            // colDate
            // 
            this.colDate.DataPropertyName = "DateTime";
            this.colDate.HeaderText = "Fecha";
            this.colDate.MinimumWidth = 6;
            this.colDate.Name = "colDate";
            this.colDate.ReadOnly = true;
            this.colDate.Width = 125;
            // 
            // colType
            // 
            this.colType.DataPropertyName = "type";
            this.colType.HeaderText = "Tipo";
            this.colType.MinimumWidth = 6;
            this.colType.Name = "colType";
            this.colType.ReadOnly = true;
            this.colType.Width = 125;
            // 
            // colFrom
            // 
            this.colFrom.DataPropertyName = "FromString";
            this.colFrom.HeaderText = "Origen";
            this.colFrom.MinimumWidth = 6;
            this.colFrom.Name = "colFrom";
            this.colFrom.ReadOnly = true;
            this.colFrom.Width = 125;
            // 
            // colBody
            // 
            this.colBody.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colBody.DataPropertyName = "body";
            this.colBody.HeaderText = "Mensaje";
            this.colBody.MinimumWidth = 6;
            this.colBody.Name = "colBody";
            this.colBody.ReadOnly = true;
            // 
            // colImage
            // 
            this.colImage.DataPropertyName = "image";
            this.colImage.HeaderText = "Imágen";
            this.colImage.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.colImage.MinimumWidth = 6;
            this.colImage.Name = "colImage";
            this.colImage.ReadOnly = true;
            this.colImage.Width = 125;
            // 
            // colAck
            // 
            this.colAck.DataPropertyName = "AckString";
            this.colAck.HeaderText = "Ack";
            this.colAck.MinimumWidth = 6;
            this.colAck.Name = "colAck";
            this.colAck.ReadOnly = true;
            this.colAck.Width = 125;
            // 
            // txtFileName
            // 
            this.txtFileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFileName.Enabled = false;
            this.txtFileName.Location = new System.Drawing.Point(512, 394);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(347, 27);
            this.txtFileName.TabIndex = 11;
            // 
            // lbFileName
            // 
            this.lbFileName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbFileName.AutoSize = true;
            this.lbFileName.Location = new System.Drawing.Point(423, 401);
            this.lbFileName.Name = "lbFileName";
            this.lbFileName.Size = new System.Drawing.Size(62, 20);
            this.lbFileName.TabIndex = 12;
            this.lbFileName.Text = "Adjunto";
            // 
            // picFile
            // 
            this.picFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.picFile.Location = new System.Drawing.Point(937, 361);
            this.picFile.Name = "picFile";
            this.picFile.Size = new System.Drawing.Size(172, 133);
            this.picFile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picFile.TabIndex = 13;
            this.picFile.TabStop = false;
            // 
            // lbMimeType
            // 
            this.lbMimeType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbMimeType.AutoSize = true;
            this.lbMimeType.Location = new System.Drawing.Point(425, 433);
            this.lbMimeType.Name = "lbMimeType";
            this.lbMimeType.Size = new System.Drawing.Size(78, 20);
            this.lbMimeType.TabIndex = 14;
            this.lbMimeType.Text = "MimeType";
            // 
            // btnSearchFile
            // 
            this.btnSearchFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearchFile.Enabled = false;
            this.btnSearchFile.Location = new System.Drawing.Point(899, 394);
            this.btnSearchFile.Name = "btnSearchFile";
            this.btnSearchFile.Size = new System.Drawing.Size(28, 27);
            this.btnSearchFile.TabIndex = 15;
            this.btnSearchFile.Text = "...";
            this.btnSearchFile.UseVisualStyleBackColor = true;
            this.btnSearchFile.Click += new System.EventHandler(this.btnSearchFile_Click);
            // 
            // txtMimeType
            // 
            this.txtMimeType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMimeType.Enabled = false;
            this.txtMimeType.Location = new System.Drawing.Point(512, 427);
            this.txtMimeType.Name = "txtMimeType";
            this.txtMimeType.Size = new System.Drawing.Size(415, 27);
            this.txtMimeType.TabIndex = 16;
            // 
            // dgvChats
            // 
            this.dgvChats.AllowUserToAddRows = false;
            this.dgvChats.AllowUserToDeleteRows = false;
            this.dgvChats.AllowUserToResizeColumns = false;
            this.dgvChats.AllowUserToResizeRows = false;
            this.dgvChats.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvChats.ColumnHeadersHeight = 150;
            this.dgvChats.ColumnHeadersVisible = false;
            this.dgvChats.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colContactPhotoProfile,
            this.colContactName,
            this.colUnRead});
            this.dgvChats.Location = new System.Drawing.Point(23, 122);
            this.dgvChats.MultiSelect = false;
            this.dgvChats.Name = "dgvChats";
            this.dgvChats.ReadOnly = true;
            this.dgvChats.RowHeadersVisible = false;
            this.dgvChats.RowHeadersWidth = 51;
            this.dgvChats.RowTemplate.Height = 100;
            this.dgvChats.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvChats.Size = new System.Drawing.Size(382, 372);
            this.dgvChats.TabIndex = 17;
            this.dgvChats.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvChats_CellMouseClick);
            // 
            // colContactPhotoProfile
            // 
            this.colContactPhotoProfile.DataPropertyName = "profilePicture";
            this.colContactPhotoProfile.HeaderText = "Foto";
            this.colContactPhotoProfile.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.colContactPhotoProfile.MinimumWidth = 6;
            this.colContactPhotoProfile.Name = "colContactPhotoProfile";
            this.colContactPhotoProfile.ReadOnly = true;
            this.colContactPhotoProfile.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colContactPhotoProfile.Width = 125;
            // 
            // colContactName
            // 
            this.colContactName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colContactName.DataPropertyName = "name";
            this.colContactName.HeaderText = "Nombre del contacto";
            this.colContactName.MinimumWidth = 6;
            this.colContactName.Name = "colContactName";
            this.colContactName.ReadOnly = true;
            // 
            // colUnRead
            // 
            this.colUnRead.DataPropertyName = "unreadCount";
            this.colUnRead.HeaderText = "Sin leer";
            this.colUnRead.MinimumWidth = 6;
            this.colUnRead.Name = "colUnRead";
            this.colUnRead.ReadOnly = true;
            this.colUnRead.Width = 75;
            // 
            // btnRemoveFile
            // 
            this.btnRemoveFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveFile.Enabled = false;
            this.btnRemoveFile.Location = new System.Drawing.Point(867, 394);
            this.btnRemoveFile.Name = "btnRemoveFile";
            this.btnRemoveFile.Size = new System.Drawing.Size(26, 27);
            this.btnRemoveFile.TabIndex = 18;
            this.btnRemoveFile.Text = "X";
            this.btnRemoveFile.UseVisualStyleBackColor = true;
            this.btnRemoveFile.Click += new System.EventHandler(this.btnRemoveFile_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1121, 506);
            this.Controls.Add(this.btnRemoveFile);
            this.Controls.Add(this.dgvChats);
            this.Controls.Add(this.txtMimeType);
            this.Controls.Add(this.btnSearchFile);
            this.Controls.Add(this.lbMimeType);
            this.Controls.Add(this.picFile);
            this.Controls.Add(this.lbFileName);
            this.Controls.Add(this.txtFileName);
            this.Controls.Add(this.grdMessages);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.lbMensaje);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.lbPassword);
            this.Controls.Add(this.lblUser);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdMessages)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChats)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Label lbPassword;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Label lbMensaje;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.DataGridView grdMessages;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.Label lbFileName;
        private System.Windows.Forms.PictureBox picFile;
        private System.Windows.Forms.Label lbMimeType;
        private System.Windows.Forms.Button btnSearchFile;
        private System.Windows.Forms.TextBox txtMimeType;
        private System.Windows.Forms.DataGridView dgvChats;
        private System.Windows.Forms.Button btnRemoveFile;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFrom;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBody;
        private System.Windows.Forms.DataGridViewImageColumn colImage;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAck;
        private System.Windows.Forms.DataGridViewImageColumn colContactPhotoProfile;
        private System.Windows.Forms.DataGridViewTextBoxColumn colContactName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUnRead;
    }
}

