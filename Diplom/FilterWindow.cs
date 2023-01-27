using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

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

        public bool TeacherCheck;
        public bool AuditoryCheck;
        public bool GroupCheck;
        public bool KafedraCheck;
        public bool DisciplineCheck;

        List<string> Discipline;
        List<string> Kafedra;

        internal FilterWindow(ScheduleDataModel scheduleDataModel, ScheduleRow[] nagr)
        {
            this.scheduleDataModel = scheduleDataModel;
            this.nagr = nagr;

            TitleListDiscipline = new List<string>();
            TitleListKafedra = new List<string>();
            TitleListAuditorys = new List<string>();
            TitleListGroups = new List<string>();
            TitleListTeacher = new List<string>();

            InitializeComponent();
        }

        private void GroupsButton_Click(object sender, EventArgs e)
        {
            List<string> GroupsText = new List<string>();

            GroupsText.AddRange(GroupsTextBox.Text.Split(';').ToList().Where(name => name != " ").Select(name => name.Trim()));

            ItemsSelectorModalWindow groups = new ItemsSelectorModalWindow(2, scheduleDataModel, GroupsText);

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

            List<string> KafedraText = new List<string>();

            KafedraText.AddRange(KafedraTextBox.Text.Split(';').ToList().Where(name => name != " ").Select(name => name.Trim()));

            ItemsSelectorModalWindow kafedra = new ItemsSelectorModalWindow(4, KafedraText, Kafedra);

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
            List<string> TeacherText = new List<string>();

            TeacherText.AddRange(TeacherTextBox.Text.Split(';').ToList().Where(name => name != " ").Select(name => name.Trim()));

            ItemsSelectorModalWindow teachers = new ItemsSelectorModalWindow(1, scheduleDataModel, TeacherText);

            if (teachers.ShowDialog() == DialogResult.OK)
            {
                TitleListTeacher = teachers.TitleList;
                var value = " ";

                foreach (var name in TitleListTeacher)
                    value += name + "; ";

                TeacherTextBox.Text = value.Trim().TrimEnd(';');
            }
        }

        private void AuditorysButton_Click(object sender, EventArgs e)
        {
            List<string> AuditorysText = new List<string>();

            AuditorysText.AddRange(AuditorysTextBox.Text.Split(';').ToList().Where(name => name != " ").Select(name => name.Trim()));

            ItemsSelectorModalWindow auditorys = new ItemsSelectorModalWindow(3, scheduleDataModel, AuditorysText);

            if (auditorys.ShowDialog() == DialogResult.OK)
            {
                TitleListAuditorys = auditorys.TitleList;
                var value = " ";

                foreach (var name in TitleListAuditorys)
                    value += name + "; ";

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

            List<string> DisciplineText = new List<string>();

            DisciplineText.AddRange(DisciplineTextBox.Text.Split(';').ToList().Where(name => name != " ").Select(name => name.Trim()));

            ItemsSelectorModalWindow discipline = new ItemsSelectorModalWindow(5, DisciplineText, Discipline);

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
            TeacherCheck = TeacherCheckBox.Checked;
            AuditoryCheck = AuditorysCheckBox.Checked;
            GroupCheck = GroupsCheckBox.Checked;
            DisciplineCheck = DisciplineCheckBox.Checked;
            KafedraCheck = KafedraCheckBox.Checked;

            this.DialogResult = DialogResult.OK;
        }

        private void GroupsTextBox_MouseMove(object sender, MouseEventArgs e)
        {
            ToolTip t = new ToolTip();
            
            t.SetToolTip(sender as TextBox, (sender as TextBox).Text);
        }
    }
}
