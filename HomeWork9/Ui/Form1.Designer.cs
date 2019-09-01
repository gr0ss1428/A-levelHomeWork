namespace Ui
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
            this.button1 = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.buttonStudent = new System.Windows.Forms.Button();
            this.buttonTeacher = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.buttonNewStudent = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(717, 418);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Выход";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // listView1
            // 
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(8, 76);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(670, 365);
            this.listView1.TabIndex = 2;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // buttonStudent
            // 
            this.buttonStudent.Location = new System.Drawing.Point(12, 18);
            this.buttonStudent.Name = "buttonStudent";
            this.buttonStudent.Size = new System.Drawing.Size(75, 23);
            this.buttonStudent.TabIndex = 3;
            this.buttonStudent.Text = "Студенты";
            this.buttonStudent.UseVisualStyleBackColor = true;
            this.buttonStudent.Click += new System.EventHandler(this.ButtonStudent_Click);
            // 
            // buttonTeacher
            // 
            this.buttonTeacher.Location = new System.Drawing.Point(93, 18);
            this.buttonTeacher.Name = "buttonTeacher";
            this.buttonTeacher.Size = new System.Drawing.Size(105, 23);
            this.buttonTeacher.TabIndex = 4;
            this.buttonTeacher.Text = "Преподаватели";
            this.buttonTeacher.UseVisualStyleBackColor = true;
            this.buttonTeacher.Click += new System.EventHandler(this.ButtonTeacher_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(13, 48);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(85, 21);
            this.comboBox1.TabIndex = 5;
            this.comboBox1.Visible = false;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.ComboBox1_SelectedIndexChanged);
            // 
            // buttonNewStudent
            // 
            this.buttonNewStudent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonNewStudent.Location = new System.Drawing.Point(684, 12);
            this.buttonNewStudent.Name = "buttonNewStudent";
            this.buttonNewStudent.Size = new System.Drawing.Size(108, 23);
            this.buttonNewStudent.TabIndex = 6;
            this.buttonNewStudent.Text = "Новый студент";
            this.buttonNewStudent.UseVisualStyleBackColor = true;
            this.buttonNewStudent.Click += new System.EventHandler(this.ButtonNewStudent_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(204, 18);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "Группы";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.Location = new System.Drawing.Point(684, 47);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(108, 23);
            this.button3.TabIndex = 8;
            this.button3.Text = "Новый препод";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.Button3_Click);
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button4.Location = new System.Drawing.Point(684, 81);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(108, 23);
            this.button4.TabIndex = 9;
            this.button4.Text = "Новая группа";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.Button4_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.buttonNewStudent);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.buttonTeacher);
            this.Controls.Add(this.buttonStudent);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button buttonStudent;
        private System.Windows.Forms.Button buttonTeacher;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button buttonNewStudent;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
    }
}

