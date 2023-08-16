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
    public partial class SearchHosteliteForm : Form
    {
        public SearchHosteliteForm()
        {
            InitializeComponent();
        }

        private void linkSearchByName_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form f = new SearchByNameForm();
            f.Show();
            this.Close();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
            Form f = new AdminForm();
            f.Show();
            
        }

        private void linkSearchByRn_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
            Form f = new SearchByRnForm();
            f.Show();
        }

        private void SearchHosteliteForm_Load(object sender, EventArgs e)
        {

        }
    }
}
