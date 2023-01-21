using MySql.Data.MySqlClient;
using MySql.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Leitstelle
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {

                    string connStr = "Datasource =94.130.133.100;username=LF8Projekt;password=BDbD)dw!Dvv!7q6k;database=LF8Projekt";
                    MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                string BEN = Benutzername.Text;
                BEN = '"' + BEN + '"';
                string PAS = Passwort.Text;
                conn.Open();
                string sql = "Select * from `benutzerdaten` Where LS = '1' and `Benutzername` = " + BEN + " and `Passwort` = " + PAS + "";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                           while (rdr.Read())
            {
                Console.WriteLine(rdr[0]+" -- "+rdr[1]);
            }
            int  ID = Convert.ToInt32(rdr[0]);
            Console.WriteLine(ID);
            rdr.Close();

                if (ID >= 0)
                {
                    
                    Form1 test = new Form1();
                    test.Show();
                    this.Hide();
                }

                else{

                    Console.WriteLine();
                }
                
                
                
                conn.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Benutzerdaten Falsch");
            }
        }
    }
}
