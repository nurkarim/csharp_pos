using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SuperShop.CrystalReport.sale.ViewReport
{
    public partial class saleReportViewer : Form
    {
        public saleReportViewer()
        {
            InitializeComponent();
        }
        public string SL { get { return txt_sl.Text; } set { txt_sl.Text = value; } }
        public string Type { get { return txt_type.Text; } set { txt_type.Text = value; } }
        public string dateA { get { return label1.Text; } set { label1.Text = value; } }
        public string dateB { get { return label2.Text; } set { label2.Text = value; } }
        private void saleReportViewer_Load(object sender, EventArgs e)
        {
            if(txt_sl.Text=="dateA")
            {
                CrystalReport.sale.DailySaleReport obj = new DailySaleReport();
                obj.SetParameterValue("date",label1.Text);
                crystalReportViewer1.ReportSource = obj;
                crystalReportViewer1.Refresh();
            }
            else if (txt_sl.Text == "dateADateB")
            {
                CrystalReport.sale.MonthlySaleReport obj = new MonthlySaleReport();
                obj.SetParameterValue("dateA", label1.Text);
                obj.SetParameterValue("dateB", label2.Text);
                crystalReportViewer1.ReportSource = obj;
                crystalReportViewer1.Refresh();
            }
            else if (txt_sl.Text == "typea")
            {
                CrystalReport.sale.CashSaleReport obj = new CashSaleReport();
                obj.SetParameterValue("type", txt_type.Text);
                crystalReportViewer1.ReportSource = obj;
                crystalReportViewer1.Refresh();
            }
            else if (txt_sl.Text == "typeAndDate")
            {
                CrystalReport.sale.dailyTypeWaiseSaleReport obj = new dailyTypeWaiseSaleReport();
                obj.SetParameterValue("type", txt_type.Text);
                obj.SetParameterValue("date", label1.Text);
                crystalReportViewer1.ReportSource = obj;
                crystalReportViewer1.Refresh();
            }

            else if (txt_sl.Text == "typeAndDateToDate")
            {
                CrystalReport.sale.MonthlyTypeWiseSaleReport obj= new MonthlyTypeWiseSaleReport();
                obj.SetParameterValue("type", txt_type.Text);
                obj.SetParameterValue("dateA", label1.Text);
                obj.SetParameterValue("dateB", label2.Text);
                crystalReportViewer1.ReportSource = obj;
                crystalReportViewer1.Refresh();
            }
            else if (txt_sl.Text == "month")
            {
                CrystalReport.sale.onlyMonthlySaleReport obj = new onlyMonthlySaleReport();
               
                obj.SetParameterValue("month", label1.Text);
               
                crystalReportViewer1.ReportSource = obj;
                crystalReportViewer1.Refresh();
            }

            else if (txt_sl.Text == "all")
            {
                CrystalReport.sale.allSaleReport obj = new allSaleReport();

              
                crystalReportViewer1.ReportSource = obj;
                crystalReportViewer1.Refresh();
            }

            else if (txt_sl.Text == "customerAcording")
            {
                CrystalReport.sale.customerSaleReport obj = new customerSaleReport();

                obj.SetParameterValue("id", label1.Text);

                crystalReportViewer1.ReportSource = obj;
                crystalReportViewer1.Refresh();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txt_type_Click(object sender, EventArgs e)
        {

        }

        private void txt_sl_Click(object sender, EventArgs e)
        {

        }
    }
}
