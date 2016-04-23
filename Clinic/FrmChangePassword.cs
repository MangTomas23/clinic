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
    public partial class FrmChangePassword : Form
    {
        MainForm frmMain;
        public FrmChangePassword(MainForm frmMain)
        {
            InitializeComponent();
            this.frmMain = frmMain;
            MessageBox.Show(frmMain.getUser());
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            var collection = MainForm.database.GetCollection<BsonDocument>("users");
            var filter = Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(frmMain.getUser()));

            var result = collection.Find(filter).ToList().First();

            string oldPassword = result["password"].ToString();

            if (txtOldPassword.Text.Equals("") || txtNewPassword.Text.Equals("") || txtConfirm.Text.Equals(""))
            {
                MessageBox.Show("Invalid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        
            if (!txtOldPassword.Text.Equals(oldPassword))
            {
                MessageBox.Show("Old password is incorrect!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!txtNewPassword.Text.Equals(txtConfirm.Text))
            {
                MessageBox.Show("Passwords don't match!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var update = Builders<BsonDocument>.Update
                .Set("password", txtNewPassword.Text);

            collection.UpdateOne(filter, update);
            MessageBox.Show("Password changed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Hide();
        }
    }
}
