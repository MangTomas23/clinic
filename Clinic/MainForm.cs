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
    public partial class MainForm : Form
    {
        public static IMongoClient client;
        public static IMongoDatabase database;
        private IMongoCollection<BsonDocument> collection;
        private string user_id;

        public MainForm(string user_id)
        {
            InitializeComponent();
            client = new MongoClient();
            database = client.GetDatabase("clinic");
            collection = database.GetCollection<BsonDocument>("patients");
            this.user_id = user_id;
            fillPatientsList();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        public void fillPatientsList()
        {
            DataGridView dv = dataGridView1;
            dv.Rows.Clear();
            
            var builder = Builders<BsonDocument>.Filter;
            var filter = builder.Regex("firstname", new BsonRegularExpression(txtSearch.Text));
            var result = collection.Find(filter).ToList();

            int i;
            foreach (var x in result)
            {
                try {
                    i = dv.Rows.Add();
                    dv[0, i].Value = x["_id"];
                    dv[1, i].Value = x["firstname"];
                    dv[2, i].Value = x["middlename"];
                    dv[3, i].Value = x["lastname"];
                    dv[4, i].Value = x["address"];
                } catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            new FrmNewPatient(this).Show();
        }



        private void txtSearch_keyup(object sender, KeyEventArgs e)
        {
            fillPatientsList();
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try {
                string objectId = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                var filter = Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(objectId));
                var r = collection.Find(filter).ToList().First();

                lblFullname.Text = r["firstname"].ToString() + " " +
                    r["middlename"].ToString() + " " + r["lastname"].ToString();
                lblAddress.Text = r["address"].ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result.Equals(DialogResult.Yes))
            {
                this.Dispose();
            }
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            new FrmHistoryRecord(dataGridView1.SelectedRows[0].Cells[0].Value.ToString()).ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var id = ObjectId.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            DialogResult result = MessageBox.Show("Are you sure you want to delete this patient. All of its records will be lost.", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
            if (result.Equals(DialogResult.Yes))
            {
                var filter = Builders<BsonDocument>.Filter.Eq("_id", id);
                collection.DeleteOne(filter);
                fillPatientsList();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            string id = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            new FrmNewPatient(this, id).ShowDialog();
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            string id = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            new FrmPayment(id).ShowDialog();
        }

        private void accountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FrmChangePassword(this).ShowDialog();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to logout?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result.Equals(DialogResult.Yes))
            {
                this.Hide();
                new LoginForm().Show();
            }
        }

        public string getUser()
        {
            return user_id;
        }

        private void btnPrintDataSheet_Click(object sender, EventArgs e)
        {
            string id = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            new Print.FrmPrintDataSheet(id).ShowDialog();
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FrmUsers().ShowDialog();
        }

        private void profileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FrmProfile(getUser()).ShowDialog();
        }
               

        private void btnReferralSheet_Click(object sender, EventArgs e)
        {
            DataSet1 ds = new DataSet1();

            new Print.FrmPrintForm(ds, new Print.ReferralSheet()).ShowDialog();   
        }

        private void btnConsent_Click(object sender, EventArgs e)
        {
            string id = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            new Print.FrmPrintForm(new DataSet1(), new Print.ConsentForAdmission(), id).ShowDialog();
        }

        private void backupToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
