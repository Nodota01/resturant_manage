﻿using MyTestForm.dao;
using MyTestForm.domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyTestForm.Forms
{
    public partial class DeskList : Form
    {
        private DeskDao deskDao;

        public DeskList()
        {
            InitializeComponent();
            deskDao = new DeskDao();
            DataRefresh();
        }

        /// <summary>
        /// 处理和刷新结果集
        /// </summary>
        private void DataRefresh()
        {
            var desks = deskDao.SelectAll();
            var dataSet = new List<Object>();
            //判断是否有占位
            foreach(Desk desk in desks)
            {
                bool available = (desk.current_record == "0");
                dataSet.Add(new {desk_id = desk.desk_id, desk_name = desk.desk_name, is_available = available});
            }
            this.dataGridView.DataSource = dataSet;
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            DataRefresh();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void NewRecordButton_Click(object sender, EventArgs e)
        {
            //获取id后进入edit
            if (dataGridView.CurrentRow != null)
            {
                int index = dataGridView.CurrentRow.Index;
                string desk_id = dataGridView.Rows[index].Cells["desk_id"].Value.ToString();
                VisitRecordEdit visitRecordEdit = new VisitRecordEdit(desk_id);
                //退出编辑后刷新数据
                visitRecordEdit.ShowDialog();
                this.DataRefresh();
            }
            else
            {
                MessageBox.Show("尚未选择数据");
            }
        }

        private void LeaveDeskButton_Click(object sender, EventArgs e)
        {
            //获取id后设current_id 为0
            if (dataGridView.CurrentRow != null)
            {
                int index = dataGridView.CurrentRow.Index;
                string desk_id = dataGridView.Rows[index].Cells["desk_id"].Value.ToString();
                Desk desk = new Desk();
                desk.desk_id = desk_id;
                desk.current_record = "0";
                deskDao.SetVisitRecord(desk);
                this.DataRefresh();
            }
            else
            {
                MessageBox.Show("尚未选择数据");
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            //获取是否可用并删除
            if (dataGridView.CurrentRow != null)
            {
                int index = dataGridView.CurrentRow.Index;
                bool is_available = (bool)dataGridView.Rows[index].Cells["is_available"].Value;
                //如果座位上有人
                if(is_available == false)
                {
                    MessageBox.Show("当前状态不可删除");
                }
                else
                {
                    deskDao.Delete(new { desk_id = dataGridView.Rows[index].Cells["desk_id"].Value.ToString() });
                }
                this.DataRefresh();
            }
            else
            {
                MessageBox.Show("尚未选择数据");
            }
        }

        private void InsertButton_Click(object sender, EventArgs e)
        {
            DeskEdit deskEdit = new DeskEdit();
            deskEdit.ShowDialog();
            this.DataRefresh();
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            if (dataGridView.CurrentRow != null)
            {
                int index = dataGridView.CurrentRow.Index;
                bool is_available = (bool)dataGridView.Rows[index].Cells["is_available"].Value;
                //如果座位上有人
                if (is_available == false)
                {
                    MessageBox.Show("当前状态不可修改");
                }
                else
                {
                    string desk_id = dataGridView.Rows[index].Cells["desk_id"].Value.ToString();
                    DeskEdit deskEdit = new DeskEdit(desk_id);
                    deskEdit.ShowDialog();
                }
                this.DataRefresh();
            }
            else
            {
                MessageBox.Show("尚未选择数据");
            }
        }
    }
}
