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
    public partial class FrmProfile : Form
    {
        private string id;

        public FrmProfile(string _id)
        {
            InitializeComponent();
            var collection = MainForm.database.GetCollection<BsonDocument>("users");
            var filter = Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(_id));
            var result = collection.Find(filter).ToList().First();

            id = _id;

            try
            {
                txtName.Text = result["name"].ToString();
                txtAddress.Text = result["address"].ToString();
                txtContact.Text = result["contact"].ToString();
            } catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var collection = MainForm.database.GetCollection<BsonDocument>("users");
            var filter = Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(id));

            var update = Builders<BsonDocument>.Update
                .Set("name", txtName.Text)
                .Set("address", txtAddress.Text)
                .Set("contact", txtContact.Text);

            collection.UpdateOne(filter, update);
        }
    }
}
