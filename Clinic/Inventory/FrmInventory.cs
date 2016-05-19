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
    public partial class FrmInventory : Form
    {
        private IMongoCollection<BsonDocument> collection;

        public FrmInventory()
        {
            InitializeComponent();
            collection = MainForm.database.GetCollection<BsonDocument>("inventory");

            loadInventory();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            new FrmAddItem().ShowDialog();
        }

        private void loadInventory()
        {
            dgv.Rows.Clear();

            var result = collection.Find(new BsonDocument()).ToList();

            int i;
            foreach(var r in result)
            {
                i = dgv.Rows.Add();
                dgv[0, i].Value = r["_id"];
                dgv[1, i].Value = r["item"];
                dgv[2, i].Value = r["quantity"];
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var id = ObjectId.Parse(dgv.SelectedRows[0].Cells[0].Value.ToString());
            var filter = Builders<BsonDocument>.Filter.Eq("_id", id);

            collection.DeleteOne(filter);
            loadInventory();
        }
    }
}
