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
    public partial class NewTeacher : Form
    {
        Manager manGroup;
        public NewTeacher()
        {
            InitializeComponent();
        }
        public NewTeacher(Manager m)
        {
            InitializeComponent();
            manGroup = m;
            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(new object[] {"Доцент", "Лектор", "Ассистент" }); // не пиши на обжектах будешь терять время на боксинге анбоксинге и потом еще с приведением типом получишь кучу ошибок указвый строгую типизацию где это возможно.
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            string name = String.Empty;
            if (textBox1.Text != String.Empty) name = textBox1.Text;

            string surname = String.Empty;
            if (textBox2.Text != String.Empty) surname = textBox2.Text;

            uint age = 0;
            bool parse = false;
            if (textBox3.Text != String.Empty) parse = uint.TryParse(textBox3.Text, out age);

            string pos = String.Empty;
            if (comboBox1.SelectedItem != null) pos = (string)comboBox1.SelectedItem;

            uint length = 0;
            bool parse2 = false; // не логичное название переменой код не читается я не могу без запуска приложения понять что ты тут парсишь
            if (textBox5.Text != String.Empty) parse2 = uint.TryParse(textBox5.Text, out length);

            string messageError = String.Empty;
            if (name == String.Empty) messageError += "Введите имя\n";
            if (surname == String.Empty) messageError += "Введите фамилию\n";
            if (!parse) messageError += "Введите возраст\n";
            if (comboBox1.SelectedItem == null) messageError += "Выберите должность\n";  // ВСЕ UI элементы надо называть соответсвенно вот я только на этой строчке догадываюсь что ComboBox1 = это список должностей
            if (!parse2) messageError += "Введите кол-во в группе\n";

            if (messageError != String.Empty) MessageBox.Show(messageError);
            else
            {
                manGroup.NewTeaher(new Teacher(name, surname, age, pos, length));
                this.Close();
            }
        }
        private void TextBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8)  // магические цифры в коде
            {
                e.Handled = true;
            }
        }
    }
}
