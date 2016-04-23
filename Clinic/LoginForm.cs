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
    public partial class LoginForm : Form
    {
        public static IMongoClient client;
        public static IMongoDatabase database;

        public LoginForm()
        {
            InitializeComponent();

            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/C mongod --dbpath c:/mongodata";
            process.StartInfo = startInfo;
            process.Start();
            

            client = new MongoClient();
            database = client.GetDatabase("clinic");
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            var collection = database.GetCollection<BsonDocument>("users");
            var builder = Builders<BsonDocument>.Filter;
            var filter = builder.Eq("username", username) & builder.Eq("password", password) ;
            var result = collection.Find(filter).ToList();

            if(result.Count != 0)
            {
                this.Hide();
                new MainForm(result[0]["_id"].ToString()).Show();
            }
            else
            {
                MessageBox.Show("Incorrect username or password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtPassword.Focus();
            }
        }
    }
}
