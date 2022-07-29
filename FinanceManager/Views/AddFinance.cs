using FinanceManager.Business;
using FinanceManager.DB;
using FinanceManager.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;

namespace FinanceManager
{
    public partial class AddFinance : Form
    {
        public static List<FinanceDetails> oFinanceDetails = new List<FinanceDetails>();
        private readonly ContactModel contactModel = new ContactModel();

        public AddFinance()
        {
            InitializeComponent();

            LoadDropDowns();
        }

        private void LoadDropDowns()
        {
            try
            {
                cmbContect.DisplayMember = "Name";
                cmbContect.ValueMember = "Id";
                cmbContect.DataSource = contactModel.GetAll();
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
                if (ValidateChildren(ValidationConstraints.Enabled))
                {
                    FinanceDetails financeDetails = new FinanceDetails();

                    financeDetails.Name = txtName.Text;
                    if (rbExpence.Checked)
                    {
                        financeDetails.Type = rbExpence.Text;
                    }
                    else if (rbIncome.Checked)
                    {
                        financeDetails.Type = rbIncome.Text;
                    }
                    financeDetails.ContactId = Convert.ToInt32(cmbContect.SelectedValue);
                    financeDetails.Amount = Convert.ToDouble(txtAmount.Text);
                    if (chkRecurring.Checked)
                    {
                        financeDetails.Recurring = true;
                    }
                    else
                    {
                        financeDetails.Recurring = false;
                    }
                    financeDetails.Date = Convert.ToDateTime(dtpDate.Text);
                    oFinanceDetails.Add(financeDetails);

                    financeDetails = null;

                    gvFinanceData.DataSource = null;
                    gvFinanceData.DataSource = oFinanceDetails;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                e.Cancel = true;
                txtName.Focus();
                epName.SetError(txtName, "Name should not be left blank!");
            }
            else
            {
                e.Cancel = false;
                epName.SetError(txtName, "");
            }
        }

        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtAmount_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAmount.Text))
            {
                e.Cancel = true;
                txtAmount.Focus();
                epAmount.SetError(txtAmount, "Name should not be left blank!");
            }
            else
            {
                e.Cancel = false;
                epAmount.SetError(txtAmount, "");
            }
        }
    }
}