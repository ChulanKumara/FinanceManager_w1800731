using FinanceManager.Business;
using FinanceManager.Models;
using System;
using System.Windows.Forms;

namespace FinanceManager
{
    public partial class SearchFinance : Form
    {
        private readonly FinanceModel financeModel = new FinanceModel();

        public SearchFinance()
        {
            InitializeComponent();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            try
            {
                LoadGrid();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void LoadGrid()
        {
            try
            {
                gvFinanceData.AutoGenerateColumns = false;
                string type = string.Empty;
                if (rbExpence.Checked)
                {
                    type = rbExpence.Text;
                }
                else if (rbIncome.Checked)
                {
                    type = rbIncome.Text;
                }

                gvFinanceData.DataSource = financeModel.GetAllDataByParams(type, dtpFromDate.Value, dtpToDate.Value);

                DataGridViewButtonColumn btnUpdate = new DataGridViewButtonColumn
                {
                    Name = "btnUpdate",
                    HeaderText = "Update Data",
                    Text = "Update"
                };
                if (gvFinanceData.Columns["btnUpdate"] == null)
                {
                    gvFinanceData.Columns.Insert(7, btnUpdate);
                }

                DataGridViewButtonColumn btnDelete = new DataGridViewButtonColumn
                {
                    Name = "btnDelete",
                    HeaderText = "Delete Data",
                    Text = "Delete"
                };

                if (gvFinanceData.Columns["btnDelete"] == null)
                {
                    gvFinanceData.Columns.Insert(8, btnDelete);
                }

                gvFinanceData.CellClick += dataGridViewSoftware_CellClick;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void dataGridViewSoftware_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == gvFinanceData.Columns["btnDelete"].Index)
                {
                    DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete?", "Delete", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        DataGridViewRow oGridViewRow = gvFinanceData.Rows[Convert.ToInt32(e.RowIndex.ToString())];
                        var id = oGridViewRow.Cells["Id"].Value;
                        if (financeModel.DeleteData(Convert.ToInt32(id)))
                        {
                            MessageBox.Show("Data deleted successfully");
                            LoadGrid();
                        }
                        else
                        {
                            MessageBox.Show("Something went wrong!!");
                        }
                    }
                }
                if (e.ColumnIndex == gvFinanceData.Columns["btnUpdate"].Index)
                {
                    DialogResult dialogResult = MessageBox.Show("Are you sure you want to update this record?", "Update", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        DataGridViewRow oGridViewRow = gvFinanceData.Rows[Convert.ToInt32(e.RowIndex.ToString())];
                        FinanceDetails financeDetails = new FinanceDetails();

                        try
                        {
                            double Amount = Convert.ToDouble(oGridViewRow.Cells["Amount"].Value);
                            financeDetails.Id = Convert.ToInt32(oGridViewRow.Cells["Id"].Value);
                            financeDetails.ContactId = Convert.ToInt32(oGridViewRow.Cells["ContactId"].Value);
                            financeDetails.Name = oGridViewRow.Cells["Name"].Value.ToString();
                            financeDetails.Type = oGridViewRow.Cells["Type"].Value.ToString();
                            financeDetails.Amount = Amount;
                            financeDetails.Recurring = (bool)oGridViewRow.Cells["Recurring"].Value;
                            financeDetails.Date = (DateTime)oGridViewRow.Cells["Date"].Value;
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Aount data is not correct");
                        }

                        if (financeModel.UpdateData(financeDetails))
                        {
                            MessageBox.Show("Data updated successfully");
                            LoadGrid();
                        }
                        else
                        {
                            MessageBox.Show("Something went wrong!!");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}