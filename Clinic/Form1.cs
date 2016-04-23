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
    
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void CrystalReport21_InitReport(object sender, EventArgs e)
        {

        }

        private void btnCreatePdf_Click(object sender, EventArgs e)
        {

        }

        private void btnCreatePdf_Click_1(object sender, EventArgs e)
        {
            DataSet1 ds = new DataSet1();
            DataTable t = ds.Tables.Add("Items");
            //t.Columns.Add("id", Type.GetType("System.Int32"));
            t.Columns.Add("firstname", Type.GetType("System.String"));
            t.Columns.Add("middlename", Type.GetType("System.String"));

            

            var collection = MainForm.database.GetCollection<BsonDocument>("patients");
            var res = collection.Find(new BsonDocument()).ToList().First();

            DataRow r;

            r = t.NewRow();
            r["firstname"] = res["firstname"];
            r["middlename"] = res["middlename"];
            t.Rows.Add(r);




            //PrintPatient objRpt = new PrintPatient();
            //objRpt.SetDataSource(ds.Tables[1]);
            //crystalReportViewer1.ReportSource = objRpt;
            crystalReportViewer1.Refresh();

            /*
            < startup useLegacyV2RuntimeActivationPolicy = "true" >
 
            < supportedRuntime version = "v4.0" sku = ".NETFramework,Version=v4.0" />
            </ startup > */
        }
    }
}
