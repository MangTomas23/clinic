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
namespace Clinic.Print
{
    public partial class FrmPrintDataSheet : Form
    {
        public FrmPrintDataSheet(string id)
        {
            InitializeComponent();
            var collection = MainForm.database.GetCollection<BsonDocument>("patients");
            var filter = Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(id));
            var res = collection.Find(filter).First();

            Console.WriteLine(res);
            DataSet1 ds = new DataSet1();
            DataRow r = ds.dtDataSheet.NewRow();

            try {
                r["firstname"] = res["firstname"];
                r["middlename"] = res["middlename"];
                r["lastname"] = res["lastname"];
                r["age"] = res["age"];
                r["sex"] = res["sex"] == "MALE" ? "M":"F";
                r["address"] = res["address"];
                r["religion"] = res["religion"];
                r["civil_status"] = res["civil_status"];
                r["birthdate"] = res["birthdate"];
                r["birthplace"] = res["birthplace"];
                r["nationality"] = res["nationality"];
                r["occupation"] = res["occupation"];
                r["employer"] = res["employer"];
                var f = res["father"];
                r["fname"] = f["name"];
                r["faddress"] = f["address"];
                r["foccupation"] = f["occupation"];
                r["femployer"] = f["employer"];
                var m = res["mother"];
                r["mname"] = m["name"];
                r["maddress"] = m["address"];
                r["moccupation"] = m["occupation"];
                r["memployer"] = m["employer"];
                var e = res["emergency"];
                r["ename"] = e["name"];
                r["eaddress"] = e["address"];
                r["econtact"] = e["contact"];
                r["erelationship"] = e["relationship"];
            } catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            ds.dtDataSheet.Rows.Add(r);

            DataRow row = ds.dtApp.NewRow();

            var col = MainForm.database.GetCollection<BsonDocument>("app");
            var result = col.Find(new BsonDocument()).First();

            Console.WriteLine(result);
            row["app_name"] = result["name"];
            row["app_address"] = result["address"];

            ds.dtApp.Rows.Add(row);


            PrintPatient objRpt = new PrintPatient();
            
            objRpt.SetDataSource(ds);
            crystalReportViewer1.ReportSource = objRpt;
            crystalReportViewer1.Refresh();
        }

        private void FrmPrintDataSheet_Load(object sender, EventArgs e)
        {

        }
    }
}
