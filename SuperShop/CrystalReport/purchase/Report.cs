using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SuperShop.CrystalReport.purchase
{
    public partial class Report : Form
    {
        public Report()
        {
            InitializeComponent();
        }

        public string Data { get { return textBox1.Text; } set { textBox1.Text = value; } }
        public string Data1 { get { return textBox2.Text; } set { textBox2.Text = value; } }
        public string Data2 { get { return textBox3.Text; } set { textBox3.Text = value; } }
        private void Report_Load(object sender, EventArgs e)
        {
            if(textBox1.Text=="paid")
            {
                purchase.type obj = new type();
                obj.SetParameterValue("type",textBox2.Text);
                crystalReportViewer1.ReportSource = obj;
            }
            else if (textBox1.Text == "due")
            {
                purchase.type obj = new type();
                obj.SetParameterValue("type", textBox2.Text);
                crystalReportViewer1.ReportSource = obj;
            }
            
            else if (textBox1.Text == "left")
            {
                purchase.type obj = new type();
                obj.SetParameterValue("type", textBox2.Text);
                crystalReportViewer1.ReportSource = obj;
            }
            else if (textBox1.Text == "daily")
            {
                purchase.dailyPurchase obj = new dailyPurchase();
                obj.SetParameterValue("date", textBox2.Text);
                crystalReportViewer1.ReportSource = obj;
            }
            else if (textBox1.Text == "month")
            {
                purchase.monthlyPurchase obj = new monthlyPurchase();
                obj.SetParameterValue("date", textBox2.Text);
                crystalReportViewer1.ReportSource = obj;
            }
            else if (textBox1.Text == "monthSupliyer")
            {
                purchase.MonthlysupliyerAccordingReport obj = new MonthlysupliyerAccordingReport();
                obj.SetParameterValue("id", textBox2.Text);
                obj.SetParameterValue("date", textBox3.Text);
                crystalReportViewer1.ReportSource = obj;
            }
            else if (textBox1.Text == "week")
            {
                purchase.weeklyPurchase obj = new weeklyPurchase();
                obj.SetParameterValue("date", textBox2.Text);
                obj.SetParameterValue("dateB", textBox3.Text);
                crystalReportViewer1.ReportSource = obj;
            }
            else if (textBox1.Text == "week")
            {
                purchase.weeklyPurchase obj = new weeklyPurchase();
                obj.SetParameterValue("date", textBox2.Text);
                obj.SetParameterValue("dateB", textBox3.Text);
                crystalReportViewer1.ReportSource = obj;
            }
            else if (textBox1.Text == "sup")
            {
                purchase.supliyerAccordingReport obj = new supliyerAccordingReport();
                obj.SetParameterValue("id", textBox2.Text);
               
                crystalReportViewer1.ReportSource = obj;
            }

            else if (textBox1.Text == "dailyCash")
            {
                purchase.datewisetype obj = new datewisetype();
                obj.SetParameterValue("type", textBox3.Text);
                obj.SetParameterValue("date", textBox2.Text);

                crystalReportViewer1.ReportSource = obj;
            }
   
            else if (textBox1.Text == "vouch")
            {
                purchase.voucherPurchaseReport obj = new voucherPurchaseReport();
            
                obj.SetParameterValue("id", textBox2.Text);

                crystalReportViewer1.ReportSource = obj;
            }
            
        }
    }
}
