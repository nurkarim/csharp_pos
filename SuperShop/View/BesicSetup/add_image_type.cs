using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using MySql.Data.MySqlClient;
namespace SuperShop.View.BesicSetup
{
    public partial class add_image_type : Form
    {
        public add_image_type()
        {
            InitializeComponent();
        }
        DB.config connect = new DB.config();
        MySqlConnection condatabase;
      
        DB.query _query = new DB.query();
       
       
        private void button2_Click(object sender, EventArgs e)
        {

            try
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Filter = "Image files | *.jpg";
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    textBox1.Text = openFileDialog1.FileName;
                    pictureBox2.Image = Image.FromFile(openFileDialog1.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            byte[] imageBt = null;
            FileStream fStream = new FileStream(this.imagePath.Text, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fStream);
            imageBt = br.ReadBytes((int)fStream.Length);

      


            condatabase = connect.connection();
            condatabase.Open();
            MySqlCommand cmd = new MySqlCommand("insert into paid_type_image(image_paid) values(@img)", condatabase);
            cmd.Parameters.Add(new MySqlParameter("@img",imageBt));
            cmd.ExecuteNonQuery();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "JPG Files(*.jpg)|*.jpg|PNG Files(*.png)|*.png|All Files(*.*)|*.*";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string picLoc = openFileDialog1.FileName.ToString();
                imagePath.Text = picLoc;
                pictureBox1.ImageLocation = picLoc;

            }
        }
    }
}
