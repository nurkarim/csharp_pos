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
    public partial class income : Form
    {
        public income()
        {
            InitializeComponent();
            
        }
        Controller.DailyIncomeController _incomeController = new Controller.DailyIncomeController();
        Model.IncomeModel _model = new Model.IncomeModel();
        DB.query _query = new DB.query();
        private void income_Load(object sender, EventArgs e)
        {
            view();
        }

        void view()
        {
            dataGridView1.DataSource = _query.selectWhere("viewincome", "Date='" + dateTimePicker1.Text + "'");
        }
        public string userName { get { return label8.Text; } set { label8.Text = value; } }
   
        private void btnadd_Click(object sender, EventArgs e)
        {
            _incomeController.Date = Convert.ToString(dateTimePicker1.Text);
            _incomeController.Title = Convert.ToString(textBox1.Text);
            _incomeController.Amount = Convert.ToString(textBox2.Text);
            _incomeController.Type = Convert.ToString(comboBox1.Text);
            _incomeController.Note = Convert.ToString(richTextBox1.Text);
            _incomeController.USER = Convert.ToString(label8.Text);
            _model.save(_incomeController);
            view();
            textBox1.Text = "";
            textBox2.Text = "";
            comboBox1.Text = "";
            richTextBox1.Text = "";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            view();
            textBox1.Text = "";
            textBox2.Text = "";
            comboBox1.Text = "";
            richTextBox1.Text = "";
        }
    }
}
