using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Data;
namespace SuperShop.DB
{
    class query
    {
        config connect = new config();
        
        MySqlConnection conDatabase;
        MySqlCommand cmd;
        MySqlTransaction transaction;
        public void EIInsert(string table, string colums, string values)
        {
            try
            {
                int a = -1;
                conDatabase = connect.connection();
                conDatabase.Open();
                transaction = conDatabase.BeginTransaction();
                cmd = new MySqlCommand();
                cmd.Connection = conDatabase;
                cmd.CommandText = "INSERT INTO " + table + " (" + colums + ") VALUES (" + values + ")";
                cmd.Transaction = transaction;

                a = cmd.ExecuteNonQuery();
                if (a > 0)
                {
                   
                }
                else
                {
                  

                }
                cmd.Dispose();
                transaction.Commit();
            }
            catch (Exception)
            {
               
            }

            return;
        }
        
        public void Insert(string table, string colums, string values)
        {
            try
            {
                int a = -1;
                conDatabase = connect.connection();
                conDatabase.Open();
                transaction = conDatabase.BeginTransaction();
                cmd = new MySqlCommand();
                cmd.Connection = conDatabase;
                cmd.CommandText = "INSERT INTO " + table + " (" + colums + ") VALUES (" + values + ")";
                cmd.Transaction = transaction;

                a = cmd.ExecuteNonQuery();
                if (a > 0)
                {
                    MessageBox.Show("Save Success");
                }
                else 
                {
                    MessageBox.Show("Save UnSuccess");
                
                }
                cmd.Dispose();
                transaction.Commit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return;
        }
        private string lastId;
        public string LastId { get { return lastId; } set { lastId = value; } }
        public void InsertA(string table, string colums, string values)
        {

            
            try
            {
                int a = -1;
                conDatabase = connect.connection();
                conDatabase.Open();
                transaction = conDatabase.BeginTransaction();
                cmd = new MySqlCommand();
                cmd.Connection = conDatabase;
                cmd.CommandText = "INSERT INTO " + table + " (" + colums + ") VALUES (" + values + ")";
                cmd.Transaction = transaction;
                a = cmd.ExecuteNonQuery();
                LastId = Convert.ToString(cmd.LastInsertedId);
                if (a > 0)
                {
                  
                    MessageBox.Show("Save Success");
                }
                else
                {
                    MessageBox.Show("Save UnSuccess");

                }
               
                cmd.Dispose();
                transaction.Commit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
          
        }

        public DataTable Select(string tableName)
        {


            DataTable datatable = null;

            conDatabase = connect.connection();
            conDatabase.Open();
            cmd = new MySqlCommand();
            cmd.Connection = conDatabase;
            cmd.CommandText = "SELECT * FROM " + tableName + " ";
            MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
            datatable = new DataTable();
            sda.Fill(datatable);
            return datatable;
        }
        public DataTable SelectFullTable(string tableName)
        {


            DataTable datatable = null;

            conDatabase = connect.connection();
            conDatabase.Open();
            cmd = new MySqlCommand();
            cmd.Connection = conDatabase;
            cmd.CommandText =  tableName;
            MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
            datatable = new DataTable();
            sda.Fill(datatable);
            return datatable;
        }
        public DataTable selectWhere(string tableName,string field)
        {


            DataTable datatable = null;

            conDatabase = connect.connection();
            conDatabase.Open();
            cmd = new MySqlCommand();
            cmd.Connection = conDatabase;
            cmd.CommandText = "SELECT * FROM " + tableName + " where "+field+"";
            MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
            datatable = new DataTable();
            sda.Fill(datatable);
            return datatable;
        }
        public DataTable selectMultipale(string data,string table, string field)
        {


            DataTable datatable = null;

            conDatabase = connect.connection();
            conDatabase.Open();
            cmd = new MySqlCommand();
            cmd.Connection = conDatabase;
            cmd.CommandText = "SELECT " + data + "From" + table + " where " + field + "";
            MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
            datatable = new DataTable();
            sda.Fill(datatable);
            return datatable;
        }
        public void Delete(string table, string row, string whereRow)
        {
            try
            {
                int a = -1;
                conDatabase = connect.connection();
                conDatabase.Open();

                cmd = new MySqlCommand();
                cmd.Connection = conDatabase;
                cmd.CommandText = "DELETE FROM " + table + " WHERE " + row + "=" + whereRow + "";
                a = cmd.ExecuteNonQuery();

                cmd.Dispose();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

            return;
        }
        public void DeleteFullTable(string table)
        {
            try
            {
                int a = -1;
                conDatabase = connect.connection();
                conDatabase.Open();

                cmd = new MySqlCommand();
                cmd.Connection = conDatabase;
                cmd.CommandText = "DELETE FROM " + table + "";
                a = cmd.ExecuteNonQuery();

                cmd.Dispose();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

            return;
        }
        public void DeleteAndWhere(string table, string AndwhereRow)
        {
            try
            {
                int a = -1;
                conDatabase = connect.connection();
                conDatabase.Open();
                cmd = new MySqlCommand();
                cmd.Connection = conDatabase;
                cmd.CommandText = "DELETE FROM " + table + " " + AndwhereRow + " ";
                a = cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

            return;
        }

        public void Update(string table, string setData, string Fields, string ID)
        {
            try
            {
                int a = -1;
                conDatabase = connect.connection();
                conDatabase.Open();
                cmd = new MySqlCommand();
                cmd.Connection = conDatabase;
                cmd.CommandText = "UPDATE " + table + " SET  " + setData + " WHERE " + Fields + "= " + ID + " ";
                a = cmd.ExecuteNonQuery();
                a = cmd.ExecuteNonQuery();
                if (a > 0)
                {
                    MessageBox.Show("Update Success");
                }
                else
                {
                    MessageBox.Show("Update UnSuccess");

                }
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

            return;
        }
        public void UpdateAndWhere(string table, string setData, string Fields)
        {
            try
            {
                int a = -1;
                conDatabase = connect.connection();
                conDatabase.Open();
                cmd = new MySqlCommand();
                cmd.Connection = conDatabase;
                cmd.CommandText = "UPDATE " + table + " SET  " + setData + " WHERE " + Fields + "";
                a = cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

            return;
        }
        public void genarateId(string id, string table, string Fields, string fields2)
        {
            int sumId;
            string genarateId;
            conDatabase = connect.connection();
            conDatabase.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conDatabase;
            cmd.CommandText = "select count(" + id + ") from " + table + " where " + Fields + "='" + fields2 + "'";
            MySqlDataReader dr;
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {

                int getId = dr.GetInt32(0);
                string count = getId.ToString();
                sumId = Convert.ToInt32(getId) + 1;
                if (0 < sumId & 99 > sumId)
                {
                    genarateId = "0000" + sumId.ToString();
                }

                else if (99 < sumId)
                {
                    genarateId = "000" + sumId.ToString();
                }

                else if (1000 == sumId)
                {
                    genarateId = "000" + sumId.ToString();

                }

            }


        }

    }
}
