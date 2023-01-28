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

        public List<string> titleListGroups;
        public List<string> titleListKafedra;
        public List<string> titleListTeacher;
        public List<string> titleListAuditorys;
        public List<string> titleListDiscipline;

        public bool teacherCheck;
        public bool auditoryCheck;
        public bool groupCheck;
        public bool kafedraCheck;
        public bool disciplineCheck;

        List<string> disciplineList;
        List<string> kafedraList;

        internal FilterWindow(ScheduleDataModel scheduleDataModel, ScheduleRow[] nagr)
        {
            this.scheduleDataModel = scheduleDataModel;
            this.nagr = nagr;

            titleListDiscipline = new List<string>();
            titleListKafedra = new List<string>();
            titleListAuditorys = new List<string>();
            titleListGroups = new List<string>();
            titleListTeacher = new List<string>();

            InitializeComponent();
        }

        private void GroupsButton_Click(object sender, EventArgs e)
        {
            List<string> groupsText = new List<string>();

            groupsText.AddRange(GroupsTextBox.Text.Split(';').ToList().Where(name => name != " ").Select(name => name.Trim()));

            ItemsSelectorModalWindow groups = new ItemsSelectorModalWindow(2, scheduleDataModel, groupsText);

            if (groups.ShowDialog() == DialogResult.OK)
            {
                titleListGroups = groups.titleList;
                var value = "";

                foreach (var name in titleListGroups)
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

            kafedraList = allKafedra.Distinct().ToList();
        }

        private void KafedraButton_Click(object sender, EventArgs e)
        {
            ReadKafedra();

            List<string> kafedraText = new List<string>();

            kafedraText.AddRange(KafedraTextBox.Text.Split(';').ToList().Where(name => name != " ").Select(name => name.Trim()));

            ItemsSelectorModalWindow kafedra = new ItemsSelectorModalWindow(4, kafedraText, kafedraList);

            if (kafedra.ShowDialog() == DialogResult.OK)
            {
                titleListKafedra = kafedra.titleList;
                var value = " ";

                foreach (var name in titleListKafedra)
                    value += name + "; ";

                KafedraTextBox.Text = value.Trim().TrimEnd(';');
            }
        }

        private void TeacherButton_Click(object sender, EventArgs e)
        {
            List<string> teacherText = new List<string>();

            teacherText.AddRange(TeacherTextBox.Text.Split(';').ToList().Where(name => name != " ").Select(name => name.Trim()));

            ItemsSelectorModalWindow teachers = new ItemsSelectorModalWindow(1, scheduleDataModel, teacherText);

            if (teachers.ShowDialog() == DialogResult.OK)
            {
                titleListTeacher = teachers.titleList;
                var value = " ";

                foreach (var name in titleListTeacher)
                    value += name + "; ";

                TeacherTextBox.Text = value.Trim().TrimEnd(';');
            }
        }

        private void AuditorysButton_Click(object sender, EventArgs e)
        {
            List<string> auditorysText = new List<string>();

            auditorysText.AddRange(AuditorysTextBox.Text.Split(';').ToList().Where(name => name != " ").Select(name => name.Trim()));

            ItemsSelectorModalWindow auditorys = new ItemsSelectorModalWindow(3, scheduleDataModel, auditorysText);

            if (auditorys.ShowDialog() == DialogResult.OK)
            {
                titleListAuditorys = auditorys.titleList;
                var value = " ";

                foreach (var name in titleListAuditorys)
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

            disciplineList = allDiscipline.Distinct().ToList();
        }

        private void DisciplineButton_Click(object sender, EventArgs e)
        {
            ReadDiscipline();

            List<string> disciplineText = new List<string>();

            disciplineText.AddRange(DisciplineTextBox.Text.Split(';').ToList().Where(name => name != " ").Select(name => name.Trim()));

            ItemsSelectorModalWindow discipline = new ItemsSelectorModalWindow(5, disciplineText, disciplineList);

            if (discipline.ShowDialog() == DialogResult.OK)
            {
                titleListDiscipline = discipline.titleList;
                var value = " ";

                foreach (var name in titleListDiscipline)
                    value += name + "; ";

                DisciplineTextBox.Text = value.Trim().TrimEnd(';');
            }
        }

        private void Filter_Click(object sender, EventArgs e)
        {
            teacherCheck = TeacherCheckBox.Checked;
            auditoryCheck = AuditorysCheckBox.Checked;
            groupCheck = GroupsCheckBox.Checked;
            disciplineCheck = DisciplineCheckBox.Checked;
            kafedraCheck = KafedraCheckBox.Checked;

            this.DialogResult = DialogResult.OK;
        }

        private void GroupsTextBox_MouseMove(object sender, MouseEventArgs e)
        {
            ToolTip toolTip = new ToolTip();
            
            toolTip.SetToolTip(sender as TextBox, (sender as TextBox).Text);
        }
    }
}
