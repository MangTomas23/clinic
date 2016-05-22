﻿using System;
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
        
        public FrmEditItem(string id)
        {
            InitializeComponent();
            this.id = id;
            collection = MainForm.database.GetCollection<BsonDocument>("inventory");
            var filter = Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(id));
            var result = collection.Find(filter).First();

            txtItem.Text = result["item"].ToString();
            txtQuantity.Text = result["quantity"].ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

        }
    }
}
