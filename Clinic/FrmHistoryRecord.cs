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
    public partial class FrmHistoryRecord : Form
    {
        private string id;
        private BsonDocument hr;
        private IMongoCollection<BsonDocument> collection;
        private FilterDefinition<BsonDocument> filter;
        private string currentHistory;
        private int position;

        public FrmHistoryRecord(string _id)
        {
            InitializeComponent();
            id = _id;
            position = 0;
            collection = MainForm.database.GetCollection<BsonDocument>("patients");
            filter = Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(id));

            hr = collection.Find(filter).First();
            lblName.Text = hr["firstname"].ToString() + " " + hr["middlename"].ToString() + 
                " " + hr["lastname"].ToString();

            if (historyEmpty())
            {
                setEmpty();
            }else
            {
                lblHistoryNumber.Text = "1/" + hr["history"].AsBsonArray.Count;
                btnPrevious.Enabled = false;
                currentHistory = hr["history"][0]["_id"].ToString();

                setInfo();
            }
            
        }
        
        private void btnPrint_Click(object sender, EventArgs e)
        {
            new Print.FrmPrintHistory(id, currentHistory).ShowDialog();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(lastPosition())
            {
                var document = new BsonDocument
                    {
                        {"_id", ObjectId.GenerateNewId()},
                        {"date", dtpDate.Value},
                        {"ward", txtWard.Text},
                        {"general_data", txtGeneralData.Text},
                    };
                var update = Builders<BsonDocument>.Update.AddToSet("history", document);
                collection.UpdateOne(filter, update);
                MessageBox.Show("Record saved!");
            }
            else
            {
                var builder = Builders<BsonDocument>.Filter;
                var filter = builder.Eq("_id", ObjectId.Parse(id)) & builder.Eq("history._id", ObjectId.Parse(currentHistory));

                var update = Builders<BsonDocument>.Update
                    .Set("history.$.date", dtpDate.Value)
                    .Set("history.$.ward", txtWard.Text)
                    .Set("history.$.general_data", txtGeneralData.Text)
                    ;
                collection.UpdateOne(filter, update);
                MessageBox.Show("Updated successfully.");
            }

            if (historyEmpty())
            {
                btnNext.Enabled = true;
                clear();
                hasHistory();
            }
        }

        private void clear()
        {
            txtWard.Text = "";
            txtGeneralData.Text = "";
        }

        private Boolean historyEmpty()
        {
            hr = collection.Find(filter).First();

            try
            {
                if (hr["history"].AsBsonArray.Count == 0)
                {
                    return true;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return true;
            }

            return false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to delete this record?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if(result.Equals(DialogResult.Yes))
            {
                var update = Builders<BsonDocument>.Update
                    .Pull("history", new BsonDocument { { "_id", ObjectId.Parse(currentHistory) } });
                collection.UpdateOne(filter, update);
                if (historyEmpty())
                {
                    setEmpty();
                }
            }
        }

        private void setEmpty()
        {
            MessageBox.Show("History empty.");
            btnPrevious.Enabled = false;
            btnNext.Enabled = false;
            btnPrint.Enabled = false;
            btnDelete.Enabled = false;
            lblHistoryNumber.Text = "0/0";
            clear();
        }

        private void hasHistory()
        {
            btnDelete.Enabled = true;
            btnNext.Enabled = true;
            lblHistoryNumber.Text = "1/" + hr["history"].AsBsonArray.Count;
        }

        private Boolean lastPosition()
        {
            if(position.Equals(hr["history"].AsBsonArray.Count))
            {
                return true;
            }
            return false;
        }

        private Boolean firstPosition()
        {
            if (position.Equals(0))
            {
                return true;
            }
            return false;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            position++;
            if (lastPosition())
            {
                clear();
                btnPrevious.Enabled = true;
                btnNext.Enabled = false;
                btnPrint.Enabled = false;
                btnDelete.Enabled = false;
            }
            else
            {
                setInfo();
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            position--;
            if(firstPosition())
            {
                btnPrevious.Enabled = false;
                btnNext.Enabled = true;
            }
            setInfo();
        }

        private void setInfo()
        {
            txtWard.Text = hr["history"][position]["ward"].ToString();
            dtpDate.Value = DateTime.Parse(hr["history"][position]["date"].ToString());
            txtGeneralData.Text = hr["history"][position]["general_data"].ToString();
            currentHistory = hr["history"][position]["_id"].ToString();
            lblHistoryNumber.Text = (position + 1) + "/" + hr["history"].AsBsonArray.Count;
            btnDelete.Enabled = true;
            btnPrint.Enabled = true;
        }
    }
}
