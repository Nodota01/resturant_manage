using ConsoleApp1.dao;
using ConsoleApp1.dba;
using ConsoleApp1.domain;
using MyTestForm.Util;
using System;

using System.Windows.Forms;

namespace MyTestForm
{
    public partial class Form1 : Form
    {

        private PatientDao patientDao = new PatientDao();
        private Patient patient;
        private uint entityID = 0;


        public Form1(uint ID)
        {
            InitializeComponent();
            //如果传入ID则查出来并放入控件
            entityID = ID;
            patient = patientDao.Select(new {id = entityID })[0];
            Util.Binding.BindObjectToForm(this, patient, typeof(Patient));
        }
        public Form1()
        {
            InitializeComponent();
            patient = null;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //新增
            if(patient == null)
            {
                patient = new Patient();
                if (Util.Binding.BindFormToObject(this, patient, typeof(Patient)) && patientDao.Insert(patient))
                {
                    MessageBox.Show("添加成功");
                }
                else
                {
                    MessageBox.Show("添加失败");
                }
            }
            //更新
            else
            {
                if((Util.Binding.BindFormToObject(this, patient, typeof(Patient)) && patientDao.Update(patient)))
                {
                    MessageBox.Show("更新成功");
                }
                else
                {
                    MessageBox.Show("更新失败");
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DataBaseAccess.GetConnection().Close();
            this.Dispose();
        }
    }
}
