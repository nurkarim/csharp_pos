using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace SuperShop.View.user
{
    public partial class user : Form
    {
        public user()
        {
            InitializeComponent();
            ProducstName();
        }
        public string userID { get { return txt_user_id.Text; } set { txt_user_id.Text = value; } }
        DB.config _con = new DB.config();
        DB.query _query = new DB.query();
        MySqlConnection conDatabase;
        string sale;
        string purchase;
        string besic;
        string cus;
        string sup;
        string payroll;
        string record;
        string acc;
        string setting;
        string stockS;
        string daily;
        string profile;
        string bank;
        string opBalance;
        //=============Report section==============//
        string expenseR;
        string incomeR;
        string incomeExR;
        string saleR;
        string purchaR;
        string employeeR;
        string customerLadgerR;
        string supplierR;
        string profitR;
        string bankR;
        string stockR;






        public void ProducstName()
        {
            try
            {
                //var category = _categoryModel.dataRead();
                //comboBox1.DataSource = category;

                conDatabase = _con.connection();
                conDatabase.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conDatabase;
                cmd.CommandText = "SELECT id,user_name FROM user";
                MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                sda.Dispose();
                cmd_product_id.DataSource = ds.Tables[0];
                cmd_product_id.ValueMember = "id";
                cmd_product_id.DisplayMember = "user_name";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        public void checkMenu()
        {
            try
            {
                conDatabase = _con.connection();
                conDatabase.Open();
                MySqlCommand cmd = new MySqlCommand("select * from menu_paiority where user_id='" + cmd_product_id.SelectedValue + "'", conDatabase);
                MySqlDataReader dr;
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    if (dr["sale"].ToString() == "1")
                    {
                        checkBox1.Checked = true;
                    }
                    else
                    {
                        checkBox1.Checked = false;

                    }
                    if (dr["purchase"].ToString() == "1")
                    {
                        checkBox3.Checked = true;
                    }
                    else
                    {
                        checkBox3.Checked = false;

                    }
                    if (dr["besic"].ToString() == "1")
                    {
                        checkBox2.Checked = true;
                    }
                    else
                    {
                        checkBox2.Checked = false;

                    }
                    if (dr["customer"].ToString() == "1")
                    {
                        checkBox7.Checked = true;
                    }
                    else
                    {
                        checkBox7.Checked = false;

                    }
                    if (dr["suppliyer"].ToString() == "1")
                    {
                        checkBox8.Checked = true;
                    }
                    else
                    {
                        checkBox8.Checked = false;

                    }
                    if (dr["payroll"].ToString() == "1")
                    {
                        checkBox20.Checked = true;
                    }
                    else
                    {
                        checkBox20.Checked = false;

                    }

                    if (dr["stock"].ToString() == "1")
                    {
                        checkBox27.Checked = true;
                    }
                    else
                    {
                        checkBox27.Checked = false;

                    }

                    if (dr["record"].ToString() == "1")
                    {
                        checkBox28.Checked = true;
                    }
                    else
                    {
                        checkBox28.Checked = false;

                    }

                    if (dr["account"].ToString() == "1")
                    {
                        checkBox30.Checked = true;
                    }
                    else
                    {
                        checkBox30.Checked = false;

                    }

                    if (dr["setting"].ToString() == "1")
                    {
                        checkBox31.Checked = true;
                    }
                    else
                    {
                        checkBox31.Checked = false;

                    }
                    if (dr["daily_opera"].ToString() == "1")
                    {
                        checkBox9.Checked = true;
                    }
                    else
                    {
                        checkBox9.Checked = false;

                    }
                    if (dr["profile"].ToString() == "1")
                    {
                        checkBox10.Checked = true;
                    }
                    else
                    {
                        checkBox10.Checked = false;

                    }
                    if (dr["bank"].ToString() == "1")
                    {
                        checkBox11.Checked = true;
                    }
                    else
                    {
                        checkBox11.Checked = false;

                    }
                    if (dr["opening_blance"].ToString() == "1")
                    {
                        checkBox12.Checked = true;
                    }
                    else
                    {
                        checkBox12.Checked = false;

                    }
                    if (dr["expenseR"].ToString() == "1")
                    {
                        checkBox15.Checked = true;
                    }
                    else
                    {
                        checkBox15.Checked = false;

                    }
                    if (dr["incomeR"].ToString() == "1")
                    {
                        checkBox14.Checked = true;
                    }
                    else
                    {
                        checkBox14.Checked = false;

                    }
                    if (dr["income_expense_r"].ToString() == "1")
                    {
                        checkBox21.Checked = true;
                    }
                    else
                    {
                        checkBox21.Checked = false;

                    }
                    if (dr["sale_r"].ToString() == "1")
                    {
                        checkBox19.Checked = true;
                    }
                    else
                    {
                        checkBox19.Checked = false;

                    }
                    if (dr["purchase_r"].ToString() == "1")
                    {
                        checkBox18.Checked = true;
                    }
                    else
                    {
                        checkBox18.Checked = false;

                    }

                    if (dr["employee"].ToString() == "1")
                    {
                        checkBox22.Checked = true;
                    }
                    else
                    {
                        checkBox22.Checked = false;

                    }

                    if (dr["customr_ladger"].ToString() == "1")
                    {
                        checkBox13.Checked = true;
                    }
                    else
                    {
                        checkBox13.Checked = false;

                    }

                    if (dr["supliyer_r"].ToString() == "1")
                    {
                        checkBox24.Checked = true;
                    }
                    else
                    {
                        checkBox24.Checked = false;

                    }

                    if (dr["profite_loss"].ToString() == "1")
                    {
                        checkBox29.Checked = true;
                    }
                    else
                    {
                        checkBox29.Checked = false;

                    }

                    if (dr["bank_r"].ToString() == "1")
                    {
                        checkBox5.Checked = true;
                    }
                    else
                    {
                        checkBox5.Checked = false;

                    }

                    if (dr["stock_r"].ToString() == "1")
                    {
                        checkBox6.Checked = true;
                    }
                    else
                    {
                        checkBox6.Checked = false;

                    }
                    dr.Close();
                }
                else
                {

                }
            }
            catch (Exception) { }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox27_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox27.Checked == true)
            {
                stockS = "1";
            }
            else
            {
                stockS = "0";

            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnadd_Click(object sender, EventArgs e)
        {

            if (textBox2.Text != "" && cmd_product_id.Text != "")
            {
                _query.InsertA("user", "user_name,email,user_type,password", "'" + Convert.ToString(cmd_product_id.Text) + "','" + Convert.ToString(textBox1.Text) + "','" + Convert.ToString(comboBox2.Text) + "','" + Convert.ToString(textBox2.Text) + "'");
                _query.EIInsert("menu_paiority", "user_id,sale,purchase,besic,customer,suppliyer,payroll,stock,record,account,setting,daily_opera,profile,bank,opening_blance,expenseR,incomeR,income_expense_r,sale_r,purchase_r,employee,customr_ladger,supliyer_r,profite_loss,bank_r,stock_r,created_by", "'" + _query.LastId + "','" + sale + "','" + purchase + "','" + besic + "','" + cus + "','" + sup + "','" + payroll + "','" + stockS + "','" + record + "','" + acc + "','" + setting + "','" + daily + "','" + profile + "','" + bank + "','" + opBalance + "','" + expenseR + "','" + incomeR + "','" + incomeExR + "','" + saleR + "','" + purchaR + "','" + employeeR + "','" + customerLadgerR + "','" + supplierR + "','" + profitR + "','" + bankR + "','" + stockR + "','" + txt_user_id.Text + "'");
                view();
            }
            else {
                MessageBox.Show("Sorry Input was required");
            }
        }

        void view()
    {
        dataGridView1.DataSource = _query.SelectFullTable("select user.user_name,user.user_type,user.password,menu_paiority.sale,menu_paiority.purchase,menu_paiority.besic,menu_paiority.customer,menu_paiority.suppliyer,menu_paiority.payroll,menu_paiority.stock,record,menu_paiority.account,menu_paiority.setting,menu_paiority.daily_opera,menu_paiority.profile,menu_paiority.bank,menu_paiority.opening_blance,menu_paiority.expenseR,menu_paiority.incomeR,menu_paiority.income_expense_r,menu_paiority.sale_r,menu_paiority.purchase_r,menu_paiority.employee,menu_paiority.customr_ladger,menu_paiority.supliyer_r,menu_paiority.profite_loss,menu_paiority.bank_r,menu_paiority.stock_r,menu_paiority.created_by from menu_paiority inner join user on menu_paiority.user_id=user.id");
    }

        private void user_Load(object sender, EventArgs e)
        {
            view();
            sale = "0";
            saleR = "0";
            purchaR = "0";
            purchase = "0";
             besic="0";
             cus = "0";
             sup = "0";
             payroll = "0";
             record = "0";
             acc = "0";
             setting = "0";
             stockS = "0";
             daily = "0";
             profile = "0";
             bank = "0";
             opBalance = "0";
             expenseR = "0";
             incomeR = "0";
             incomeExR = "0";


             employeeR = "0";
             customerLadgerR = "0";
             supplierR = "0";
             profitR = "0";
             bankR = "0";
             stockR = "0";
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                sale = "1";
            }
            else
            {
                sale = "0";
            
            }
        }

        private void checkBox3_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
            {
                purchase = "1";
            }
            else
            {
                purchase = "0";

            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                besic = "1";
            }
            else
            {
                besic = "0";

            }
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox7.Checked == true)
            {
                cus = "1";
            }
            else
            {
                cus = "0";

            }
        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox8.Checked == true)
            {
              sup = "1";
            }
            else
            {
                sup = "0";

            }
        }

        private void checkBox20_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox20.Checked == true)
            {
                payroll = "1";
            }
            else
            {
                payroll = "0";

            }
        }

        private void checkBox28_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox28.Checked == true)
            {
                record = "1";
            }
            else
            {
                record = "0";

            }
        }

        private void checkBox30_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox30.Checked == true)
            {
                acc = "1";
            }
            else
            {
                acc = "0";

            }
        }

        private void checkBox31_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox31.Checked == true)
            {
                setting = "1";
            }
            else
            {
                setting = "0";

            }
        }

        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox9.Checked == true)
            {
                daily = "1";
            }
            else
            {
                daily = "0";

            }
        }

        private void checkBox10_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox10.Checked == true)
            {
                profile = "1";
            }
            else
            {
                profile = "0";

            }
        }

        private void checkBox11_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox11.Checked == true)
            {
                bank = "1";
            }
            else
            {
                bank = "0";

            }
        }

        private void checkBox12_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox12.Checked == true)
            {
                opBalance = "1";
            }
            else
            {
                opBalance = "0";

            }
        }

        private void checkBox15_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox15.Checked == true)
            {
                expenseR = "1";
            }
            else
            {
                expenseR = "0";

            }
        }

        private void checkBox14_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox14.Checked == true)
            {
                incomeR= "1";
            }
            else
            {
                incomeR = "0";

            }
        }

        private void checkBox21_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox21.Checked == true)
            {
                incomeExR = "1";
            }
            else
            {
                incomeExR = "0";

            }
        }

        private void checkBox19_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox19.Checked == true)
            {
                saleR = "1";
            }
            else
            {
                saleR = "0";

            }
        }

        private void checkBox18_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox18.Checked == true)
            {
                purchaR = "1";
            }
            else
            {
                purchaR = "0";

            }
        }

        private void checkBox22_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox22.Checked == true)
            {
                employeeR = "1";
            }
            else
            {
                employeeR = "0";

            }
        }

        private void checkBox24_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox24.Checked == true)
            {
                supplierR = "1";
            }
            else
            {
                supplierR = "0";

            }
        }

        private void checkBox29_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox29.Checked == true)
            {
                profitR = "1";
            }
            else
            {
                profitR = "0";

            }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked == true)
            {
                bankR = "1";
            }
            else
            {
                bankR = "0";

            }
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox6.Checked == true)
            {
                stockR = "1";
            }
            else
            {
                stockR = "0";

            }
        }

        private void checkBox13_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox13.Checked == true)
            {
                customerLadgerR = "1";
            }
            else
            {
                customerLadgerR = "0";

            }
        }

        private void cmd_product_id_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkMenu();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            _query.Delete("menu_paiority", "user_id", "'"+cmd_product_id.SelectedValue+"'");
            _query.EIInsert("menu_paiority", "user_id,sale,purchase,besic,customer,suppliyer,payroll,stock,record,account,setting,daily_opera,profile,bank,opening_blance,expenseR,incomeR,income_expense_r,sale_r,purchase_r,employee,customr_ladger,supliyer_r,profite_loss,bank_r,stock_r,created_by", "'" + cmd_product_id.SelectedValue + "','" + sale + "','" + purchase + "','" + besic + "','" + cus + "','" + sup + "','" + payroll + "','" + stockS + "','" + record + "','" + acc + "','" + setting + "','" + daily + "','" + profile + "','" + bank + "','" + opBalance + "','" + expenseR + "','" + incomeR + "','" + incomeExR + "','" + saleR + "','" + purchaR + "','" + employeeR + "','" + customerLadgerR + "','" + supplierR + "','" + profitR + "','" + bankR + "','" + stockR + "','" + txt_user_id.Text + "'");
            view();
        }
    }
}
