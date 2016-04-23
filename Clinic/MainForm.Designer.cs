namespace Clinic
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFirstname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMiddlename = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLastname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblFullname = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ribbon1 = new System.Windows.Forms.Ribbon();
            this.rbtnLogout = new System.Windows.Forms.RibbonButton();
            this.ribbonSeparator1 = new System.Windows.Forms.RibbonSeparator();
            this.rbtnExit = new System.Windows.Forms.RibbonButton();
            this.ribbonTab1 = new System.Windows.Forms.RibbonTab();
            this.ribbonPanel1 = new System.Windows.Forms.RibbonPanel();
            this.rbtnNew = new System.Windows.Forms.RibbonButton();
            this.rbtnEdit = new System.Windows.Forms.RibbonButton();
            this.rbtnDelete = new System.Windows.Forms.RibbonButton();
            this.ribbonSeparator3 = new System.Windows.Forms.RibbonSeparator();
            this.ribbonLabel1 = new System.Windows.Forms.RibbonLabel();
            this.rtxtSearch = new System.Windows.Forms.RibbonTextBox();
            this.ribbonPanel2 = new System.Windows.Forms.RibbonPanel();
            this.rbtnPrintDataSheet = new System.Windows.Forms.RibbonButton();
            this.rbtnHistory = new System.Windows.Forms.RibbonButton();
            this.rbtnReferral = new System.Windows.Forms.RibbonButton();
            this.rbtnConsent = new System.Windows.Forms.RibbonButton();
            this.rbtnPayment = new System.Windows.Forms.RibbonButton();
            this.ribbonTab2 = new System.Windows.Forms.RibbonTab();
            this.ribbonPanel3 = new System.Windows.Forms.RibbonPanel();
            this.rbtnBackup = new System.Windows.Forms.RibbonButton();
            this.ribbonSeparator2 = new System.Windows.Forms.RibbonSeparator();
            this.rbtnRestore = new System.Windows.Forms.RibbonButton();
            this.ribbonPanel4 = new System.Windows.Forms.RibbonPanel();
            this.rbtnProfile = new System.Windows.Forms.RibbonButton();
            this.rbtnChangePassword = new System.Windows.Forms.RibbonButton();
            this.ribbonPanel5 = new System.Windows.Forms.RibbonPanel();
            this.rbtnSystemUsers = new System.Windows.Forms.RibbonButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtSearch);
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Location = new System.Drawing.Point(10, 197);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(633, 328);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Patients";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(334, 287);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Search";
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(381, 280);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(246, 26);
            this.txtSearch.TabIndex = 2;
            this.txtSearch.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtSearch_keyup);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colFirstname,
            this.colMiddlename,
            this.colLastname,
            this.colAddress});
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView1.Location = new System.Drawing.Point(6, 21);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(621, 252);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_RowEnter);
            // 
            // colId
            // 
            this.colId.HeaderText = "Id";
            this.colId.Name = "colId";
            this.colId.Visible = false;
            // 
            // colFirstname
            // 
            this.colFirstname.HeaderText = "First Name";
            this.colFirstname.Name = "colFirstname";
            // 
            // colMiddlename
            // 
            this.colMiddlename.HeaderText = "Middle Name";
            this.colMiddlename.Name = "colMiddlename";
            // 
            // colLastname
            // 
            this.colLastname.HeaderText = "Last Name";
            this.colLastname.Name = "colLastname";
            // 
            // colAddress
            // 
            this.colAddress.HeaderText = "Address";
            this.colAddress.Name = "colAddress";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.lblAddress);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.lblFullname);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(12, 524);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(935, 110);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Patient\'s Information";
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddress.Location = new System.Drawing.Point(74, 53);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(68, 16);
            this.lblAddress.TabIndex = 6;
            this.lblAddress.Text = "               ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Address:";
            // 
            // lblFullname
            // 
            this.lblFullname.AutoSize = true;
            this.lblFullname.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFullname.Location = new System.Drawing.Point(60, 27);
            this.lblFullname.Name = "lblFullname";
            this.lblFullname.Size = new System.Drawing.Size(53, 16);
            this.lblFullname.TabIndex = 6;
            this.lblFullname.Text = "Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Name:";
            // 
            // ribbon1
            // 
            this.ribbon1.BackColor = System.Drawing.SystemColors.Window;
            this.ribbon1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ribbon1.Location = new System.Drawing.Point(0, 0);
            this.ribbon1.Minimized = false;
            this.ribbon1.Name = "ribbon1";
            // 
            // 
            // 
            this.ribbon1.OrbDropDown.BorderRoundness = 8;
            this.ribbon1.OrbDropDown.Location = new System.Drawing.Point(0, 0);
            this.ribbon1.OrbDropDown.MenuItems.Add(this.rbtnLogout);
            this.ribbon1.OrbDropDown.MenuItems.Add(this.ribbonSeparator1);
            this.ribbon1.OrbDropDown.MenuItems.Add(this.rbtnExit);
            this.ribbon1.OrbDropDown.Name = "";
            this.ribbon1.OrbDropDown.Size = new System.Drawing.Size(527, 163);
            this.ribbon1.OrbDropDown.TabIndex = 0;
            this.ribbon1.OrbImage = null;
            this.ribbon1.OrbStyle = System.Windows.Forms.RibbonOrbStyle.Office_2013;
            this.ribbon1.OrbText = "File";
            this.ribbon1.RibbonTabFont = new System.Drawing.Font("Trebuchet MS", 9F);
            this.ribbon1.Size = new System.Drawing.Size(959, 161);
            this.ribbon1.TabIndex = 7;
            this.ribbon1.Tabs.Add(this.ribbonTab1);
            this.ribbon1.Tabs.Add(this.ribbonTab2);
            this.ribbon1.TabsMargin = new System.Windows.Forms.Padding(12, 26, 20, 0);
            this.ribbon1.Text = "ribbon1";
            this.ribbon1.ThemeColor = System.Windows.Forms.RibbonTheme.Blue;
            // 
            // rbtnLogout
            // 
            this.rbtnLogout.Image = ((System.Drawing.Image)(resources.GetObject("rbtnLogout.Image")));
            this.rbtnLogout.SmallImage = global::Clinic.Properties.Resources.logout_icon_42404;
            this.rbtnLogout.Text = "Logout";
            // 
            // rbtnExit
            // 
            this.rbtnExit.AltKey = "x";
            this.rbtnExit.Image = ((System.Drawing.Image)(resources.GetObject("rbtnExit.Image")));
            this.rbtnExit.SmallImage = global::Clinic.Properties.Resources.Action_exit_icon;
            this.rbtnExit.Text = "Exit";
            // 
            // ribbonTab1
            // 
            this.ribbonTab1.Panels.Add(this.ribbonPanel1);
            this.ribbonTab1.Panels.Add(this.ribbonPanel2);
            this.ribbonTab1.Text = "Patient";
            // 
            // ribbonPanel1
            // 
            this.ribbonPanel1.Items.Add(this.rbtnNew);
            this.ribbonPanel1.Items.Add(this.rbtnEdit);
            this.ribbonPanel1.Items.Add(this.rbtnDelete);
            this.ribbonPanel1.Items.Add(this.ribbonSeparator3);
            this.ribbonPanel1.Items.Add(this.ribbonLabel1);
            this.ribbonPanel1.Items.Add(this.rtxtSearch);
            this.ribbonPanel1.Text = "Options";
            // 
            // rbtnNew
            // 
            this.rbtnNew.Image = global::Clinic.Properties.Resources.user_male_add;
            this.rbtnNew.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbtnNew.SmallImage")));
            this.rbtnNew.Text = "New";
            this.rbtnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // rbtnEdit
            // 
            this.rbtnEdit.Image = global::Clinic.Properties.Resources.user_male_edit_icon;
            this.rbtnEdit.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbtnEdit.SmallImage")));
            this.rbtnEdit.Text = "Edit";
            this.rbtnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // rbtnDelete
            // 
            this.rbtnDelete.Image = global::Clinic.Properties.Resources.user_male_remove;
            this.rbtnDelete.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbtnDelete.SmallImage")));
            this.rbtnDelete.Text = "Delete";
            this.rbtnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // ribbonLabel1
            // 
            this.ribbonLabel1.Text = "Search Patient:";
            // 
            // rtxtSearch
            // 
            this.rtxtSearch.Text = "";
            this.rtxtSearch.TextBoxText = "";
            this.rtxtSearch.TextBoxWidth = 180;
            // 
            // ribbonPanel2
            // 
            this.ribbonPanel2.Items.Add(this.rbtnPrintDataSheet);
            this.ribbonPanel2.Items.Add(this.rbtnHistory);
            this.ribbonPanel2.Items.Add(this.rbtnReferral);
            this.ribbonPanel2.Items.Add(this.rbtnConsent);
            this.ribbonPanel2.Items.Add(this.rbtnPayment);
            this.ribbonPanel2.Text = "Tasks";
            // 
            // rbtnPrintDataSheet
            // 
            this.rbtnPrintDataSheet.Image = global::Clinic.Properties.Resources.application_vnd_openxmlformats_officedocument_spreadsheetml1;
            this.rbtnPrintDataSheet.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbtnPrintDataSheet.SmallImage")));
            this.rbtnPrintDataSheet.Text = "Print Patient\'s Data Sheet";
            this.rbtnPrintDataSheet.Click += new System.EventHandler(this.btnPrintDataSheet_Click);
            // 
            // rbtnHistory
            // 
            this.rbtnHistory.Image = global::Clinic.Properties.Resources.application_vnd_openxmlformats_officedocument_spreadsheetml1;
            this.rbtnHistory.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbtnHistory.SmallImage")));
            this.rbtnHistory.Text = "History Record";
            this.rbtnHistory.Click += new System.EventHandler(this.btnHistory_Click);
            // 
            // rbtnReferral
            // 
            this.rbtnReferral.Image = global::Clinic.Properties.Resources.application_vnd_openxmlformats_officedocument_spreadsheetml1;
            this.rbtnReferral.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbtnReferral.SmallImage")));
            this.rbtnReferral.Text = "Referral Sheet";
            this.rbtnReferral.Click += new System.EventHandler(this.btnReferralSheet_Click);
            // 
            // rbtnConsent
            // 
            this.rbtnConsent.Image = global::Clinic.Properties.Resources.application_vnd_openxmlformats_officedocument_spreadsheetml1;
            this.rbtnConsent.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbtnConsent.SmallImage")));
            this.rbtnConsent.Text = "Consent for Admission";
            this.rbtnConsent.Click += new System.EventHandler(this.btnConsent_Click);
            // 
            // rbtnPayment
            // 
            this.rbtnPayment.Image = global::Clinic.Properties.Resources.application_vnd_openxmlformats_officedocument_spreadsheetml1;
            this.rbtnPayment.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbtnPayment.SmallImage")));
            this.rbtnPayment.Text = "Payment";
            this.rbtnPayment.Click += new System.EventHandler(this.btnPayment_Click);
            // 
            // ribbonTab2
            // 
            this.ribbonTab2.Panels.Add(this.ribbonPanel3);
            this.ribbonTab2.Panels.Add(this.ribbonPanel4);
            this.ribbonTab2.Panels.Add(this.ribbonPanel5);
            this.ribbonTab2.Text = "Settings";
            // 
            // ribbonPanel3
            // 
            this.ribbonPanel3.Items.Add(this.rbtnBackup);
            this.ribbonPanel3.Items.Add(this.ribbonSeparator2);
            this.ribbonPanel3.Items.Add(this.rbtnRestore);
            this.ribbonPanel3.Text = "Database";
            // 
            // rbtnBackup
            // 
            this.rbtnBackup.Image = global::Clinic.Properties.Resources._1049257;
            this.rbtnBackup.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbtnBackup.SmallImage")));
            this.rbtnBackup.Text = "Backup";
            // 
            // rbtnRestore
            // 
            this.rbtnRestore.Image = global::Clinic.Properties.Resources.upload_database;
            this.rbtnRestore.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbtnRestore.SmallImage")));
            this.rbtnRestore.Text = "Restore";
            // 
            // ribbonPanel4
            // 
            this.ribbonPanel4.Items.Add(this.rbtnProfile);
            this.ribbonPanel4.Items.Add(this.rbtnChangePassword);
            this.ribbonPanel4.Text = "User";
            // 
            // rbtnProfile
            // 
            this.rbtnProfile.Image = global::Clinic.Properties.Resources.profileL;
            this.rbtnProfile.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbtnProfile.SmallImage")));
            this.rbtnProfile.Text = "Profile";
            // 
            // rbtnChangePassword
            // 
            this.rbtnChangePassword.Image = global::Clinic.Properties.Resources.login_logo;
            this.rbtnChangePassword.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbtnChangePassword.SmallImage")));
            this.rbtnChangePassword.Text = "Change Password";
            // 
            // ribbonPanel5
            // 
            this.ribbonPanel5.Items.Add(this.rbtnSystemUsers);
            this.ribbonPanel5.Text = "System Users";
            // 
            // rbtnSystemUsers
            // 
            this.rbtnSystemUsers.Image = global::Clinic.Properties.Resources.IC3697551;
            this.rbtnSystemUsers.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbtnSystemUsers.SmallImage")));
            this.rbtnSystemUsers.Text = "Manage";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = global::Clinic.Properties.Resources.clinic_logo_29223444;
            this.pictureBox1.Location = new System.Drawing.Point(651, 203);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(279, 271);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(959, 674);
            this.Controls.Add(this.ribbon1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFirstname;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMiddlename;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLastname;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAddress;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblFullname;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Ribbon ribbon1;
        private System.Windows.Forms.RibbonTab ribbonTab1;
        private System.Windows.Forms.RibbonPanel ribbonPanel1;
        private System.Windows.Forms.RibbonButton rbtnNew;
        private System.Windows.Forms.RibbonTab ribbonTab2;
        private System.Windows.Forms.RibbonButton rbtnEdit;
        private System.Windows.Forms.RibbonButton rbtnDelete;
        private System.Windows.Forms.RibbonPanel ribbonPanel2;
        private System.Windows.Forms.RibbonSeparator ribbonSeparator1;
        private System.Windows.Forms.RibbonButton rbtnExit;
        private System.Windows.Forms.RibbonPanel ribbonPanel3;
        private System.Windows.Forms.RibbonButton rbtnBackup;
        private System.Windows.Forms.RibbonSeparator ribbonSeparator2;
        private System.Windows.Forms.RibbonButton rbtnRestore;
        private System.Windows.Forms.RibbonSeparator ribbonSeparator3;
        private System.Windows.Forms.RibbonLabel ribbonLabel1;
        private System.Windows.Forms.RibbonTextBox rtxtSearch;
        private System.Windows.Forms.RibbonButton rbtnPrintDataSheet;
        private System.Windows.Forms.RibbonButton rbtnHistory;
        private System.Windows.Forms.RibbonButton rbtnReferral;
        private System.Windows.Forms.RibbonButton rbtnConsent;
        private System.Windows.Forms.RibbonButton rbtnPayment;
        private System.Windows.Forms.RibbonPanel ribbonPanel4;
        private System.Windows.Forms.RibbonButton rbtnProfile;
        private System.Windows.Forms.RibbonButton rbtnChangePassword;
        private System.Windows.Forms.RibbonPanel ribbonPanel5;
        private System.Windows.Forms.RibbonButton rbtnSystemUsers;
        private System.Windows.Forms.RibbonButton rbtnLogout;
    }
}