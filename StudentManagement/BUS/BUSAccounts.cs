using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;


namespace BUS
{
    public class BUSAccounts
    {
        DALAccounts dal_acc = new DALAccounts();

        public int CountAll()
        {
            return dal_acc.CountAll();
        }


        public bool Add(DTOAccounts acc)
        {
            string action = "I";
            return dal_acc.Crud(acc, action);
        }

        public bool Update(DTOAccounts acc)
        {
            string action = "U";
            return dal_acc.Crud(acc, action);
        }

        public bool Delete(DTOAccounts acc)
        {
            string action = "D";
            return dal_acc.Crud(acc, action);
        }

        public bool Login(DTOAccounts acc )
        {
            return dal_acc.Login(acc);
        }
    }

}
