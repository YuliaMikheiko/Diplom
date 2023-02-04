using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Diplom
{
    public partial class FilterWindow : Form
    {
        ScheduleDataModel scheduleDataModel;
        ScheduleRow[] nagr;

        public List<string> titleListGroups;
        public List<string> titleListKafedra;
        public List<string> titleListTeacher;
        public List<string> titleListAuditorys;
        public List<string> titleListDiscipline;
        public List<string> titleListKurs;
        public List<string> idListNt;

        public bool teacherCheck;
        public bool auditoryCheck;
        public bool groupCheck;
        public bool kafedraCheck;
        public bool disciplineCheck;
        public bool kursCheck;
        public bool ntCheck;

        List<string> disciplineList;
        List<string> kafedraList;
        List<string> kursList;
        List<KeyValuePair<int, string>> ntList;

        internal FilterWindow(ScheduleDataModel scheduleDataModel, ScheduleRow[] nagr)
        {
            this.scheduleDataModel = scheduleDataModel;
            this.nagr = nagr;

            titleListDiscipline = new List<string>();
            titleListKafedra = new List<string>();
            titleListAuditorys = new List<string>();
            titleListGroups = new List<string>();
            titleListTeacher = new List<string>();
            titleListKurs = new List<string>();
            idListNt = new List<string>();

            InitializeComponent();
        }

        private void GroupsButton_Click(object sender, EventArgs e)
        {
            List<string> groupsText = new List<string>();

            groupsText.AddRange(GroupsTextBox.Text.Split(';').ToList().Where(name => name != "").Select(name => name.Trim()));

            ItemsSelectorModalWindow groups = new ItemsSelectorModalWindow(1, scheduleDataModel, groupsText);

            if (groups.ShowDialog() == DialogResult.OK)
            {
                GroupsTextBox.Text = String.Join("; ", groups.titleList);

                titleListGroups.AddRange(groups.titleList.Select(item => item.Replace("(И,О)", "").Replace("(И,З)", "").Trim()));
            }
        }

        private void KafedraButton_Click(object sender, EventArgs e)
        {
            List<string> allKafedra = nagr.Select(item => item.kaf).ToList();

            kafedraList = allKafedra.Distinct().ToList();

            List<string> kafedraText = new List<string>();

            kafedraText.AddRange(KafedraTextBox.Text.Split(';').ToList().Where(name => name != "").Select(name => name.Trim()));

            ItemsSelectorModalWindow kafedra = new ItemsSelectorModalWindow(kafedraText, kafedraList);

            if (kafedra.ShowDialog() == DialogResult.OK)
            {
                titleListKafedra = kafedra.titleList;

                KafedraTextBox.Text = String.Join("; ", titleListKafedra);
            }
        }

        private void TeacherButton_Click(object sender, EventArgs e)
        {
            List<string> teacherText = new List<string>();

            teacherText.AddRange(TeacherTextBox.Text.Split(';').ToList().Where(name => name != "").Select(name => name.Trim()));

            ItemsSelectorModalWindow teachers = new ItemsSelectorModalWindow(0, scheduleDataModel, teacherText);

            if (teachers.ShowDialog() == DialogResult.OK)
            {
                titleListTeacher = teachers.titleList;

                TeacherTextBox.Text = String.Join("; ", titleListTeacher);
            }
        }

        private void AuditorysButton_Click(object sender, EventArgs e)
        {
            List<string> auditorysText = new List<string>();

            auditorysText.AddRange(AuditorysTextBox.Text.Split(';').ToList().Where(name => name != "").Select(name => name.Trim()));

            ItemsSelectorModalWindow auditorys = new ItemsSelectorModalWindow(2, scheduleDataModel, auditorysText);

            if (auditorys.ShowDialog() == DialogResult.OK)
            {
                titleListAuditorys = auditorys.titleList;

                AuditorysTextBox.Text = String.Join("; ", titleListAuditorys);
            }
        }

        private void DisciplineButton_Click(object sender, EventArgs e)
        {
            List<string> allDiscipline = nagr.Select(item => item.discipline).ToList();

            disciplineList = allDiscipline.Distinct().ToList();

            List<string> disciplineText = new List<string>();

            disciplineText.AddRange(DisciplineTextBox.Text.Split(';').ToList().Where(name => name != "").Select(name => name.Trim()));

            ItemsSelectorModalWindow discipline = new ItemsSelectorModalWindow(disciplineText, disciplineList);

            if (discipline.ShowDialog() == DialogResult.OK)
            {
                titleListDiscipline = discipline.titleList;

                DisciplineTextBox.Text = String.Join("; ", titleListDiscipline);
            }
        }

        private void NtButton_Click(object sender, EventArgs e)
        {
            ntList = new List<KeyValuePair<int, string>>
            {
                new KeyValuePair<int, string>(1, "Лекция"),
                new KeyValuePair<int, string>(2, "Практика"),
                new KeyValuePair<int, string>(3, "Лаба"),
                new KeyValuePair<int, string>(4, "Консультация"),
                new KeyValuePair<int, string>(5, "Экзамен консультация"),
                new KeyValuePair<int, string>(6, "Экзамен"),
                new KeyValuePair<int, string>(7, "Зачет"),
            };

            List<string> ntText = new List<string>();

            ntText.AddRange(NtTextBox.Text.Split(';').ToList().Where(name => name != "").Select(name => name.Trim()));

            ItemsSelectorModalWindow nt = new ItemsSelectorModalWindow(ntText, ntList);

            if (nt.ShowDialog() == DialogResult.OK)
            {
                idListNt.AddRange(nt.idsList.Select(item => item.ToString()));
               
                NtTextBox.Text = String.Join("; ", nt.titleList);
            }
        }

        private void KursButton_Click(object sender, EventArgs e)
        {
            List<string> allKurs = new List<string>();

            Dictionary<int, SubGroup> dSub_groups = scheduleDataModel.GetGroups();

            allKurs.AddRange(dSub_groups.Select(item => item.Value.kurs.ToString()));

            kursList = allKurs.Distinct().ToList();

            List<string> kursText = new List<string>();

            kursText.AddRange(KursTextBox.Text.Split(';').ToList().Where(name => name != "").Select(name => name.Trim()));

            ItemsSelectorModalWindow kurs = new ItemsSelectorModalWindow(kursText, kursList);

            if (kurs.ShowDialog() == DialogResult.OK)
            {
                titleListKurs = kurs.titleList;
               
                KursTextBox.Text = String.Join("; ", titleListKurs);
            }
        }

        private void Filter_Click(object sender, EventArgs e)
        {
            teacherCheck = TeacherCheckBox.Checked;
            auditoryCheck = AuditorysCheckBox.Checked;
            groupCheck = GroupsCheckBox.Checked;
            disciplineCheck = DisciplineCheckBox.Checked;
            kafedraCheck = KafedraCheckBox.Checked;
            kursCheck = KursCheckBox.Checked;
            ntCheck = NtCheckBox.Checked;

            this.DialogResult = DialogResult.OK;
        }

        private void TextBox_MouseMove(object sender, MouseEventArgs e)
        {
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(sender as TextBox, (sender as TextBox).Text);
        }
    }
}