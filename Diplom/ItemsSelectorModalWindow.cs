using System;
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
        public List<string> TitleList;

        List<string> Kafedra;

        ScheduleRow nagr;

        Dictionary<int, Teacher> teachers;
        Dictionary<int, Auditory> auditories;
        Dictionary<int, SubGroup> sub_groups_info;

        internal ItemsSelectorModalWindow(int type, ScheduleRow nagr, ScheduleDataModel scheduleDataModel)
        {
            InitializeComponent();

            this.nagr = nagr;

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

        internal ItemsSelectorModalWindow(int type, ScheduleDataModel scheduleDataModel)
        {
            InitializeComponent();

            teachers = scheduleDataModel.GetTeachers();
            auditories = scheduleDataModel.GetAuditories();
            sub_groups_info = scheduleDataModel.GetGroups();

            if (type == 1)
                ReadTeachersFilter();
            if (type == 2)
                ReadGroupsFilter();
            if (type == 3)
                ReadAuditorysFilter();
        }

        internal ItemsSelectorModalWindow(int type, ScheduleDataModel scheduleDataModel, List<string> Kafedra)
        {
            InitializeComponent();

            this.Kafedra = Kafedra;

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
                    Checked = nagr.teachers.Contains(x.Key)
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
                   // Checked = nagr.teachers.Contains(x.Key)
                }).ToList()
            );
        }

        private void ReadGroups()
        {
            ItemsDGV.DataSource = new BindingListView<RowCheckedItem>(
                sub_groups_info.Select(x => new RowCheckedItem
                {
                    Key = x.Key,
                    Value = x.Value.title,
                    Checked = nagr.sub_groups.Contains(x.Key),
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
                    //Checked = nagr.sub_groups.Contains(x.Key),
                }).ToList()
            );
        }

        private void ReadAuditorys()
        {
            ItemsDGV.DataSource = new BindingListView<RowCheckedItem>(
                auditories.Select(x => new RowCheckedItem
                {
                    Key = x.Key,
                    Value = x.Value.title,
                    Checked = nagr.auds.Contains(x.Key),
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
                    //Checked = nagr.auds.Contains(x.Key),
                }).ToList()
            );
        }

        private void ReadKafedraFilter()
        {
            ItemsDGV.DataSource = new BindingListView<RowCheckedItem>(
                Kafedra.Select(x => new RowCheckedItem
                {
                    Value = x
                }).OrderBy(x => x.Value).ToList()
            );
        }

        private void ReadDisciplineFilter()
        {
            ItemsDGV.DataSource = new BindingListView<RowCheckedItem>(
                Kafedra.Select(x => new RowCheckedItem
                {
                    Value = x
                }).OrderBy(x => x.Value).ToList()
            );
        }

        private void Choice_Click(object sender, EventArgs e)
        {
            idsList = new List<int?>();
            TitleList = new List<string>();

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
            TitleList = items.Select(x => x.Value).ToList();

            this.DialogResult = DialogResult.OK;
        }

        private void filter_TextChanged(object sender, EventArgs e)
        {
            (ItemsDGV.DataSource as BindingListView<RowCheckedItem>).ApplyFilter(x =>
            {
                return filter.Text == "" || x.Value.Contains(filter.Text);
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
