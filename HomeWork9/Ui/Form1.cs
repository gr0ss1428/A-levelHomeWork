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
    enum ListNow
    {
        STUDENT, TEACHER
    }
    public partial class Form1 : Form
    {
        internal Manager managerGroup;
        ListNow now;
        public Form1()
        {
            InitializeComponent();
            managerGroup = new Manager();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            managerGroup.NewTeaher(new Teacher("Иван", "Иванов", 30, "Доцент", 20));
            managerGroup.NewTeaher(new Teacher("Петр", "Петров", 30, "Лектор", 15));
            managerGroup.NewTeaher(new Teacher("Василий", "Васильев", 30, "Ассистент", 5));

            var t = managerGroup.GetTeacherArr().ToArray();
            managerGroup.NewGroup(5, t[0]);
            managerGroup.NewGroup(2, t[1]);
            managerGroup.NewGroup(3, t[2]);

            managerGroup.NewStudent(new Student("Сергей", "Сергеев", 18, 5));
            managerGroup.NewStudent(new Student("Дмитрий", "Ульянов", 18, 2));
            managerGroup.NewStudent(new Student("Андей", "Андреев", 18, 3));

            now = ListNow.TEACHER;
            this.ButtonTeacher_Click(buttonTeacher, null);
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void ButtonTeacher_Click(object sender, EventArgs e)
        {
            comboBox1.Visible = true;
            now = ListNow.TEACHER;
            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(new object[] { "ВСЕ", "Доцент", "Лектор", "Ассистент" });
            comboBox1.SelectedIndex = 0;
            PrintTeacher();
        }
        private void ButtonStudent_Click(object sender, EventArgs e)
        {
            comboBox1.Visible = true;
            now = ListNow.STUDENT;
            comboBox1.Items.Clear();
            comboBox1.Items.Add("ВСЕ");
            uint[] groups = managerGroup.GetGroups();
            foreach (var g in groups)
            {
                comboBox1.Items.Add(g);
            }
            comboBox1.SelectedIndex = 0;
            PrintStudents("ВСЕ");
        }
        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (now == ListNow.TEACHER)
            {
                PrintTeacher((string)comboBox1.SelectedItem);
            }
            else if (now == ListNow.STUDENT)
            {
                PrintStudents(comboBox1.SelectedItem);
            }
        }
        private void PrintStudents(object ob)
        {
            SetColumnStudent();
            int count = 1;
            foreach (var t in managerGroup.GetStudentsArr(ob))
            {
                ListViewItem item = new ListViewItem(count.ToString(), 0);
                item.SubItems.Add(t.Surname);
                item.SubItems.Add(t.Name);
                item.SubItems.Add(t.Age.ToString());
                item.SubItems.Add(t.Group.ToString());
                listView1.Items.Add(item);
                count++;
            }
        }
        private void PrintTeacher(string pos = "ВСЕ")
        {
            int count = 1;
            SetColumnTeacher();
            foreach (var t in managerGroup.GetTeacherArr(pos))
            {
                ListViewItem item = new ListViewItem(count.ToString(), 0);
                item.SubItems.Add(t.Surname);
                item.SubItems.Add(t.Name);
                item.SubItems.Add(t.Age.ToString());
                item.SubItems.Add(t.Position);
                item.SubItems.Add(t.MaxStudentsInGroup.ToString());
                listView1.Items.Add(item);
                count++;
            }
        }
        private void SetColumnTeacher()
        {
            listView1.Clear();
            listView1.Columns.Add("№", 50, HorizontalAlignment.Left);
            listView1.Columns.Add("Фамилия", 100, HorizontalAlignment.Left);
            listView1.Columns.Add("Имя", 100, HorizontalAlignment.Left);
            listView1.Columns.Add("Возраст", 100, HorizontalAlignment.Left);
            listView1.Columns.Add("Должность", 100, HorizontalAlignment.Left);
            listView1.Columns.Add("Кол-во слушателей в группе", 200, HorizontalAlignment.Left);
        }
        private void SetColumnStudent()
        {
            listView1.Clear();
            listView1.Columns.Add("№", 50, HorizontalAlignment.Left);
            listView1.Columns.Add("Фамилия", 100, HorizontalAlignment.Left);
            listView1.Columns.Add("Имя", 100, HorizontalAlignment.Left);
            listView1.Columns.Add("Возраст", 100, HorizontalAlignment.Left);
            listView1.Columns.Add("Группа", 100, HorizontalAlignment.Left);
        }
        private void ButtonNewStudent_Click(object sender, EventArgs e)
        {
            NewStudent newStudent = new NewStudent(managerGroup);
            newStudent.ShowDialog();
            PrintStudents("ВСЕ");
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            comboBox1.Visible = false;
            listView1.Clear();
            listView1.Columns.Add("№", 50, HorizontalAlignment.Left);
            listView1.Columns.Add("Группа №", 100, HorizontalAlignment.Left);
            listView1.Columns.Add("Преподаватель", 100, HorizontalAlignment.Left);
            listView1.Columns.Add("Кол-во", 100, HorizontalAlignment.Left);
            listView1.Columns.Add("Свободно", 100, HorizontalAlignment.Left);
            int count = 1;
            foreach (var g in managerGroup.GetGroupsOb().OrderBy(g=>g.Number))
            {
                ListViewItem item = new ListViewItem(count.ToString(), 0);
                item.SubItems.Add(g.Number.ToString());
                item.SubItems.Add(g.Teacher.Surname);
                item.SubItems.Add(g.CurrentLength.ToString());
                item.SubItems.Add(g.GetFree().ToString());
                listView1.Items.Add(item);
                count++;
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            NewTeacher nt = new NewTeacher(managerGroup);
            nt.ShowDialog();
            PrintTeacher();
        }
        private void Button4_Click(object sender, EventArgs e)
        {
            NewGroup ng = new NewGroup(managerGroup);
            ng.ShowDialog();
            Button2_Click(null, null);
        }
    }
}
