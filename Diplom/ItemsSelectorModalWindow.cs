using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.Json;
using System.IO;

namespace WindowsFormsApp2
{
    public partial class ItemsSelectorModalWindow : Form
    {
        public List<int?> idsList;
        public List<string> TitleList;
        private ScheduleDataModel scheduleDataModel;
        int type;
        ScheduleRow[] nagr;
        int row;
        Dictionary<int, Teacher> teachers;
        Dictionary<int, Auditory> auditories;
        Dictionary<int, SubGroup> sub_groups_info;

        internal ItemsSelectorModalWindow(int type, int row, ScheduleRow[] nagr, ScheduleDataModel scheduleDataModel)
        {
            this.scheduleDataModel = scheduleDataModel;
            InitializeComponent();
            this.nagr = nagr;
            this.type = type;
            this.row = row;
            teachers = scheduleDataModel.GetTeachers();
            auditories = scheduleDataModel.GetAuditories();
            sub_groups_info = scheduleDataModel.GetGroups();

            if (type == 1)
                ReadTeachers();
            else if (type == 2)
                ReadGroups();
            else
                ReadAuditorys();
        }

        private void ReadTeachers()
        {
            ItemsDGV.RowCount = teachers.Count;
            ItemsDGV.ColumnCount = 3;

            var i = 0;
            foreach(var teacher in teachers)
            { 
                ItemsDGV.Rows[i].Cells[1].Value = teacher.Value.id;
                ItemsDGV.Rows[i].Cells[2].Value = teacher.Value.name;
                for(int j = 0; j < nagr[row].teachers.Length; j++)
                {
                    if (nagr[row].teachers[j] == teacher.Value.id)
                    {
                        ItemsDGV.Rows[i].Cells[0].Value = true;
                    }
                }
                i++;
            }
            
        }

        private void ReadGroups()
        {
            ItemsDGV.RowCount = sub_groups_info.Count;
            ItemsDGV.ColumnCount = 3;

            var i = 0;
            foreach (var groups in sub_groups_info)
            {
                ItemsDGV.Rows[i].Cells[1].Value = groups.Value.id;
                ItemsDGV.Rows[i].Cells[2].Value = groups.Value.title;
                for (int j = 0; j < nagr[row].sub_groups.Length; j++)
                {
                    if (nagr[row].sub_groups[j] == groups.Value.id)
                    {
                        ItemsDGV.Rows[i].Cells[0].Value = true;
                    }
                }
                i++;
            }
        }

        private void ReadAuditorys()
        {
            ItemsDGV.RowCount = auditories.Count;
            ItemsDGV.ColumnCount = 3;

            var i = 0;
            foreach (var auditorys in auditories)
            {
                ItemsDGV.Rows[i].Cells[1].Value = auditorys.Value.id;
                ItemsDGV.Rows[i].Cells[2].Value = auditorys.Value.title;
                for (int j = 0; j < nagr[row].auds.Length; j++)
                {
                    if (nagr[row].auds[j] == auditorys.Value.id)
                    {
                        ItemsDGV.Rows[i].Cells[0].Value = true;
                    }
                }
                i++;
            }
        }

        private void Choice_Click(object sender, EventArgs e)
        {
            if (type == 1)
            {
                idsList = new List<int?>();
                TitleList = new List<string>();
                foreach (DataGridViewRow rows in ItemsDGV.Rows)
                {
                    if (rows.Cells[0].Value != null)
                    {
                        if ((bool)rows.Cells[0].Value)
                        {
                            idsList.Add((int)rows.Cells[1].Value);
                            TitleList.Add(rows.Cells[2].Value.ToString());
                        }
                    }
                }
            }

            if (type == 2)
            {
                idsList = new List<int?>();
                TitleList = new List<string>();
                foreach (DataGridViewRow rows in ItemsDGV.Rows)
                {
                    if (rows.Cells[0].Value != null)
                    {
                        if ((bool)rows.Cells[0].Value)
                        {
                            idsList.Add((int)rows.Cells[1].Value);
                            TitleList.Add((string)rows.Cells[2].Value);
                        }
                    }

                }
            }

            if (type == 3)
            {
                idsList = new List<int?>();
                TitleList = new List<string>();
                foreach (DataGridViewRow rows in ItemsDGV.Rows)
                {
                    if (rows.Cells[0].Value != null)
                    {
                        if ((bool)rows.Cells[0].Value)
                        {
                            idsList.Add((int)rows.Cells[1].Value);
                            TitleList.Add((string)rows.Cells[2].Value);
                        }
                    }
                }
            }
            this.DialogResult = DialogResult.OK;
        }
    }
}
