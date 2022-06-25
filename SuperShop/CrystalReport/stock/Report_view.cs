using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using CrystalDecisions.CrystalReports.Engine;
namespace SuperShop.CrystalReport.stock
{
    public partial class Report_view : Form
    {
        public Report_view()
        {
            InitializeComponent();
        }
        ReportDocument cryRpt = new ReportDocument();
        public string Type { get { return textBox1.Text; } set { textBox1.Text = value; } }
        public string Date1 { get { return textBox2.Text; } set { textBox2.Text = value; } }
        public string Date2 { get { return textBox3.Text; } set { textBox3.Text = value; } }
        public string SoftwareType { get { return label1.Text; } set { label1.Text = value; } }

        DB.config con = new DB.config();
        DB.query _query = new DB.query();
        MySqlConnection cn;
        ReportDocument crysal = new ReportDocument();
        private void Report_view_Load(object sender, EventArgs e)
        {
            if(textBox1.Text=="all")
            {
                CrystalReport.stock.stock obj = new stock();
                crystalReportViewer1.ReportSource = obj;

            }
            else if (textBox1.Text == "barcode")
            {
                CrystalReport.stock.barcode obj = new barcode();
                obj.SetParameterValue("id",textBox2.Text);
                crystalReportViewer1.ReportSource = obj;

            }

            else if (textBox1.Text == "cat")
            {
                if (label1.Text == "Electronics")
                {
                CrystalReport.stock.product_type_stok_report obj = new product_type_stok_report();
                obj.SetParameterValue("catId", textBox2.Text);
                crystalReportViewer1.ReportSource = obj;
                }
                else
                {
                    CrystalReport.stock.InventoryProduct_type_stok_report obj = new InventoryProduct_type_stok_report();
                    obj.SetParameterValue("catId", textBox2.Text);
                    crystalReportViewer1.ReportSource = obj;
                }

            }

            else if (textBox1.Text == "scat")
            {
                if (label1.Text == "Electronics")
                {
                    CrystalReport.stock.product_subCategory_stok_report obj = new product_subCategory_stok_report();
                    obj.SetParameterValue("catId", textBox2.Text);
                    crystalReportViewer1.ReportSource = obj;
                }
                else
                {
                    CrystalReport.stock.inventoryProduct_subCategory_stok_report obj = new inventoryProduct_subCategory_stok_report();
                    obj.SetParameterValue("catId", textBox2.Text);
                    crystalReportViewer1.ReportSource = obj;
                }

            }
            else if (textBox1.Text == "exp")
            {
                if (label1.Text == "Electronics")
                {
                    CrystalReport.stock.exper_date obj = new exper_date();
                    obj.SetParameterValue("date", textBox2.Text);
                    crystalReportViewer1.ReportSource = obj;
                }
                else
                {
                    CrystalReport.stock.inventory_exper_date obj = new inventory_exper_date();
                    obj.SetParameterValue("date", textBox2.Text);
                    crystalReportViewer1.ReportSource = obj;
                }
            }   
        }

        private void button1_Click(object sender, EventArgs e)
        {
         
        }
    }
}
