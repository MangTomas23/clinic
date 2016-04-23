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
    public partial class FrmPrintHistory : Form
    {
        public FrmPrintHistory(string id, string hid)
        {
            InitializeComponent();
            var collection = MainForm.database.GetCollection<BsonDocument>("patients");
            var builder = Builders<BsonDocument>.Filter;
            var filter = builder.Eq("_id", ObjectId.Parse(id));
            var res = collection.Find(filter).First();

            DataSet1 ds = new DataSet1();
            
            try
            {
                DataRow r = ds.dtHistory.NewRow();

                r["name"] = res["firstname"].ToString() + " " +
                    res["middlename"].ToString() + " " + res["lastname"].ToString();

                res = collection.Aggregate().Unwind("history").Match(new BsonDocument { { "history._id", ObjectId.Parse(hid) } }).First();
                Console.Write(res);
               r["ward"] = res["history"]["ward"];               
               r["date"] = DateTime.Parse(res["history"]["date"].ToString()).ToShortDateString();               
               r["general_data"] = res["history"]["general_data"];

                ds.dtHistory.Rows.Add(r);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.GetBaseException());
            }

            HistoryReport objRpt = new HistoryReport();
            objRpt.SetDataSource(ds.Tables[1]);
            crystalReportViewer1.ReportSource = objRpt;
            crystalReportViewer1.Refresh();
        }
    }
}
