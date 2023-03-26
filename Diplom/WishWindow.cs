using System;
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
        int type;

        Dictionary<int, Teacher> teachers;
        Dictionary<int, Auditory> auditories;
        Dictionary<int, SubGroup> sub_groups_info;

        ScheduleDataModel scheduleDataModel;

        internal WishWindow(int type, ScheduleDataModel scheduleDataModel, List<int?> idList)
        {
            InitializeComponent();

            this.idList = idList;
            this.scheduleDataModel = scheduleDataModel;
            this.type = type;

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

            switch (week % 2)
            {
                case 1:
                    tableLayoutPanel1.Controls.Add(label, day * 2 + 1, pair);
                    break;
                default:
                    tableLayoutPanel1.Controls.Add(label, day * 2, pair);
                    break;
            }
        }

        private void PairMouseMove(System.Windows.Forms.Label label, int pair)
        {
            switch (pair)
            {
                case 0:
                    label.MouseMove += Pair1_MouseMove;
                    break;
                case 1:
                    label.MouseMove += Pair2_MouseMove;
                    break;
                case 2:
                    label.MouseMove += Pair3_MouseMove;
                    break;
                case 3:
                    label.MouseMove += Pair4_MouseMove;
                    break;
                case 4:
                    label.MouseMove += Pair5_MouseMove;
                    break;
                case 5:
                    label.MouseMove += Pair6_MouseMove;
                    break;
                case 6:
                    label.MouseMove += Pair7_MouseMove;
                    break;
                case 7:
                    label.MouseMove += Pair8_MouseMove;
                    break;
            }
        }

        public void DayMouseMove(System.Windows.Forms.Label label, int day)
        {
            switch (day)
            {
                case 0:
                    label.MouseMove += Monday_MouseMove;
                    break;
                case 1:
                    label.MouseMove += Tuesday_MouseMove;
                    break;
                case 2:
                    label.MouseMove += Wednesday_MouseMove;
                    break;
                case 3:
                    label.MouseMove += Thursday_MouseMove;
                    break;
                case 4:
                    label.MouseMove += Friday_MouseMove;
                    break;
                case 5:
                    label.MouseMove += Saturday_MouseMove;
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
            if (type == 0)
            {
                SaveTeacher();
                (scheduleDataModel as JsonScheduleDataModel).teacher = teachers;
            }
            if (type == 1)
            {
                SaveGroup();
                (scheduleDataModel as JsonScheduleDataModel).teacher = teachers;
            }
                SaveGroup();
            if (type == 2)
                SaveAud();

            (scheduleDataModel as JsonScheduleDataModel).teacher = teachers;
            scheduleDataModel.Save();
            this.DialogResult = DialogResult.OK;
        }

        public void SaveTeacher()
        {
            foreach (var teacher in teachers.SelectMany(teacher => idList.Where(id => teacher.Value.id == id).Select(id => new { }).Select(_ => teacher)))
            {
                for (int i = 0; i < tableLayoutPanel1.ColumnCount; i++)
                {
                    for (int j = 0; j < tableLayoutPanel1.RowCount; j++)
                    {
                        int wish = 0;
                        switch (tableLayoutPanel1.GetControlFromPosition(i, j).Text)
                        {
                            case "О":
                                wish = 1;
                                break;
                            case "Д":
                                wish = 11;
                                break;
                            case "И":
                                wish = 12;
                                break;
                            case "Ф":
                                wish = 14;
                                break;
                            case "С":
                                wish = 15;
                                break;
                            case "К":
                                wish = 16;
                                break;
                            case "В":
                                wish = 20;
                                break;
                            case "":
                                wish = 10;
                                break;
                        }

                        if (tableLayoutPanel1.GetControlFromPosition(i, j).Text != "")
                        {
                            if (i % 2 == 0)
                            {
                                teacher.Value.wishes[i / 2, j, 0] = new int[] { wish };
                            }
                            else
                            {
                                teacher.Value.wishes[(i - 1) / 2, j, 1] = new int[] { wish };
                            }
                        }
                        else
                        {
                            if (i % 2 == 0)
                            {
                                teacher.Value.wishes[i / 2, j, 0] = null;
                            }
                            else
                            {
                                teacher.Value.wishes[(i - 1) / 2, j, 1] = null;
                            }
                        }
                    }
                }
            }
        }

        public void SaveGroup()
        {
            foreach (var group in sub_groups_info.SelectMany(group => idList.Where(id => group.Value.id == id).Select(id => new { }).Select(_ => group)))
            {
                for (int i = 0; i < tableLayoutPanel1.ColumnCount; i++)
                {
                    for (int j = 0; j < tableLayoutPanel1.RowCount; j++)
                    {
                        int wish = 0;
                        switch (tableLayoutPanel1.GetControlFromPosition(i, j).Text)
                        {
                            case "О":
                                wish = 1;
                                break;
                            case "Д":
                                wish = 11;
                                break;
                            case "И":
                                wish = 12;
                                break;
                            case "Ф":
                                wish = 14;
                                break;
                            case "С":
                                wish = 15;
                                break;
                            case "К":
                                wish = 16;
                                break;
                            case "В":
                                wish = 20;
                                break;
                            case "":
                                wish = 10;
                                break;
                        }

                        if (tableLayoutPanel1.GetControlFromPosition(i, j).Text != "")
                        {
                            if (i % 2 == 0)
                            {
                                group.Value.wishes[i / 2, j, 0] = new int[] { wish };
                            }
                            else
                            {
                                group.Value.wishes[(i - 1) / 2, j, 1] = new int[] { wish };
                            }
                        }
                        else
                        {
                            if (i % 2 == 0)
                            {
                                group.Value.wishes[i / 2, j, 0] = null;
                            }
                            else
                            {
                                group.Value.wishes[(i - 1) / 2, j, 1] = null;
                            }
                        }
                    }
                }
            }
        }

        public void SaveAud()
        {
            foreach (var aud in auditories.SelectMany(aud => idList.Where(id => aud.Value.id == id).Select(id => new { }).Select(_ => aud)))
            {
                for (int i = 0; i < tableLayoutPanel1.ColumnCount; i++)
                {
                    for (int j = 0; j < tableLayoutPanel1.RowCount; j++)
                    {
                        int wish = 0;
                        switch (tableLayoutPanel1.GetControlFromPosition(i, j).Text)
                        {
                            case "О":
                                wish = 1;
                                break;
                            case "Д":
                                wish = 11;
                                break;
                            case "И":
                                wish = 12;
                                break;
                            case "Ф":
                                wish = 14;
                                break;
                            case "С":
                                wish = 15;
                                break;
                            case "К":
                                wish = 16;
                                break;
                            case "В":
                                wish = 20;
                                break;
                            case "":
                                wish = 10;
                                break;
                        }

                        if (tableLayoutPanel1.GetControlFromPosition(i, j).Text != "")
                        {
                            if (i % 2 == 0)
                            {
                                aud.Value.wishes[i / 2, j, 0] = new int[] { wish };
                            }
                            else
                            {
                                aud.Value.wishes[(i - 1) / 2, j, 1] = new int[] { wish };
                            }
                        }
                        else
                        {
                            if (i % 2 == 0)
                            {
                                aud.Value.wishes[i / 2, j, 0] = null;
                            }
                            else
                            {
                                aud.Value.wishes[(i - 1) / 2, j, 1] = null;
                            }
                        }
                    }
                }
            }
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

        private void Monday_MouseMove(object sender, MouseEventArgs e)
        {
            Monday.BackColor = Color.LightSteelBlue;
            Tuesday.BackColor = Color.FromArgb(255, 240, 240, 240);
            Wednesday.BackColor = Color.FromArgb(255, 240, 240, 240);
            Thursday.BackColor = Color.FromArgb(255, 240, 240, 240);
            Friday.BackColor = Color.FromArgb(255, 240, 240, 240);
            Saturday.BackColor = Color.FromArgb(255, 240, 240, 240);
        }

        private void Tuesday_MouseMove(object sender, MouseEventArgs e)
        {
            Monday.BackColor = Color.FromArgb(255, 240, 240, 240);
            Tuesday.BackColor = Color.LightSteelBlue;
            Wednesday.BackColor = Color.FromArgb(255, 240, 240, 240);
            Thursday.BackColor = Color.FromArgb(255, 240, 240, 240);
            Friday.BackColor = Color.FromArgb(255, 240, 240, 240);
            Saturday.BackColor = Color.FromArgb(255, 240, 240, 240);
        }

        private void Wednesday_MouseMove(object sender, MouseEventArgs e)
        {
            Monday.BackColor = Color.FromArgb(255, 240, 240, 240);
            Tuesday.BackColor = Color.FromArgb(255, 240, 240, 240);
            Wednesday.BackColor = Color.LightSteelBlue;
            Thursday.BackColor = Color.FromArgb(255, 240, 240, 240);
            Friday.BackColor = Color.FromArgb(255, 240, 240, 240);
            Saturday.BackColor = Color.FromArgb(255, 240, 240, 240);
        }

        private void Thursday_MouseMove(object sender, MouseEventArgs e)
        {
            Monday.BackColor = Color.FromArgb(255, 240, 240, 240);
            Tuesday.BackColor = Color.FromArgb(255, 240, 240, 240);
            Wednesday.BackColor = Color.FromArgb(255, 240, 240, 240);
            Thursday.BackColor = Color.LightSteelBlue;
            Friday.BackColor = Color.FromArgb(255, 240, 240, 240);
            Saturday.BackColor = Color.FromArgb(255, 240, 240, 240);
        }

        private void Friday_MouseMove(object sender, MouseEventArgs e)
        {
            Monday.BackColor = Color.FromArgb(255, 240, 240, 240);
            Tuesday.BackColor = Color.FromArgb(255, 240, 240, 240);
            Wednesday.BackColor = Color.FromArgb(255, 240, 240, 240);
            Thursday.BackColor = Color.FromArgb(255, 240, 240, 240);
            Friday.BackColor = Color.LightSteelBlue;
            Saturday.BackColor = Color.FromArgb(255, 240, 240, 240);
        }

        private void Saturday_MouseMove(object sender, MouseEventArgs e)
        {
            Monday.BackColor = Color.FromArgb(255, 240, 240, 240);
            Tuesday.BackColor = Color.FromArgb(255, 240, 240, 240);
            Wednesday.BackColor = Color.FromArgb(255, 240, 240, 240);
            Thursday.BackColor = Color.FromArgb(255, 240, 240, 240);
            Friday.BackColor = Color.FromArgb(255, 240, 240, 240);
            Saturday.BackColor = Color.LightSteelBlue;
        }

        private void Pair1_MouseMove(object sender, MouseEventArgs e)
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

        private void Pair2_MouseMove(object sender, MouseEventArgs e)
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

        private void Pair3_MouseMove(object sender, MouseEventArgs e)
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

        private void Pair4_MouseMove(object sender, MouseEventArgs e)
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

        private void Pair5_MouseMove(object sender, MouseEventArgs e)
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

        private void Pair6_MouseMove(object sender, MouseEventArgs e)
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

        private void Pair7_MouseMove(object sender, MouseEventArgs e)
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

        private void Pair8_MouseMove(object sender, MouseEventArgs e)
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