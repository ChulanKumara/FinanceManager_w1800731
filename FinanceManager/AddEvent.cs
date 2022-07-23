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
                oEventDetails.Add(eventDetails);
                eventDetails = null;

                gvEvent.DataSource = null;
                gvEvent.DataSource = oEventDetails;
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