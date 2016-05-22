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

namespace Clinic.Inventory
{
    public partial class FrmQuantity : Form
    {
        public enum Operation {ADD, SUBTRACT };
        private FrmInventory frmInventory;
        private string id;
        private IMongoCollection<BsonDocument> collection;
        private FilterDefinition<BsonDocument> filter;
        private BsonDocument result;
        private Operation operation;

        public FrmQuantity(string id, FrmInventory frmInventory,Operation operation)
        {
            InitializeComponent();
            this.frmInventory = frmInventory;
            this.id = id;
            this.operation = operation;
            collection = MainForm.database.GetCollection<BsonDocument>("inventory");
            filter = Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(id));
            result = collection.Find(filter).First();

            txtItem.Text = result["item"].ToString();
            txtQuantity.Text = "0";
            txtQuantity.Focus();
            txtQuantity.SelectionStart = 0;
            txtQuantity.SelectionLength = 1;
            if (operation.Equals(Operation.SUBTRACT))
            {
                btnUpdate.Text = "Subtract";
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int quantity = Int32.Parse(result["quantity"].ToString());
            int value;
            int res = 0;
            UpdateDefinition<BsonDocument> update;

            try {
                value = Int32.Parse(txtQuantity.Text);
            }catch(Exception ex)
            {
                MessageBox.Show("Please enter a valid integer. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            switch (operation)
            {
                case Operation.ADD:
                    res = quantity + value;
                    break;
                case Operation.SUBTRACT:
                    res = quantity - value;
                    break;
            }

            update = Builders<BsonDocument>.Update
                        .Set("quantity", res);
            collection.UpdateOne(filter, update);
            this.Hide();
            frmInventory.loadInventory();
        }
    }
}
