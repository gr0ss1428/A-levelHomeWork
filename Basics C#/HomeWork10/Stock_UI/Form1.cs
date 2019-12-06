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
    public partial class Form1 : Form
    {
        Stock stock;
        DateTime emulCurrenDate;
        public Form1()
        {
            stock = new Stock(1000);
            emulCurrenDate = DateTime.Now;
            InitializeComponent();
            stock.update += UpdateParam;
            labelStockFree.Text = $"{stock.CurrentVolume.ToString("0")}/{stock.MaxVolume.ToString("0")}";
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            stock.AddProduct(new SProduct("Макароны", 50, 10, 30));
            stock.AddProduct(new SProduct("Сыр", 150, 1, 20));
            stock.AddProduct(new SProduct("Молоко", 90, 1, 5));
            stock.AddProduct(new SProduct("Колбаса", 200, 5, 8));
            stock.AddProduct(new SProduct("Вода", 10, 1, 365));
            stock.AddProduct(new SProduct("Помидоры",23 , 1, 10));
            

        }
        public void UpdateParam()
        {
            labelStockFree.Text = $"{stock.CurrentVolume.ToString("0")}/{stock.MaxVolume.ToString("0")}";
            listViewBase.Clear();
            listViewBase.Columns.Add("№",50,HorizontalAlignment.Left);
            listViewBase.Columns.Add("Название",100, HorizontalAlignment.Left);
            listViewBase.Columns.Add("Цена", 100, HorizontalAlignment.Left);
            listViewBase.Columns.Add("Объем", 100, HorizontalAlignment.Left);
            listViewBase.Columns.Add("Дата поступления", 150, HorizontalAlignment.Left);
            listViewBase.Columns.Add("Срок годности", 100, HorizontalAlignment.Left);
            listViewBase.Columns.Add("Дата просрочки", 150, HorizontalAlignment.Left);
            int count = 1;
            foreach (var item in stock.GetSProductsArr())
            {
                ListViewItem listViewI = new ListViewItem(count.ToString());
                if (item.IsExpired(emulCurrenDate)) listViewI.ForeColor = Color.Red;
                listViewI.SubItems.Add(item.Name);
                listViewI.SubItems.Add(item.Price.ToString());
                listViewI.SubItems.Add(item.Volume.ToString());
                listViewI.SubItems.Add(item._DateReception.ToShortDateString());
                listViewI.SubItems.Add(item._ValidDay.ToString());
                listViewI.SubItems.Add(item.ExpiredDate().ToShortDateString());
                listViewBase.Items.Add(listViewI);
                count++;
            }

        }

        private void DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            emulCurrenDate = dateTimePicker1.Value;
            UpdateParam();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            stock.WriteOff(emulCurrenDate);
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            AddProduct addProduct = new AddProduct(stock,emulCurrenDate);
            addProduct.ShowDialog();
        }
    }
}
