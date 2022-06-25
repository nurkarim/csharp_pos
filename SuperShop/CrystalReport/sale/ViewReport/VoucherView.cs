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
    public partial class VoucherView : Form
    {
        public VoucherView()
        {
            InitializeComponent();
        }
        public string vaoucher { get { return label1.Text; } set { label1.Text = value; } }
        public string type { get { return label2.Text; } set { label2.Text = value; } }
        private void VoucherView_Load(object sender, EventArgs e)
        {
            if (label2.Text == "Electronics")
            {
            CrystalReport.sale.voucherLoanAccording obj = new voucherLoanAccording();
            obj.SetParameterValue("id",label1.Text);
            crystalReportViewer1.ReportSource = obj;
            crystalReportViewer1.Refresh();
            }
            else  if (label2.Text == "inventory")
            {
                CrystalReport.sale.voucher obj = new voucher();
                obj.SetParameterValue("voucher", label1.Text);
                crystalReportViewer1.ReportSource = obj;
                crystalReportViewer1.Refresh();
            }
            else if (label2.Text == "Garments")
            {
                CrystalReport.sale.Clothvoucher obj = new Clothvoucher();
                obj.SetParameterValue("voucher", label1.Text);
                crystalReportViewer1.ReportSource = obj;
                crystalReportViewer1.Refresh();
            }

            
        }
    }
}
