using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;


namespace BUS
{
    public class BUSStudents
    {
        DALStudents dal_st = new DALStudents();

        public int CountAll()
        {
            return dal_st.CountAll();
        }


        public bool Add(DTOStudents st)
        {
            string action = "I";
            return dal_st.Crud(st, action);
        }

        public bool Update(DTOStudents st)
        {
            string action = "U";
            return dal_st.Crud(st, action);
        }

        public bool Delete(DTOStudents st)
        {
            string action = "D";
            return dal_st.Crud(st, action);
        }
    }

}
