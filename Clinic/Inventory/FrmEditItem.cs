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
    public partial class FrmEditItem : Form
    {
        private string id;
        private IMongoCollection<BsonDocument> collection;
        private FilterDefinition<BsonDocument> filter;
        private FrmInventory frmInventory;
        
        public FrmEditItem(string id, FrmInventory frmInventory)
        {
            InitializeComponent();
            this.id = id;
            this.frmInventory = frmInventory;

            collection = MainForm.database.GetCollection<BsonDocument>("inventory");
            filter = Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(id));

            var result = collection.Find(filter).First();

            txtItem.Text = result["item"].ToString();
            txtQuantity.Text = result["quantity"].ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if(txtQuantity.Text.Trim() == "" || txtQuantity.Text.Trim() == "")
            {
                MessageBox.Show("Please fill up all the fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try {
                Int32.Parse(txtQuantity.Text);
            }catch(System.FormatException ex)
            {
                Console.WriteLine(ex);
                MessageBox.Show("Please enter a valid integer", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtQuantity.Focus();
                txtQuantity.SelectAll();
                return;
            }
            var update = Builders<BsonDocument>.Update
                .Set("item", txtItem.Text)
                .Set("quantity", txtQuantity.Text);

            collection.UpdateOne(filter, update);
            frmInventory.loadInventory();
            this.Hide();
        }
    }
}
