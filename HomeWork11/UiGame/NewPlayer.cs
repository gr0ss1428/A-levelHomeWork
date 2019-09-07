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
    public partial class NewPlayer : Form
    {
        struct TempPlayer
        {
            public string name;
            public int skills;
            public TempPlayer(string name,int skills)
            {
                this.name = name;
                this.skills = skills;
            }
        }
        Form1 view;
        List<TempPlayer> players;
        IServer server;
        public NewPlayer()
        {
            InitializeComponent();
        }
        public NewPlayer(IServer server,Form1 form1)
        {
            InitializeComponent();
            this.server = server;
            view = form1;
            players = new List<TempPlayer>();
            foreach (var skill in Skills.SkillsPlayerStr)
            {
                comboBox1.Items.Add(skill);
            }
            comboBox1.SelectedIndex = 0;
            textBox2.Text = "120";
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Button3_Click(object sender, EventArgs e)
        {
            if(textBox1.Text==String.Empty)
            {
                MessageBox.Show("Введите имя игрока");
            }
            else
            {
                if (players.Count < 8)
                {
                    players.Add(new TempPlayer(textBox1.Text,comboBox1.SelectedIndex));
                    listView1.Items.Add(new ListViewItem(new string[] { textBox1.Text, Skills.SkillsPlayerStr[comboBox1.SelectedIndex] }));
                }
                else button3.Enabled = false;
            }
            textBox1.Text = String.Empty;
            comboBox1.SelectedIndex = 0;
        }
        private void Button4_Click(object sender, EventArgs e)
        {
            button3.Enabled = true;
            textBox1.Text = String.Empty;
            comboBox1.SelectedIndex = 0;
            players.Clear();
            listView1.Items.Clear();
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != String.Empty && players.Count >=2)
            {
                int weight = 0;
                bool parse = int.TryParse(textBox2.Text, out weight);
                if (parse && weight >= 40 && weight <= 140)
                {
                    server.ClearPlayer();
                    view.ClearInfo();
                    foreach (var p in players)
                    {
                        server.AddPlayer(p.name, (Skills.SkillsPlayerEnum)p.skills);
                    }
                    view.SetPumpkinWeight(weight);
                    server.NewPumpkinWeight(weight);
                    server.UpdateVictory(); 
                    Task.Factory.StartNew(() => server.NewTry());
                    this.Close();
                }
                else MessageBox.Show("Вес тыквы в приделах от 40 до 140");
            }
            else
            {
                if(textBox2.Text==String.Empty) MessageBox.Show("Введите вес тыквы");
                if(players.Count<2) MessageBox.Show("Введите больше игроков");
            }
        }
        private void TextBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8)
            {
                e.Handled = true;
            }
        }
        private void Button5_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Skills.SkillsPlayerStr.Count; i++)
            {
                players.Add(new TempPlayer(Skills.SkillsPlayerStr[i], i));
                listView1.Items.Add(new ListViewItem(new string[] { Skills.SkillsPlayerStr[i], Skills.SkillsPlayerStr[i] }));
            }
        }
    }
}
