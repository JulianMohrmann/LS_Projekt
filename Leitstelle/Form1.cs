using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using MySql.Data.MySqlClient; //Wird benötigt für die Verbindung mit MySql
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace Leitstelle
{
    public partial class Form1 : Form
    {
        //Hier geben wir die Connection zur Datenbank an mit IP Username dem Passwort und welche Datenbank
        MySqlConnection cn = new MySqlConnection("Datasource =94.130.133.100;username=LF8Projekt;password=BDbD)dw!Dvv!7q6k;database=LF8Projekt");
        MySqlCommand command;
        MySqlDataAdapter da;
        MySqlDataReader reader;
        DataTable dt;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //Hier wird direkt nachdem Start einmal die Datenbank geladen/geupdatet (Oben)
            try
            {
                cn.Open();
                command = new MySqlCommand("Select * from einsatzort Where erledigt = '0'", cn);
                command.ExecuteNonQuery();
                dt = new DataTable();
                da = new MySqlDataAdapter(command);
                da.Fill(dt);
                dataGridView1.DataSource = dt.DefaultView;
                cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //Hier wird direkt nachdem Start einmal die Datenbank geladen/geupdatet (Unten)
            try
            {
                cn.Open();
                command = new MySqlCommand("Select * from einsatz Where erledigt = '0'", cn);
                command.ExecuteNonQuery();
                dt = new DataTable();
                da = new MySqlDataAdapter(command);
                da.Fill(dt);
                dataGridView2.DataSource = dt.DefaultView;
                cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SpeBtn_Click(object sender, EventArgs e)
        {
            //hier wird für jedes Fahrzeig ein String angelegt,
            string W1 = "";
            string W2 = "";
            string W3 = "";
            string W4 = "";
            string W5 = "";
            string W6 = "";
            string W7 = "";
            string W8 = "";
            string W9 = "";
            string W10 = "";
            string W11 = "";
            string W12 = "";
            string W13 = "";
            string W14 = "";
            string W15 = "";
            string W16 = "";
            string W17 = "";
            string W18 = "";
            string W19 = "";
            string W20 = "";
            string W21 = "";
            string W22 = "";
            string W23 = "";
            string W24 = "";
            string W25 = "";


            //Um diese hier zu Checken ob die Abgehackt sind.
            if (checkBox1.Checked) W1 = "01/07-01 ,";
            if (checkBox2.Checked) W2 = "01/08-01 ,";
            if (checkBox3.Checked) W3 = "01/08-02 ,";
            if (checkBox4.Checked) W4 = "01/08-03 ,";
            if (checkBox5.Checked) W5 = "01/08-04 ,";
            if (checkBox6.Checked) W6 = "01/08-05 ,";
            if (checkBox7.Checked) W7 = "01/10-01 ,";
            if (checkBox8.Checked) W8 = "01/10-02 ,";
            if (checkBox9.Checked) W9 = "01/10-03 ,";
            if (checkBox10.Checked) W10 = "01/10-04 ,";
            if (checkBox11.Checked) W11 = "01/10-05 ,";
            if (checkBox12.Checked) W12 = "01/10-06 ,";
            if (checkBox13.Checked) W13 = "01/10-07 ,";
            if (checkBox14.Checked) W14 = "01/10-08 ,";
            if (checkBox15.Checked) W15 = "01/11-01 ,";
            if (checkBox16.Checked) W16 = "01/12-01 ,";
            if (checkBox17.Checked) W17 = "01/17-01 ,";
            if (checkBox18.Checked) W18 = "01/27-01 ,";
            if (checkBox19.Checked) W19 = "01//30-01 ,";
            if (checkBox20.Checked) W20 = "01/48-01 ,";
            if (checkBox21.Checked) W21 = "01/50-01 ,";
            if (checkBox22.Checked) W22 = "01/52-01 ,";
            if (checkBox23.Checked) W23 = "01/59-01 ,";
            if (checkBox24.Checked) W24 = "01/59-02 ,";
            if (checkBox25.Checked) W25 = "01/66-01";
            //Hier werden alle Strings in einen String gepackt damit wir mehrere Wagen gleichzeitig Alamieren können
            string AlleAF = W1 + W2 + W3 + W4 + W5 + W6 + W7 + W8 + W9 + W10 + W11 + W12 + W13 + W14 + W15 + W16 + W17 + W18 + W19 + W20 + W21 + W22 + W23 + W24 + W25;
            if (txtStra.Text == "" || txtHausnummer.Text == "" || txtOrt.Text == "" || txtPLZ.Text == "" || txtOrts.Text == "" || txtLKreis.Text == "" || txtGebäude.Text == "" || txtGenauigkeit.Text == "" || txtBild.Text == "" || txtText.Text == "" || AlleAF == "")
            {
                MessageBox.Show("Bitte fülle alle Text Felder aus!");
            }
            else
            {
                try
                {
                    cn.Close();
                    cn.Open();
                    //Hiermit können wir Daten aus den Textboxen einfügen
                    command = new MySqlCommand("Insert into einsatzort(Strasse,Hausnummer,Ort,PLZ,Ortsteil,Landkreis,Gebäude,Genauigkeit) VALUES('" + txtStra.Text + "','" + txtHausnummer.Text + "','" + txtOrt.Text + "','" + txtPLZ.Text + "','" + txtOrts.Text + "','" + txtLKreis.Text + "','" + txtGebäude.Text + "','" + txtGenauigkeit.Text + "')", cn);
                    command.ExecuteNonQuery();
                    command = new MySqlCommand("Insert into einsatz(Datum,Uhrzeit,Meldebild,Freitext,Alamierte_Fa) VALUES('" + dateTimePicker1.Text + "','" + dateTimePicker2.Text + "','" + txtBild.Text + "','" + txtText.Text + "','" + AlleAF + "')", cn);
                    command.ExecuteNonQuery();
                    cn.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                //Hier werden Automatisch nachdem einfügen die Text Felder geleert
                txtBild.Clear();
                txtEinsatz.Clear();
                txtGebäude.Clear();
                txtGenauigkeit.Clear();
                txtHausnummer.Clear();
                txtLKreis.Clear();
                txtOrt.Clear();
                txtOrts.Clear();
                txtPLZ.Clear();
                txtStra.Clear();
                txtText.Clear();
                checkBox1.Checked = false;
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                checkBox4.Checked = false;
                checkBox5.Checked = false;
                checkBox6.Checked = false;
                checkBox7.Checked = false;
                checkBox8.Checked = false;
                checkBox9.Checked = false;
                checkBox10.Checked = false;
                checkBox11.Checked = false;
                checkBox12.Checked = false;
                checkBox13.Checked = false;
                checkBox14.Checked = false;
                checkBox15.Checked = false;
                checkBox16.Checked = false;
                checkBox17.Checked = false;
                checkBox18.Checked = false;
                checkBox19.Checked = false;
                checkBox20.Checked = false;
                checkBox21.Checked = false;
                checkBox22.Checked = false;
                checkBox23.Checked = false;
                checkBox24.Checked = false;
                checkBox25.Checked = false;
                //Hier wird direkt nachdem Einfügen einmal die Datenbank geladen/geupdatet (Oben)
                try
                {
                    cn.Open();
                    command = new MySqlCommand("Select * from einsatzort Where erledigt = '0'", cn);
                    command.ExecuteNonQuery();
                    dt = new DataTable();
                    da = new MySqlDataAdapter(command);
                    da.Fill(dt);
                    dataGridView1.DataSource = dt.DefaultView;
                    cn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                //Hier wird direkt nachdem Einfügen einmal die Datenbank geladen/geupdatet (Unten)
                try
                {
                    cn.Open();
                    command = new MySqlCommand("Select * from einsatz Where erledigt = '0'", cn);
                    command.ExecuteNonQuery();
                    dt = new DataTable();
                    da = new MySqlDataAdapter(command);
                    da.Fill(dt);
                    dataGridView2.DataSource = dt.DefaultView;
                    cn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        //Hiermit können wir die Einsätze als Erledigt kennzeichen.
        private void button2_Click(object sender, EventArgs e)
        {
            if (txtEinsatz.Text == "")
            {
                MessageBox.Show("Bitte Einsatz ID eintragen!");
            }
            else
            {
                cn.Close();
                string Probe = (txtEinsatz.Text);
                string SQL = ("UPDATE `einsatz` SET erledigt = '1' WHERE `Einsatz_Nr.` = '" + Probe + "'");
                string SQL1 = ("UPDATE `einsatzort` SET erledigt = '1' WHERE `Einsatzort_ID` = '" + Probe + "'");
                cn.Open();
                command = new MySqlCommand(SQL, cn);
                command.ExecuteNonQuery();
                command = new MySqlCommand(SQL1, cn);
                command.ExecuteNonQuery();
                dt = new DataTable();
                da = new MySqlDataAdapter(command);
                da.Fill(dt);
                dataGridView1.DataSource = dt.DefaultView;
                cn.Close();
                txtEinsatz.Clear();
                //Hier wird nachdem man den Einsatz Beendet hat einmal die Datenbank geladen/geupdatet (Oben)
                try
                {
                    cn.Open();
                    command = new MySqlCommand("Select * from einsatzort Where erledigt = '0'", cn);
                    command.ExecuteNonQuery();
                    dt = new DataTable();
                    da = new MySqlDataAdapter(command);
                    da.Fill(dt);
                    dataGridView1.DataSource = dt.DefaultView;
                    cn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                //Hier wird nachdem man den Einsatz Beendet hat einmal die Datenbank geladen/geupdatet (Unten)
                try
                {
                    cn.Open();
                    command = new MySqlCommand("Select * from einsatz Where erledigt = '0'", cn);
                    command.ExecuteNonQuery();
                    dt = new DataTable();
                    da = new MySqlDataAdapter(command);
                    da.Fill(dt);
                    dataGridView2.DataSource = dt.DefaultView;
                    cn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        //Hiermit Löschen wir die Texte in den Textfeldern und die Checkmarks in den Checkboxen auf Knopf druck.
        private void button1_Click(object sender, EventArgs e)
        {
            txtBild.Clear();
            txtEinsatz.Clear();
            txtGebäude.Clear();
            txtGenauigkeit.Clear();
            txtHausnummer.Clear();
            txtLKreis.Clear();
            txtOrt.Clear();
            txtOrts.Clear();
            txtPLZ.Clear();
            txtStra.Clear();
            txtText.Clear();
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
            checkBox5.Checked = false;
            checkBox6.Checked = false;
            checkBox7.Checked = false;
            checkBox8.Checked = false;
            checkBox9.Checked = false;
            checkBox10.Checked = false;
            checkBox11.Checked = false;
            checkBox12.Checked = false;
            checkBox13.Checked = false;
            checkBox14.Checked = false;
            checkBox15.Checked = false;
            checkBox16.Checked = false;
            checkBox17.Checked = false;
            checkBox18.Checked = false;
            checkBox19.Checked = false;
            checkBox20.Checked = false;
            checkBox21.Checked = false;
            checkBox22.Checked = false;
            checkBox23.Checked = false;
            checkBox24.Checked = false;
            checkBox25.Checked = false;
        }
    }
}
