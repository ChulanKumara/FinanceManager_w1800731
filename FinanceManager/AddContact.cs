using FinanceManager.Common;
using FinanceManager.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinanceManager
{
    public partial class AddContact : Form
    {
        public static List<ContactDetails> oContactDetails = new List<ContactDetails>();

        public AddContact()
        {
            InitializeComponent();
            LoadDropDowns();
        }

        private void LoadDropDowns()
        {
            try
            {
                cmbCategory.DisplayMember = "TextField";
                cmbCategory.ValueMember = "ValueField";
                cmbCategory.DataSource = CommonValues.ComboboxDataBind(typeof(ContactCatogery));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                ContactDetails contactDetails = new ContactDetails();
                contactDetails.Name = txtName.Text;
                if (rbPayee.Checked)
                {
                    contactDetails.Type = rbPayee.Text;
                }
                else if (rbPayer.Checked)
                {
                    contactDetails.Type = rbPayer.Text;
                }
                contactDetails.Catogery = Convert.ToInt32(cmbCategory.SelectedValue);
                oContactDetails.Add(contactDetails);
                contactDetails = null;

                gvContact.DataSource = null;
                gvContact.DataSource = oContactDetails;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}