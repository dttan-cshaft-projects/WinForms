using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTOStudents
    {

        private int _id;
        private string _student_name;
        private string _student_age;
        private string _student_address;
        private string _student_semester;


        //getter/setter

        public int Student_Id
        {
            get
            {
                return _id;
            }

            set
            {
                _id = value;
            }
        }

        public string Student_name
        {
            get
            {
                return _student_name;
            }

            set
            {
                _student_name = value;
            }
        }

        public string Student_age
        {
            get
            {
                return _student_age;
            }

            set
            {
                _student_age = value;
            }
        }

        public string Student_address
        {
            get
            {
                return _student_address;
            }

            set
            {
                _student_address = value;
            }
        }

        public string Student_semester
        {
            get
            {
                return _student_semester;
            }

            set
            {
                _student_semester = value;
            }
        }

        //contructor
        public DTOStudents()
        {

        }

        public DTOStudents(int Id, string name, string age, string address, string semester)
        {
            this.Student_Id = Id;
            this.Student_name = name;
            this.Student_age = age;
            this.Student_address = address;
            this.Student_semester = semester;

        }




    }
}
