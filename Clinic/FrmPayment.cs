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

        private void button1_Click(object sender, EventArgs e)
        {
            new FrmAddBill(id, this).ShowDialog();
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
            try {
                bill = bills[dvBill.SelectedRows[0].Index];
            }catch(Exception ex)
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

        }
    }
}
