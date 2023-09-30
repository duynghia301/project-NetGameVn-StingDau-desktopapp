using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFLab6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public void ResetInput()
        {
            txtAddress.Text = txtName.Text = txtPhone.Text = "";
            dtpkDBO.Value = DateTime.Now;
        }
        public bool CheckInput()
        {

            if(txtName.Text.Trim().Length <5 || txtName.Text.Trim().Length >36)
            {
                MessageBox.Show("Length is Val!", "Error input", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                txtName.Text = "";
                txtName.Focus();
                return false;
            }

            return true;

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if(CheckInput() != true)
                {
                    return;
                }

                ListViewItem item = new System.Windows.Forms.ListViewItem(new string[] { txtName.Text, dtpkDBO.Text, txtPhone.Text, txtAddress.Text });
                lvStaff.Items.Add(item);
                ResetInput();
                txtName.Focus();
            }
            catch
            {
                //log error;
            }
            
        }

        private void lvStaff_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            txtName.Enabled = false;
            try
            {
                ListViewItem item;
                item = e.Item;

                txtName.Text = item.Text;
                dtpkDBO.Text = item.SubItems[1].Text;
                txtPhone.Text = item.SubItems[2].Text;
                txtAddress.Text = item.SubItems[3].Text;
            }
            catch { }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int total = lvStaff.Items.Count;
            for(int i=0; i<total; i++)
            {
                if(lvStaff.Items[i].Text == txtName.Text)
                {
                    lvStaff.Items[i].SubItems[1].Text = dtpkDBO.Text;
                    lvStaff.Items[i].SubItems[2].Text = txtPhone.Text;
                    lvStaff.Items[i].SubItems[3].Text = txtAddress.Text;
                    ResetInput();
                    return;
                }
            }
            
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            int total = lvStaff.Items.Count;
            for (int i = 0; i < total; i++)
            {
                if (lvStaff.Items[i].Text == txtName.Text)
                {
                    lvStaff.Items.RemoveAt(i);
                    ResetInput();
                    return;
                }
            }
        }
    }
}
