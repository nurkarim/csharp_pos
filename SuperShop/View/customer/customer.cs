using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Text.RegularExpressions;
namespace SuperShop.View.customer
{
    public partial class customer : Form
    {
        public customer()
        {
            InitializeComponent();
            view();
        }
        DB.query _query = new DB.query();
        Controller.clientController _clientController = new Controller.clientController();
        Model.clientModel _model = new Model.clientModel();
        public void view()
        {

            dataGridView1.DataSource = _query.SelectFullTable("SELECT customer_info.id as 'ID',customer_info.`type` as 'Type',customer_info.customer_name as 'Name',customer_info.phone as 'Phone',customer_info.email as 'E-mail',customer_info.gender as 'Gender',customer_info.city as 'City',customer_info.address as 'Address',customer_info.created_at as 'Date' from customer_info where customer_info.`status`='1'");
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            txt_id.Text = dataGridView1.SelectedRows[0].Cells["ID"].Value.ToString();
            comboBox2.Text = dataGridView1.SelectedRows[0].Cells["Type"].Value.ToString();
            textBox1.Text = dataGridView1.SelectedRows[0].Cells["Name"].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells["Phone"].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells["E-mail"].Value.ToString();
            comboBox1.Text = dataGridView1.SelectedRows[0].Cells["Gender"].Value.ToString();
            comboBox3.Text = dataGridView1.SelectedRows[0].Cells["City"].Value.ToString();
            richTextBox1.Text = dataGridView1.SelectedRows[0].Cells["Address"].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
        }

        private void richTextBox2_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (radioButton1.Checked == true)
                {
                    dataGridView1.DataSource = _query.selectWhere("viewClient", "Name='" + richTextBox2.Text + "'");
                }
                else if (radioButton2.Checked == true)
                {
                    dataGridView1.DataSource = _query.selectWhere("viewClient", "Phone='" + richTextBox2.Text + "'");


                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
          
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Please Enter The Customer Name");
                return;
            }
            else if (textBox3.Text == "")
            {
                MessageBox.Show("Please Enter The Phone Number");
                return;
            }
            else
            {
                _clientController.Type = Convert.ToString(comboBox2.Text);
                _clientController.Name = Convert.ToString(textBox1.Text);
                _clientController.Email = Convert.ToString(textBox2.Text);
                _clientController.Phone = Convert.ToString(textBox3.Text);
                _clientController.Gender = Convert.ToString(comboBox1.Text);
                _clientController.City = Convert.ToString(comboBox3.Text);
                _clientController.Address = Convert.ToString(richTextBox1.Text);
                _model.save(_clientController);
                view();
                clear();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            view();
            clear();
        }

        public void update()
        {
              if (textBox1.Text == "")
            {
                MessageBox.Show("Please Enter The Customer Name");
                return;
            }
              else if (textBox3.Text == "")
              {
                  MessageBox.Show("Please Enter The Phone Number");
                  return;
              }
              else
              {
                  _clientController.Type = Convert.ToString(comboBox2.Text);
                  _clientController.Id = Convert.ToString(txt_id.Text);
                  _clientController.Name = Convert.ToString(textBox1.Text);
                  _clientController.Email = Convert.ToString(textBox2.Text);
                  _clientController.Phone = Convert.ToString(textBox3.Text);
                  _clientController.Gender = Convert.ToString(comboBox1.Text);
                  _clientController.City = Convert.ToString(comboBox3.Text);
                  _clientController.Address = Convert.ToString(richTextBox1.Text);
                  _query.Update("customer_info", "customer_name='" + _clientController.Name + "',phone='" + _clientController.Phone + "',email='" + _clientController.Email + "',gender='" + _clientController.Gender + "',city='" + _clientController.City + "',address='" + _clientController.Address + "'", "id", "'"+_clientController.Id+"'");
                  view();
                  clear();
              }
        }
        void clear()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
            richTextBox1.Text = "";
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            update();
        }

        private void button1_Click(object sender, EventArgs e)
        {
                 if (textBox1.Text == "")
            {
                MessageBox.Show("Please Enter The Customer Name");
                return;
            }
                 else if (txt_id.Text == "")
                 {
                     MessageBox.Show("Please Enter The ID NO");
                     return;
                 }
                 else
                 {
                     _query.Delete("customer_info", "id", "'" + txt_id .Text+ "'");
                 }
            
        }

        private void customer_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            if (textBox1.Text == string.Empty)

            {

                errorProvider1.SetError(textBox1, "Please Enter Name");

                errorProvider2.SetError(textBox1, "");

            }

            else

            {

                errorProvider1.SetError(textBox1, "");

                errorProvider2.SetError(textBox1, "correct");

            }
        }

        private void textBox3_Validating(object sender, CancelEventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_Validated(object sender, EventArgs e)
        {
            if (textBox3.Text == string.Empty)
            {

                errorProvider1.SetError(textBox3, "please enter Phone");
                errorProvider2.SetError(textBox3, "");

            }

            else
            {
                if (textBox3.Text.Length != 11)
                {
                    // Invalid. Set An Error.
                    errorProvider1.SetError(textBox3, "Pincode must be 11 digits");

                    Regex NumericOnly;

                    NumericOnly = new Regex(@"^([0-9]*|\d*)$");

                    if (NumericOnly.IsMatch(textBox3.Text))
                    {

                        errorProvider1.SetError(textBox3, "");

                        errorProvider2.SetError(textBox3, "correct");

                    }

                    else
                    {

                        errorProvider1.SetError(textBox3, "Please Enter only numbers");

                        errorProvider2.SetError(textBox3, "");

                    }
                }
                else
                {
                    // Valid. Clear The Error.
                    errorProvider1.SetError(textBox3, "");
                }
            }
        }
    }
}
