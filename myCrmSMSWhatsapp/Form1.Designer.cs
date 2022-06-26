
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
            this.components = new System.ComponentModel.Container();
            this.lblUser = new System.Windows.Forms.Label();
            this.lbPassword = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.lbMensaje = new System.Windows.Forms.Label();
            this.lbPhone = new System.Windows.Forms.Label();
            this.btnSend = new System.Windows.Forms.Button();
            this.grdMessages = new System.Windows.Forms.DataGridView();
            this.colDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFrom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBody = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colImage = new System.Windows.Forms.DataGridViewImageColumn();
            this.colAck = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsMessages = new System.Windows.Forms.BindingSource(this.components);
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.lbFileName = new System.Windows.Forms.Label();
            this.picFile = new System.Windows.Forms.PictureBox();
            this.lbMimeType = new System.Windows.Forms.Label();
            this.btnSearchFile = new System.Windows.Forms.Button();
            this.txtMimeType = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.grdMessages)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsMessages)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFile)).BeginInit();
            this.SuspendLayout();
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Location = new System.Drawing.Point(84, 32);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(59, 20);
            this.lblUser.TabIndex = 0;
            this.lblUser.Text = "Usuario";
            // 
            // lbPassword
            // 
            this.lbPassword.AutoSize = true;
            this.lbPassword.Location = new System.Drawing.Point(84, 65);
            this.lbPassword.Name = "lbPassword";
            this.lbPassword.Size = new System.Drawing.Size(83, 20);
            this.lbPassword.TabIndex = 1;
            this.lbPassword.Text = "Contraseña";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(173, 32);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(210, 27);
            this.txtUsername.TabIndex = 2;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(173, 65);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(210, 27);
            this.txtPassword.TabIndex = 3;
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(173, 98);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(210, 29);
            this.btnLogin.TabIndex = 4;
            this.btnLogin.Text = "Iniciar sesión";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // txtMessage
            // 
            this.txtMessage.Enabled = false;
            this.txtMessage.Location = new System.Drawing.Point(173, 196);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(210, 27);
            this.txtMessage.TabIndex = 8;
            // 
            // txtPhone
            // 
            this.txtPhone.Enabled = false;
            this.txtPhone.Location = new System.Drawing.Point(173, 163);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(210, 27);
            this.txtPhone.TabIndex = 7;
            // 
            // lbMensaje
            // 
            this.lbMensaje.AutoSize = true;
            this.lbMensaje.Location = new System.Drawing.Point(84, 196);
            this.lbMensaje.Name = "lbMensaje";
            this.lbMensaje.Size = new System.Drawing.Size(64, 20);
            this.lbMensaje.TabIndex = 6;
            this.lbMensaje.Text = "Mensaje";
            // 
            // lbPhone
            // 
            this.lbPhone.AutoSize = true;
            this.lbPhone.Location = new System.Drawing.Point(84, 163);
            this.lbPhone.Name = "lbPhone";
            this.lbPhone.Size = new System.Drawing.Size(67, 20);
            this.lbPhone.TabIndex = 5;
            this.lbPhone.Text = "Teléfono";
            // 
            // btnSend
            // 
            this.btnSend.Enabled = false;
            this.btnSend.Location = new System.Drawing.Point(173, 433);
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
            this.colFrom,
            this.colBody,
            this.colImage,
            this.colAck});
            this.grdMessages.Location = new System.Drawing.Point(427, 28);
            this.grdMessages.Name = "grdMessages";
            this.grdMessages.RowHeadersWidth = 51;
            this.grdMessages.RowTemplate.Height = 100;
            this.grdMessages.Size = new System.Drawing.Size(682, 434);
            this.grdMessages.TabIndex = 10;
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
            this.colImage.HeaderText = "image";
            this.colImage.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
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
            this.txtFileName.Enabled = false;
            this.txtFileName.Location = new System.Drawing.Point(173, 229);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(165, 27);
            this.txtFileName.TabIndex = 11;
            this.txtFileName.Text = "C:\\Users\\elhum\\OneDrive\\Imágenes\\SMSWhatSApp.png";
            // 
            // lbFileName
            // 
            this.lbFileName.AutoSize = true;
            this.lbFileName.Location = new System.Drawing.Point(84, 236);
            this.lbFileName.Name = "lbFileName";
            this.lbFileName.Size = new System.Drawing.Size(62, 20);
            this.lbFileName.TabIndex = 12;
            this.lbFileName.Text = "Adjunto";
            // 
            // picFile
            // 
            this.picFile.Location = new System.Drawing.Point(173, 295);
            this.picFile.Name = "picFile";
            this.picFile.Size = new System.Drawing.Size(210, 121);
            this.picFile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picFile.TabIndex = 13;
            this.picFile.TabStop = false;
            // 
            // lbMimeType
            // 
            this.lbMimeType.AutoSize = true;
            this.lbMimeType.Location = new System.Drawing.Point(86, 268);
            this.lbMimeType.Name = "lbMimeType";
            this.lbMimeType.Size = new System.Drawing.Size(78, 20);
            this.lbMimeType.TabIndex = 14;
            this.lbMimeType.Text = "MimeType";
            // 
            // btnSearchFile
            // 
            this.btnSearchFile.Location = new System.Drawing.Point(345, 229);
            this.btnSearchFile.Name = "btnSearchFile";
            this.btnSearchFile.Size = new System.Drawing.Size(38, 27);
            this.btnSearchFile.TabIndex = 15;
            this.btnSearchFile.Text = "...";
            this.btnSearchFile.UseVisualStyleBackColor = true;
            this.btnSearchFile.Click += new System.EventHandler(this.btnSearchFile_Click);
            // 
            // txtMimeType
            // 
            this.txtMimeType.Enabled = false;
            this.txtMimeType.Location = new System.Drawing.Point(173, 262);
            this.txtMimeType.Name = "txtMimeType";
            this.txtMimeType.Size = new System.Drawing.Size(210, 27);
            this.txtMimeType.TabIndex = 16;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1121, 474);
            this.Controls.Add(this.txtMimeType);
            this.Controls.Add(this.btnSearchFile);
            this.Controls.Add(this.lbMimeType);
            this.Controls.Add(this.picFile);
            this.Controls.Add(this.lbFileName);
            this.Controls.Add(this.txtFileName);
            this.Controls.Add(this.grdMessages);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.lbMensaje);
            this.Controls.Add(this.lbPhone);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.lbPassword);
            this.Controls.Add(this.lblUser);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdMessages)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsMessages)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFile)).EndInit();
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
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label lbMensaje;
        private System.Windows.Forms.Label lbPhone;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.DataGridView grdMessages;
        private System.Windows.Forms.BindingSource bsMessages;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFrom;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBody;
        private System.Windows.Forms.DataGridViewImageColumn colImage;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAck;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.Label lbFileName;
        private System.Windows.Forms.PictureBox picFile;
        private System.Windows.Forms.Label lbMimeType;
        private System.Windows.Forms.Button btnSearchFile;
        private System.Windows.Forms.TextBox txtMimeType;
    }
}

