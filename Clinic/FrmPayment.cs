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
    public partial class FrmPayment : Form
    {
        private string id;
        private IMongoCollection<BsonDocument> collection;
        private BsonArray bills;

        public FrmPayment(string id)
        {
            InitializeComponent();
            this.id = id;
            collection = MainForm.database.GetCollection<BsonDocument>("patients");
            fillBillList();
        }
        
        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to delete this record?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            string bid = dvBill.SelectedRows[0].Cells[2].Value.ToString();

            var filter = Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(id));
            var update = Builders<BsonDocument>.Update.Pull("bills", new BsonDocument{{ "_id", ObjectId.Parse(bid)} });

            collection.UpdateOne(filter, update);
            fillBillList();
        }

        public void fillBillList()
        {
            var filter = Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(id));
            var result = collection.Find(filter).First();

            dvBill.Rows.Clear();
            try {
                bills = result["bills"].AsBsonArray;


                for (int i = 0; i < bills.Count; i++)
                {
                    int x = dvBill.Rows.Add();
                    dvBill[0, x].Value = bills[i]["date"];
                    dvBill[2, x].Value = bills[i]["_id"];
                    //dtBill[0, x].Value = bills["name"];
                }
            }catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }

        private void dvBill_SelectionChanged(object sender, EventArgs e)
        {
            dvItems.Rows.Clear();
            var bill = bills[0];
            try
            {
                bill = bills[dvBill.SelectedRows[0].Index];
            }
            catch (Exception ex)
            {
                bill = bills[0];
            }
            var items = bill["items"].AsBsonArray;
            Console.WriteLine(items);

            for(int i = 0; i < items.Count; i++)
            {
                int x = dvItems.Rows.Add();
                dvItems[0, x].Value = items[i]["name"];
                dvItems[1, x].Value = items[i]["amount"];
            }

            lblTotal.Text = string.Format("{0:n}", bill["total"]);
            try
            {
                lblChange.Text = bill["change"].ToString();
                txtAmountPaid.Text = bill["paid"].ToString();
            }catch(System.Collections.Generic.KeyNotFoundException ex)
            {
                Console.WriteLine(ex.ToString());
                lblChange.Text = "";
                txtAmountPaid.Text = "";
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            new FrmAddBill(id, this).ShowDialog();
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            double total = Convert.ToDouble(lblTotal.Text);
            double paid;
            try
            {
                paid = Convert.ToDouble(txtAmountPaid.Text);
            }catch(System.FormatException ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show("Please enter a valid value", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            double change = paid - total;
            lblChange.Text = string.Format("{0:n}", change);
            txtAmountPaid.Text = string.Format("{0:n}", Convert.ToDouble(txtAmountPaid.Text));

            ObjectId id = ObjectId.Parse(dvBill.SelectedRows[0].Cells[2].Value.ToString());
            FilterDefinition<BsonDocument> filter = Builders<BsonDocument>.Filter.Eq("bills._id", id);
            UpdateDefinition<BsonDocument> update = Builders<BsonDocument>.Update
                .Set("bills.$.paid", txtAmountPaid.Text)
                .Set("bills.$.change", lblChange.Text);

            collection.UpdateOne(filter, update);

            int selectedRowIndex = dvBill.SelectedRows[0].Index;
            fillBillList();
            dvBill.ClearSelection();
            dvBill.Rows[selectedRowIndex].Selected = true;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            ObjectId id = ObjectId.Parse(dvBill.SelectedRows[0].Cells[2].Value.ToString());
            FilterDefinition<BsonDocument> filter = Builders<BsonDocument>.Filter.Eq("bills._id", id);
            BsonDocument r = collection.Find(filter).First();
            int selectedIndex = dvBill.SelectedRows[0].Index;

            DataSet1 ds = new DataSet1();
            DataRow row;
            var items = r["bills"][selectedIndex]["items"].AsBsonArray;

            row = ds.dtReceipt.NewRow();
            row["patient_name"] = string.Format("{0} {1} {2}", r["firstname"].ToString(),
                r["middlename"].ToString(), r["lastname"].ToString());
            try
            {
                row["address"] = r["address"];
            }catch(System.Collections.Generic.KeyNotFoundException ex)
            {
                Console.WriteLine(ex.ToString());
            }

            ds.dtReceipt.Rows.Add(row);

            foreach (var item in items)
            {
                row = ds.dtReceipt.NewRow();
                row["item"] = item["name"];
                row["amount"] = item["amount"];
                ds.dtReceipt.Rows.Add(row);
            }

            row = ds.dtReceipt.NewRow();
            row["total"] = r["bills"][selectedIndex]["total"];
            try
            {
                row["amount_paid"] = r["bills"][selectedIndex]["paid"];
                row["change"] = r["bills"][selectedIndex]["change"];
            }catch(System.Collections.Generic.KeyNotFoundException ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show("Unpaid");
                return;
            }
            ds.dtReceipt.Rows.Add(row);

            new Print.FrmPrintForm(ds, new Print.PrintReceipt()).ShowDialog();
        }
    }
}
