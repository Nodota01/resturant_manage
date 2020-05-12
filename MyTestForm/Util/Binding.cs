using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.Control;

namespace MyTestForm.Util
{
    class Binding
    {
        public static bool BindFormToObject(Form form, Object obj, Type objType)
        {
            Control[] controls = form.Controls.Find("panelMain", true);
            Panel panel = null;
            Dictionary<string, PropertyInfo> propertiesDir = GetObjPropertyDir(objType);
            if (controls.Length == 0 || !(controls[0] is Panel))
            {
                return false;
            }
            else {
                panel = (Panel)controls[0];
            }
            //panel下的控件集合
            ControlCollection subPanelControls = panel.Controls;
            foreach (Control control in subPanelControls)
            {
                PropertyInfo property = null;
                if (propertiesDir.TryGetValue(control.Name, out property))
                {
                    //如果是textbox则获取内容
                    TextBox textBox = control as TextBox;
                    if (textBox != null)
                    {
                        //判断属性类型
                        if (property.PropertyType.IsAssignableFrom(typeof(string)))
                        {
                            property.SetValue(obj, textBox.Text);
                        }
                        else
                        {
                            property.SetValue(obj, Convert.ChangeType(textBox.Text, property.PropertyType));
                        }
                    }
                    //如果是复选框则给01
                    ComboBox comboBox = control as ComboBox;
                    if (comboBox != null)
                    {
                        bool value = comboBox.SelectedIndex == 0 ? false : true;
                        property.SetValue(obj, value);
                    }
                }
            }
            return true;
        }

        public static bool BindObjectToForm(Form form, Object obj, Type objType)
        {
            Control[] controls = form.Controls.Find("panelMain", true);
            Panel panel = null;
            Dictionary<string, PropertyInfo> propertiesDir = GetObjPropertyDir(objType);
            if (controls.Length == 0 || !(controls[0] is Panel))
            {
                return false;
            }
            else
            {
                panel = (Panel)controls[0];
            }
            ControlCollection subPanelControls = panel.Controls;
            foreach (Control control in subPanelControls)
            {
                PropertyInfo property = null;
                if (propertiesDir.TryGetValue(control.Name, out property))
                {
                    //如果是textbox则获取内容
                    TextBox textBox = control as TextBox;
                    if (textBox != null)
                    {
                        textBox.Text = property.GetValue(obj).ToString();
                    }
                    //如果是复选框则给01
                    ComboBox comboBox = control as ComboBox;
                    if (comboBox != null)
                    {
                        bool value = (bool)property.GetValue(obj);
                        comboBox.SelectedIndex = value==false ? 0 : 1;
                    }
                }
            }
            return true;
        }

        //获得实体属性集合
        private static Dictionary<string, PropertyInfo> GetObjPropertyDir(Type objType)
        {
            Dictionary<string, PropertyInfo> propertiesDir = new Dictionary<string, PropertyInfo>();
            PropertyInfo[] properties = objType.GetProperties();
            foreach(PropertyInfo property in properties)
            {
                propertiesDir.Add(property.Name, property);
            }
            return propertiesDir;
        }
    }
}
