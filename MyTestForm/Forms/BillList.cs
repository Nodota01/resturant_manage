using MyTestForm.dao;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyTestForm.Forms
{
    public partial class BillList : Form
    {

        BillDao billDao = new BillDao();

        public BillList()
        {
            InitializeComponent();
            DataRefresh();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DataRefresh()
        {
            this.dataGridView.DataSource = billDao.SelectAll();
        }
    }
}
