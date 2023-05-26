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
            btnLogin.Enabled = false;

        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            

            if (ValidateChildren(ValidationConstraints.Enabled) )
            {
                
                DTOAccounts acc = new DTOAccounts(username, password);

                bool check = BUSAcc.Login(acc);
                if (check)
                {
                    MessageBox.Show("Login Successfully");
                }
                else
                {
                    MessageBox.Show("Login Fail");
                }
            }
            

        }


        private void TxtUsername_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                e.Cancel = true;
                txtUsername.Focus();
                errorProvider1.SetError(txtUsername, "Username should not be left blank!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtUsername, "");


            }
        }

        private void TxtPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                e.Cancel = true;
                txtPassword.Focus();
                errorProvider1.SetError(txtPassword, "Password should not be left blank!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtPassword, "");


            }
        }

       

        private void FrmLogin_Validated(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUsername.Text) && (string.IsNullOrEmpty(txtPassword.Text)) {
                btnLogin.Enabled = true;
            }
        }

        private void FrmLogin_Validated(object sender, CancelEventArgs e)
        {

        }
    }
}
