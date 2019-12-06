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
    public partial class NewStudent : Form
    {
        
        Manager manGroup;
        public NewStudent()
        {
            InitializeComponent();
        }
        public NewStudent(Manager m)
        {
            InitializeComponent();
            manGroup = m;
            FillComboBox();
        }
        private void FillComboBox()
        {
            comboBox1.Items.Clear();
            Group[] gr = manGroup.GetGroupsOb();
            foreach(var g in gr.OrderBy(g=>g.Number))
            {
                if (g.GetFree() != 0) comboBox1.Items.Add(g.Number);
            }
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            this.Close();
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
            string name = String.Empty;
            if (textBox2.Text != String.Empty) name = textBox2.Text;
            string surname = String.Empty;
            if (textBox3.Text != String.Empty) surname = textBox3.Text;
            uint age=0;
            bool parse=false;
            if (textBox1.Text != String.Empty) parse=uint.TryParse(textBox1.Text,out age);
            uint numberGroup=0;
            if (comboBox1.SelectedItem != null) numberGroup = (uint)comboBox1.SelectedItem;
            string messageError=String.Empty;
            if (name == String.Empty) messageError += "Введите имя\n";
            if (surname == String.Empty) messageError += "Введите фамилию\n";
            if(!parse) messageError += "Введите возраст\n";
            if(comboBox1.SelectedItem==null) messageError += "Выберите группу\n";
            if (messageError != String.Empty) MessageBox.Show(messageError);
            else
            {
                bool succes= manGroup.NewStudent( new Student(name, surname, age, numberGroup));
                if (succes) this.Close();
                else MessageBox.Show("Не удалось добавить студента в группу, возможно в ней нет мест");
            }
        }
    }
}
