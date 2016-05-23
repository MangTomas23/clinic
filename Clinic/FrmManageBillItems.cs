using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MongoDB.Driver;
using MongoDB.Bson;

namespace Clinic
{
    public partial class FrmManageBillItems : Form
    {
        private IMongoCollection<BsonDocument> collection;
        private Boolean editMode;
        private FrmAddBill frmAddBill;

        public FrmManageBillItems(FrmAddBill frmAddBill)
        {
            InitializeComponent();
            collection = MainForm.database.GetCollection<BsonDocument>("bill_items");
            this.frmAddBill = frmAddBill;
            loadItems();
        }

        private void loadItems()
        {
            dgv.Rows.Clear();

            var result = collection.Find(new BsonDocument()).ToList();

            int i;
            foreach (var r in result)
            {
                i = dgv.Rows.Add();
                dgv[0, i].Value = r["_id"];
                dgv[1, i].Value = r["item"];
                dgv[2, i].Value = r["amount"];
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            txtItem.ReadOnly = false;
            txtAmount.ReadOnly = false;
            txtItem.Focus();
            btnSave.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtItem.Text.Trim() == "" || txtAmount.Text.Trim() == "")
            {
                MessageBox.Show("Please fill up all the fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!editMode)
            {
                var document = new BsonDocument
                {
                    {"item", txtItem.Text },
                    {"amount", string.Format("{0:n}", Convert.ToDouble(txtAmount.Text)) }
                };

                collection.InsertOne(document);
            }
            else
            {
                ObjectId id = ObjectId.Parse(dgv.SelectedRows[0].Cells[0].Value.ToString());
                FilterDefinition<BsonDocument> filter = Builders<BsonDocument>.Filter.Eq("_id", id);
                UpdateDefinition<BsonDocument> update = Builders<BsonDocument>.Update
                    .Set("item", txtItem.Text)
                    .Set("amount", string.Format("{0:n}", Convert.ToDouble(txtAmount.Text)));

                collection.UpdateOne(filter, update);
                editMode = false;
            }

            txtItem.Text = "";
            txtAmount.Text = "";
            txtItem.ReadOnly = true;
            txtAmount.ReadOnly = true;
            btnSave.Enabled = false;
            loadItems();
            frmAddBill.loadItems();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult confirmation = MessageBox.Show("Are you sure you want to delete this item?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(confirmation.Equals(DialogResult.No))
            {
                return;
            }

            ObjectId id = ObjectId.Parse(dgv.SelectedRows[0].Cells[0].Value.ToString());
            FilterDefinition<BsonDocument> filter = Builders<BsonDocument>.Filter.Eq("_id", id);
            collection.DeleteOne(filter);
            loadItems();
            frmAddBill.loadItems();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            txtItem.ReadOnly = false;
            txtAmount.ReadOnly = false;
            txtItem.Text = dgv.SelectedRows[0].Cells[1].Value.ToString();
            txtAmount.Text = dgv.SelectedRows[0].Cells[2].Value.ToString();
            txtItem.Focus();
            btnSave.Enabled = true;
            editMode = true;
        }
    }
}
