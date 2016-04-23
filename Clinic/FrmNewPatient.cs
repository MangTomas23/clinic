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
    public partial class FrmNewPatient : Form
    {
        MainForm frmMain;
        Boolean edit;
        string id;

        public FrmNewPatient(MainForm frmMain)
        {
            Initialize(frmMain);
        }

        public FrmNewPatient(MainForm frmMain, string id)
        {
            Initialize(frmMain);

            var collection = MainForm.database.GetCollection<BsonDocument>("patients");
            var filter = Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(id));
            var r = collection.Find(filter).ToList().First();

            edit = true;
            this.id = id;

            try
            {
                txtFirstname.Text = r["firstname"].ToString();
                txtMiddlename.Text = r["middlename"].ToString();
                txtLastname.Text = r["lastname"].ToString();
                cboSex.SelectedItem = r["sex"].ToString();
                txtAge.Text = r["age"].ToString();
                dtpBirthdate.Value = DateTime.Parse(r["birthdate"].ToString());
                txtBirthplace.Text = r["birthplace"].ToString();
                cboCivilStatus.SelectedItem = r["civil_status"].ToString();
                txtAddress.Text = r["address"].ToString();
                txtReligion.Text = r["religion"].ToString();
                txtNationality.Text = r["nationality"].ToString();
                txtOccupation.Text = r["occupation"].ToString();
                txtEmployer.Text = r["employer"].ToString();

                var father = r["father"];
                txtFName.Text = father["name"].ToString();
                txtFAddress.Text = father["address"].ToString();
                txtFOccupation.Text = father["occupation"].ToString();
                txtFEmployer.Text = father["employer"].ToString();

                var mother = r["mother"];
                txtMName.Text = mother["name"].ToString();
                txtMAddress.Text = mother["address"].ToString();
                txtMOccupation.Text = mother["occupation"].ToString();
                txtMEmployer.Text = mother["employer"].ToString();

                var emergency = r["emergency"];
                txtEName.Text = emergency["name"].ToString();
                txtEContact.Text = emergency["contact"].ToString();
                txtEAddress.Text = emergency["address"].ToString();
                txtERelationship.Text = emergency["relationship"].ToString();


            } catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void Initialize(MainForm frmMain)
        {
            InitializeComponent();
            this.frmMain = frmMain;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(!edit)
            {
                saveToDatabase();
            }
            else
            {
                updateRecord();
            }

            frmMain.fillPatientsList();
        }

        private void saveToDatabase()
        {

            var collection = MainForm.database.GetCollection<BsonDocument>("patients");

            try
            {

                var document = new BsonDocument
                {
                    {"firstname", txtFirstname.Text },
                    {"middlename", txtMiddlename.Text },
                    {"lastname", txtLastname.Text },
                    {"sex", cboSex.SelectedItem.ToString() },
                    {"birthdate", dtpBirthdate.Value},
                    {"age", txtAge.Text },
                    {"birthplace", txtBirthplace.Text },
                    {"civil_status", cboCivilStatus.SelectedItem.ToString()},
                    {"address", txtAddress.Text },
                    {"religion", txtReligion.Text },
                    {"nationality", txtNationality.Text },
                    {"occupation", txtOccupation.Text },
                    {"employer", txtEmployer.Text },
                    {"mother", new BsonDocument {
                        { "name", txtMName.Text},
                        { "address", txtMAddress.Text},
                        { "occupation", txtMOccupation.Text},
                        { "employer", txtMEmployer.Text},
                    }},
                    {"father", new BsonDocument {
                        { "name", txtFName.Text},
                        { "address", txtFAddress.Text},
                        { "occupation", txtFOccupation.Text},
                        { "employer", txtFEmployer.Text},
                    }},
                    {"emergency", new BsonDocument {
                        {"name", txtEName.Text },
                        {"address", txtEAddress.Text },
                        {"contact", txtEContact.Text },
                        {"relationship", txtERelationship.Text }
                    }}
                };

                collection.InsertOne(document);
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please complete the form.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Console.WriteLine(ex.ToString());
            }
        }

        private void updateRecord()
        {
            var collections = MainForm.database.GetCollection<BsonDocument>("patients");
            var filter = Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(id));

            try {
                var update = Builders<BsonDocument>.Update
                    .Set("firstname", txtFirstname.Text)
                    .Set("middlename", txtMiddlename.Text)
                    .Set("lastname", txtLastname.Text)
                    .Set("sex", cboSex.SelectedItem.ToString())
                    .Set("birthdate", dtpBirthdate.Value.ToString())
                    .Set("age", txtAge.Text)
                    .Set("birthplace", txtBirthplace.Text)
                    .Set("civil_status", cboCivilStatus.SelectedItem.ToString())
                    .Set("address", txtAddress.Text)
                    .Set("religion", txtReligion.Text)
                    .Set("nationality", txtNationality.Text)
                    .Set("occupation", txtOccupation.Text)
                    .Set("employer", txtEmployer.Text)
                    .Set("father.name", txtFName.Text)
                    .Set("father.address", txtFAddress.Text)
                    .Set("father.occupation", txtFOccupation.Text)
                    .Set("father.employer", txtFEmployer.Text)

                    .Set("mother.name", txtMName.Text)
                    .Set("mother.address", txtMAddress.Text)
                    .Set("mother.occupation", txtMOccupation.Text)
                    .Set("mother.employer", txtMEmployer.Text)

                    .Set("emergency.name", txtEName.Text)
                    .Set("emergency.address", txtEAddress.Text)
                    .Set("emergency.contact", txtEContact.Text)
                    .Set("emergency.relationship", txtERelationship.Text)
                    ;

                collections.UpdateOne(filter, update);
                this.Hide();
            }catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }

        private void dtpBirthdate_ValueChanged(object sender, EventArgs e)
        {

            TimeSpan ts = DateTime.Now - Convert.ToDateTime(dtpBirthdate.Value);
            int age = Convert.ToInt32(ts.Days) / 365;
            txtAge.Text = age.ToString();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
