using MyTestForm.dao;
using MyTestForm.domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyTestForm.Forms
{
    public partial class MeterialAddStorage : Form
    {

        MeterialDao meterialDao = new MeterialDao();
        BillDao billDao = new BillDao();
        Meterial meterial;

        public MeterialAddStorage(string meterial_id)
        {
            InitializeComponent();
            //获取对象
            this.meterial = meterialDao.Select(new { meterial_id = meterial_id })[0];
        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            if (Regex.IsMatch(AddNumBox.Text.Trim(), @"^\d+\.\d+\z|^\d+\z"))
            {
                //更新库存
                decimal addNum = Convert.ToDecimal(AddNumBox.Text.Trim());
                meterial.storage += addNum;
                meterialDao.Update(meterial);
                //记录账单
                Bill bill = new Bill();
                bill.type = "食材";
                bill.type_name = meterial.meterial_name;
                bill.type_id = meterial.meterial_id;
                bill.cost = -(meterial.price * addNum);
                billDao.Insert(bill);

                MessageBox.Show("进货成功");
            }
            else
            {
                MessageBox.Show("请输入数字");
            }
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            this.AddNumBox.Text = "";
        }
    }
}
