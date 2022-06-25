using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SuperShop.View.BesicSetup
{
    public partial class cost : Form
    {
        Controller.ExpenseController _controller = new Controller.ExpenseController();
        Model.ExpenseModel _model = new Model.ExpenseModel();
        DB.query _query = new DB.query();
        public cost()
        {
            InitializeComponent();
           
        }
        public string USERID { get { return label9.Text; } set { label9.Text = value; } }
       

        void view()
        {
            dataGridView1.DataSource = _query.selectWhere("viewexpense", "Date='"+dateTimePicker1.Text+"'");
        }
        private void cost_Load(object sender, EventArgs e)
        {
            view();
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            _controller.Date = Convert.ToString(dateTimePicker1.Text);
            _controller.Title = Convert.ToString(textBox1.Text);
            _controller.Amount = Convert.ToString(textBox2.Text);
            _controller.Type = Convert.ToString(comboBox1.Text);
            _controller.Note = Convert.ToString(richTextBox1.Text);
            _controller.USER = Convert.ToString(label9.Text);
            _model.save(_controller);
            view();
            textBox1.Text = "";
            textBox2.Text = "";
            richTextBox1.Text = "";
            comboBox1.Text = "";
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            view();
            textBox1.Text = "";
            textBox2.Text = "";
            richTextBox1.Text = "";
            comboBox1.Text = "";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells["Titel"].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells["Amount"].Value.ToString();
            richTextBox1.Text = dataGridView1.SelectedRows[0].Cells["Note"].Value.ToString();
            comboBox1.Text = dataGridView1.SelectedRows[0].Cells["Type"].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells["ID"].Value.ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            _controller.Date = Convert.ToString(dateTimePicker1.Text);
            _controller.Title = Convert.ToString(textBox1.Text);
            _controller.Amount = Convert.ToString(textBox2.Text);
            _controller.Type = Convert.ToString(comboBox1.Text);
            _controller.Note = Convert.ToString(richTextBox1.Text);
            _controller.USER = Convert.ToString(label9.Text);
            _controller.ID = Convert.ToString(textBox3.Text);
            _model.Update(_controller);
            view();
            textBox1.Text = "";
            textBox2.Text = "";
            richTextBox1.Text = "";
            comboBox1.Text = "";
        }
    }
}
