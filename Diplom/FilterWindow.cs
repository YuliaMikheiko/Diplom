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

        internal FilterWindow(ScheduleDataModel scheduleDataModel, ScheduleRow[] nagr)
        {
            this.scheduleDataModel = scheduleDataModel;
            this.nagr = nagr;

            InitializeComponent();
        }

        private void GroupsButton_Click(object sender, EventArgs e)
        {
            int type = 2;

            List<string> GroupsText = new List<string>();

            if (GroupsTextBox.Text == "")
                GroupsText.Add("");
            else
                 GroupsText = GroupsTextBox.Text.Split().ToList();

            ItemsSelectorModalWindow groups = new ItemsSelectorModalWindow(type, scheduleDataModel, GroupsText);

            if (groups.ShowDialog() == DialogResult.OK)
            {
                List<int?> idsList = groups.idsList;
                List<string> TitleList = groups.TitleList;
                var value = " ";

                if (idsList.Count > 0)
                {
                    value = "";
                    foreach (var name in TitleList)
                        value += name + " ";
                }
                GroupsTextBox.Text = value;
            }
        }

        private void KafedraButton_Click(object sender, EventArgs e)
        {
            List<string> allKafedra = new List<string>();

            int i = 0;
            foreach(var item in nagr)
            {
                allKafedra.Add(nagr[i].kaf);
                i++;
            }

            List<string> Kafedra = allKafedra.Distinct().ToList();

            List<string> KafedraText1 = new List<string>();

            if (KafedraTextBox.Text != "")
            {
                List<string> KafedraText = KafedraTextBox.Text.Split(',').ToList();

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
                List<string> TitleList = kafedra.TitleList;
                var value = " ";
                
                foreach (var name in TitleList)
                    value += name + ", ";

                KafedraTextBox.Text = value;
            }
        }

        private void TeacherButton_Click(object sender, EventArgs e)
        {
            int type = 1;

            List<string> TeacherText1 = new List<string>();

            if (TeacherTextBox.Text != "")
            {
                List<string> TeacherText = TeacherTextBox.Text.Split(',').ToList();

                foreach (var name in TeacherText)
                {
                    if (name != " ")
                        TeacherText1.Add(name.Trim());
                }
            }

        ItemsSelectorModalWindow teachers = new ItemsSelectorModalWindow(type, scheduleDataModel, TeacherText1);

            if (teachers.ShowDialog() == DialogResult.OK)
            {
                List<int?> idsList = teachers.idsList;
                List<string> TitleList = teachers.TitleList;
                var value = " ";

                if (idsList.Count > 0)
                {
                    value = "";
                    foreach (var name in TitleList)
                        value += name + ", ";
                }
                TeacherTextBox.Text = value;
            }

        }

        private void AuditorysButton_Click(object sender, EventArgs e)
        {
            int type = 3;

            List<string> AuditorysText = new List<string>();

            if (AuditorysTextBox.Text == "")
                AuditorysText.Add("");
            else
                AuditorysText = AuditorysTextBox.Text.Split().ToList();

            ItemsSelectorModalWindow auditorys = new ItemsSelectorModalWindow(type, scheduleDataModel, AuditorysText);

            if (auditorys.ShowDialog() == DialogResult.OK)
            {
                List<int?> idsList = auditorys.idsList;
                List<string> TitleList = auditorys.TitleList;
                var value = " ";

                if (idsList.Count > 0)
                {
                    value = "";
                    foreach (var name in TitleList)
                        value += name + " ";
                }
                AuditorysTextBox.Text = value;
            }
        }

        private void DisciplineButton_Click(object sender, EventArgs e)
        {
            List<string> allDiscipline = new List<string>();

            int i = 0;
            foreach (var item in nagr)
            {
                allDiscipline.Add(nagr[i].discipline);
                i++;
            }

            List<string> Discipline = allDiscipline.Distinct().ToList();

            List<string> DisciplineText1 = new List<string>();

            if (DisciplineTextBox.Text != "")
            {
                List<string> DisciplineText = DisciplineTextBox.Text.Split(',').ToList();

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
                List<string> TitleList = discipline.TitleList;
                var value = " ";
                
                foreach (var name in TitleList)
                    value += name + ", ";

                DisciplineTextBox.Text = value;
            }
        }

        private void Filter_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
