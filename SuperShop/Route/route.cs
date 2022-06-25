using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using SuperShop.Route;
using System.Windows.Forms;
namespace SuperShop.Route
{
    class route
    {
        private string typeUserId;
        public string User_Name
        {
            get { return typeUserId; }
            set { typeUserId = value; }
        }
          
        public void FromCheck()
        {
            if (Application.OpenForms.OfType<Payroll.From.add_bonus>().Count() == 1)
            {
                Application.OpenForms.OfType<Payroll.From.add_bonus>().First().Close();
            }
            if (Application.OpenForms.OfType<Payroll.From.finalizeSalery>().Count() == 1)
            {
                Application.OpenForms.OfType<Payroll.From.finalizeSalery>().First().Close();
            }
            if (Application.OpenForms.OfType<Payroll.From.EmployeeManageSalary>().Count() == 1)
            {
                Application.OpenForms.OfType<Payroll.From.EmployeeManageSalary>().First().Close();
            }
            if (Application.OpenForms.OfType<Payroll.From.employee_attendance>().Count() == 1)
            {
                Application.OpenForms.OfType<Payroll.From.employee_attendance>().First().Close();
            }
            if (Application.OpenForms.OfType<View.employee.addNewEmployee>().Count() == 1)
            {
                Application.OpenForms.OfType<View.employee.addNewEmployee>().First().Close();
            }
            if (Application.OpenForms.OfType<View.Electronic.PurchaseElectronic>().Count() == 1)
            {
                Application.OpenForms.OfType<View.Electronic.PurchaseElectronic>().First().Close();
            }
            if (Application.OpenForms.OfType<View.BesicSetup.Category>().Count() == 1)
            {
                Application.OpenForms.OfType<View.BesicSetup.Category>().First().Close();
            }
            if (Application.OpenForms.OfType<View.BesicSetup.SubCategory>().Count() == 1)
            {
                Application.OpenForms.OfType<View.BesicSetup.SubCategory>().First().Close();
            }
            if (Application.OpenForms.OfType<View.BesicSetup.Brand>().Count() == 1)
            {
                Application.OpenForms.OfType<View.BesicSetup.Brand>().First().Close();
            }
            if (Application.OpenForms.OfType<View.Product.product>().Count() == 1)
            {
                Application.OpenForms.OfType<View.Product.product>().First().Close();
            }
            if (Application.OpenForms.OfType<View.DailyOperation.IncomeExpenseSourch>().Count() == 1)
            {
                Application.OpenForms.OfType<View.DailyOperation.IncomeExpenseSourch>().First().Close();
            }
            if (Application.OpenForms.OfType< View.purchase.Record>().Count() == 1)
            {
                Application.OpenForms.OfType<View.purchase.Record>().First().Close();
            }
            if (Application.OpenForms.OfType<View.sale.RecordSale>().Count() == 1)
            {
                Application.OpenForms.OfType<View.sale.RecordSale>().First().Close();
            }
            if (Application.OpenForms.OfType<CrystalReport.sale.ViewReport.VoucherView>().Count() == 1)
            {
                Application.OpenForms.OfType<CrystalReport.sale.ViewReport.VoucherView>().First().Close();
            }
            if (Application.OpenForms.OfType<View.user.user>().Count() == 1)
            {
                Application.OpenForms.OfType<View.user.user>().First().Close();
            }
            if (Application.OpenForms.OfType<View.customer.ReportFrom>().Count() == 1)
            {
                Application.OpenForms.OfType<View.customer.ReportFrom>().First().Close();
            }
        }
        public void user()
        {

            View.user.user obj = new View.user.user();
            FromCheck();
            obj.MdiParent = SuperShop.index.ActiveForm;
            obj.Show();
        }
        public void currency()
        {

            View.BesicSetup.currency obj = new View.BesicSetup.currency();
            FromCheck();
            obj.MdiParent = SuperShop.index.ActiveForm;
            obj.Show();
        }
        public void clientLadger()
        {

            View.customer.ReportFrom obj = new View.customer.ReportFrom();
            FromCheck();
            obj.MdiParent = SuperShop.index.ActiveForm;
            obj.StartPosition = FormStartPosition.CenterScreen;
            obj.Show();
            obj.Focus();
        }
        public void saleRecord()
        {

            View.sale.RecordSale obj = new View.sale.RecordSale();
            FromCheck();
            obj.MdiParent = SuperShop.index.ActiveForm;
            obj.Show();
        }
        public void currencySetup()
        {

            View.BesicSetup.currencySetup obj = new View.BesicSetup.currencySetup();
            FromCheck();
            obj.MdiParent = SuperShop.index.ActiveForm;
            obj.Show();
        }
        public void purchaseRecord()
        {
            
            View.purchase.Record obj = new View.purchase.Record();
            FromCheck();
            obj.MdiParent = SuperShop.index.ActiveForm;
            obj.Show();
        }
        public void stocks()
        {

            View.stock.inventoryStock obj = new View.stock.inventoryStock();
            obj.MdiParent = SuperShop.index.ActiveForm;
            obj.Show();
        }

       
        public void dashboard()
        {
            
            View.dashboard obj = new View.dashboard();
            obj.MdiParent = SuperShop.index.ActiveForm;
            obj.Show();
        }
        public void payroll()
        {
            
            View.employee.E_Dashboard obj = new View.employee.E_Dashboard();
            obj.MdiParent = SuperShop.index.ActiveForm;
            obj.Show();
        } 
   
        public void SoftwareConfig()
        {
            
            View.BesicSetup.SoftwareConfig obj = new View.BesicSetup.SoftwareConfig();
            obj.MdiParent =SuperShop.index.ActiveForm;
            obj.Show();
         }
        public void item()
        {
            
            View.BesicSetup.Item obj = new View.BesicSetup.Item();
            obj.MdiParent = SuperShop.index.ActiveForm;
            obj.Show();      
        }

        public void brand()
        {
            
            View.BesicSetup.Brand obj = new View.BesicSetup.Brand();
            
            FromCheck();
            obj.MdiParent = SuperShop.index.ActiveForm;
            obj.Show();
        }
        public void incomeExpenseTitle()
        {
            View.DailyOperation.IncomeExpenseSourch obj = new View.DailyOperation.IncomeExpenseSourch();
            FromCheck();
            obj.MdiParent = SuperShop.index.ActiveForm;
            obj.Show();

        }
        public void categoryss()
        {
            
            View.BesicSetup.Category obj = new View.BesicSetup.Category();
            FromCheck();
            obj.MdiParent = SuperShop.index.ActiveForm;
            obj.Show();
        }
        public void Subcategoryss()
        {
           
            View.BesicSetup.SubCategory obj = new View.BesicSetup.SubCategory();
      
            FromCheck();
            obj.MdiParent = SuperShop.index.ActiveForm;
            obj.Show();
        }
        public void product()
        {
           
            View.Product.product obj = new View.Product.product();
          

            FromCheck();
            obj.MdiParent = SuperShop.index.ActiveForm;
            obj.Show();
        }
       
       
        public void SaleReturn()
        {
         
            View.sale.SaleReturn obj = new View.sale.SaleReturn();
            obj.MdiParent = SuperShop.index.ActiveForm;
            obj.Show();
        }
        public void SaleReport()
        {
            
            View.report.SaleReport obj = new View.report.SaleReport();
            obj.MdiParent = SuperShop.index.ActiveForm;
            obj.Show();
        }
        public void PurchaseReport()
        {
           
            View.report.purchaseReport obj = new View.report.purchaseReport();
            obj.MdiParent = SuperShop.index.ActiveForm;
            obj.Show();
        }
        public void CustomerReport()
        {
            
            View.report.ClintReport obj = new View.report.ClintReport();
            obj.MdiParent = SuperShop.index.ActiveForm;
            obj.Show();
        }
        public void incomeReport()
        {
            
            View.report.incomeReport obj = new View.report.incomeReport();
            obj.MdiParent = SuperShop.index.ActiveForm;
            obj.Show();
        }
        public void costReport()
        {
            
            View.report.CostReport obj = new View.report.CostReport();
            obj.MdiParent = SuperShop.index.ActiveForm;
            obj.Show();
        }
        public void customer()
        {
           
            View.customer.customer obj = new View.customer.customer();
            obj.MdiParent = SuperShop.index.ActiveForm;
            obj.Show();
        }
        public void income()
        {
            
            View.BesicSetup.income obj = new View.BesicSetup.income();
            obj.MdiParent = SuperShop.index.ActiveForm;
            obj.Show();
        }
        public void cost()
        {
           
            View.BesicSetup.cost obj = new View.BesicSetup.cost();
            obj.MdiParent = SuperShop.index.ActiveForm;
            obj.Show();
        }
        public void stockReport()
        {
            
            View.report.Store obj = new View.report.Store();
            obj.MdiParent = SuperShop.index.ActiveForm;
            obj.Show();
        }
        public void due()
        {
            
            View.customer.duePayment obj = new View.customer.duePayment();
            obj.MdiParent = SuperShop.index.ActiveForm;
            obj.Show();
        }

       
    }
}
