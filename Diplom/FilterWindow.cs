using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Diplom
{
    public partial class FilterWindow : Form
    {
        ScheduleDataModel scheduleDataModel;
        ScheduleRow[] nagr;
        public List<string> TitleListGroups;
        public List<string> TitleListKafedra;
        public List<string> TitleListTeacher;
        public List<string> TitleListAuditorys;
        public List<string> TitleListDiscipline;

        List<string> Discipline;
        List<string> Kafedra;

        internal FilterWindow(ScheduleDataModel scheduleDataModel, ScheduleRow[] nagr)
        {
            this.scheduleDataModel = scheduleDataModel;
            this.nagr = nagr;

            InitializeComponent();
        }

        private void GroupsButton_Click(object sender, EventArgs e)
        {
            List<string> GroupsText1 = new List<string>();

            if (GroupsTextBox.Text != "")
            {
                List<string> GroupsText = GroupsTextBox.Text.Split(';').ToList();

                foreach (var name in GroupsText)
                {
                    if (name != " ")
                        GroupsText1.Add(name.Trim());
                }
            }

            int type = 2;

            ItemsSelectorModalWindow groups = new ItemsSelectorModalWindow(type, scheduleDataModel, GroupsText1);

            if (groups.ShowDialog() == DialogResult.OK)
            {
                TitleListGroups = groups.TitleList;
                var value = "";

                foreach (var name in TitleListGroups)
                    value += name + "; ";

                GroupsTextBox.Text = value.Trim().TrimEnd(';');
            }
        }
        
        public void ReadKafedra()
        {
            List<string> allKafedra = new List<string>();

            int i = 0;
            foreach (var item in nagr)
            {
                allKafedra.Add(nagr[i].kaf);
                i++;
            }

            Kafedra = allKafedra.Distinct().ToList();
        }

        private void KafedraButton_Click(object sender, EventArgs e)
        {
            ReadKafedra();

            List<string> KafedraText1 = new List<string>();

            if (KafedraTextBox.Text != "")
            {
                List<string> KafedraText = KafedraTextBox.Text.Split(';').ToList();

                foreach (var name in KafedraText)
                {
                    if (name != " ")
                        KafedraText1.Add(name.Trim());
                }
            }

            int type = 4;

            ItemsSelectorModalWindow kafedra = new ItemsSelectorModalWindow(type, KafedraText1, Kafedra);

            if (kafedra.ShowDialog() == DialogResult.OK)
            {
                TitleListKafedra = kafedra.TitleList;
                var value = " ";
                
                foreach (var name in TitleListKafedra)
                    value += name + "; ";

                KafedraTextBox.Text = value.Trim().TrimEnd(';');
            }
        }

        private void TeacherButton_Click(object sender, EventArgs e)
        {
            List<string> TeacherText1 = new List<string>();

            if (TeacherTextBox.Text != "")
            {
                List<string> TeacherText = TeacherTextBox.Text.Split(';').ToList();

                foreach (var name in TeacherText)
                {
                    if (name != " ")
                        TeacherText1.Add(name.Trim());
                }
            }

            int type = 1;

            ItemsSelectorModalWindow teachers = new ItemsSelectorModalWindow(type, scheduleDataModel, TeacherText1);

            if (teachers.ShowDialog() == DialogResult.OK)
            {
                List<int?> idsList = teachers.idsList;
                TitleListTeacher = teachers.TitleList;
                var value = " ";

                if (idsList.Count > 0)
                {
                    value = "";
                    foreach (var name in TitleListTeacher)
                        value += name + "; ";
                }
                TeacherTextBox.Text = value.Trim().TrimEnd(';');
            }

        }

        private void AuditorysButton_Click(object sender, EventArgs e)
        {
            List<string> AuditorysText1 = new List<string>();

            if (AuditorysTextBox.Text != "")
            {
                List<string> AuditorysText = AuditorysTextBox.Text.Split(';').ToList();

                foreach (var name in AuditorysText)
                {
                    if (name != " ")
                        AuditorysText1.Add(name.Trim());
                }
            }

            int type = 3;

            ItemsSelectorModalWindow auditorys = new ItemsSelectorModalWindow(type, scheduleDataModel, AuditorysText1);

            if (auditorys.ShowDialog() == DialogResult.OK)
            {
                List<int?> idsList = auditorys.idsList;
                TitleListAuditorys = auditorys.TitleList;
                var value = " ";

                if (idsList.Count > 0)
                {
                    value = "";
                    foreach (var name in TitleListAuditorys)
                        value += name + "; ";
                }
                AuditorysTextBox.Text = value.Trim().TrimEnd(';');
            }
        }

        public void ReadDiscipline()
        {
            List<string> allDiscipline = new List<string>();

            int i = 0;
            foreach (var item in nagr)
            {
                allDiscipline.Add(nagr[i].discipline);
                i++;
            }

            Discipline = allDiscipline.Distinct().ToList();
        }

        private void DisciplineButton_Click(object sender, EventArgs e)
        {
            ReadDiscipline();

            List<string> DisciplineText1 = new List<string>();

            if (DisciplineTextBox.Text != "")
            {
                List<string> DisciplineText = DisciplineTextBox.Text.Split(';').ToList();

                foreach (var name in DisciplineText)
                {
                    if (name != " ")
                        DisciplineText1.Add(name.Trim());
                }
            }
                       
            int type = 5;

            ItemsSelectorModalWindow discipline = new ItemsSelectorModalWindow(type, DisciplineText1, Discipline);

            if (discipline.ShowDialog() == DialogResult.OK)
            {
                TitleListDiscipline = discipline.TitleList;
                var value = " ";
                
                foreach (var name in TitleListDiscipline)
                    value += name + "; ";

                DisciplineTextBox.Text = value.Trim().TrimEnd(';');
            }
        }

        private void Filter_Click(object sender, EventArgs e)
        {
            if (DisciplineTextBox.Text == "")
            {
                ReadDiscipline();
                TitleListDiscipline = new List<string>();
                TitleListDiscipline = Discipline;
            }
            if (KafedraTextBox.Text == "")
            {
                ReadKafedra();
                TitleListKafedra = new List<string>();
                TitleListKafedra = Kafedra;
            }
            if (AuditorysTextBox.Text == "")
            {
                Dictionary<int, Auditory> DAuditories = scheduleDataModel.GetAuditories();
                TitleListAuditorys = new List<string>();
                int i = 0;
                foreach (var auditori in DAuditories)
                {
                    TitleListAuditorys.Add(auditori.Value.title);
                    i++;
                }
            }
            if (GroupsTextBox.Text == "")
            {
                Dictionary<int, SubGroup> DGroups = scheduleDataModel.GetGroups();
                TitleListGroups = new List<string>();
                foreach (var groups in DGroups)
                    TitleListGroups.Add(groups.Value.title);
            }
            if (TeacherTextBox.Text == "")
            {
                Dictionary<int, Teacher> DTeachers = scheduleDataModel.GetTeachers();
                TitleListTeacher = new List<string>();
                foreach (var teachers in DTeachers)
                    TitleListTeacher.Add(teachers.Value.name);
            }
            this.DialogResult = DialogResult.OK;
        }
    }
}
