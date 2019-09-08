namespace UiGame
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.richTextBoxInfoSters = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonNewPlayers = new System.Windows.Forms.Button();
            this.buttonNewTry = new System.Windows.Forms.Button();
            this.listViewPlayersVictory = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxPumpWeight = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // richTextBoxInfoSters
            // 
            this.richTextBoxInfoSters.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxInfoSters.Location = new System.Drawing.Point(12, 70);
            this.richTextBoxInfoSters.Name = "richTextBoxInfoSters";
            this.richTextBoxInfoSters.ReadOnly = true;
            this.richTextBoxInfoSters.Size = new System.Drawing.Size(678, 548);
            this.richTextBoxInfoSters.TabIndex = 0;
            this.richTextBoxInfoSters.Text = "";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(856, 595);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Выход";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // buttonNewPlayers
            // 
            this.buttonNewPlayers.Location = new System.Drawing.Point(12, 12);
            this.buttonNewPlayers.Name = "buttonNewPlayers";
            this.buttonNewPlayers.Size = new System.Drawing.Size(102, 23);
            this.buttonNewPlayers.TabIndex = 2;
            this.buttonNewPlayers.Text = "Новые игроки";
            this.buttonNewPlayers.UseVisualStyleBackColor = true;
            this.buttonNewPlayers.Click += new System.EventHandler(this.Button2_Click);
            // 
            // buttonNewTry
            // 
            this.buttonNewTry.Location = new System.Drawing.Point(121, 12);
            this.buttonNewTry.Name = "buttonNewTry";
            this.buttonNewTry.Size = new System.Drawing.Size(102, 23);
            this.buttonNewTry.TabIndex = 3;
            this.buttonNewTry.Text = "Новая попытка";
            this.buttonNewTry.UseVisualStyleBackColor = true;
            this.buttonNewTry.Click += new System.EventHandler(this.Button3_Click);
            // 
            // listViewPlayersVictory
            // 
            this.listViewPlayersVictory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewPlayersVictory.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listViewPlayersVictory.GridLines = true;
            this.listViewPlayersVictory.HideSelection = false;
            this.listViewPlayersVictory.Location = new System.Drawing.Point(696, 70);
            this.listViewPlayersVictory.Name = "listViewPlayersVictory";
            this.listViewPlayersVictory.Scrollable = false;
            this.listViewPlayersVictory.ShowItemToolTips = true;
            this.listViewPlayersVictory.Size = new System.Drawing.Size(235, 331);
            this.listViewPlayersVictory.TabIndex = 4;
            this.listViewPlayersVictory.UseCompatibleStateImageBehavior = false;
            this.listViewPlayersVictory.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Имя";
            this.columnHeader1.Width = 150;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Победы";
            this.columnHeader2.Width = 82;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(424, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Вес тыквы: ";
            // 
            // textBoxPumpWeight
            // 
            this.textBoxPumpWeight.Location = new System.Drawing.Point(499, 13);
            this.textBoxPumpWeight.Name = "textBoxPumpWeight";
            this.textBoxPumpWeight.Size = new System.Drawing.Size(61, 20);
            this.textBoxPumpWeight.TabIndex = 6;
            this.textBoxPumpWeight.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox1_KeyPress);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(584, 12);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 7;
            this.button4.Text = "Задать";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.Button4_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(941, 630);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.textBoxPumpWeight);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listViewPlayersVictory);
            this.Controls.Add(this.buttonNewTry);
            this.Controls.Add(this.buttonNewPlayers);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.richTextBoxInfoSters);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "Game";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBoxInfoSters;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button buttonNewPlayers;
        private System.Windows.Forms.Button buttonNewTry;
        private System.Windows.Forms.ListView listViewPlayersVictory;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxPumpWeight;
        private System.Windows.Forms.Button button4;
    }
}

