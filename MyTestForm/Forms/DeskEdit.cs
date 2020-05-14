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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyTestForm.Forms
{
    public partial class DeskEdit : Form
    {

        private DeskDao deskDao = new DeskDao();

        private string desk_id;

        private Desk desk;

        public DeskEdit()
        {
            InitializeComponent();
            this.Text = "新增";
            desk = null;
        }

        public DeskEdit(string desk_id)
        {
            InitializeComponent();
            this.Text = "编辑";
            this.desk_id = desk_id;
            desk = deskDao.Select(new { desk_id = desk_id })[0] ;
            Util.Binding.BindObjectToForm(this, desk, typeof(Desk));
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //根据是否存有对象判别新增还是修改
            if (desk == null)
            {
                desk = new Desk();
                if (Util.Binding.BindFormToObject(this, desk, typeof(Desk)) && deskDao.Insert(desk))
                {
                    MessageBox.Show("添加成功");
                    this.Text = "正在编辑 - " + desk.desk_name;
                }
                else
                {
                    MessageBox.Show("添加失败");
                }
            }
            //更新
            else
            {
                if ((Util.Binding.BindFormToObject(this, desk, typeof(Desk)) && deskDao.Update(desk)))
                {
                    MessageBox.Show("更新成功");
                    this.Text = "正在编辑 - " + desk.desk_name;
                }
                else
                {
                    MessageBox.Show("更新失败");
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
