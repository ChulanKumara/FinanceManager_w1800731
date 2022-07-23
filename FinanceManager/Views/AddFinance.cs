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

        public FinanceManagerDB financeManagerDB = new FinanceManagerDB();

        public AddFinance()
        {
            InitializeComponent();
            if (File.Exists("FinanceDatabase.xml"))
            {
                financeManagerDB.ReadXml("FinanceDatabase.xml");
            }
            LoadDropDowns();
        }

        private void LoadDropDowns()
        {
            try
            {
                cmbContect.DisplayMember = "Name";
                cmbContect.ValueMember = "Id";
                cmbContect.DataSource = financeManagerDB.Contact;
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
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}