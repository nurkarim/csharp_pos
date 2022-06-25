using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace SuperShop.View.BesicSetup
{
    public partial class SubCategory : Form
    {
        
        DB.config connect = new DB.config();
        DB.query _query = new DB.query();
        MySqlConnection conDatabase;
        MySqlCommand cmd;
        Controller.subCategoryController _subCategoryController = new Controller.subCategoryController();
        Model.subCategoryModel _subModel = new Model.subCategoryModel();
        public SubCategory()
        {
            InitializeComponent();
            items();
            dataGridView1.DataSource = _query.Select("viewsubcategory");
        }
        public void items()
        {
            try
            {
                //var category = _categoryModel.dataRead();
                //comboBox1.DataSource = category;

                conDatabase = connect.connection();
                conDatabase.Open();
                cmd = new MySqlCommand();
                cmd.Connection = conDatabase;
                cmd.CommandText = "SELECT id,name FROM category";
                MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                sda.Dispose();
                comboBox1.DataSource = ds.Tables[0];
                comboBox1.ValueMember = "id";
                comboBox1.DisplayMember = "name";
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
      
        public String ChildText
        {

            get { return label1.Text; }

            set { label1.Text = value; }

        }
        private void SubCategory_Load(object sender, EventArgs e)
        {

        }

        private void SubCategory_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                label2.Text = dataGridView1.SelectedRows[0].Cells["code"].Value.ToString();
                comboBox1.Text = dataGridView1.SelectedRows[0].Cells["Category/Type Name"].Value.ToString();
                textBox1.Text = dataGridView1.SelectedRows[0].Cells["Sub-Category Name"].Value.ToString();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          
          
        }


        private void btnadd_Click(object sender, EventArgs e)
        {

            
            _subCategoryController.categoryId = Convert.ToString(comboBox1.SelectedValue);
            _subCategoryController.Name = Convert.ToString(textBox1.Text);
            _subCategoryController.user = Convert.ToString(label1.Text);
            _subModel.save(_subCategoryController);
            dataGridView1.DataSource = _query.Select("viewsubcategory");
            textBox1.Clear();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            _subCategoryController.categoryId = Convert.ToString(comboBox1.SelectedValue);
            _subCategoryController.Name = Convert.ToString(textBox1.Text);
            _subCategoryController.SubcategoryId = Convert.ToString(label2.Text);
            _subModel.updateSuB(_subCategoryController);
            dataGridView1.DataSource = _query.Select("viewsubcategory");

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            dataGridView1.DataSource = _query.Select("viewsubcategory");

        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
