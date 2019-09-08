using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProductStock;

namespace Stock_UI
{
    public partial class AddProduct : Form
    {
        Stock mainStock;
        DateTime currDt;
        public AddProduct()
        {
            InitializeComponent();
        }
        public AddProduct(Stock stock, DateTime currentDate)
        {
            mainStock = stock;
            currDt = currentDate;

            InitializeComponent();
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            string name = textBoxName.Text;
            int price = 0;
            bool parsePrice = int.TryParse(textBoxPrice.Text, out price);
            double volume = 0;
            bool parseVolume = double.TryParse(textBoxVolume.Text, out volume);
            int validDay = 0;
            bool parseValidDay = int.TryParse(textBoxValidDay.Text, out validDay);
            string message = String.Empty;
            if (name == String.Empty) message += "Введите название\n";
            if (!parsePrice) message += "Введите цену\n";
            if (!parseVolume) message += "Введите вес\n";
            if (!parseValidDay) message += "Введите срок годности\n";
            if (message != String.Empty)
            {
                MessageBox.Show(message);
            }
            else
            {
                if (volume > mainStock.CurrentFreeSpace())
                {
                    if (mainStock.CurrentFreeSpace() != 0)
                    {
                        MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                        DialogResult result;
                        result = MessageBox.Show($"На складе осталось места {mainStock.CurrentFreeSpace()} тонн, добавить?", "", buttons);
                        if (result == DialogResult.Yes)
                        {
                            mainStock.AddProduct(new SProduct(name, price, mainStock.CurrentFreeSpace(), validDay, dateTimePickerProductInBase.Value));
                            this.Close();
                        }
                    }
                    else MessageBox.Show($"На складе не хватает места.");
                }
                else
                {
                    mainStock.AddProduct(new SProduct(name, price, volume, validDay, dateTimePickerProductInBase.Value));
                    this.Close();
                }
            }
        }
        private void TextBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8) //цифры + Backspace
            {
                e.Handled = true;
            }
        }
        private void AddProduct_Load(object sender, EventArgs e)
        {
            dateTimePickerProductInBase.Value = currDt;
        }
    }
}
