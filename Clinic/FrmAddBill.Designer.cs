namespace Clinic
{
    partial class FrmAddBill
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dv1 = new System.Windows.Forms.DataGridView();
            this.colItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.btnManage = new DevExpress.XtraEditors.SimpleButton();
            this.txtAmount = new DevExpress.XtraEditors.TextEdit();
            this.cbItem = new DevExpress.XtraEditors.ComboBoxEdit();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.btnPrint = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.dv1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAmount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbItem.Properties)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtpDate
            // 
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDate.Location = new System.Drawing.Point(583, 16);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(153, 20);
            this.dtpDate.TabIndex = 100;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(552, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Date";
            // 
            // dv1
            // 
            this.dv1.AllowUserToAddRows = false;
            this.dv1.AllowUserToDeleteRows = false;
            this.dv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dv1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colItem,
            this.colAmount});
            this.dv1.Location = new System.Drawing.Point(12, 42);
            this.dv1.Name = "dv1";
            this.dv1.RowHeadersVisible = false;
            this.dv1.Size = new System.Drawing.Size(724, 201);
            this.dv1.TabIndex = 2;
            this.dv1.CellStateChanged += new System.Windows.Forms.DataGridViewCellStateChangedEventHandler(this.dv1_CellStateChanged);
            this.dv1.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.dv1_RowStateChanged);
            // 
            // colItem
            // 
            dataGridViewCellStyle7.NullValue = null;
            this.colItem.DefaultCellStyle = dataGridViewCellStyle7;
            this.colItem.HeaderText = "Item";
            this.colItem.Name = "colItem";
            this.colItem.Width = 540;
            // 
            // colAmount
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "N2";
            dataGridViewCellStyle8.NullValue = null;
            this.colAmount.DefaultCellStyle = dataGridViewCellStyle8;
            this.colAmount.HeaderText = "Amount";
            this.colAmount.Name = "colAmount";
            this.colAmount.Width = 180;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Item";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(479, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Amount";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(515, 252);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Total:";
            // 
            // txtTotal
            // 
            this.txtTotal.Location = new System.Drawing.Point(555, 249);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtTotal.Size = new System.Drawing.Size(181, 20);
            this.txtTotal.TabIndex = 6;
            // 
            // btnManage
            // 
            this.btnManage.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnManage.Location = new System.Drawing.Point(12, 12);
            this.btnManage.Name = "btnManage";
            this.btnManage.Size = new System.Drawing.Size(144, 23);
            this.btnManage.TabIndex = 101;
            this.btnManage.Text = "Manage Items && Amount";
            this.btnManage.Click += new System.EventHandler(this.btnManage_Click);
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(481, 37);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(173, 20);
            this.txtAmount.TabIndex = 2;
            // 
            // cbItem
            // 
            this.cbItem.Location = new System.Drawing.Point(9, 37);
            this.cbItem.Name = "cbItem";
            this.cbItem.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbItem.Size = new System.Drawing.Size(461, 20);
            this.cbItem.TabIndex = 1;
            this.cbItem.EditValueChanged += new System.EventHandler(this.cbItem_EditValueChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cbItem);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtAmount);
            this.groupBox1.Location = new System.Drawing.Point(12, 272);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(724, 68);
            this.groupBox1.TabIndex = 102;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Add to list";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(261, 346);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(110, 23);
            this.btnCancel.TabIndex = 103;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSave.Location = new System.Drawing.Point(377, 346);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(110, 23);
            this.btnSave.TabIndex = 103;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAdd.Location = new System.Drawing.Point(660, 35);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(58, 23);
            this.btnAdd.TabIndex = 103;
            this.btnAdd.Text = "Add";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnPrint.Location = new System.Drawing.Point(162, 12);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(110, 23);
            this.btnPrint.TabIndex = 103;
            this.btnPrint.Text = "Print";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // FrmAddBill
            // 
            this.AcceptButton = this.btnAdd;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(748, 383);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnManage);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.dv1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpDate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmAddBill";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FrmAddBill";
            ((System.ComponentModel.ISupportInitialize)(this.dv1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAmount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbItem.Properties)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dv1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTotal;
        private DevExpress.XtraEditors.SimpleButton btnManage;
        private DevExpress.XtraEditors.TextEdit txtAmount;
        private DevExpress.XtraEditors.ComboBoxEdit cbItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn colItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAmount;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnPrint;
    }
}