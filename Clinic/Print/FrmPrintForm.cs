using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Clinic.Print
{
    public partial class FrmPrintForm : Form
    {
        public FrmPrintForm(DataSet1 ds, ReportClass rpt)
        {
            Initialize(ds, rpt, null);
        }

        public FrmPrintForm(DataSet1 ds, ReportClass rpt, string p_id)
        {
            Initialize(ds, rpt, p_id);
        }

        private void Initialize(DataSet1 ds, ReportClass rpt, string p_id)
        {
            InitializeComponent();

            //set app datasource
            DataRow row = ds.dtApp.NewRow();
            var collection = MainForm.database.GetCollection<BsonDocument>("app");
            var result = collection.Find(new BsonDocument()).First();
            row["app_name"] = result["name"];
            row["app_address"] = result["address"];
            ds.dtApp.Rows.Add(row);

            if(p_id != null)
            {
                collection = MainForm.database.GetCollection<BsonDocument>("patients");
                var filter = Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(p_id));
                result = collection.Find(filter).First();

                row = ds.dtDataSheet.NewRow();
                row["firstname"] = result["firstname"];
                row["middlename"] = result["middlename"];
                row["lastname"] = result["lastname"];

                ds.dtDataSheet.Rows.Add(row);
            }


            rpt.SetDataSource(ds);
            crystalReportViewer1.ReportSource = rpt;
            crystalReportViewer1.Refresh();
        }
    }
}
