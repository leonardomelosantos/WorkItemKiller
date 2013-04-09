namespace WorkItemKiller
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            this.lblUrlTFS = new System.Windows.Forms.Label();
            this.txtUrlTFS = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.lblUserName = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.toolTipWindow = new System.Windows.Forms.ToolTip(this.components);
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.txtWitadminPath = new System.Windows.Forms.TextBox();
            this.lblWitAdminPath = new System.Windows.Forms.Label();
            this.btnOpenFileDialog = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.rbtnEndsWithDelete = new System.Windows.Forms.RadioButton();
            this.rbtnStartsWithDelete = new System.Windows.Forms.RadioButton();
            this.rbtnContainsDelete = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // lblUrlTFS
            // 
            this.lblUrlTFS.AutoSize = true;
            this.lblUrlTFS.Location = new System.Drawing.Point(12, 19);
            this.lblUrlTFS.Name = "lblUrlTFS";
            this.lblUrlTFS.Size = new System.Drawing.Size(92, 13);
            this.lblUrlTFS.TabIndex = 0;
            this.lblUrlTFS.Text = "Server/Collection:";
            // 
            // txtUrlTFS
            // 
            this.txtUrlTFS.Location = new System.Drawing.Point(110, 16);
            this.txtUrlTFS.MaxLength = 500;
            this.txtUrlTFS.Name = "txtUrlTFS";
            this.txtUrlTFS.Size = new System.Drawing.Size(288, 20);
            this.txtUrlTFS.TabIndex = 1;
            this.txtUrlTFS.Text = "http://server:8080/tfs/MyCollection";
            this.toolTipWindow.SetToolTip(this.txtUrlTFS, "Sample: http://server:8080/tfs/MyCollection");
            this.txtUrlTFS.WordWrap = false;
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(110, 42);
            this.txtUserName.MaxLength = 80;
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(121, 20);
            this.txtUserName.TabIndex = 3;
            this.txtUserName.Text = "domain\\username";
            this.txtUserName.WordWrap = false;
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(12, 45);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(58, 13);
            this.lblUserName.TabIndex = 2;
            this.lblUserName.Text = "Username:";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(110, 68);
            this.txtPassword.MaxLength = 80;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(121, 20);
            this.txtPassword.TabIndex = 5;
            this.txtPassword.WordWrap = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Password:";
            // 
            // txtWitadminPath
            // 
            this.txtWitadminPath.Location = new System.Drawing.Point(110, 94);
            this.txtWitadminPath.MaxLength = 500;
            this.txtWitadminPath.Name = "txtWitadminPath";
            this.txtWitadminPath.ReadOnly = true;
            this.txtWitadminPath.Size = new System.Drawing.Size(288, 20);
            this.txtWitadminPath.TabIndex = 7;
            this.txtWitadminPath.Text = "C:\\Program Files (x86)\\Microsoft Visual Studio 10.0\\Common7\\IDE\\witadmin.exe";
            this.toolTipWindow.SetToolTip(this.txtWitadminPath, "Path of \"Work Item Tracking Administration Tool\"\r\n\r\nSample: C:\\Program Files (x86" +
        ")\\Microsoft Visual Studio 10.0\\Common7\\IDE\\witadmin.exe");
            this.txtWitadminPath.WordWrap = false;
            // 
            // lblWitAdminPath
            // 
            this.lblWitAdminPath.AutoSize = true;
            this.lblWitAdminPath.Location = new System.Drawing.Point(12, 97);
            this.lblWitAdminPath.Name = "lblWitAdminPath";
            this.lblWitAdminPath.Size = new System.Drawing.Size(98, 13);
            this.lblWitAdminPath.TabIndex = 6;
            this.lblWitAdminPath.Text = "Witadmin.exe path:";
            // 
            // btnOpenFileDialog
            // 
            this.btnOpenFileDialog.Location = new System.Drawing.Point(404, 91);
            this.btnOpenFileDialog.Name = "btnOpenFileDialog";
            this.btnOpenFileDialog.Size = new System.Drawing.Size(27, 23);
            this.btnOpenFileDialog.TabIndex = 8;
            this.btnOpenFileDialog.Text = "...";
            this.btnOpenFileDialog.UseVisualStyleBackColor = true;
            this.btnOpenFileDialog.Click += new System.EventHandler(this.btnOpenFileDialog_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(174, 208);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(101, 23);
            this.btnStart.TabIndex = 9;
            this.btnStart.Text = "&Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 124);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Work items that:";
            // 
            // rbtnEndsWithDelete
            // 
            this.rbtnEndsWithDelete.AutoSize = true;
            this.rbtnEndsWithDelete.Location = new System.Drawing.Point(110, 170);
            this.rbtnEndsWithDelete.Name = "rbtnEndsWithDelete";
            this.rbtnEndsWithDelete.Size = new System.Drawing.Size(154, 17);
            this.rbtnEndsWithDelete.TabIndex = 11;
            this.rbtnEndsWithDelete.Text = "Title ends with \"[DELETE]\"";
            this.rbtnEndsWithDelete.UseVisualStyleBackColor = true;
            // 
            // rbtnStartsWithDelete
            // 
            this.rbtnStartsWithDelete.AutoSize = true;
            this.rbtnStartsWithDelete.Checked = true;
            this.rbtnStartsWithDelete.Location = new System.Drawing.Point(110, 124);
            this.rbtnStartsWithDelete.Name = "rbtnStartsWithDelete";
            this.rbtnStartsWithDelete.Size = new System.Drawing.Size(156, 17);
            this.rbtnStartsWithDelete.TabIndex = 12;
            this.rbtnStartsWithDelete.TabStop = true;
            this.rbtnStartsWithDelete.Text = "Title starts with \"[DELETE]\"";
            this.rbtnStartsWithDelete.UseVisualStyleBackColor = true;
            // 
            // rbtnContainsDelete
            // 
            this.rbtnContainsDelete.AutoSize = true;
            this.rbtnContainsDelete.Location = new System.Drawing.Point(110, 147);
            this.rbtnContainsDelete.Name = "rbtnContainsDelete";
            this.rbtnContainsDelete.Size = new System.Drawing.Size(149, 17);
            this.rbtnContainsDelete.TabIndex = 13;
            this.rbtnContainsDelete.Text = "Title contains \"[DELETE]\"";
            this.rbtnContainsDelete.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(438, 243);
            this.Controls.Add(this.rbtnContainsDelete);
            this.Controls.Add(this.rbtnStartsWithDelete);
            this.Controls.Add(this.rbtnEndsWithDelete);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnOpenFileDialog);
            this.Controls.Add(this.txtWitadminPath);
            this.Controls.Add(this.lblWitAdminPath);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.txtUrlTFS);
            this.Controls.Add(this.lblUrlTFS);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Work Item Killer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblUrlTFS;
        private System.Windows.Forms.TextBox txtUrlTFS;
        private System.Windows.Forms.ToolTip toolTipWindow;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.TextBox txtWitadminPath;
        private System.Windows.Forms.Label lblWitAdminPath;
        private System.Windows.Forms.Button btnOpenFileDialog;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rbtnEndsWithDelete;
        private System.Windows.Forms.RadioButton rbtnStartsWithDelete;
        private System.Windows.Forms.RadioButton rbtnContainsDelete;
    }
}