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
                comboBoxSkills.Items.Add(skill);
            }
            comboBoxSkills.SelectedIndex = 0;
            textBoxPumpWeight.Text = "120";
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Button3_Click(object sender, EventArgs e)
        {
            if(textBoxNamePlayer.Text==String.Empty)
            {
                MessageBox.Show("Введите имя игрока");
            }
            else
            {
                if (players.Count < 8)
                {
                    players.Add(new TempPlayer(textBoxNamePlayer.Text,comboBoxSkills.SelectedIndex));
                    listViewPlayersAdd.Items.Add(new ListViewItem(new string[] { textBoxNamePlayer.Text, Skills.SkillsPlayerStr[comboBoxSkills.SelectedIndex] }));
                }
                else buttonAddPlayer.Enabled = false;
            }
            textBoxNamePlayer.Text = String.Empty;
            comboBoxSkills.SelectedIndex = 0;
        }
        private void Button4_Click(object sender, EventArgs e)
        {
            buttonAddPlayer.Enabled = true;
            textBoxNamePlayer.Text = String.Empty;
            comboBoxSkills.SelectedIndex = 0;
            players.Clear();
            listViewPlayersAdd.Items.Clear();
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            if (textBoxPumpWeight.Text != String.Empty && players.Count >=2)
            {
                int weight = 0;
                bool parseWeight = int.TryParse(textBoxPumpWeight.Text, out weight);
                if (parseWeight && weight >= 40 && weight <= 140)
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
                if(textBoxPumpWeight.Text==String.Empty) MessageBox.Show("Введите вес тыквы");
                if(players.Count<2) MessageBox.Show("Введите больше игроков");
            }
        }
        private void TextBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8)//цифры и Backspace
            {
                e.Handled = true;
            }
        }
        private void Button5_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Skills.SkillsPlayerStr.Count; i++)
            {
                players.Add(new TempPlayer(Skills.SkillsPlayerStr[i], i));
                listViewPlayersAdd.Items.Add(new ListViewItem(new string[] { Skills.SkillsPlayerStr[i], Skills.SkillsPlayerStr[i] }));
            }
        }
    }
}
