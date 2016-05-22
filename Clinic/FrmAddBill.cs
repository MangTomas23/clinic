using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MongoDB.Bson;
using MongoDB.Driver;


namespace Clinic
{
    public partial class FrmAddBill : Form
    {
        private string id;
        private FrmPayment frmPayment;
        public FrmAddBill(string id, FrmPayment frmPayment)
        {
            InitializeComponent();
            this.id = id;
            this.frmPayment = frmPayment;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            double amount = 0;
            try {
                amount = Convert.ToDouble(txtAmount.Text);
            }catch(System.FormatException ex)
            {
                Console.Write(ex.ToString());
                MessageBox.Show("Invalid Value", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtAmount.Focus();
                return;
            }

            int i = dv1.Rows.Add();
            dv1[1, i].Value = amount;
            dv1[0, i].Value = cbItem.Text;

            cbItem.Focus();
            cbItem.Text = "";
            txtAmount.Text = "";

            computeTotal();
        }

        private void computeTotal()
        {
            double total = 0;
            foreach(DataGridViewRow x in dv1.Rows)
            {
                total += Convert.ToDouble(x.Cells[1].Value);
            }

            txtTotal.Text = string.Format("{0:n}", total);
        }

        private void dv1_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            computeTotal();
        }

        private void dv1_CellStateChanged(object sender, DataGridViewCellStateChangedEventArgs e)
        {
            computeTotal();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            DataSet1 ds = new DataSet1();
            DataRow row;

            foreach (DataGridViewRow x in dv1.Rows)
            {
                row = ds.dtBill.NewRow();
                row["items"] = x.Cells[0].Value;
                row["amount"] = string.Format("{0:n}", x.Cells[1].Value);
                ds.dtBill.Rows.Add(row);
            }

            row = ds.dtBill.NewRow();
            row["total"] = txtTotal.Text;
            ds.dtBill.Rows.Add(row);

            new Print.FrmPrintForm(ds, new Print.Bill()).ShowDialog();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var collection = MainForm.database.GetCollection<BsonDocument>("patients");
            var filter = Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(id));

            BsonArray items = new BsonArray();
            
            for(int x = 0; x < dv1.Rows.Count -1; x++)
            {
                items.Add(new BsonDocument {
                    {"name", dv1.Rows[x].Cells[0].Value.ToString()},
                    {"amount", Convert.ToDouble(dv1.Rows[x].Cells[1].Value)}
                });
            }

            var document = new BsonDocument
            {
                {"_id", ObjectId.GenerateNewId()},
                {"date", dtpDate.Value},
                {"items", items},
                {"total", txtTotal.Text},
            };

            var update = Builders<BsonDocument>.Update.AddToSet("bills", document);
            collection.UpdateOne(filter, update);

            MessageBox.Show("Record saved successfully.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Hide();
            frmPayment.fillBillList();
        }

        private void btnManage_Click(object sender, EventArgs e)
        {
            new FrmManageBillItems().ShowDialog();
        }
    }
}
