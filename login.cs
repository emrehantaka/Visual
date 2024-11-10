using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Form_2024_Week_4_Bunifu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string user_name = "nesrin";
        int password = 1234;
        private void bunifuLabel4_Click(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            if (user_name == bunifuTextBox1.Text && password == Convert.ToInt16(bunifuTextBox2.Text))
            {

                MessageBox.Show(" Congrulations!!! Username and Password  are True....",
                    "Sign In Panel", MessageBoxButtons.OK);


                Form1 form1 = new Form1();
                this.Hide();
                Form2 form = new Form2();
                form.Show();

            }
           else  MessageBox.Show(" Username and Password  are WRONG....",
                    "Sign In Panel", MessageBoxButtons.OK);
        }
    }
}
