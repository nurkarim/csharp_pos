using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SuperShop.View.supplier
{
    public partial class supplier : Form
    {
        public supplier()
        {
            InitializeComponent();
            view();
        }
        DB.query _query = new DB.query();
        Model.supplierModel _model = new Model.supplierModel();
        Controller.supplierController _controllerSupplier = new Controller.supplierController();
        public string User { get { return user_id.Text; } set { user_id.Text = value; } }
        public void view()
        {
            dataGridView1.DataSource = _query.Select("viewsupplier");
        
        }
        private void button1_Click(object sender, EventArgs e)
        {
            _controllerSupplier.Address = Convert.ToString(richTextBox1.Text);
            _controllerSupplier.Name = Convert.ToString(txt_name.Text);
            _controllerSupplier.CAddress = Convert.ToString(richTextBox2.Text);
            _controllerSupplier.CEmail = Convert.ToString(txt_cmail.Text);
            _controllerSupplier.CName = Convert.ToString(txt_cName.Text);
            _controllerSupplier.CPhone =  Convert.ToString(txt_cnumber.Text);
            _controllerSupplier.Email = Convert.ToString(txt_email.Text);
            _controllerSupplier.Gender = Convert.ToString(cmd_gender.Text);
            _controllerSupplier.USER = Convert.ToString(user_id.Text);
            _controllerSupplier.Phone = Convert.ToString(txt_phone.Text);
            _model.save(_controllerSupplier);
            view();
            clear();
        }

        private void supplier_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            _controllerSupplier.Address = Convert.ToString(richTextBox1.Text);
            _controllerSupplier.Name = Convert.ToString(txt_name.Text);
            _controllerSupplier.CAddress = Convert.ToString(richTextBox2.Text);
            _controllerSupplier.CEmail = Convert.ToString(txt_cmail.Text);
            _controllerSupplier.CName = Convert.ToString(txt_cName.Text);
            _controllerSupplier.CPhone = Convert.ToString(txt_cnumber.Text);
            _controllerSupplier.Email = Convert.ToString(txt_email.Text);
            _controllerSupplier.Gender = Convert.ToString(cmd_gender.Text);
            _controllerSupplier.USER = Convert.ToString(user_id.Text);
            _controllerSupplier.Phone = Convert.ToString(txt_phone.Text);
            _controllerSupplier.ID = Convert.ToString(id.Text);
            _model.update(_controllerSupplier);
            view();
            clear();
        }
        public void clear()
        {

            txt_cmail.Clear();
            txt_cName.Clear();
            txt_cnumber.Clear();
            txt_name.Clear();
            txt_email.Clear();
            txt_phone.Clear();
            richTextBox1.Clear();
            richTextBox2.Clear();
            cmd_gender.Text="";

        }
        private void button3_Click(object sender, EventArgs e)
        {
            clear();
            view();
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                id.Text = dataGridView1.SelectedRows[0].Cells["ID"].Value.ToString();
                txt_name.Text = dataGridView1.SelectedRows[0].Cells["Name"].Value.ToString();
                txt_phone.Text = dataGridView1.SelectedRows[0].Cells["Phone"].Value.ToString();
                txt_email.Text = dataGridView1.SelectedRows[0].Cells["E-mail"].Value.ToString();
                txt_cnumber.Text = dataGridView1.SelectedRows[0].Cells["Company Phone"].Value.ToString();
                txt_cName.Text = dataGridView1.SelectedRows[0].Cells["Company Name"].Value.ToString();
                txt_cmail.Text = dataGridView1.SelectedRows[0].Cells["Company E-mail"].Value.ToString();
                cmd_gender.Text = dataGridView1.SelectedRows[0].Cells["Gender"].Value.ToString();
                richTextBox1.Text = dataGridView1.SelectedRows[0].Cells["Address"].Value.ToString();
                richTextBox2.Text = dataGridView1.SelectedRows[0].Cells["Company Address"].Value.ToString();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
