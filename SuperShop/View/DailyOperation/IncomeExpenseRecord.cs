using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace SuperShop.View.DailyOperation
{
    public partial class IncomeExpenseRecord : Form
    {
        public IncomeExpenseRecord()
        {
            InitializeComponent();
            view();
            income();
            expense();
            genarateId();
            IgenarateId();
        }
     
        DB.query _query = new DB.query();
        DB.config conDatebase = new DB.config();
        MySqlConnection cn;


        public void IgenarateId()
        {

            try
            {
                int sumId;
                int booth = Convert.ToInt32(DateTime.Now.ToString("yy"));
                cn = conDatebase.connection();
                cn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "SELECT id+1 FROM income_voucher order by id desc";
                MySqlDataReader dr;
                dr = cmd.ExecuteReader();

                if (dr.Read())
                {

                    int getId = dr.GetInt32(0);


                    textBox4.Text = getId.ToString();
                    sumId = Convert.ToInt32(getId);
                    if (0 < sumId & 99 > sumId)
                    {
                        textBox4.Text = "INC-" + booth + "00" + sumId.ToString();
                    }

                    else if (99 < sumId)
                    {
                        textBox4.Text = "INC-" + booth + "0" + sumId.ToString();
                    }

                    else if (100 < sumId)
                    {
                        textBox4.Text = "INC-" + booth + "0" + sumId.ToString();

                    }
                    else if (1000 <= sumId)
                    {
                        textBox4.Text = "INC-" + booth + "0" + sumId.ToString();

                    }


                }

                else
                {

                    sumId = Convert.ToInt32(1);
                    if (0 < sumId & 99 > sumId)
                    {
                        textBox4.Text = "INC-" + booth + "00" + sumId.ToString();
                    }

                    else if (99 < sumId)
                    {
                        textBox4.Text = "INC-" + booth + "0" + sumId.ToString();
                    }

                    else if (100 < sumId)
                    {
                        textBox4.Text = "INC-" + booth + "0" + sumId.ToString();

                    }
                    else if (1000 <= sumId)
                    {
                        textBox4.Text = "INC-" + booth + "0" + sumId.ToString();

                    }

                }
                dr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

        }
        public void view()
        {
            try
            {
                cn = conDatebase.connection();
                cn.Open();
                MySqlCommand cmd = new MySqlCommand("" + richTextBox1.Text + "", cn);
                MySqlDataAdapter dr = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                dr.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void IncomeExpenseRecord_Load(object sender, EventArgs e)
        {

        }
       public void income()
        {
            try
            {
                cn = conDatebase.connection();
                cn.Open();
                MySqlCommand cmd = new MySqlCommand("select sum(amount) as 'Amount' from temp_income_table", cn);
                MySqlDataReader dr;
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    textBox1.Text = dr["Amount"].ToString();
                }
                else
                {
                    textBox1.Text = "0";
                }
            }
           catch(Exception)
            {}
        }
       public void genarateId()
       {

           try
           {
               int sumId;
               int booth = Convert.ToInt32(DateTime.Now.ToString("yy"));
               cn = conDatebase.connection();
               cn.Open();
               MySqlCommand cmd = new MySqlCommand();
               cmd.Connection = cn;
               cmd.CommandText = "SELECT id+1 FROM expense_voucher order by id desc";
               MySqlDataReader dr;
               dr = cmd.ExecuteReader();

               if (dr.Read())
               {

                   int getId = dr.GetInt32(0);


                   txt_voucher_no.Text = getId.ToString();
                   sumId = Convert.ToInt32(getId);
                   if (0 < sumId & 99 > sumId)
                   {
                       txt_voucher_no.Text = "EXP-" + booth + "00" + sumId.ToString();
                   }

                   else if (99 < sumId)
                   {
                       txt_voucher_no.Text = "EXP-" + booth + "0" + sumId.ToString();
                   }

                   else if (100 < sumId)
                   {
                       txt_voucher_no.Text = "EXP-" + booth + "0" + sumId.ToString();

                   }
                   else if (1000 <= sumId)
                   {
                       txt_voucher_no.Text = "EXP-" + booth + "0" + sumId.ToString();

                   }


               }

               else
               {

                   sumId = Convert.ToInt32(1);
                   if (0 < sumId & 99 > sumId)
                   {
                       txt_voucher_no.Text = "EXP-" + booth + "00" + sumId.ToString();
                   }

                   else if (99 < sumId)
                   {
                       txt_voucher_no.Text = "EXP-" + booth + "0" + sumId.ToString();
                   }

                   else if (100 < sumId)
                   {
                       txt_voucher_no.Text = "EXP-" + booth + "0" + sumId.ToString();

                   }
                   else if (1000 <= sumId)
                   {
                       txt_voucher_no.Text = "EXP-" + booth + "0" + sumId.ToString();

                   }

               }
               dr.Close();
           }
           catch (Exception ex)
           {
               MessageBox.Show(ex.Message);

           }

       }
       public void expense()
       {
           try{
           cn = conDatebase.connection();
           cn.Open();
           MySqlCommand cmd = new MySqlCommand("select sum(amount) as 'Amount' from temp_expense_table", cn);
           MySqlDataReader dr;
           dr = cmd.ExecuteReader();
           if (dr.Read())
           {
               textBox2.Text = dr["Amount"].ToString();
           }
           else
           {
               textBox2.Text = "0";
           }
           }
           catch (Exception)
           { }
       }
        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            view();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
        public string USERID { get { return label2.Text; } set { label2.Text = value; } }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            cn = conDatebase.connection();
            cn.Open();
            int i=0;
            int a = -1;
            for (i = 0; i <= dataGridView1.Rows.Count - 1;i++ )
            {
                MySqlCommand cmd = new MySqlCommand("INSERT INTO income_expense_temp_table (date,I_title,I_amount,E_title,E_amount) values ('" + dateTimePicker1.Text + "','" + dataGridView1.Rows[i].Cells["ICode"].Value.ToString() + "','" + dataGridView1.Rows[i].Cells["AMOUNT"].Value.ToString() + "','" + dataGridView1.Rows[i].Cells["Expense ID"].Value.ToString() + "','" + dataGridView1.Rows[i].Cells["EAmount"].Value.ToString() + "')", cn);
               // _query.EIInsert("income_expense_temp_table", "date,I_title,I_amount,E_title,E_amount", "'" + dateTimePicker1.Text + "','" + dataGridView1.Rows[i].Cells["ICode"].Value.ToString() + "','" + dataGridView1.Rows[i].Cells["AMOUNT"].Value.ToString() + "','" + dataGridView1.Rows[i].Cells["Expense ID"].Value.ToString() + "','" + dataGridView1.Rows[i].Cells["Emount"].Value.ToString() + "'");
                a=cmd.ExecuteNonQuery();
            }
            if(a>0)
            {

                _query.InsertA("income_voucher", "date,voucher_id,total,type,user_id,note", "'" + dateTimePicker1.Text + "','" + textBox4.Text + "','" + textBox1.Text + "','Cash','" + label2.Text + "','Income'");
                for (int l = 0; l <= dataGridView1.Rows.Count - 1; l++)
                {
                    _query.EIInsert("income", "date,income_sourch,amount,fk_income_voucher_id,note,user_id", "'" + dateTimePicker1.Text + "','" + Convert.ToString(dataGridView1.Rows[l].Cells["ICode"].Value.ToString()) + "','" + Convert.ToString(dataGridView1.Rows[l].Cells["AMOUNT"].Value.ToString()) + "','" + _query.LastId + "','income','" + label2.Text + "'");
                }
                int c = -1;

                MySqlCommand cmdE = new MySqlCommand("insert into expense_voucher (date,voucher_id,total,type,user_id,note) values ('" + dateTimePicker1.Text + "','" + txt_voucher_no.Text + "','" + textBox2.Text + "','Cash','" + label2.Text + "','Expense')", cn);
                c = cmdE.ExecuteNonQuery();
                label3.Text = Convert.ToString(cmdE.LastInsertedId);
                if (c>0)
                {
                for (int j = 0; j <= dataGridView1.Rows.Count - 1; j++)
                {
                    _query.EIInsert("expense", "date,expense_sourche,amount,recived_type,note,recived_by,fk_expense_voucher_id", "'" + dateTimePicker1.Text + "','" + Convert.ToString(dataGridView1.Rows[j].Cells["Expense ID"].Value.ToString()) + "','" + Convert.ToString(dataGridView1.Rows[j].Cells["EAmount"].Value.ToString()) + "','Cash','Expense','" + label2.Text + "','" + label3.Text + "'");

                }
                }

                MySqlCommand cmda = new MySqlCommand("TRUNCATE temp_expense_table", cn);
                cmda.ExecuteNonQuery();
                MySqlCommand cmdabb = new MySqlCommand("TRUNCATE temp_income_table", cn);
                cmdabb.ExecuteNonQuery();

                view();
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
