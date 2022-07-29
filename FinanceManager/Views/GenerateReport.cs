using FinanceManager.Business;
using FinanceManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace FinanceManager
{
    public partial class GenerateReport : Form
    {
        public GenerateReport()
        {
            InitializeComponent();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            try
            {
                FinanceModel financeModel = new FinanceModel();
                List<FinanceDetails> oFinanceDetails = financeModel.GetAllDataBydate(dtpFromDate.Value, dtpToDate.Value);
                var expenceData = oFinanceDetails.FindAll(x => x.Type == "Expence").GroupBy(
                    p => p.Date.ToString("MMMM"),
                    (key, g) => new
                    {
                        Month = key,
                        Amount = g.Select(x => x.Amount).Sum()
                    }).ToList();

                var incomeData = oFinanceDetails.FindAll(x => x.Type == "Income").GroupBy(
                    p => p.Date.ToString("MMMM"),
                    (key, g) => new
                    {
                        Month = key,
                        Amount = g.Select(x => x.Amount).Sum()
                    }).ToList();

                foreach (var series in chFinance.Series)
                {
                    series.Points.Clear();
                }
                foreach (var expence in expenceData)
                {
                    chFinance.Series["Expence"].Points.AddXY(expence.Month, expence.Amount.ToString());
                }

                foreach (var income in incomeData)
                {
                    chFinance.Series["Income"].Points.AddXY(income.Month, income.Amount.ToString());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}