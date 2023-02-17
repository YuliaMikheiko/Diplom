using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Equin.ApplicationFramework;

namespace Diplom
{
    public partial class ItemsSelectorModalWindow : Form
    {
        public List<int?> idsList;
        public List<string> titleList;

        List<string> title;
        List<KeyValuePair<int, string>> Nt;
        List<string> titleText;

        Dictionary<int, Teacher> teachers;
        Dictionary<int, Auditory> auditories;
        Dictionary<int, SubGroup> sub_groups_info;

        internal ItemsSelectorModalWindow(int type, ScheduleDataModel scheduleDataModel, List<string> titleText)
        {
            InitializeComponent();

            teachers = scheduleDataModel.GetTeachers();
            auditories = scheduleDataModel.GetAuditories();
            sub_groups_info = scheduleDataModel.GetGroups();

            this.titleText = titleText;

            if (type == 0)
                ReadTeachers();
            if (type == 1)
                ReadGroups();
            if (type == 2)
                ReadAuditorys();
        }

        internal ItemsSelectorModalWindow(List<string> titleText, List<string> title)
        {
            InitializeComponent();

            this.title = title;
            this.titleText = titleText;

            ReadFilter();
        }

        internal ItemsSelectorModalWindow(List<string> titleText, List<KeyValuePair<int, string>> Nt)
        {
            InitializeComponent();

            this.Nt = Nt;
            this.titleText = titleText;

            ReadNt();
        }

        private void ReadTeachers()
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
                    Checked = titleText.Contains(x.Value.title)
                }).OrderByDescending(x => x.Checked).ToList()
            );
        }

        private void ReadFilter()
        {
            keyDataGridViewTextBoxColumn.Visible = false;
            ItemsDGV.DataSource = new BindingListView<RowCheckedItem>(
                title.Select(x => new RowCheckedItem
                {
                    Value = x,
                    Checked = titleText.Contains(x)
                }).OrderBy(x => x.Value).OrderByDescending(x => x.Checked).ToList()
            );
        }

        private void ReadNt()
        {
            ItemsDGV.DataSource = new BindingListView<RowCheckedItem>(
                Nt.Select(x => new RowCheckedItem
                {
                    Key = x.Key,
                    Value = x.Value,
                    Checked = titleText.Contains(x.Value)
                }).OrderBy(x => x.Key).OrderByDescending(x => x.Checked).ToList()
            );
        }

        private void Choice_Click(object sender, EventArgs e)
        {
            idsList = new List<int?>();
            titleList = new List<string>();

            (ItemsDGV.DataSource as BindingListView<RowCheckedItem>).RemoveFilter();

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

        private void Reset_Click(object sender, EventArgs e)
        {
            Filter.Clear();

            (ItemsDGV.DataSource as BindingListView<RowCheckedItem>).RemoveFilter();

            foreach (DataGridViewRow rows in ItemsDGV.Rows)
                rows.Cells[0].Value = false;


        }
    }

    public class RowCheckedItem
    {
        public bool Checked { get; set; }
        public int Key { get; set; }
        public string Value { get; set; }
    }
}