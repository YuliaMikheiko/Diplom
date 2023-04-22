using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
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

            switch (type)
            {
                case 0:
                    WishTeacher();
                    break;
                case 1:
                    WishGroups();
                    break;
                case 2:
                    WishAuditorys();
                    break;
            }

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
            Label label = new Label
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

        private void PairMouseMove(Label label, int pair)
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

        public void DayMouseMove(Label label, int day)
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
                var label = sender as Label;
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
            switch (type)
            {
                case 0:
                    SaveTeacher();
                    (scheduleDataModel as JsonScheduleDataModel).teacher = teachers;
                    break;
                case 1:
                    SaveGroup();
                    (scheduleDataModel as JsonScheduleDataModel).subGroup = sub_groups_info;
                    break;
                case 2:
                    (scheduleDataModel as JsonScheduleDataModel).auditory = auditories;
                    SaveAud();
                    break;
            }

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
                        int wish = w(i, j);

                        if (tableLayoutPanel1.GetControlFromPosition(i, j).Text != "")
                        {
                            switch (i % 2)
                            {
                                case 0:
                                    teacher.Value.wishes[i / 2, j, 0] = new int[] { wish };
                                    break;
                                default:
                                    teacher.Value.wishes[(i - 1) / 2, j, 1] = new int[] { wish };
                                    break;
                            }
                        }
                        else
                        {
                            switch (i % 2)
                            {
                                case 0:
                                    teacher.Value.wishes[i / 2, j, 0] = null;
                                    break;
                                default:
                                    teacher.Value.wishes[(i - 1) / 2, j, 1] = null;
                                    break;
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
                        int wish = w(i, j);

                        if (tableLayoutPanel1.GetControlFromPosition(i, j).Text != "")
                        {
                            switch (i % 2)
                            {
                                case 0:
                                    group.Value.wishes[i / 2, j, 0] = new int[] { wish };
                                    break;
                                default:
                                    group.Value.wishes[(i - 1) / 2, j, 1] = new int[] { wish };
                                    break;
                            }
                        }
                        else
                        {
                            switch (i % 2)
                            {
                                case 0:
                                    group.Value.wishes[i / 2, j, 0] = null;
                                    break;
                                default:
                                    group.Value.wishes[(i - 1) / 2, j, 1] = null;
                                    break;
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
                        int wish = w(i,j);

                        if (tableLayoutPanel1.GetControlFromPosition(i, j).Text != "")
                        {
                            switch (i % 2)
                            {
                                case 0:
                                    aud.Value.wishes[i / 2, j, 0] = new int[] { wish };
                                    break;
                                default:
                                    aud.Value.wishes[(i - 1) / 2, j, 1] = new int[] { wish };
                                    break;
                            }
                        }
                        else
                        {
                            switch (i % 2)
                            {
                                case 0:
                                    aud.Value.wishes[i / 2, j, 0] = null;
                                    break;
                                default:
                                    aud.Value.wishes[(i - 1) / 2, j, 1] = null;
                                    break;
                            }
                        }
                    }
                }
            }
        }

        public int w(int i, int j)
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
            return wish;
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
            ColorDay(6);
            ColorPair(9);
        }

        private void Monday_MouseMove(object sender, MouseEventArgs e) => ColorDay(0);

        private void Tuesday_MouseMove(object sender, MouseEventArgs e) => ColorDay(1);

        private void Wednesday_MouseMove(object sender, MouseEventArgs e) => ColorDay(2);

        private void Thursday_MouseMove(object sender, MouseEventArgs e) => ColorDay(3);

        private void Friday_MouseMove(object sender, MouseEventArgs e) => ColorDay(4);

        private void Saturday_MouseMove(object sender, MouseEventArgs e) => ColorDay(5);

        public void ColorDay( int y)
        {
            var color = new Color[6];
            for (int i = 0; i<6; i++)
            {
                if (y==i)
                {
                    color[i] = Color.LightSteelBlue;
                }
                else
                {
                    color[i] = Color.FromArgb(255, 240, 240, 240);
                }
            }

            Monday.BackColor = color[0];
            Tuesday.BackColor = color[1];
            Wednesday.BackColor = color[2];
            Thursday.BackColor = color[3];
            Friday.BackColor = color[4];
            Saturday.BackColor = color[5];
        }

        private void Pair1_MouseMove(object sender, MouseEventArgs e) => ColorPair(0);

        private void Pair2_MouseMove(object sender, MouseEventArgs e) => ColorPair(1);

        private void Pair3_MouseMove(object sender, MouseEventArgs e) => ColorPair(2);

        private void Pair4_MouseMove(object sender, MouseEventArgs e) => ColorPair(3);

        private void Pair5_MouseMove(object sender, MouseEventArgs e) => ColorPair(4);

        private void Pair6_MouseMove(object sender, MouseEventArgs e) => ColorPair(5);

        private void Pair7_MouseMove(object sender, MouseEventArgs e) => ColorPair(6);

        private void Pair8_MouseMove(object sender, MouseEventArgs e) => ColorPair(7);

        public void ColorPair(int y)
        {
            var color = new Color[8];
            for (int i = 0; i < 8; i++)
            {
                if (y == i)
                {
                    color[i] = Color.LightSteelBlue;
                }
                else
                {
                    color[i] = Color.FromArgb(255, 240, 240, 240);
                }
            }

            Pair1.BackColor = color[0];
            Pair2.BackColor = color[1];
            Pair3.BackColor = color[2];
            Pair4.BackColor = color[3];
            Pair5.BackColor = color[4];
            Pair6.BackColor = color[5];
            Pair7.BackColor = color[6];
            Pair8.BackColor = color[7];
        }
    }
}