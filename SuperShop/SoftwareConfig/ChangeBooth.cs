using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SuperShop.SoftwareConfig
{
    public partial class ChangeBooth : Form
    {
        Controller.bothController _boothController = new Controller.bothController();
        Model.BoothModel _boothModel = new Model.BoothModel();
        public ChangeBooth()
        {
            InitializeComponent();
        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            _boothController.PcId_No = Convert.ToString(textBox1.Text);
            _boothController.BoothName = Convert.ToString(comboBox1.Text);
            _boothModel.saveBooth(_boothController);
        }

        private void ChangeBooth_Load(object sender, EventArgs e)
        {
            textBox1.Text = hardware.GetProcessorId();
        }
    }
}
