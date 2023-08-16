using Buisness_Application.BL;
using Buisness_Application.DL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.GUI
{
    public partial class LoadingForm : Form
    {
        public LoadingForm()
        {
            InitializeComponent();
        }

        private void LoadingForm_Load(object sender, EventArgs e)
        {
            UserDL.LoadUsersFromFile(ExtraBL.GetUsersPath());
            NoticesDL.LoadNoticesFromFile(ExtraBL.GetNoticesPath());
            MessCRUD.LoadMessMenuFromFile(ExtraBL.GetMessPath());
            ComplaintsDL.LoadComplaintsFromFile(ExtraBL.GetComplaintsPath());
            ReviewsDL.LoadReviewsFromFile(ExtraBL.GetReviewsPath());
            ChallanDL.LoadChallansFromFile(ExtraBL.GetChallanPath());
            FinancialRecordDL.LoadFinancialRecordFromFile(ExtraBL.GetRecordPath());
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            panel1.Width += 40;
            if(panel1.Width >= 400)
            {
                timer1.Enabled = false;
                this.Hide();
                Form f = new LoginFrom();
                f.Show();
            }
        }
    }
}
