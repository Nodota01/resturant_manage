using MyTestForm.dao;
using MyTestForm.domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyTestForm.Forms
{
    public partial class VisitRecordEdit : Form
    {

        private VisitRecordDao visitRecordDao;
        private DeskDao deskDao;

        private string desk_id;

        /// <summary>
        /// 传入桌id创建入座记录
        /// </summary>
        /// <param name="desk_id"></param>
        public VisitRecordEdit(string desk_id)
        {
            InitializeComponent();
            this.desk_id = desk_id;
            visitRecordDao = new VisitRecordDao();
            deskDao = new DeskDao();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 插入访问记录，更新桌子状态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Regex.IsMatch(NumTextBox.Text, @"^\d+\.\d+\z|^\d+\z")) {
                //插入访问记录
                VisitRecord visitRecord = new VisitRecord();
                visitRecord.desk_id = this.desk_id;
                visitRecord.consumer_num = Convert.ToInt32(NumTextBox.Text);
                visitRecordDao.Insert(visitRecord);

                //更新桌子状态
                Desk desk = new Desk();
                desk.desk_id = this.desk_id;
                desk.current_record = visitRecord.visit_record_id;
                deskDao.SetVisitRecord(desk);

                this.Close();
            }
            else
            {
                MessageBox.Show("请输入数字");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            NumTextBox.Text = "";
        }
    }
}
