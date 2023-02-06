﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Diplom
{
    public partial class WishWindow : Form
    {
        string text;
        Color color;
        List<int?> idList;

        Dictionary<int, Teacher> teachers;
        Dictionary<int, Auditory> auditories;
        Dictionary<int, SubGroup> sub_groups_info;

        internal WishWindow(int type, ScheduleDataModel scheduleDataModel, List<int?> idList)
        {
            InitializeComponent();

            this.idList = idList;

            teachers = scheduleDataModel.GetTeachers();
            auditories = scheduleDataModel.GetAuditories();
            sub_groups_info = scheduleDataModel.GetGroups();

            if (type == 0)
                WishTeacher();
            if (type == 1)
                WishGroups();
            if (type == 2)
                WishAuditorys();

            text = null;
        }

        public void WishTeacher()
        {
            foreach (var teacher in teachers.SelectMany(teacher => idList.Where(id => teacher.Value.id == id).Select(id => new { }).Select(_ => teacher)))
            {
                for (int day = 0; day < 6; day++)
                {
                    for (int pair = 0; pair < 8; pair++)
                    {
                        for (int week = 0; week < 2; week++)
                        {
                            if (teacher.Value.wishes[day, pair, week] != null)
                            {
                                TextAndColor(teacher.Value.wishes[day, pair, week][0]);
                            }
                            else
                            {
                                color = Color.PowderBlue;
                                text = "";
                            }

                            DrawLabel(day, pair, week);
                        }
                    }
                }
            }
        }

        public void WishGroups()
        {
            foreach (var group in sub_groups_info.SelectMany(group => idList.Where(id => group.Value.id == id).Select(id => new { }).Select(_ => group)))
            {
                for (int day = 0; day < 6; day++)
                {
                    for (int pair = 0; pair < 8; pair++)
                    {
                        for (int week = 0; week < 2; week++)
                        {
                            if (group.Value.wishes[day, pair, week] != null)
                            {
                                TextAndColor(group.Value.wishes[day, pair, week][0]);
                            }
                            else
                            {
                                color = Color.PowderBlue;
                                text = "";
                            }

                            DrawLabel(day, pair, week);
                        }
                    }
                }
            }
        }

        public void WishAuditorys()
        {
            foreach (var aud in auditories.SelectMany(aud => idList.Where(id => aud.Value.id == id).Select(id => new { }).Select(_ => aud)))
            {
                for (int day = 0; day < 6; day++)
                {
                    for (int pair = 0; pair < 8; pair++)
                    {
                        for (int week = 0; week < 2; week++)
                        {
                            if (aud.Value.wishes[day, pair, week] != null)
                            {
                                TextAndColor(aud.Value.wishes[day, pair, week][0]);
                            }
                            else
                            {
                                color = Color.PowderBlue;
                                text = "";
                            }

                            DrawLabel(day, pair, week);
                        }
                    }
                }
            }
        }

        public void DrawLabel(int day, int pair, int week)
        {
            System.Windows.Forms.Label label = new System.Windows.Forms.Label
            {
                Size = new Size(34, 34),
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = color,
                Text = text
            };
            label.Click += Label_Click;

            DayMouseMove(label, day);
            PairMouseMove(label, pair);

            if (week % 2 == 1)
            {
                tableLayoutPanel1.Controls.Add(label, day * 2 + 1, pair);
            }
            else
            {
                tableLayoutPanel1.Controls.Add(label, day * 2, pair);
            }
        }

        private void PairMouseMove(System.Windows.Forms.Label label, int pair)
        {
            switch (pair)
            {
                case 0:
                    label.MouseMove += Label_MouseMove6;
                    break;
                case 1:
                    label.MouseMove += Label_MouseMove7;
                    break;
                case 2:
                    label.MouseMove += Label_MouseMove8;
                    break;
                case 3:
                    label.MouseMove += Label_MouseMove9;
                    break;
                case 4:
                    label.MouseMove += Label_MouseMove10;
                    break;
                case 5:
                    label.MouseMove += Label_MouseMove11;
                    break;
                case 6:
                    label.MouseMove += Label_MouseMove12;
                    break;
                case 7:
                    label.MouseMove += Label_MouseMove13;
                    break;
            }
        }

        public void DayMouseMove(System.Windows.Forms.Label label, int day)
        {
            switch (day)
            {
                case 0:
                    label.MouseMove += Label_MouseMove;
                    break;
                case 1:
                    label.MouseMove += Label_MouseMove1;
                    break;
                case 2:
                    label.MouseMove += Label_MouseMove2;
                    break;
                case 3:
                    label.MouseMove += Label_MouseMove3;
                    break;
                case 4:
                    label.MouseMove += Label_MouseMove4;
                    break;
                case 5:
                    label.MouseMove += Label_MouseMove5;
                    break;
            }
        }

        public void TextAndColor(int wish)
        {
            switch (wish)
            {
                case 1:
                    color = Color.LightGreen;
                    text = "О";
                    break;
                case 11:
                    color = Color.LightCoral;
                    text = "Д";
                    break;
                case 12:
                    color = Color.Turquoise;
                    text = "И";
                    break;
                case 14:
                    color = Color.HotPink;
                    text = "Ф";
                    break;
                case 15:
                    color = Color.CornflowerBlue;
                    text = "С";
                    break;
                case 16:
                    color = Color.Plum;
                    text = "К";
                    break;
                case 20:
                    color = Color.Gold;
                    text = "В";
                    break;
            }
        }

        private void Label_Click(object sender, EventArgs e)
        {
            if (text != null)
            {
                var label = sender as System.Windows.Forms.Label;
                label.Text = text;
                label.BackColor = color;
            }
        }

        private void Choice_Click(object sender, EventArgs e)
        {
            var button = sender as Button;
            text = button.Text;
            color = button.BackColor;
        }

        private void Accept_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void Release_MouseMove(object sender, MouseEventArgs e)
        {
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(sender as Button, "Освободить");
        }

        private void Kafedra_MouseMove(object sender, MouseEventArgs e)
        {
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(sender as Button, "Кафедра");
        }

        private void Sovet_MouseMove(object sender, MouseEventArgs e)
        {
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(sender as Button, "Совет");
        }

        private void Dovuzovskoye_MouseMove(object sender, MouseEventArgs e)
        {
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(sender as Button, "Довузовское образование");
        }

        private void Voyennaya_MouseMove(object sender, MouseEventArgs e)
        {
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(sender as Button, "Военная кафедра");
        }

        private void Language_MouseMove(object sender, MouseEventArgs e)
        {
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(sender as Button, "Иностранный язык");
        }

        private void PhysicalCulture_MouseMove(object sender, MouseEventArgs e)
        {
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(sender as Button, "Физическая культура");
        }

        private void Empty_MouseMove(object sender, MouseEventArgs e)
        {
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(sender as Button, "Пусто");
        }

        private void WishWindow_MouseMove(object sender, MouseEventArgs e)
        {
            Monday.BackColor = Color.FromArgb(255, 240, 240, 240);
            Tuesday.BackColor = Color.FromArgb(255, 240, 240, 240);
            Wednesday.BackColor = Color.FromArgb(255, 240, 240, 240);
            Thursday.BackColor = Color.FromArgb(255, 240, 240, 240);
            Friday.BackColor = Color.FromArgb(255, 240, 240, 240);
            Saturday.BackColor = Color.FromArgb(255, 240, 240, 240);

            Pair1.BackColor = Color.FromArgb(255, 240, 240, 240);
            Pair2.BackColor = Color.FromArgb(255, 240, 240, 240);
            Pair3.BackColor = Color.FromArgb(255, 240, 240, 240);
            Pair4.BackColor = Color.FromArgb(255, 240, 240, 240);
            Pair5.BackColor = Color.FromArgb(255, 240, 240, 240);
            Pair6.BackColor = Color.FromArgb(255, 240, 240, 240);
            Pair7.BackColor = Color.FromArgb(255, 240, 240, 240);
            Pair8.BackColor = Color.FromArgb(255, 240, 240, 240);
        }

        private void Label_MouseMove(object sender, MouseEventArgs e)
        {
            Monday.BackColor = Color.LightSteelBlue;
            Tuesday.BackColor = Color.FromArgb(255, 240, 240, 240);
            Wednesday.BackColor = Color.FromArgb(255, 240, 240, 240);
            Thursday.BackColor = Color.FromArgb(255, 240, 240, 240);
            Friday.BackColor = Color.FromArgb(255, 240, 240, 240);
            Saturday.BackColor = Color.FromArgb(255, 240, 240, 240);
        }

        private void Label_MouseMove1(object sender, MouseEventArgs e)
        {
            Monday.BackColor = Color.FromArgb(255, 240, 240, 240);
            Tuesday.BackColor = Color.LightSteelBlue;
            Wednesday.BackColor = Color.FromArgb(255, 240, 240, 240);
            Thursday.BackColor = Color.FromArgb(255, 240, 240, 240);
            Friday.BackColor = Color.FromArgb(255, 240, 240, 240);
            Saturday.BackColor = Color.FromArgb(255, 240, 240, 240);
        }

        private void Label_MouseMove2(object sender, MouseEventArgs e)
        {
            Monday.BackColor = Color.FromArgb(255, 240, 240, 240);
            Tuesday.BackColor = Color.FromArgb(255, 240, 240, 240);
            Wednesday.BackColor = Color.LightSteelBlue;
            Thursday.BackColor = Color.FromArgb(255, 240, 240, 240);
            Friday.BackColor = Color.FromArgb(255, 240, 240, 240);
            Saturday.BackColor = Color.FromArgb(255, 240, 240, 240);
        }

        private void Label_MouseMove3(object sender, MouseEventArgs e)
        {
            Monday.BackColor = Color.FromArgb(255, 240, 240, 240);
            Tuesday.BackColor = Color.FromArgb(255, 240, 240, 240);
            Wednesday.BackColor = Color.FromArgb(255, 240, 240, 240);
            Thursday.BackColor = Color.LightSteelBlue;
            Friday.BackColor = Color.FromArgb(255, 240, 240, 240);
            Saturday.BackColor = Color.FromArgb(255, 240, 240, 240);
        }

        private void Label_MouseMove4(object sender, MouseEventArgs e)
        {
            Monday.BackColor = Color.FromArgb(255, 240, 240, 240);
            Tuesday.BackColor = Color.FromArgb(255, 240, 240, 240);
            Wednesday.BackColor = Color.FromArgb(255, 240, 240, 240);
            Thursday.BackColor = Color.FromArgb(255, 240, 240, 240);
            Friday.BackColor = Color.LightSteelBlue;
            Saturday.BackColor = Color.FromArgb(255, 240, 240, 240);
        }

        private void Label_MouseMove5(object sender, MouseEventArgs e)
        {
            Monday.BackColor = Color.FromArgb(255, 240, 240, 240);
            Tuesday.BackColor = Color.FromArgb(255, 240, 240, 240);
            Wednesday.BackColor = Color.FromArgb(255, 240, 240, 240);
            Thursday.BackColor = Color.FromArgb(255, 240, 240, 240);
            Friday.BackColor = Color.FromArgb(255, 240, 240, 240);
            Saturday.BackColor = Color.LightSteelBlue;
        }

        private void Label_MouseMove6(object sender, MouseEventArgs e)
        {
            Pair1.BackColor = Color.LightSteelBlue;
            Pair2.BackColor = Color.FromArgb(255, 240, 240, 240);
            Pair3.BackColor = Color.FromArgb(255, 240, 240, 240);
            Pair4.BackColor = Color.FromArgb(255, 240, 240, 240);
            Pair5.BackColor = Color.FromArgb(255, 240, 240, 240);
            Pair6.BackColor = Color.FromArgb(255, 240, 240, 240);
            Pair7.BackColor = Color.FromArgb(255, 240, 240, 240);
            Pair8.BackColor = Color.FromArgb(255, 240, 240, 240);
        }

        private void Label_MouseMove7(object sender, MouseEventArgs e)
        {
            Pair1.BackColor = Color.FromArgb(255, 240, 240, 240);
            Pair2.BackColor = Color.LightSteelBlue;
            Pair3.BackColor = Color.FromArgb(255, 240, 240, 240);
            Pair4.BackColor = Color.FromArgb(255, 240, 240, 240);
            Pair5.BackColor = Color.FromArgb(255, 240, 240, 240);
            Pair6.BackColor = Color.FromArgb(255, 240, 240, 240);
            Pair7.BackColor = Color.FromArgb(255, 240, 240, 240);
            Pair8.BackColor = Color.FromArgb(255, 240, 240, 240);
        }

        private void Label_MouseMove8(object sender, MouseEventArgs e)
        {
            Pair1.BackColor = Color.FromArgb(255, 240, 240, 240);
            Pair2.BackColor = Color.FromArgb(255, 240, 240, 240);
            Pair3.BackColor = Color.LightSteelBlue;
            Pair4.BackColor = Color.FromArgb(255, 240, 240, 240);
            Pair5.BackColor = Color.FromArgb(255, 240, 240, 240);
            Pair6.BackColor = Color.FromArgb(255, 240, 240, 240);
            Pair7.BackColor = Color.FromArgb(255, 240, 240, 240);
            Pair8.BackColor = Color.FromArgb(255, 240, 240, 240);
        }

        private void Label_MouseMove9(object sender, MouseEventArgs e)
        {
            Pair1.BackColor = Color.FromArgb(255, 240, 240, 240);
            Pair2.BackColor = Color.FromArgb(255, 240, 240, 240);
            Pair3.BackColor = Color.FromArgb(255, 240, 240, 240);
            Pair4.BackColor = Color.LightSteelBlue;
            Pair5.BackColor = Color.FromArgb(255, 240, 240, 240);
            Pair6.BackColor = Color.FromArgb(255, 240, 240, 240);
            Pair7.BackColor = Color.FromArgb(255, 240, 240, 240);
            Pair8.BackColor = Color.FromArgb(255, 240, 240, 240);
        }

        private void Label_MouseMove10(object sender, MouseEventArgs e)
        {
            Pair1.BackColor = Color.FromArgb(255, 240, 240, 240);
            Pair2.BackColor = Color.FromArgb(255, 240, 240, 240);
            Pair3.BackColor = Color.FromArgb(255, 240, 240, 240);
            Pair4.BackColor = Color.FromArgb(255, 240, 240, 240);
            Pair5.BackColor = Color.LightSteelBlue;
            Pair6.BackColor = Color.FromArgb(255, 240, 240, 240);
            Pair7.BackColor = Color.FromArgb(255, 240, 240, 240);
            Pair8.BackColor = Color.FromArgb(255, 240, 240, 240);
        }

        private void Label_MouseMove11(object sender, MouseEventArgs e)
        {
            Pair1.BackColor = Color.FromArgb(255, 240, 240, 240);
            Pair2.BackColor = Color.FromArgb(255, 240, 240, 240);
            Pair3.BackColor = Color.FromArgb(255, 240, 240, 240);
            Pair4.BackColor = Color.FromArgb(255, 240, 240, 240);
            Pair5.BackColor = Color.FromArgb(255, 240, 240, 240);
            Pair6.BackColor = Color.LightSteelBlue;
            Pair7.BackColor = Color.FromArgb(255, 240, 240, 240);
            Pair8.BackColor = Color.FromArgb(255, 240, 240, 240);
        }

        private void Label_MouseMove12(object sender, MouseEventArgs e)
        {
            Pair1.BackColor = Color.FromArgb(255, 240, 240, 240);
            Pair2.BackColor = Color.FromArgb(255, 240, 240, 240);
            Pair3.BackColor = Color.FromArgb(255, 240, 240, 240);
            Pair4.BackColor = Color.FromArgb(255, 240, 240, 240);
            Pair5.BackColor = Color.FromArgb(255, 240, 240, 240);
            Pair6.BackColor = Color.FromArgb(255, 240, 240, 240);
            Pair7.BackColor = Color.LightSteelBlue;
            Pair8.BackColor = Color.FromArgb(255, 240, 240, 240);
        }

        private void Label_MouseMove13(object sender, MouseEventArgs e)
        {
            Pair1.BackColor = Color.FromArgb(255, 240, 240, 240);
            Pair2.BackColor = Color.FromArgb(255, 240, 240, 240);
            Pair3.BackColor = Color.FromArgb(255, 240, 240, 240);
            Pair4.BackColor = Color.FromArgb(255, 240, 240, 240);
            Pair5.BackColor = Color.FromArgb(255, 240, 240, 240);
            Pair6.BackColor = Color.FromArgb(255, 240, 240, 240);
            Pair7.BackColor = Color.FromArgb(255, 240, 240, 240);
            Pair8.BackColor = Color.LightSteelBlue;
        }
    }
}