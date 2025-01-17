﻿using System;
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

namespace Clinic.Inventory
{
    public partial class FrmAddItem : Form
    {
        public FrmAddItem()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(txtItem.Text.Trim().Equals("") || txtQuantity.Text.Trim().Equals(""))
            {
                MessageBox.Show("Please fill up all the fields. ", "Incomplete Fields", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            IMongoCollection<BsonDocument> collection = MainForm.database.GetCollection<BsonDocument>("inventory");

            var document = new BsonDocument
            {
                {"item", txtItem.Text },
                {"quantity", txtQuantity.Text }
            };

            collection.InsertOne(document);
        }
    }
}
