using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Project
{
    class Employe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Roletypee RoleType { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
        public int Salary { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public Gender Genderr { get; set;}
        private static int _id;
        public Employe()
        {
            Id=++_id;
        }
    }
    enum Roletypee
    { 
        ADMIN,
        STAF
    }
    enum Gender
    {
        MAN,
        WOMAN

    }
}
