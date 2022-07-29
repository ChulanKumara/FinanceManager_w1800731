using FinanceManager.Business;
using FinanceManager.DB;
using FinanceManager.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace FinanceManager
{
    public partial class MainMenu : Form
    {
        private FinanceManagerDB financeManagerDB = new FinanceManagerDB();
        private List<FinanceDetails> financeDetails = null;
        private List<ContactDetails> contactDetails = null;
        private List<EventDetails> eventDetails = null;

        public MainMenu()
        {
            InitializeComponent();
            if (File.Exists("FinanceDatabase.xml"))
            {
                financeManagerDB.ReadXml("FinanceDatabase.xml");
            }
        }

        private async void btnAddFinance_Click(object sender, EventArgs e)
        {
            try
            {
                AddFinance addFinance = new AddFinance();
                addFinance.Activate();
                addFinance.ShowDialog();
                financeDetails = AddFinance.oFinanceDetails;
                if (financeDetails != null)
                {
                    foreach (var item in financeDetails)
                    {
                        FinanceManagerDB.FinanceRow row = financeManagerDB.Finance.NewFinanceRow();
                        row.ContactId = item.ContactId;
                        row.Name = item.Name;
                        row.Type = item.Type;
                        row.Amount = item.Amount;
                        row.Recurring = item.Recurring;
                        row.Date = item.Date;

                        financeManagerDB.Finance.AddFinanceRow(row);
                        financeManagerDB.AcceptChanges();
                    }

                    financeManagerDB.WriteXml("FinanceDatabase.xml");

                    FinanceModel financeModel = new FinanceModel();
                    if (await financeModel.SaveFinanceDetails(financeDetails))
                    {
                        MessageBox.Show("Finance Data Successfully Added!!!");
                        financeManagerDB = new FinanceManagerDB();
                        File.Delete("FinanceDatabase.xml");
                    }
                    else
                    {
                        MessageBox.Show("Something Went Wrong!!!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex}");
            }
        }

        private async void btnAddContact_Click(object sender, EventArgs e)
        {
            try
            {
                AddContact addContact = new AddContact();
                addContact.Activate();
                addContact.ShowDialog();
                contactDetails = AddContact.oContactDetails;

                if (contactDetails != null)
                {
                    foreach (var item in contactDetails)
                    {
                        FinanceManagerDB.ContactRow row = financeManagerDB.Contact.NewContactRow();
                        row.Name = item.Name;
                        row.Type = item.Type;
                        row.Category = item.Catogery;
                        financeManagerDB.Contact.AddContactRow(row);
                        financeManagerDB.AcceptChanges();
                    }

                    financeManagerDB.WriteXml("FinanceDatabase.xml");

                    ContactModel contactModel = new ContactModel();
                    if (await contactModel.SaveContactDetails(contactDetails))
                    {
                        MessageBox.Show("Contact Data Successfully Added!!!");
                        financeManagerDB = new FinanceManagerDB();
                        File.Delete("FinanceDatabase.xml");
                    }
                    else
                    {
                        MessageBox.Show("Something Went Wrong!!!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex}");
            }
        }

        private async void btnAddEvent_Click(object sender, EventArgs e)
        {
            try
            {
                AddEvent addEvent = new AddEvent();
                addEvent.Activate();
                addEvent.ShowDialog();
                eventDetails = AddEvent.oEventDetails;

                if (eventDetails != null)
                {
                    foreach (var item in eventDetails)
                    {
                        FinanceManagerDB.EventRow row = financeManagerDB.Event.NewEventRow();
                        row.Name = item.Name;
                        row.Description = item.Description;
                        row.Type = item.Type;
                        row.Recurring = item.Recurring;
                        row.Date = item.Date;
                        financeManagerDB.Event.AddEventRow(row);
                        financeManagerDB.AcceptChanges();
                    }

                    financeManagerDB.WriteXml("FinanceDatabase.xml");

                    EventModel eventModel = new EventModel();
                    if (await eventModel.SaveEventDetails(eventDetails))
                    {
                        MessageBox.Show("Event Data Successfully Added!!!");
                        financeManagerDB = new FinanceManagerDB();
                        File.Delete("FinanceDatabase.xml");
                    }
                    else
                    {
                        MessageBox.Show("Something Went Wrong!!!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex}");
            }
        }

        private void btnSearchFinance_Click(object sender, EventArgs e)
        {
            SearchFinance searchFinance = new SearchFinance();
            searchFinance.Activate();
            searchFinance.ShowDialog();
        }

        private void btnGenerateReport_Click(object sender, EventArgs e)
        {
            GenerateReport generateReport = new GenerateReport();
            generateReport.Activate();
            generateReport.ShowDialog();
        }
    }
}