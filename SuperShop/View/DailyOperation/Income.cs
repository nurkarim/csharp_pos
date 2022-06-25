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
    public partial class Income : Form
    {
        public Income()
        {
            InitializeComponent();
            genarateId();

            income();
        }
        DB.config connect = new DB.config();
        MySqlConnection conDatabase;
        DB.query _query = new DB.query();
        public string USERID { get { return label9.Text; } set { label9.Text = value; } }
        Controller.ExpenseController _controller = new Controller.ExpenseController();
        Model.ExpenseModel _model = new Model.ExpenseModel();
        public void income()
        {
            try
            {
                //var category = _categoryModel.dataRead();
                //comboBox1.DataSource = category;

                conDatabase = connect.connection();
                conDatabase.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conDatabase;
                cmd.CommandText = "SELECT id,name FROM income_type where status='1'";
                MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                sda.Dispose();
                cmd_expesnse_type.DataSource = ds.Tables[0];
                cmd_expesnse_type.ValueMember = "id";
                cmd_expesnse_type.DisplayMember = "name";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void genarateId()
        {

            try
            {
                int sumId;
                int booth = Convert.ToInt32(DateTime.Now.ToString("yy"));
                conDatabase = connect.connection();
                conDatabase.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conDatabase;
                cmd.CommandText = "SELECT id+1 FROM income_voucher order by id desc";
                MySqlDataReader dr;
                dr = cmd.ExecuteReader();

                if (dr.Read())
                {

                    int getId = dr.GetInt32(0);


                    txt_voucher_no.Text = getId.ToString();
                    sumId = Convert.ToInt32(getId);
                    if (0 < sumId & 99 > sumId)
                    {
                        txt_voucher_no.Text = "INC-" + booth + "00" + sumId.ToString();
                    }

                    else if (99 < sumId)
                    {
                        txt_voucher_no.Text = "INC-" + booth + "0" + sumId.ToString();
                    }

                    else if (100 < sumId)
                    {
                        txt_voucher_no.Text = "INC-" + booth + "0" + sumId.ToString();

                    }
                    else if (1000 <= sumId)
                    {
                        txt_voucher_no.Text = "INC-" + booth + "0" + sumId.ToString();

                    }


                }

                else
                {

                    sumId = Convert.ToInt32(1);
                    if (0 < sumId & 99 > sumId)
                    {
                        txt_voucher_no.Text = "INC-" + booth + "00" + sumId.ToString();
                    }

                    else if (99 < sumId)
                    {
                        txt_voucher_no.Text = "INC-" + booth + "0" + sumId.ToString();
                    }

                    else if (100 < sumId)
                    {
                        txt_voucher_no.Text = "INC-" + booth + "0" + sumId.ToString();

                    }
                    else if (1000 <= sumId)
                    {
                        txt_voucher_no.Text = "INC-" + booth + "0" + sumId.ToString();

                    }

                }
                dr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

        }
        private void btnadd_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(cmd_expesnse_type.SelectedValue) == "")
                {
                    MessageBox.Show("Please retrieve Expense Title", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (textBox1.Text == "")
                {
                    MessageBox.Show("Please enter no. of Amount", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox1.Focus();
                    return;
                }
                double SaleQty = Convert.ToDouble(textBox1.Text);
                if (SaleQty == 0)
                {
                    MessageBox.Show("no. of Amount can not be zero", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox1.Focus();
                    return;
                }

                if (listView2.Items.Count == 0)
                {

                    ListViewItem lst = new ListViewItem();
                    lst.SubItems.Add(Convert.ToString(cmd_expesnse_type.SelectedValue));
                    lst.SubItems.Add(label10.Text);
                    lst.SubItems.Add(textBox1.Text);


                    listView2.Items.Add(lst);
                    textBox3.Text = subtot().ToString();


                    cmd_expesnse_type.Text = "";
                    textBox1.Text = "";
                    return;
                }

                for (int j = 0; j <= listView2.Items.Count - 1; j++)
                {
                    if (listView2.Items[j].SubItems[1].Text == Convert.ToString(cmd_expesnse_type.SelectedValue))
                    {
                        listView2.Items[j].SubItems[1].Text = Convert.ToString(cmd_expesnse_type.SelectedValue);
                        listView2.Items[j].SubItems[2].Text = label10.Text;
                        listView2.Items[j].SubItems[3].Text = textBox1.Text;


                        textBox3.Text = subtot().ToString();


                        cmd_expesnse_type.Text = "";
                        textBox1.Text = "";
                        return;

                    }
                }

                ListViewItem lst1 = new ListViewItem();

                lst1.SubItems.Add(Convert.ToString(cmd_expesnse_type.SelectedValue));
                lst1.SubItems.Add(label10.Text);
                lst1.SubItems.Add(textBox1.Text);


                listView2.Items.Add(lst1);
                textBox3.Text = subtot().ToString();


                cmd_expesnse_type.Text = "";
                textBox1.Text = "";

                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        public double subtot()
        {

            int i = 0;
            int j = 0;
            int k = 0;
            i = 0;
            j = 0;
            k = 0;

            try
            {
                j = listView2.Items.Count;
                for (i = 0; i <= j - 1; i++)
                {
                    k = k + Convert.ToInt32(listView2.Items[i].SubItems[3].Text);
                }
                textBox3.Text = j.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return k;

        }
        public void removeCart()
        {
            try
            {
                if (listView2.Items.Count == 0)
                {
                    MessageBox.Show("No items to remove", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    int itmCnt = 0;
                    int i = 0;
                    int t = 0;

                    listView2.FocusedItem.Remove();
                    itmCnt = listView2.Items.Count;
                    t = 1;

                    for (i = 1; i <= itmCnt + 1; i++)
                    {
                        //Dim lst1 As New ListViewItem(i)
                        //ListView1.Items(i).SubItems(0).Text = t
                        t = t + 1;

                    }
                    textBox3.Text = subtot().ToString();
                }


                if (listView2.Items.Count == 0)
                {
                    textBox3.Text = "0";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void cmd_expesnse_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            label10.Text = cmd_expesnse_type.Text;
        }

        private void Income_Load(object sender, EventArgs e)
        {
            cmd_expesnse_type.Text = "";
            label10.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            removeCart();
        }

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = "";
        }
        void clear()
        {
            textBox3.Text = "00.00";

            for (int k = 0; k <= listView2.Items.Count - 1; k++)
            {
                listView2.Items[k].Remove();
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            
            clear();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

            if (textBox3.Text == "00.00")
            {
                MessageBox.Show("Please Add The Source");
                return;
            }
            else if (textBox3.Text == "")
            {
                MessageBox.Show("Please Add The Source");
                return;
            }
            else if (textBox3.Text == "0")
            {
                MessageBox.Show("Please Add The Source");
                return;
            }
            else
            {

                int i = 0;
                for (i = 0; i <= listView2.Items.Count - 1; i++)
                {
                    _query.EIInsert("temp_income_table", "date,income_sourch_id,amount,income_name", "'" + dateTimePicker1.Text + "','" + Convert.ToString(listView2.Items[i].SubItems[1].Text) + "','" + Convert.ToString(listView2.Items[i].SubItems[3].Text) + "','" + Convert.ToString(listView2.Items[i].SubItems[2].Text) + "'");

                }
            }

            clear();
        }
    }
}
