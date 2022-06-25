using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Runtime.Caching;
namespace SuperShop
{
    public partial class index : Form
    {
        Route.route _route = new Route.route();
        DB.config cn = new DB.config();
        MySqlConnection connect;
        string boothName;
         
        public index(string value,string valueu2,string value3)
        {
            InitializeComponent();
            //menuStrip1.Renderer = new MyRenderer();
            txtId.Text = value;
            txtType.Text = valueu2;
            txtSoftwareType.Text = value3;
            TopLevelControl.Text = "Inventory Management                Booth: " ;
        }
        private string _booth;
        public string booths { get { return _booth; } set { _booth = value; } }
         public void con()
        {
            connect = cn.connection();
        if(connect.State==ConnectionState.Open)
        {
            connect.Close();

        }
        connect.Open();
        
        }

         public void booth()
         {
            
             try
             {

                 label1.Text = hardware.GetProcessorId();
                 con();
                 MySqlCommand cmd = new MySqlCommand("SELECT * from booth_setup where pc_id='" + label1.Text + "'", connect);
                 MySqlDataReader dr;
                 dr = cmd.ExecuteReader();
                 if (dr.Read())
                 {
                     boothName = dr["booth_name"].ToString();
                     TopLevelControl.Text ="Inventory Management                Booth: " + boothName;
                 }
                 else 
                 {

                     SoftwareConfig.ChangeBooth obj = new SoftwareConfig.ChangeBooth();
                     obj.MdiParent = this;
                     obj.Show();
                 }
             }
             catch (Exception ex)
             {
                 MessageBox.Show(ex.Message);
             }
         }
         public void Flush()
         {
             List<string> cacheKeys = MemoryCache.Default.Select(kvp => kvp.Key).ToList();
             foreach (string cacheKey in cacheKeys)
             {
                 MemoryCache.Default.Remove(cacheKey);
             }
         }

         public void checkBlance()
         {
             try
             {
                 con();
                 MySqlCommand cmd = new MySqlCommand("select * from daily_cash_statement where date='" + dateTimePicker1.Text + "'", connect);
                 MySqlDataReader dr;
                 dr = cmd.ExecuteReader();
                 if (dr.Read())
                 {
                     dr.Close();
                 }
                 else
                 {
                     View.Transection.Cash_in obj = new View.Transection.Cash_in();
                     obj.MdiParent = index.ActiveForm;
                     obj.Show();
                 }
             }
             catch(Exception)
             {}
         
         }

         public void checkMenu()
         {
             try
             {
                 con();
                 MySqlCommand cmd = new MySqlCommand("select * from menu_paiority where user_id='" + txtId.Text + "'", connect);
                 MySqlDataReader dr;
                 dr = cmd.ExecuteReader();
                 if (dr.Read())
                 {
                     if (dr["sale"].ToString() == "1")
                     {
                         saleToolStripMenuItem6.Visible = true;
                     }
                     else
                     {
                         saleToolStripMenuItem6.Visible = false;

                     }
                     if (dr["purchase"].ToString() == "1")
                     {
                         saleToolStripMenuItem4.Visible = true;
                     }
                     else
                     {
                         saleToolStripMenuItem4.Visible = false;

                     }
                     if (dr["besic"].ToString() == "1")
                     {
                         besicSetupToolStripMenuItem1.Visible = true;
                     }
                     else
                     {
                         besicSetupToolStripMenuItem1.Visible = false;

                     }
                     if (dr["customer"].ToString() == "1")
                     {
                         clientToolStripMenuItem.Visible = true;
                     }
                     else
                     {
                         clientToolStripMenuItem.Visible = false;

                     }
                     if (dr["suppliyer"].ToString() == "1")
                     {
                         supplierToolStripMenuItem.Visible = true;
                     }
                     else
                     {
                         supplierToolStripMenuItem.Visible = false;

                     }
                     if (dr["payroll"].ToString() == "1")
                     {
                         payrollToolStripMenuItem1.Visible = true;
                     }
                     else
                     {
                         payrollToolStripMenuItem1.Visible = false;

                     }

                     if (dr["stock"].ToString() == "1")
                     {
                         stockToolStripMenuItem3.Visible = true;
                     }
                     else
                     {
                         stockToolStripMenuItem3.Visible = false;

                     }

                     if (dr["record"].ToString() == "1")
                     {
                         recordToolStripMenuItem.Visible = true;
                     }
                     else
                     {
                         recordToolStripMenuItem.Visible = false;

                     }

                     if (dr["account"].ToString() == "1")
                     {
                         accountSectionToolStripMenuItem.Visible = true;
                     }
                     else
                     {
                         accountSectionToolStripMenuItem.Visible = false;

                     }

                     if (dr["setting"].ToString() == "1")
                     {
                         settingToolStripMenuItem.Visible = true;
                     }
                     else
                     {
                         settingToolStripMenuItem.Visible = false;

                     }
                     if (dr["daily_opera"].ToString() == "1")
                     {
                         dailyOperationToolStripMenuItem1.Visible = true;
                     }
                     else
                     {
                         dailyOperationToolStripMenuItem1.Visible = false;

                     }
                     if (dr["profile"].ToString() == "1")
                     {
                         profileToolStripMenuItem.Visible = true;
                     }
                     else
                     {
                         profileToolStripMenuItem.Visible = false;

                     }
                     if (dr["bank"].ToString() == "1")
                     {
                         bankToolStripMenuItem2.Visible = true;
                     }
                     else
                     {
                         bankToolStripMenuItem2.Visible = false;

                     }
                     if (dr["opening_blance"].ToString() == "1")
                     {
                         openingBalanceToolStripMenuItem.Visible = true;
                     }
                     else
                     {
                         openingBalanceToolStripMenuItem.Visible = false;

                     }
                     if (dr["expenseR"].ToString() == "1")
                     {
                         expenseToolStripMenuItem.Visible = true;
                     }
                     else
                     {
                         expenseToolStripMenuItem.Visible = false;

                     }
                     if (dr["incomeR"].ToString() == "1")
                     {
                         incomeToolStripMenuItem2.Visible = true;
                     }
                     else
                     {
                         incomeToolStripMenuItem2.Visible = false;

                     }
                     if (dr["income_expense_r"].ToString() == "1")
                     {
                         incomeExpenseToolStripMenuItem.Visible = true;
                     }
                     else
                     {
                         incomeExpenseToolStripMenuItem.Visible = false;

                     }
                     if (dr["sale_r"].ToString() == "1")
                     {
                         saleToolStripMenuItem5.Visible = true;
                     }
                     else
                     {
                         saleToolStripMenuItem5.Visible = false;

                     }
                     if (dr["purchase_r"].ToString() == "1")
                     {
                         purchaseToolStripMenuItem5.Visible = true;
                     }
                     else
                     {
                         purchaseToolStripMenuItem5.Visible = false;

                     }

                     if (dr["employee"].ToString() == "1")
                     {
                         employeeToolStripMenuItem2.Visible = true;
                     }
                     else
                     {
                         employeeToolStripMenuItem2.Visible = false;

                     }

                     if (dr["customr_ladger"].ToString() == "1")
                     {
                         clientLadgerBookToolStripMenuItem.Visible = true;
                     }
                     else
                     {
                         clientLadgerBookToolStripMenuItem.Visible = false;

                     }

                     if (dr["supliyer_r"].ToString() == "1")
                     {
                         supplierToolStripMenuItem1.Visible = true;
                     }
                     else
                     {
                         supplierToolStripMenuItem1.Visible = false;

                     }

                     if (dr["profite_loss"].ToString() == "1")
                     {
                         profitAndLossToolStripMenuItem.Visible = true;
                     }
                     else
                     {
                         profitAndLossToolStripMenuItem.Visible = false;

                     }

                     if (dr["bank_r"].ToString() == "1")
                     {
                         bankToolStripMenuItem1.Visible = true;
                     }
                     else
                     {
                         bankToolStripMenuItem1.Visible = false;

                     }

                     if (dr["stock_r"].ToString() == "1")
                     {
                         stockToolStripMenuItem2.Visible = true;
                     }
                     else
                     {
                         stockToolStripMenuItem2.Visible = false;

                     }
                     dr.Close();
                 }
                 else
                 {

                 }
             }
             catch(Exception){}
         }
        private void index_Load(object sender, EventArgs e)
        {
            booth();
            //notifyIcon1.BalloonTipText = "Application Minimized";
            //notifyIcon1.BalloonTipTitle = "Inventory Management";
            //menuStrip1.ForeColor = Color.White;
            //accountToolStripMenuItem.Enabled = false;
            checkBlance();
            Flush();
            checkMenu();
        }
        private class MyRenderer : ToolStripProfessionalRenderer
        {
            protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
            {
                Rectangle rc = new Rectangle(Point.Empty, e.Item.Size);
                Color c = e.Item.Selected ? Color.SteelBlue : Color.SteelBlue;
                using (SolidBrush brush = new SolidBrush(c))
                    e.Graphics.FillRectangle(brush, rc);
            }
        }
     
        private void softwareTitleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _route.SoftwareConfig();

            
        }

        private void index_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
               // ShowInTaskbar = false;
                //notifyIcon1.Visible = true;
                //notifyIcon1.ShowBalloonTip(1000);
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //ShowInTaskbar = false;
            //notifyIcon1.Visible = false;
            //WindowState = FormWindowState.Normal;
            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            _route.dashboard();
        }
        private void index_FormClosing(object sender, FormClosingEventArgs e)
        {
            View.login.login obj = new View.login.login();
            obj.Show();
        }
        private void pictureBox7_Click(object sender, EventArgs e)
        {
            
            
         
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            

        }

        private void addProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            if (txtSoftwareType.Text == "Electronics")
            {
                View.Product.ElectronicProduct obj = new  View.Product.ElectronicProduct();
                if (Application.OpenForms.OfType<View.Product.ElectronicProduct>().Count() == 1)
                {
                    Application.OpenForms.OfType<View.Product.ElectronicProduct>().First().Close();
                }
                obj.user = txtId.Text;
                obj.MdiParent = SuperShop.index.ActiveForm;
                obj.Show();

            }
            else if (txtSoftwareType.Text == "Garments")
            {
                View.Product.clothProduct obj = new View.Product.clothProduct();
                if (Application.OpenForms.OfType<View.Product.clothProduct>().Count() == 1)
                {
                    Application.OpenForms.OfType<View.Product.clothProduct>().First().Close();
                }
                obj.MdiParent = SuperShop.index.ActiveForm;
                obj.Show();
            }
            else if (txtSoftwareType.Text == "inventory")
            {

                _route.product();
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (txtSoftwareType.Text == "Garments")
            {
                _route.FromCheck();
                View.ClothSHop.clothPurchase obj = new View.ClothSHop.clothPurchase(txtSoftwareType.Text);
                obj.getBooth = boothName.ToString();
                obj.getUser = txtId.Text;
                obj.MdiParent = SuperShop.index.ActiveForm;
                obj.Show();
            }
            else if (txtSoftwareType.Text == "inventory")
            {
                _route.FromCheck();
                View.purchase.purchase obj = new View.purchase.purchase();
                obj.getBooth = boothName.ToString();
                obj.getUser = txtId.Text;
                obj.softwareType = txtSoftwareType.Text;
                obj.MdiParent = SuperShop.index.ActiveForm;
                obj.Show();
            }
           
            else if (txtSoftwareType.Text == "Electronics")
            {
                _route.FromCheck();
                View.Electronic.PurchaseElectronic obj = new View.Electronic.PurchaseElectronic();
                obj.Booth = boothName.ToString();
                obj.getUser = txtId.Text;
                obj.MdiParent = this;
                obj.Show();
            }
        }

        private void payrollToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
        }

        private void clientPaymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void incomeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            View.DailyOperation.Income obj = new View.DailyOperation.Income();
            obj.USERID = txtId.Text;
            obj.MdiParent = SuperShop.index.ActiveForm;
            obj.Show();
        }

        private void expensePaymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            View.DailyOperation.Expense obj = new View.DailyOperation.Expense();
            obj.USERID = txtId.Text;
            obj.MdiParent = SuperShop.index.ActiveForm;
            obj.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
           
        }

        private void newToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            _route.customer();
        }

        private void incomeToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            _route.incomeReport();
        }

        private void expenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _route.costReport();
        }

        private void purchaseToolStripMenuItem5_Click(object sender, EventArgs e)
        {
           
        }

        private void productCategoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            View.BesicSetup.SubCategory child = new View.BesicSetup.SubCategory();
            if (Application.OpenForms.OfType<View.BesicSetup.SubCategory>().Count() == 1)
            {
                Application.OpenForms.OfType<View.BesicSetup.SubCategory>().First().Close();
            }
            child.ChildText = txtId.Text;
            txtId.Text = child.ChildText;
            child.MdiParent = this;
            child.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            _route.SaleReport(); 
        }

        private void newToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            View.sale.SaleReturn obj = new View.sale.SaleReturn();
            if (Application.OpenForms.OfType<View.sale.SaleReturn>().Count() == 1)
            {
                Application.OpenForms.OfType<View.sale.SaleReturn>().First().Close();
            }
            obj.Booth = boothName.ToString();
            obj.User = txtId.Text;
            obj.MdiParent = this;
            obj.Show();
        }

        private void brandToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            _route.brand();
        }

        private void productTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _route.categoryss();
        }

        private void stockToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            _route.stocks();
        }

        private void newToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            View.supplier.supplier child = new View.supplier.supplier();

            child.User = txtId.Text;
            
            child.MdiParent = this;
            child.Show();
        }

        private void saleToolStripMenuItem7_Click(object sender, EventArgs e)
        {
        }

        private void purchaseToolStripMenuItem6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
           
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
           
        }

        private void tranToolStripMenuItem_Click(object sender, EventArgs e)
        {
            View.Transection.transectionSummary obj = new View.Transection.transectionSummary();
            obj.Booth = boothName.ToString();
            obj.User = txtId.Text;
            obj.MdiParent = this;
            obj.Show();
        }

        private void incomeAndExpenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void newToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            View.purchase.purchaseReturn obj = new View.purchase.purchaseReturn();
            obj.Booth = boothName.ToString();
            obj.User = txtId.Text;
            obj.MdiParent = this;
            obj.Show();
        }

        private void addBankToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void bankDepositToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void bankLoanToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void addSummaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
         
        }

        private void addIncomeExpenseSourchTitleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _route.incomeExpenseTitle();
        }

        private void saleReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            View.report.SaleReport obj = new View.report.SaleReport();
            obj.userName = txtId.Text;
            obj.SoftwareType = txtSoftwareType.Text;
            obj.MdiParent = this;
            obj.StartPosition = FormStartPosition.CenterScreen;
            obj.Show();
        }

        private void recordToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            _route.purchaseRecord();
        }

        private void currencyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _route.currencySetup();
        }

        private void addCurrencyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _route.currency();
        }

        private void saleToolStripMenuItem9_Click(object sender, EventArgs e)
        {

            if (txtSoftwareType.Text == "Electronics")
            {
                View.Electronic.saleElectronic obj = new View.Electronic.saleElectronic();
                obj.Booth = boothName.ToString();
                obj.getUser = txtId.Text;
                obj.MdiParent = SuperShop.index.ActiveForm;
                obj.Show();

            }
            else if (txtSoftwareType.Text == "Garments")
            {
                View.ClothSHop.clothsalep obj = new View.ClothSHop.clothsalep();
                obj.MdiParent = SuperShop.index.ActiveForm;
                obj.Show();
            }
            else if (txtSoftwareType.Text == "inventory")
            {
                View.sale.Sale obj = new View.sale.Sale();
                obj.Booth = boothName.ToString();
                obj.getUser = txtId.Text;
                obj.MdiParent = SuperShop.index.ActiveForm;
                obj.Show();

            }
        }

        private void recordToolStripMenuItem3_Click(object sender, EventArgs e)
        {

            View.sale.RecordSale obj = new View.sale.RecordSale();
            obj.Booth = boothName.ToString();
            obj.getuser = txtId.Text;
            obj.softwareType = txtSoftwareType.Text;
            obj.MdiParent = SuperShop.index.ActiveForm;
            obj.Show();


        }

        private void closeOperationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            View.DailyOperation.IncomeExpenseRecord obj = new View.DailyOperation.IncomeExpenseRecord();
            obj.USERID = txtId.Text;
            obj.MdiParent = this;
            obj.Show();
        }

        private void reportToolStripMenuItem6_Click(object sender, EventArgs e)
        {
        }

        private void userToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            View.user.user obj = new View.user.user();
            obj.userID = txtId.Text;
             obj.MdiParent = this;
             obj.Show();
        }

        private void addTypeImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
         
        }

        private void purchaseReturnToolStripMenuItem_Click(object sender, EventArgs e)
        {
         
        }

        private void companySettingToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void addEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _route.FromCheck();

            View.employee.addNewEmployee obj = new View.employee.addNewEmployee();
            obj.MdiParent = index.ActiveForm;
            obj.Show();
        }

        private void addAttendanceToolStripMenuItem_Click(object sender, EventArgs e)
        {

            _route.FromCheck();
            Payroll.From.employee_attendance obj = new Payroll.From.employee_attendance();
            obj.getUser = txtId.Text;
            obj.MdiParent = index.ActiveForm;
            obj.Show();
        }

        private void manageOfSalaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _route.FromCheck();
            Payroll.From.EmployeeManageSalary obj = new Payroll.From.EmployeeManageSalary();
            obj.getUser = txtId.Text;
            obj.MdiParent = index.ActiveForm;
            obj.Show();
        }

        private void finalizeSalaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _route.FromCheck();
            Payroll.From.finalizeSalery obj = new Payroll.From.finalizeSalery();
            obj.getUser = txtId.Text;
            obj.MdiParent = index.ActiveForm;
            obj.Show();
        }

        private void addBonusToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void addBonusToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            _route.FromCheck();
            Payroll.From.add_bonus obj = new Payroll.From.add_bonus();
            obj.getUser = txtId.Text;
            obj.MdiParent = index.ActiveForm;
            obj.Show();
        }

        private void bonusTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _route.FromCheck();
            Payroll.From.bonus_type obj = new Payroll.From.bonus_type();
           
            obj.MdiParent = index.ActiveForm;
            obj.Show();
        }

        private void payLoanToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void incomeExpenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _route.FromCheck();
            View.report.income_expense_report obj = new View.report.income_expense_report();
            obj.MdiParent = index.ActiveForm;
            obj.Show();
        }

        private void stockToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            _route.FromCheck();
            View.report.Store obj = new View.report.Store();
            obj.MdiParent = index.ActiveForm;
            obj.SoftwareType = txtSoftwareType.Text;
            obj.Show();
        }

        private void purchaseToolStripMenuItem7_Click(object sender, EventArgs e)
        {
            _route.PurchaseReport();
        }

        private void storeConfigarationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            View.stock.Approvel_Stock obj = new View.stock.Approvel_Stock();
            obj.userId = txtId.Text;
            obj.MdiParent = SuperShop.index.ActiveForm;
            obj.Show();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            View.login.login obj = new View.login.login();
            obj.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void logoutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            View.login.login obj = new View.login.login();
            obj.Show();
        }

        private void companyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SoftwareConfig.Register_company obj = new SoftwareConfig.Register_company();
            obj.MdiParent = this;
            obj.Show();
        }

        private void paymentSalaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _route.FromCheck();
            Payroll.From.paymentSalary obj = new Payroll.From.paymentSalary();
            obj.getUser = txtId.Text;
            obj.MdiParent = this;
            obj.Show();
        }

        private void customerDueBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            View.customer.clientDueBook obj = new View.customer.clientDueBook();
            obj.MdiParent = this;
            obj.Show();
        }

        private void newBankToolStripMenuItem_Click(object sender, EventArgs e)
        {
            View.BesicSetup.addBank obj = new View.BesicSetup.addBank();
            obj.MdiParent = this;
            obj.Show();
        }

        private void depositToolStripMenuItem_Click(object sender, EventArgs e)
        {
            View.Bank.Deposit obj = new View.Bank.Deposit();
            obj.MdiParent = this;
            obj.Show();
        }

        private void loanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            View.Bank.Loan obj = new View.Bank.Loan();
            obj.MdiParent = this;
            obj.Show();
        }

        private void paidLoanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _route.FromCheck();
            View.Bank.payBankLoan obj = new View.Bank.payBankLoan();
            obj.MdiParent = index.ActiveForm;
            obj.Show();
        }

        private void employeeToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            _route.FromCheck();
            View.report.employee obj = new View.report.employee();
            obj.MdiParent = index.ActiveForm;
            obj.Show();
        }

        private void purchaseReturnToolStripMenuItem1_Click(object sender, EventArgs e)
        {
          
        }

        private void purchaseReturnToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            _route.FromCheck();

            View.report.Purchase_Return obj = new View.report.Purchase_Return();
            obj.MdiParent = index.ActiveForm;
            obj.Show();
        }

        private void cashInToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void openingBalanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            View.Transection.Cash_in obj = new View.Transection.Cash_in();
            obj.MdiParent = index.ActiveForm;
            obj.Show();
        }

        private void depositReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            View.report.BankReport obj = new View.report.BankReport();
            obj.MdiParent = index.ActiveForm;
            obj.Show();
        }

        private void saleReturnToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            View.report.saleReturnReport obj = new View.report.saleReturnReport();
            obj.MdiParent = index.ActiveForm;
            obj.Show();
        }

        private void loanReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            View.report.loan obj = new View.report.loan();
            obj.MdiParent = index.ActiveForm;
            obj.Show();
        }

        private void cashOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            View.BesicSetup.cash_out obj = new View.BesicSetup.cash_out();
            obj.MdiParent = index.ActiveForm;
            obj.Show();
        }

        private void profitAndLossToolStripMenuItem_Click(object sender, EventArgs e)
        {
            View.report.profitandloass obj = new View.report.profitandloass();
            obj.MdiParent = index.ActiveForm;
            obj.Show();
        }

        private void customerPaymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _route.FromCheck();
            View.customer.duePayment obj = new View.customer.duePayment();

            obj.userId = txtId.Text;
            obj.MdiParent = this;
            obj.Show();
        }

        private void clientLadgerBookToolStripMenuItem_Click(object sender, EventArgs e)
        {

            _route.clientLadger();
        }

        private void saleToolStripMenuItem8_Click(object sender, EventArgs e)
        {

            View.sale.RecordSale obj = new View.sale.RecordSale();
            obj.Booth = boothName.ToString();
            obj.getuser = txtId.Text;
            obj.softwareType = txtSoftwareType.Text;
            obj.MdiParent = SuperShop.index.ActiveForm;
            obj.Show();
        }

        private void recordToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            _route.FromCheck();
            View.purchase.purchase_return_record obj = new View.purchase.purchase_return_record();
            obj.MdiParent = this;
            obj.Show();
        }

        private void recordToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            _route.FromCheck();
            View.purchase.returnRecord obj = new View.purchase.returnRecord();
            obj.MdiParent = this;
            obj.Show();
        }

        private void saleReturnToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            _route.FromCheck();
            View.purchase.returnRecord obj = new View.purchase.returnRecord();
            obj.MdiParent = this;
            obj.Show();
        }

        private void incomeToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            _route.FromCheck();
            View.DailyOperation.incomeRecord obj = new View.DailyOperation.incomeRecord();
            obj.MdiParent = this;
           obj.Show();

        }

        private void rptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CrystalReport.Form1 obj = new CrystalReport.Form1();
            obj.Show();
        }

        private void purchaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            View.purchase.Record obj = new View.purchase.Record();
            obj.MdiParent = this;
            obj.Show();
        }

        private void purchaseReturnToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            View.purchase.purchase_return_record obj = new View.purchase.purchase_return_record();
            obj.MdiParent = this;
            obj.Show();
        }

        private void boothToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SoftwareConfig.ChangeBooth obj = new SoftwareConfig.ChangeBooth();
            obj.MdiParent = this;
            obj.Show();
        }

        private void addIncomeExpensTitleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _route.incomeExpenseTitle();

        }

        private void expenseToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            _route.FromCheck();
            View.DailyOperation.ExpenseRecord obj = new View.DailyOperation.ExpenseRecord();
            obj.MdiParent = this;
            obj.Show();
        }

        private void supplierLadgerBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            View.supplier.supplierLadgerBook obj = new View.supplier.supplierLadgerBook();
            obj.MdiParent = this;
            obj.Show();
        }

        private void supplierLadgerBookToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            View.supplier.supplierLadgerBook obj = new View.supplier.supplierLadgerBook();
            obj.MdiParent = this;
            obj.Show();
        }

        private void supplierPaymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            View.supplier.suplier_payment obj = new View.supplier.suplier_payment();
            obj.userId = txtId.Text;
            obj.MdiParent = this;
            obj.Show();
        }

        private void supplierToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            View.report.supplierReport obj = new View.report.supplierReport();
            obj.MdiParent = this;
            obj.Show();
        }

        private void supplierPaymentRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            View.supplier.payment_history obj = new View.supplier.payment_history();
            obj.MdiParent = this;
            obj.Show();
        }

        private void saleToolStripMenuItem10_Click(object sender, EventArgs e)
        {
            if (txtSoftwareType.Text == "Electronics")
            {
                View.Electronic.saleElectronic obj = new View.Electronic.saleElectronic();
                obj.Booth = boothName.ToString();
                obj.getUser = txtId.Text;
                obj.MdiParent = SuperShop.index.ActiveForm;
                obj.Show();

            }
            else if (txtSoftwareType.Text == "Garments")
            {
                View.ClothSHop.clothsalep obj = new View.ClothSHop.clothsalep();
                obj.MdiParent = SuperShop.index.ActiveForm;
                obj.Show();
            }
            else if (txtSoftwareType.Text == "inventory")
            {
                View.sale.Sale obj = new View.sale.Sale();
                obj.Booth = boothName.ToString();
                obj.getUser = txtId.Text;
                obj.MdiParent = SuperShop.index.ActiveForm;
                obj.Show();

            }
        }

        private void purchaseToolStripMenuItem8_Click(object sender, EventArgs e)
        {

            if (txtSoftwareType.Text == "Garments")
            {
                _route.FromCheck();
                View.ClothSHop.purchaseCloth obj = new View.ClothSHop.purchaseCloth(txtSoftwareType.Text);
                obj.getBooth = boothName.ToString();
                obj.getUser = txtId.Text;
                obj.MdiParent = SuperShop.index.ActiveForm;
                obj.Show();
            }
            else if (txtSoftwareType.Text == "inventory")
            {
                _route.FromCheck();
                View.purchase.purchase obj = new View.purchase.purchase();
                obj.getBooth = boothName.ToString();
                obj.getUser = txtId.Text;
                obj.softwareType = txtSoftwareType.Text;
                obj.MdiParent = SuperShop.index.ActiveForm;
                obj.Show();
            }

            else if (txtSoftwareType.Text == "Electronics")
            {
                _route.FromCheck();
                View.Electronic.PurchaseElectronic obj = new View.Electronic.PurchaseElectronic();
                obj.Booth = boothName.ToString();
                obj.getUser = txtId.Text;
                obj.MdiParent = this;
                obj.Show();
            }
        }

      

     
      
    }
}
