using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameLib.Player;
using GameLib;
namespace UiGame
{
  
    public partial class Form1 : Form,IDisplay
    {
        IServer server;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            server = new Server(this);
        }
        public void DisplayInfo(string message)
        {
            richTextBoxInfoSters.Invoke(new Action(() => richTextBoxInfoSters.AppendText(message+"\n")));
        }
        public void Victory(string namePlayer)
        {
            MessageBox.Show($"Победил игрок {namePlayer}");
        }
        public void MassVictory(string message)
        {
            MessageBox.Show(message);
        }
        public void UpdateVictoryHistory(BasePlayer[] players )
        {
            listViewPlayersVictory.Invoke(new Action(()=>listViewPlayersVictory.Items.Clear()));
            for(int i=0;i<players.Length;i++)
            {
                ListViewItem item = new ListViewItem(players[i].Name);
                item.SubItems.Add(players[i].Wins.ToString());
                item.ToolTipText = players[i].Skills;
                listViewPlayersVictory.Invoke(new Action(() => listViewPlayersVictory.Items.Add(item)));
            }
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Button3_Click(object sender, EventArgs e)
        {
            richTextBoxInfoSters.Clear();
            Task.Factory.StartNew(() => server.NewTry());
        }
        public void ClearInfo()
        {
            richTextBoxInfoSters.Clear();
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            NewPlayer np = new NewPlayer(server, this);
            np.ShowDialog();
        }
        public void SetPumpkinWeight(int pumpkinWeight)
        {
            textBoxPumpWeight.Text = pumpkinWeight.ToString();
        }
        private void TextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8)
            {
                e.Handled = true;
            }
        }
        private void Button4_Click(object sender, EventArgs e)
        {
            int weight = 0;
            bool parseWeight = int.TryParse(textBoxPumpWeight.Text, out weight);
            if(parseWeight)
            {
                if(weight>=40&&weight<=140)
                {
                    server.NewPumpkinWeight(weight);
                }else MessageBox.Show("Вес тыквы в приделах от 40 до 140");
            }
            else MessageBox.Show("Введите вес тыквы");
        }
    }
}
