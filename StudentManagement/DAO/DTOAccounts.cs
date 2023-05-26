using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTOAccounts
    {

        private string _username;
        private string _password;


        //getter/setter

        public string Username
        {
            get
            {
                return _username;
            }

            set
            {
                _username = value;
            }
        }

        public string Password
        {
            get
            {
                return _password;
            }

            set
            {
                _password = value;
            }
        }

        //contructor
        public DTOAccounts()
        {

        }

        public DTOAccounts(string username, string password)
        {
            this.Username = username;
            this.Password = password;

        }




    }
}
