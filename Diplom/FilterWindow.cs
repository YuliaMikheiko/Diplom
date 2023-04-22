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

        public List<string> titleShortListGroups;
        public List<string> titleListGroups;
        public List<string> titleListKafedra;
        public List<string> titleListTeacher;
        public List<string> titleListAuditorys;
        public List<string> titleListDiscipline;
        public List<string> titleListKurs;
        public List<string> idListNt;
        public List<string> titleListNt;
        public List<string> titleListOwners;
        public List<string> titleListFac;

        public bool ownersCheck;
        public bool teacherCheck;
        public bool auditoryCheck;
        public bool groupCheck;
        public bool kafedraCheck;
        public bool disciplineCheck;
        public bool kursCheck;
        public bool ntCheck;
        public bool facCheck;
        public bool zaochCheck;
        public bool ochCheck;

        List<string> disciplineList;
        List<string> kafedraList;
        List<string> kursList;
        List<string> ownersList;
        List<string> facList;

        List<KeyValuePair<int, string>> ntList;

        internal FilterWindow(ScheduleDataModel scheduleDataModel, ScheduleRow[] nagr, List<string> titleListGroups, List<string> titleListKafedra, List<string> titleListTeacher, List<string> titleListAuditorys, List<string> titleListDiscipline, List<string> titleListKurs, List<string> titleListOwners, List<string> idListNt, List<string> titleListNt, List<string> titleListFac, bool auditoryCheck, bool groupCheck, bool teacherCheck, bool kafedraCheck, bool disciplineCheck, bool kursCheck, bool ntCheck, bool ownersCheck, bool facCheck, bool zaochCheck, bool ochCheck)
        {
            InitializeComponent();

            this.scheduleDataModel = scheduleDataModel;
            this.nagr = nagr;

            this.titleListOwners = titleListOwners;
            this.titleListDiscipline = titleListDiscipline;
            this.titleListKafedra = titleListKafedra;
            this.titleListAuditorys = titleListAuditorys;
            this.titleListGroups = titleListGroups;
            this.titleListTeacher = titleListTeacher;
            this.titleListKurs = titleListKurs;
            this.idListNt = idListNt;
            this.titleListNt = titleListNt;
            this.titleListFac = titleListFac;

            this.ownersCheck = ownersCheck;
            this.teacherCheck = teacherCheck;
            this.auditoryCheck = auditoryCheck;
            this.groupCheck = groupCheck;
            this.kafedraCheck = kafedraCheck;
            this.disciplineCheck = disciplineCheck;
            this.kursCheck = kursCheck;
            this.ntCheck = ntCheck;
            this.facCheck = facCheck;
            this.zaochCheck = zaochCheck;
            this.ochCheck = ochCheck;

            OwnersTextBox.Text = String.Join("; ", titleListOwners);
            GroupsTextBox.Text = String.Join("; ", titleListGroups);
            DisciplineTextBox.Text = String.Join("; ", titleListDiscipline);
            KafedraTextBox.Text = String.Join("; ", titleListKafedra);
            AuditorysTextBox.Text = String.Join("; ", titleListAuditorys);
            TeacherTextBox.Text = String.Join("; ", titleListTeacher);
            KursTextBox.Text = String.Join("; ", titleListKurs);
            NtTextBox.Text = String.Join("; ", titleListNt);
            FacTextBox.Text = String.Join("; ", titleListFac);

            OwnersCheckBox.Checked = ownersCheck;
            TeacherCheckBox.Checked = teacherCheck;
            AuditorysCheckBox.Checked = auditoryCheck;
            GroupsCheckBox.Checked = groupCheck;
            DisciplineCheckBox.Checked = disciplineCheck;
            KafedraCheckBox.Checked = kafedraCheck;
            KursCheckBox.Checked = kursCheck;
            NtCheckBox.Checked = ntCheck;
            FacCheckBox.Checked = facCheck;
            ZaochCheckBox.Checked = zaochCheck;
            OchCheckBox.Checked = ochCheck;

            titleShortListGroups = new List<string>();
        }

        private void GroupsButton_Click(object sender, EventArgs e)
        {
            ItemsSelectorModalWindow groups = new ItemsSelectorModalWindow(1, scheduleDataModel, titleListGroups, true);

            if (groups.ShowDialog() == DialogResult.OK)
            {
                titleListGroups = groups.titleList;

                GroupsTextBox.Text = String.Join("; ", titleListGroups);

                titleShortListGroups.AddRange(titleListGroups.Select(item => item.Replace("(И,О)", "").Replace("(И,З)", "").Trim()));
            }
        }

        private void KafedraButton_Click(object sender, EventArgs e)
        {
            List<string> allKafedra = nagr.Select(item => item.kaf).ToList();

            kafedraList = allKafedra.Distinct().ToList();

            ItemsSelectorModalWindow kafedra = new ItemsSelectorModalWindow(titleListKafedra, kafedraList, true);

            if (kafedra.ShowDialog() == DialogResult.OK)
            {
                titleListKafedra = kafedra.titleList;

                KafedraTextBox.Text = String.Join("; ", titleListKafedra);
            }
        }

        private void TeacherButton_Click(object sender, EventArgs e)
        {
            ItemsSelectorModalWindow teachers = new ItemsSelectorModalWindow(0, scheduleDataModel, titleListTeacher, true);

            if (teachers.ShowDialog() == DialogResult.OK)
            {
                titleListTeacher = teachers.titleList;

                TeacherTextBox.Text = String.Join("; ", titleListTeacher);
            }
        }

        private void AuditorysButton_Click(object sender, EventArgs e)
        {
            ItemsSelectorModalWindow auditorys = new ItemsSelectorModalWindow(2, scheduleDataModel, titleListAuditorys, true);

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

            ItemsSelectorModalWindow discipline = new ItemsSelectorModalWindow(titleListDiscipline, disciplineList, true);

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

            ItemsSelectorModalWindow nt = new ItemsSelectorModalWindow(titleListNt, ntList);

            if (nt.ShowDialog() == DialogResult.OK)
            {
                idListNt.AddRange(nt.idsList.Select(item => item.ToString()));

                titleListNt = nt.titleList;

                NtTextBox.Text = String.Join("; ", titleListNt);
            }
        }

        private void KursButton_Click(object sender, EventArgs e)
        {
            List<string> allKurs = new List<string>();

            Dictionary<int, SubGroup> dSub_groups = scheduleDataModel.GetGroups();

            allKurs.AddRange(dSub_groups.Select(item => item.Value.kurs.ToString()));

            kursList = allKurs.Distinct().ToList();

            ItemsSelectorModalWindow kurs = new ItemsSelectorModalWindow(titleListKurs, kursList, true);

            if (kurs.ShowDialog() == DialogResult.OK)
            {
                titleListKurs = kurs.titleList;

                KursTextBox.Text = String.Join("; ", titleListKurs);
            }
        }

        private void OwnersButton_Click(object sender, EventArgs e)
        {
            ownersList = nagr.Where(item => item.owners != null).SelectMany(item => item.owners.Where(i => i != "" & i != " ").Select(i => i.Trim())).ToList().Distinct().ToList();

            ItemsSelectorModalWindow owners = new ItemsSelectorModalWindow(titleListOwners, ownersList, true);

            if (owners.ShowDialog() == DialogResult.OK)
            {
                titleListOwners = owners.titleList;

                OwnersTextBox.Text = String.Join("; ", titleListOwners);
            }
        }

        private void FacButton_Click(object sender, EventArgs e)
        {
            List<string> allFac = new List<string>();

            Dictionary<int, SubGroup> dSub_groups = scheduleDataModel.GetGroups();

            allFac.AddRange(dSub_groups.Select(item => item.Value.fac.ToString()));

            facList = allFac.Distinct().ToList();

            ItemsSelectorModalWindow fac = new ItemsSelectorModalWindow(titleListFac, facList, true);

            if (fac.ShowDialog() == DialogResult.OK)
            {
                titleListFac = fac.titleList;

                FacTextBox.Text = String.Join("; ", titleListFac);
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
            ownersCheck = OwnersCheckBox.Checked;
            facCheck = FacCheckBox.Checked;
            zaochCheck = ZaochCheckBox.Checked;
            ochCheck = OchCheckBox.Checked;

            this.DialogResult = DialogResult.OK;
        }

        private void TextBox_MouseMove(object sender, MouseEventArgs e)
        {
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(sender as TextBox, (sender as TextBox).Text);
        }

        private void Reset_Click(object sender, EventArgs e)
        {
            titleListOwners = new List<string>();
            titleShortListGroups = new List<string>();
            titleListGroups = new List<string>();
            titleListKafedra = new List<string>();
            titleListTeacher = new List<string>();
            titleListAuditorys = new List<string>();
            titleListDiscipline = new List<string>();
            titleListKurs = new List<string>();
            idListNt = new List<string>();
            titleListNt = new List<string>();
            titleListFac = new List<string>();

            OwnersTextBox.Clear();
            GroupsTextBox.Clear();
            DisciplineTextBox.Clear();
            KafedraTextBox.Clear();
            AuditorysTextBox.Clear();
            TeacherTextBox.Clear();
            KursTextBox.Clear();
            NtTextBox.Clear();
            FacTextBox.Clear();

            ownersCheck = false;
            teacherCheck = false;
            auditoryCheck = false;
            groupCheck = false;
            kafedraCheck = false;
            disciplineCheck = false;
            kursCheck = false;
            ntCheck = false;
            facCheck = false;
            zaochCheck = false;
            ochCheck = false;

            OwnersCheckBox.Checked = false;
            TeacherCheckBox.Checked = false;
            AuditorysCheckBox.Checked = false;
            GroupsCheckBox.Checked = false;
            DisciplineCheckBox.Checked = false;
            KafedraCheckBox.Checked = false;
            KursCheckBox.Checked = false;
            NtCheckBox.Checked = false;
            FacCheckBox.Checked = false;
            ZaochCheckBox.Checked = false;
            OchCheckBox.Checked = false;
        }
    }
}