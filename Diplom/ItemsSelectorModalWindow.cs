﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Equin.ApplicationFramework;

namespace Diplom
{
    public partial class ItemsSelectorModalWindow : Form
    {

        public List<int?> idsList;
        public List<string> titleList;

        List<string> title;
        List<string> titleText;

        Object dataItem;

        Dictionary<int, Teacher> teachers;
        Dictionary<int, Auditory> auditories;
        Dictionary<int, SubGroup> sub_groups_info;

        internal ItemsSelectorModalWindow(int type, Object dataItem, ScheduleDataModel scheduleDataModel)
        {
            InitializeComponent();

            this.dataItem = dataItem;

            teachers = scheduleDataModel.GetTeachers();
            auditories = scheduleDataModel.GetAuditories();
            sub_groups_info = scheduleDataModel.GetGroups();

            if (type == 1)
                ReadTeachers();
            if (type == 2)
                ReadGroups();
            if (type == 3)
                ReadAuditorys();
        }

        internal ItemsSelectorModalWindow(int type, ScheduleDataModel scheduleDataModel, List<string> titleText)
        {
            InitializeComponent();

            teachers = scheduleDataModel.GetTeachers();
            auditories = scheduleDataModel.GetAuditories();
            sub_groups_info = scheduleDataModel.GetGroups();

            this.titleText = titleText;

            if (type == 1)
                ReadTeachersFilter();
            if (type == 2)
                ReadGroupsFilter();
            if (type == 3)
                ReadAuditorysFilter();
        }

        internal ItemsSelectorModalWindow(int type, List<string> titleText, List<string> title)
        {
            InitializeComponent();

            this.title = title;
            this.titleText = titleText;

            if (type == 4)
                ReadKafedraFilter();
            if (type == 5)
                ReadDisciplineFilter();
        }

        private void ReadTeachers()
        {
            ItemsDGV.DataSource = new BindingListView<RowCheckedItem>(
                teachers.Select(x => new RowCheckedItem
                {
                    Key = x.Key,
                    Value = x.Value.name,
                    Checked = dataItem.ToString().Contains(x.Value.name)
                }).OrderByDescending(x => x.Checked).ToList()
            );
        }

        private void ReadTeachersFilter()
        {
            ItemsDGV.DataSource = new BindingListView<RowCheckedItem>(
                teachers.Select(x => new RowCheckedItem
                {
                    Key = x.Key,
                    Value = x.Value.name,
                    Checked = titleText.Contains(x.Value.name)
                }).OrderByDescending(x => x.Checked).ToList()
            );
        }

        private void ReadGroups()
        {
            ItemsDGV.DataSource = new BindingListView<RowCheckedItem>(
                sub_groups_info.Select(x => new RowCheckedItem
                {
                    Key = x.Key,
                    Value = x.Value.title,
                    Checked = dataItem.ToString().Contains(x.Value.title)
                }).OrderByDescending(x => x.Checked).ToList()
            );
        }

        private void ReadGroupsFilter()
        {
            ItemsDGV.DataSource = new BindingListView<RowCheckedItem>(
                sub_groups_info.Select(x => new RowCheckedItem
                {
                    Key = x.Key,
                    Value = x.Value.title,
                    Checked = titleText.Contains(x.Value.title)
                }).OrderByDescending(x => x.Checked).ToList()
            );
        }

        private void ReadAuditorys()
        {
            ItemsDGV.DataSource = new BindingListView<RowCheckedItem>(
                auditories.Select(x => new RowCheckedItem
                {
                    Key = x.Key,
                    Value = x.Value.title,
                    Checked = dataItem.ToString().Contains(x.Value.title)
                }).OrderByDescending(x => x.Checked).ToList()
            );
        }

        private void ReadAuditorysFilter()
        {
            ItemsDGV.DataSource = new BindingListView<RowCheckedItem>(
                auditories.Select(x => new RowCheckedItem
                {
                    Key = x.Key,
                    Value = x.Value.title,
                    Checked = titleText.Contains(x.Value.title)
                }).OrderByDescending(x => x.Checked).ToList()
            );
        }

        private void ReadKafedraFilter()
        {
            ItemsDGV.DataSource = new BindingListView<RowCheckedItem>(
                title.Select(x => new RowCheckedItem
                {
                    Value = x,
                    Checked = titleText.Contains(x)
                }).OrderByDescending(x => x.Checked).OrderBy(x => x.Value).ToList()
            );
        }

        private void ReadDisciplineFilter()
        {
            ItemsDGV.DataSource = new BindingListView<RowCheckedItem>(
                title.Select(x => new RowCheckedItem
                {
                    Value = x,
                    Checked = titleText.Contains(x)
                }).OrderByDescending(x => x.Checked).OrderBy(x => x.Value).ToList()
            );
        }

        private void Choice_Click(object sender, EventArgs e)
        {
            idsList = new List<int?>();
            titleList = new List<string>();

            var items = (ItemsDGV.DataSource as BindingListView<RowCheckedItem>).Where(x => x.Checked);

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
            titleList = items.Select(x => x.Value).ToList();

            this.DialogResult = DialogResult.OK;
        }

        private void Filter_TextChanged(object sender, EventArgs e)
        {
            (ItemsDGV.DataSource as BindingListView<RowCheckedItem>).ApplyFilter(x =>
            {
                return Filter.Text == "" || x.Value.ToUpper().Contains(Filter.Text.ToUpper());
            });
        }
    }

    public class RowCheckedItem
    {
        public bool Checked { get; set; }
        public int Key { get; set; }
        public string Value { get; set; }
    }
}
