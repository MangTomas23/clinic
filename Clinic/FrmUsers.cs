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
    public partial class FrmUsers : Form
    {
        public FrmUsers()
        {
            InitializeComponent();
            fillListBox();
        }

        private class User
        {
            public string id { get; set; }
            public string username { get; set; }
        }

        private void fillListBox()
        {
            var collection = MainForm.database.GetCollection<BsonDocument>("users");
            var result = collection.Find(new BsonDocument()).ToList();

            List<User> users = new List<User>();
            foreach (var r in result)
            {
                users.Add(new User { id = r["_id"].ToString(), username = r["username"].ToString() });
            }

            lb1.DataSource = users;
            lb1.DisplayMember = "username";
            lb1.ValueMember = "id";
        }

        private void lb1_Enter(object sender, EventArgs e)
        {
            loadUserInfo();
        }



        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text.Equals("") || txtName.Text.Equals("") ||
                txtAddress.Text.Equals("") || txtContact.Text.Equals("") ||
                txtPassword.Text.Equals("") || txtConfirmPassword.Text.Equals(""))
            {
                MessageBox.Show("Please complete all the fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!txtPassword.Text.Equals(txtConfirmPassword.Text))
            {
                MessageBox.Show("Passwords don't match!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var collection = MainForm.database.GetCollection<BsonDocument>("users");
            var document = new BsonDocument
            {
                {"username", txtUsername.Text }, 
                {"name", txtName.Text }, 
                {"address", txtAddress.Text }, 
                {"contact", txtContact.Text }, 
                {"password", txtPassword.Text },
            };

            collection.InsertOne(document);

            MessageBox.Show("User added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //ckear
            //reload

            txtUsername.Text = "";
            txtName.Text = "";
            txtAddress.Text = "";
            txtContact.Text = "";
            txtPassword.Text = "";
            txtConfirmPassword.Text = "";

            fillListBox();
        }

        private void lb1_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadUserInfo();
        }

        private void loadUserInfo()
        {
            try
            {
                string id = lb1.GetItemText(lb1.SelectedValue);
                var collection = MainForm.database.GetCollection<BsonDocument>("users");
                var filter = Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(id));
                var result = collection.Find(filter).First();

                lblUsername.Text = result["username"].ToString();
                lblName.Text = result["name"].ToString();
                lblAddress.Text = result["address"].ToString();
                lblContact.Text = result["contact"].ToString();
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }
        }
    }
}
