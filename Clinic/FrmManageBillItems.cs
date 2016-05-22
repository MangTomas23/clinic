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

        public FrmManageBillItems()
        {
            InitializeComponent();
            collection = MainForm.database.GetCollection<BsonDocument>("bill_items");
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            txtItem.ReadOnly = false;
            txtAmount.ReadOnly = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var document = new BsonDocument
            {
                {"item", txtItem.Text },
                {"amount", txtAmount.Text }
            };

            collection.InsertOne(document);
        }
    }
}
