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
namespace SuperShop.SoftwareConfig
{
    public partial class Register_company : Form
    {
        public Register_company()
        {
            InitializeComponent();
            showdata();
        }
        DB.query _query = new DB.query();
        Model.CompanyRegisterModel _categoryModel;
        Controller.CompanyRegisterController _categoryController;
        DB.config connect = new DB.config();
        MySqlConnection connection;
        OpenFileDialog openFileDialog;
        public void showdata()
        {
            try
            {
                connection = connect.connection();
                connection.Open();
                MySqlCommand sda = new MySqlCommand("select * from company_register", connection);
                MySqlDataReader dr;
                dr = sda.ExecuteReader();
                if (dr.Read())
                {
                    //string path = Application.StartupPath.Substring(0, Application.StartupPath.Length - 10);
                   // string data = path + "\\Image\\" + dr["logo"].ToString();
                    //pictureBox1.Image = Image.FromFile(data);
                    textBox1.Text=dr["name"].ToString();
                    textBox2.Text = dr["email"].ToString();
                    textBox3.Text = dr["phone"].ToString();
                    textBox4.Text = dr["fax"].ToString();
                    textBox5.Text = dr["country"].ToString();
                    textBox6.Text = dr["city"].ToString();
                    richTextBox1.Text = dr["address"].ToString();
                    textBox7.Text = dr["user_name"].ToString();
                    textBox8.Text = dr["password"].ToString();

                }
                dr.Close();
                MySqlCommand sdaa = new MySqlCommand("select * from check_run_software where company_id='cm-101'", connection);
                MySqlDataReader dra;
                dra = sdaa.ExecuteReader();
                if (dra.Read())
                {
                    comboBox1.Text = dra["software_type"].ToString();
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        private void btnSave_Click(object sender, EventArgs e)
        {
            
            try
            {

                connection = connect.connection();
                connection.Open();
                MySqlCommand sda = new MySqlCommand("select * from company_register where id='cm-101'", connection);
                MySqlDataReader dr;
                dr = sda.ExecuteReader();
                if(dr.Read())
                {
                    _query.Update("company_register", "name='" + Convert.ToString(textBox1.Text) + "',email='" + Convert.ToString(textBox2.Text) + "',phone='" + Convert.ToString(textBox3.Text) + "',fax='" + Convert.ToString(textBox4.Text) + "',country='" + Convert.ToString(textBox5.Text) + "',city='" + Convert.ToString(textBox6.Text) + "',address='" + Convert.ToString(richTextBox1.Text) + "'", "id", "'cm-101'");
                    dr.Close();
                }
                else{
                    _categoryModel = new Model.CompanyRegisterModel();
                    _categoryController = new Controller.CompanyRegisterController();
                    _categoryController.Name = Convert.ToString(textBox1.Text);
                    _categoryController.Email = Convert.ToString(textBox2.Text);
                    _categoryController.Phone = Convert.ToString(textBox3.Text);
                    _categoryController.FaxNo = Convert.ToString(textBox4.Text);
                    _categoryController.Country = Convert.ToString(textBox5.Text);
                    _categoryController.City = Convert.ToString(textBox6.Text);
                    _categoryController.Address = Convert.ToString(richTextBox1.Text);
                    _categoryController.UserName = Convert.ToString(textBox7.Text);
                    _categoryController.Password = Convert.ToString(textBox8.Text);
                    _categoryController.Image = Convert.ToString(imagePath.Text);
                    _categoryController.SoftwareType = Convert.ToString(comboBox1.Text);
                    //MessageBox.Show("" + _categoryController.Image.ToString());
                    _categoryModel.save(_categoryController);
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }    
        }
        private bool ValidateInput(string input, string expression, string message)
        {
            //store whether the input is valid  
            bool valid = Regex.Match(input, expression).Success;
            //if the input doesn't match the regular expression......  
            if (!valid)
            {
                //input was invalid......  
                MessageBox.Show(message, "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return valid;
        }  
        private void button2_Click(object sender, EventArgs e)
        {
            
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Choose Image File";
                openFileDialog.InitialDirectory =
                             Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
                openFileDialog.Filter = "JPG Files(*.jpg)|*.jpg|PNG Files(*.png)|*.png|All Files(*.*)|*.*";
                openFileDialog.Multiselect = false;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if (openFileDialog.CheckFileExists)
                    {

                        string path = Application.StartupPath.Substring(0,Application.StartupPath.Length-10);
                        string correctFilename = System.IO.Path.GetFileName(openFileDialog.FileName.ToString());
                        System.IO.File.Copy(openFileDialog.FileName, path + "\\Image\\" + correctFilename);
                        pictureBox1.Image = new Bitmap(openFileDialog.FileName);
                        imagePath.Text = correctFilename;
                       
                    }
                }
                // store file path in some field or textbox...
               
            }


        }

        private void Register_company_Load(object sender, EventArgs e)
        {

        }
    }
}
