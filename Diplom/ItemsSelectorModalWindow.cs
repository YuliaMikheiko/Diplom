﻿using System;
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

        ScheduleRow nagr;
       // int row;
        Dictionary<int, Teacher> teachers;
        Dictionary<int, Auditory> auditories;
        Dictionary<int, SubGroup> sub_groups_info;

        internal ItemsSelectorModalWindow(int type, ScheduleRow nagr, ScheduleDataModel scheduleDataModel)
        {
            DataGridViewColumn CheckColumn = new DataGridViewTextBoxColumn();
            DataGridViewColumn IdColumn = new DataGridViewTextBoxColumn();
            DataGridViewColumn NameColumn = new DataGridViewTextBoxColumn();

            CheckColumn.DataPropertyName = "Checked";
            IdColumn.DataPropertyName = "Key";
            NameColumn.DataPropertyName = "Value";


            InitializeComponent();
            this.nagr = nagr;

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
            ItemsDGV.DataSource = teachers.Select(x => new RowCheckedItem
            {
                Key = x.Key,
                Value = x.Value.name,
                Checked = nagr.teachers.Contains(x.Key),
            }).OrderByDescending(x =>x.Checked).ToList();
        }

        private void ReadGroups()
        {
            ItemsDGV.DataSource = sub_groups_info.Select(x => new RowCheckedItem
            {
                Key = x.Key,
                Value = x.Value.title,
                Checked = nagr.sub_groups.Contains(x.Key),
            }).OrderByDescending(x => x.Checked).ToList();
        }

        private void ReadAuditorys()
        {
            ItemsDGV.DataSource = auditories.Select(x => new RowCheckedItem
            {
                Key = x.Key,
                Value = x.Value.title,
                Checked = nagr.auds.Contains(x.Key),
            }).OrderByDescending(x => x.Checked).ToList();
        }

        private void Choice_Click(object sender, EventArgs e)
        {
            idsList = new List<int?>();
            TitleList = new List<string>();

            var items = (ItemsDGV.DataSource as List<RowCheckedItem>).Where(x => x.Checked);

            foreach (DataGridViewRow rows in ItemsDGV.Rows)
            {
                if (rows.Cells[0].Value != null)
                {
                    if ((bool)rows.Cells[0].Value)
                    {
                        idsList.Add((int)rows.Cells[1].Value);
                    }
                }
            }
            TitleList = items.Select(x => x.Value).ToList();


            this.DialogResult = DialogResult.OK;
        }
    }

    public class RowCheckedItem
    {
        public bool Checked { get; set; }
        public int Key { get; set; }
        public string Value { get; set; }
    }
}
