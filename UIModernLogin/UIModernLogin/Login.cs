using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Runtime.InteropServices;

namespace UIModernLogin
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }


        //DragAction Form
        [DllImport("User32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("User32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);


        private void TxtUsername_Click(object sender, EventArgs e)
        {
            TxtUsername.BackColor = Color.White;
            PanelUsername.BackColor = Color.White;

            PanelPassword.BackColor = SystemColors.Control;
            TxtPassword.BackColor = SystemColors.Control;
        }

        private void TxtPassword_Click(object sender, EventArgs e)
        {
            TxtUsername.BackColor = SystemColors.Control;
            PanelUsername.BackColor = SystemColors.Control;

            TxtPassword.BackColor = Color.White;
            PanelPassword.BackColor = Color.White;
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PicPassword_MouseDown(object sender, MouseEventArgs e)
        {
            TxtPassword.UseSystemPasswordChar = false;

        }

        private void PicPassword_MouseUp(object sender, MouseEventArgs e)
        {
            TxtPassword.UseSystemPasswordChar = true;
        }

        private void Login_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        
    }
}
