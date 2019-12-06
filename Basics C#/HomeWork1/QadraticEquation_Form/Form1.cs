using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QadraticEquation_Lib;

namespace QadraticEquation_Form
{
    public partial class Form1 : Form
    {
        double a;
        double b;
        double c;
        double D;
        double x1;
        double x2;
        String messageError = String.Empty;
        public Form1()
        {
            InitializeComponent();
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            this.textBox3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            x1 = x2 = 0;
            
            
        }

        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Тут можно долго возиться и отлавливать верное введение числа
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8 && number != 44 && number != 45) // цифры, клавиша BackSpace и запятая
            {
                e.Handled = true;
            }
            
           
        }
     
        private void Button1_Click(object sender, EventArgs e)
        {
            int valErr = 0;
            int count = 0;
            messageError=String.Empty;
            richTextBox1.Clear();
            count += GetValueFromUser(textBox1, "a",ref a);
            count += GetValueFromUser(textBox2, "b", ref b);
            count += GetValueFromUser(textBox3, "c", ref c);
            if(a==0)
            {
                messageError += "Первый  коэффициент (a) не должен равняться 0. Повторите ввод. \n";
                textBox1.Text = String.Empty;
                this.ActiveControl = textBox1;
                count++;
            }
            if(b==0&&c==0)
            {
                messageError += "Уровнение не имеет смысла.\n";
                textBox2.Text = String.Empty;
                textBox3.Text = String.Empty;
                this.ActiveControl = textBox2;
                count++;
            }
            if (count != 0) MessageBox.Show(messageError);
            else ThinkEquation();

        }
        private void ThinkEquation()
        {
            richTextBox1.AppendText(QETools.QEToString(a,b,c)+"0\n");
            D = QETools.GetDiscriminant(a, b, c);
            if (D < 0) richTextBox1.AppendText(string.Format("Квадратное уровнение не имеет корней. D={0} (D<0) \n", D));
            else if (D == 0)
            {
                x1 = x2 = QETools.GetX1(D, b, a);
                richTextBox1.AppendText(string.Format("Уровнение имеет два равных корня x1=x2={0}\n", x1));

            }
            else if (D > 0)
            {
                x1 = QETools.GetX1(D, b, a);
                x2 = QETools.GetX2(D, b, a);
                richTextBox1.AppendText(string.Format("Уровнение имеет два корня x1={0}, x2={1}\n", x1, x2));
            }
            if (D >= 0)
            {
                
                    richTextBox1.AppendText(QETools.LinMult(a, b, c, x1, x2)+"\n");
                

            }

        }
        private int GetValueFromUser(TextBox txb,string koef,ref double val)
        {
            int valErr = 0;
            int count = 0;
            if (txb.Text != String.Empty)
            {
                try
                {
                    valErr = QETools.ParseValue(txb.Text, ref val);
                }
                catch (Exception ex)
                {
                    messageError += "Произошла непредвиденная ошибка. Повторите ввод. \n";
                    txb.Text = String.Empty;
                    this.ActiveControl = txb;
                    count = 1;

                }
                if (valErr != 0)
                {
                  
                    messageError += MessageError(koef, valErr);
                    txb.Text = String.Empty;
                    this.ActiveControl = txb;
                    count=1;
                }
            }
            else
            {
                count = 1;
                messageError += "Вы не ввели значение ("+koef+ ") .Повторите ввод.\n";
                this.ActiveControl = txb;
                val = -1;
            }    
                  

            return count;
        }
        private string MessageError(string val,int err)
        {
            string messageError = String.Empty;
            if (err == 1) messageError += "Ваше числo ("+val+") имеет не верный формат(возможно есть буквы в числе). Повторите ввод.\n";
            else if (err == 2) messageError += "Ваше числo (" + val + ") не входит в допустимый диапазон чисел. Повторите ввод.\n";
            return messageError;
        }
    }
}
