using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Management;
using MySql.Data.MySqlClient;
using Projectlib;
namespace SuperShop
{
    static class Program
    {
       
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                DB.config connect = new DB.config();
                MySqlConnection conDatabase;
              
                    String serial = "";
                    String serialcod = "";
                    ManagementObjectSearcher mos = new ManagementObjectSearcher("SELECT * FROM Win32_BaseBoard");
                    ManagementObjectCollection moc = mos.Get();

                    foreach (ManagementObject mo in moc)
                    {
                        serial = mo["SerialNumber"].ToString();
                        serialcod = serial.ToString();
                    }
                    conDatabase = connect.connection();
                    conDatabase.Open();
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = conDatabase;
                    cmd.CommandText = "select * from project_security where hwId='" + serialcod + "'";
                    MySqlDataReader dr;
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        dr.Close();

                        MySqlCommand cmda = new MySqlCommand();
                        cmda.Connection = conDatabase;
                        cmda.CommandText = "select count(*) as tt from project_security";
                        MySqlDataReader dra;
                        dra = cmda.ExecuteReader();
                        if (dra.Read())
                        {
                            if (dra["tt"].ToString() == "1")
                            {
                                dra.Close();
                                MySqlCommand cmds = new MySqlCommand("select * from company_register", conDatabase);
                                MySqlDataReader drs;
                                drs = cmds.ExecuteReader();
                                if (drs.Read())
                                {
                                    if (drs["id"] == "")
                                    {
                                        Application.EnableVisualStyles();
                                        Application.SetCompatibleTextRenderingDefault(false);
                                        Application.Run(new SoftwareConfig.Register_company());
                                    }
                                    else
                                    {
                                        Application.EnableVisualStyles();
                                        Application.SetCompatibleTextRenderingDefault(false);
                                        Application.Run(new View.login.login());
                                    }
                                }
                                else
                                {
                                    //cm-101

                                    Application.EnableVisualStyles();
                                    Application.SetCompatibleTextRenderingDefault(false);
                                    Application.Run(new SoftwareConfig.Register_company());
                                }
                            }
                            else {
                               
                            }
                        }
                    
                        else
                        {

                        }
                    }
                    else
                    {
                        Application.EnableVisualStyles();
                        Application.SetCompatibleTextRenderingDefault(false);
                        Application.Run(new SoftwareConfig.softwareLicence());

                    }
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
