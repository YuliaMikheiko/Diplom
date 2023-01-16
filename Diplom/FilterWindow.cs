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
        internal FilterWindow(ScheduleDataModel scheduleDataModel)
        {
            this.scheduleDataModel = scheduleDataModel;
            InitializeComponent();
        }

        private void GroupsButton_Click(object sender, EventArgs e)
        {
            int type = 2;
            ItemsSelectorModalWindow groups = new ItemsSelectorModalWindow(type, scheduleDataModel);

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
            int type = 4;
            ItemsSelectorModalWindow kafedra = new ItemsSelectorModalWindow(type, scheduleDataModel);

            if (kafedra.ShowDialog() == DialogResult.OK)
            {
                List<int?> idsList = kafedra.idsList;
                List<string> TitleList = kafedra.TitleList;
                var value = " ";

                if (idsList.Count > 0)
                {
                    value = "";
                    foreach (var name in TitleList)
                        value += name + " ";
                }
                KafedraTextBox.Text = value;
            }
        }

        private void TeacherButton_Click(object sender, EventArgs e)
        {
            int type = 1;
            ItemsSelectorModalWindow teachers = new ItemsSelectorModalWindow(type, scheduleDataModel);

            if (teachers.ShowDialog() == DialogResult.OK)
            {
                List<int?> idsList = teachers.idsList;
                List<string> TitleList = teachers.TitleList;
                var value = " ";

                if (idsList.Count > 0)
                {
                    value = "";
                    foreach (var name in TitleList)
                        value += name + " ";
                }
                TeacherTextBox.Text = value;
            }

        }

        private void AuditorysButton_Click(object sender, EventArgs e)
        {
            int type = 3;
            ItemsSelectorModalWindow auditorys = new ItemsSelectorModalWindow(type, scheduleDataModel);

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
            int type = 5;
            ItemsSelectorModalWindow discipline = new ItemsSelectorModalWindow(type, scheduleDataModel);

            if (discipline.ShowDialog() == DialogResult.OK)
            {
                List<int?> idsList = discipline.idsList;
                List<string> TitleList = discipline.TitleList;
                var value = " ";

                if (idsList.Count > 0)
                {
                    value = "";
                    foreach (var name in TitleList)
                        value += name + " ";
                }
                DisciplineTextBox.Text = value;
            }
        }

        private void Filter_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
