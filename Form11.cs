using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb; //We added the lilbrary.

namespace DataGridAccess
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        OleDbConnection dc = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\ferha\\Documents\\Information.accdb");
        //dc: database connection

        private void showRecords(string mRecords)
        {

            OleDbDataAdapter da = new OleDbDataAdapter(mRecords, dc);
            DataSet ds = new DataSet();
            da.Fill(ds);

            dataGridView1.DataSource = ds.Tables[0];

            //To change Column name
            dataGridView1.Columns[1].HeaderText = "Name";
            dataGridView1.Columns[4].HeaderText = "Position";

        }
        private void button1_Click(object sender, EventArgs e)
        {
            showRecords("Select * from Members");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dc.Open();
            
            string sqlText = "INSERT INTO Members (mName,Surname,mail,mPosition) values (@mName, @mSurname, @mMail, @mPosition)";
            OleDbCommand ac = new OleDbCommand(sqlText, dc);
            //ac: access command
            ac.Parameters.AddWithValue("@mName", textBox1.Text);
            ac.Parameters.AddWithValue("@mSurname", textBox2.Text);
            ac.Parameters.AddWithValue("@mMail", textBox3.Text);
            ac.Parameters.AddWithValue("@mPosition", comboBox1.SelectedItem.ToString());
            ac.ExecuteNonQuery();
            showRecords("Select * from Members");
            dc.Close();

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            comboBox1.Refresh();


        }

        private void button3_Click(object sender, EventArgs e)
        {
            dc.Open();
            string sqlText = "delete from Members where ID=@id";
            OleDbCommand ac = new OleDbCommand(sqlText, dc);
            ac.Parameters.AddWithValue("@id", textBox5.Text);
            ac.ExecuteNonQuery();
            showRecords("Select * from Members");
            dc.Close();
            textBox5.Clear();
        }
    }
}
