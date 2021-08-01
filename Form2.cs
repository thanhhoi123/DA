using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HuffmanCoding
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            DACK_DB db = new DACK_DB();
            var query = from p in db.Histories select p;
            dgvHistory.DataSource = query.ToList();
        }

        private void butSearch_Click(object sender, EventArgs e)
        {
            DACK_DB db = new DACK_DB();
            var query = db.Histories.Where(p => p.TruocMaHoa.Contains(txtSearch.Text) || p.SauMaHoa.Contains(txtSearch.Text));
            dgvHistory.DataSource = query.ToList();
        }

        private void butDel_Click(object sender, EventArgs e)
        {
            if(dgvHistory.SelectedRows.Count > 0)
            {
                DACK_DB db = new DACK_DB();
                foreach(DataGridViewRow i in dgvHistory.SelectedRows)
                {
                    DateTime ThoiGian = Convert.ToDateTime(i.Cells["ThoiGian"].Value);                    
                    History Mydel = db.Histories.Find(ThoiGian);                    
                    db.Histories.Remove(Mydel);
                    db.SaveChanges();
                }
                var query = from p in db.Histories select p;
                dgvHistory.DataSource = query.ToList();
            }
        }

        private void butExit_Click(object sender, EventArgs e)
        {            
            this.Dispose();
        }
    }
}
