using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using universityBase_Lib;
namespace Ui
{
    public partial class NewGroup : Form
    {
        Manager manGroup;
        public NewGroup()
        {
            InitializeComponent();
        }
        public NewGroup(Manager mg)
        {
            InitializeComponent();
            manGroup = mg;
            comboBox1.Items.Clear();
            var teacher = manGroup.GetTeacherArr();
            foreach(var t in teacher)
            {
                comboBox1.Items.Add(t.Surname);
            }
        }
        private void TextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8)
            {
                e.Handled = true;
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            uint groupNum = 0;
            bool parse = false;
            string errorMessge = String.Empty;
            if (textBox1.Text != String.Empty) parse = uint.TryParse(textBox1.Text, out groupNum);

            Teacher t=null;
            if (comboBox1.SelectedItem != null) t = manGroup.GetTeacherArr().ElementAt(comboBox1.SelectedIndex);

            if (!parse) errorMessge += "Введите номер группы\n";
            else
            {
                if(manGroup.ValidNumGroup(groupNum)) errorMessge += "Такой номер группы уже есть\n";
            }
            if(t==null) errorMessge += "Выберите преподавателя\n";
            if(errorMessge!=String.Empty)
            {
                MessageBox.Show(errorMessge);
            }
            else
            {
                manGroup.NewGroup(groupNum, t);
                this.Close();
            }
        }
    }
}
