using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DTO;
using System.IO;


namespace GUI
{
    public partial class LoginForm : Form
    {

        BUSAccounts BUSAcc = new BUSAccounts();

        public LoginForm()
        {
            InitializeComponent();

            //disable button login default
            BtnLogin.Enabled = false;

            if (string.IsNullOrWhiteSpace(TxtUsername.Text))
            {
                BtnLogin.Enabled = false;
            }
            else if (string.IsNullOrWhiteSpace(TxtPassword.Text))
            {
                BtnLogin.Enabled = false;
            }
            else
            {
                BtnLogin.Enabled = true;
            }


        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            string username = TxtUsername.Text;
            string password = TxtPassword.Text;
            

            if (ValidateChildren(ValidationConstraints.Enabled) )
            {
                
                DTOAccounts acc = new DTOAccounts(username, password);

                bool check = BUSAcc.Login(acc);
                if (check)
                {
                    MessageBox.Show("Login Successfully");
                    this.Hide();

                    StudentsForm frm = new StudentsForm();
                    frm.ShowDialog(); // Show StudentsForm and
                    this.Close(); // closes the Login form instance.
                }
                else
                {
                    MessageBox.Show("Login Fail");
                }
            }
            

        }


        //validate text username
        private void TxtUsername_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtUsername.Text))
            {
                e.Cancel = true;
                TxtUsername.Focus();
                errorProvider1.SetError(TxtUsername, "Username should not be left blank!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(TxtUsername, "");


            }
        }

        //validate text password
        private void TxtPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtPassword.Text))
            {
                e.Cancel = true;
                TxtPassword.Focus();
                errorProvider1.SetError(TxtPassword, "Password should not be left blank!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(TxtPassword, "");


            }
        }

        //check Enable Login button
        private bool BtnLoginEnable()
        {
            if (!string.IsNullOrWhiteSpace(TxtUsername.Text) && !string.IsNullOrWhiteSpace(TxtPassword.Text))
            {
                return true;
            } else
            {
                return false;
            }
            
        }


        // check textBox username to enable login button
        private void TxtUsername_TextChanged(object sender, EventArgs e)
        {
            BtnLogin.Enabled = this.BtnLoginEnable();
        }

        // check textBox password to enable login button
        private void TxtPassword_TextChanged(object sender, EventArgs e)
        {
            BtnLogin.Enabled = this.BtnLoginEnable();
        }
    }
}
