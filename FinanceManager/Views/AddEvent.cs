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
    public partial class AddEvent : Form
    {
        public static List<EventDetails> oEventDetails = new List<EventDetails>();

        public AddEvent()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateChildren(ValidationConstraints.Enabled))
                {
                    EventDetails eventDetails = new EventDetails();
                    eventDetails.Name = txtName.Text;
                    eventDetails.Description = txtDescription.Text;
                    if (rbTask.Checked)
                    {
                        eventDetails.Type = rbTask.Text;
                    }
                    else if (rbAppoinment.Checked)
                    {
                        eventDetails.Type = rbAppoinment.Text;
                    }
                    if (chkRecurring.Checked)
                    {
                        eventDetails.Recurring = true;
                    }
                    else
                    {
                        eventDetails.Recurring = false;
                    }
                    eventDetails.Date = Convert.ToDateTime(dpDate.Text);
                    oEventDetails.Add(eventDetails);
                    eventDetails = null;

                    gvEvent.DataSource = null;
                    gvEvent.DataSource = oEventDetails;
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

        private void txtName_Validating(object sender, CancelEventArgs e)
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

        private void txtDescription_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDescription.Text))
            {
                e.Cancel = true;
                txtDescription.Focus();
                epDescription.SetError(txtDescription, "Description should not be left blank!");
            }
            else
            {
                e.Cancel = false;
                epDescription.SetError(txtDescription, "");
            }
        }
    }
}