using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using SuperShop.DB;
using System.Drawing.Printing;
namespace SuperShop.View.BesicSetup
{
    public partial class Item : Form
    {
        public Item()
        {
            InitializeComponent();
            genarateId(); 
        }
        Helper.helper _helper = new Helper.helper();
        Controller.ItemController _controller = new Controller.ItemController();
        Model.ItemModel _model = new Model.ItemModel();
        DB.config connect = new DB.config();
        DB.query _query = new DB.query();
        MySqlConnection conDatabase;
        MySqlCommand cmd;
        private void button1_Click(object sender, EventArgs e)
        {
            _controller.Name = textBox1.Text;
            _controller.Roll = Convert.ToString(textBox2.Text);
            try
            {
                if (_model.save(_controller))
                {}
                else 
                {
                    //this.notifyIcon2.BalloonTipText = "Save Success";
                    //this.notifyIcon2.BalloonTipTitle = "Message Success";
                   // this.notifyIcon2.Visible = true;
                   // this.notifyIcon2.ShowBalloonTip(1000);
                    //dataGridView1.DataSource = _query.selects("itemview");
                    genarateId(); 
                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
           (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {

                DB.query _query = new DB.query();
                //dataGridView1.DataSource = _query.selects("itemview");
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

                conDatabase = connect.connection();
                conDatabase.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conDatabase;
                cmd.CommandText = "SELECT count(id) From  item ";
                MySqlDataReader dr;
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {

                    int getId = dr.GetInt32(0);
                    string count = getId.ToString();
                    sumId = Convert.ToInt32(getId) + 1;
                    if (0 < sumId & 99 > sumId)
                    {
                        textBox2.Text = "ITM-" + "0000" + sumId.ToString();
                    }

                    else if (99 < sumId)
                    {
                        textBox2.Text = "ITM-" + "000" + sumId.ToString();
                    }

                    else if (1000 == sumId)
                    {
                        textBox2.Text = "ITM-" + "000" + sumId.ToString();

                    }
                    else if (1000 < sumId)
                    {
                        textBox2.Text = "ITM-" + sumId.ToString();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Item_Load(object sender, EventArgs e)
        {
            try
            {

                DB.query _query = new DB.query();
                dataGridView1.DataSource = _query.Select("itemview");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            _controller.Roll = Convert.ToString(textBox2.Text);
            try
            {
                _model.deleteItem(_controller);

                DB.query _query = new DB.query();
                //dataGridView1.DataSource = _query.selects("itemview");
                
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void notifyIcon2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.notifyIcon2.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
           

            Graphics graphic = e.Graphics;

            Font font = new Font("Courier New", 12); //must use a mono spaced font as the spaces need to line up

            float fontHeight = font.GetHeight();
            int startX = 10;
            int startY = 90;
            int offset = 40;
            conDatabase = connect.connection();
            conDatabase.Open();
            cmd = new MySqlCommand();
            cmd.Connection = conDatabase;
            cmd.CommandText = "SELECT cusId,name FROM item";
            MySqlDataReader dread = cmd.ExecuteReader();
            
            graphic.DrawString("প্রিন্স রেস্তরা", new Font("Gill Sans Ultra", 25, FontStyle.Bold), new SolidBrush(Color.Tomato), 200, 10);
            graphic.DrawString("shop@gmail.com,০০১৮৭৭২৬৬৬", new Font("Arial", 10, FontStyle.Italic), new SolidBrush(Color.Black), 200, 50);
            graphic.DrawString("Dhaka,Framget-1220,East Raza Bazar", new Font("Arial", 10, FontStyle.Italic), new SolidBrush(Color.Black),200, 70);
            graphic.DrawString("তারিখ  :" + DateTime.Now, new Font("Arial", 10), new SolidBrush(Color.Black), 10, 90);
            string top = "Item Name".PadRight(27) + "Item Id".PadRight(17) ;
            graphic.DrawString(top, font, new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + (int)fontHeight; //make the spacing consistent
            graphic.DrawString("-----------------------------------------------", font, new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + (int)fontHeight + 5; //make the spacing consistent
            while (dread.Read())
            {
                //create the string to print on the reciept
                string productDescription =dread["name"].ToString();
                string itemId = dread["cusId"].ToString();
                if (productDescription.Contains(" -"))
                {
                    string productLine = productDescription;
                    string itemsID = itemId;

                  
                    graphic.DrawString(productLine, new Font("Courier New", 12, FontStyle.Italic), new SolidBrush(Color.Red), startX, startY + offset);
                    graphic.DrawString(itemsID.PadRight(20), new Font("Courier New", 12, FontStyle.Italic), new SolidBrush(Color.Red), 290, 92 + offset);
                 
                    offset = offset + (int)fontHeight + 5; //make the spacing consistent
                }
                else
                {
                    string productLine = productDescription;
                    string itemsID = itemId;
                   
                    graphic.DrawString(productDescription, font, new SolidBrush(Color.Black), startX, startY + offset);
                    graphic.DrawString(itemsID.PadRight(20), new Font("Courier New", 12, FontStyle.Italic), new SolidBrush(Color.Red), 290, 92 + offset);
                    offset = offset + (int)fontHeight + 5; //make the spacing consistent
                }

            }
            

        }

        private void button5_Click(object sender, EventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();

            PrintDocument printDocument = new PrintDocument();

            printDialog.Document = printDocument; //add the document to the dialog box...        

            printDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(printDocument1_PrintPage); //add an event handler that will do the printing
            //printDocument.PrinterSettings.PrinterName = printer;
            // Create a new instance of Margins with 1-inch margins.
            Margins margins = new Margins(100, 100, 100, 100);
            printDocument.DefaultPageSettings.Margins = margins;
            //on a till you will not want to ask the user where to print but this is fine for the test envoironment.
           
            DialogResult result = printDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                printDocument.PrinterSettings.DefaultPageSettings.PaperSize = new PaperSize("A4",640,900);
               printDocument.Print();
               
            } 
        }
        public Margins Margins { get; set; }

        private void button6_Click(object sender, EventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            PrintDocument printDocument = new PrintDocument();
            printDialog.Document = printDocument; //add the document to the dialog box...        
            printDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(printDocument1_PrintPage); //add an event handler that will do the printing
            printDocument.PrinterSettings.DefaultPageSettings.PaperSize = new PaperSize("A4", 5, 5);            
            printPreviewDialog1.Show();
            printPreviewDialog1.Document = printDocument;
        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }
    }
}
