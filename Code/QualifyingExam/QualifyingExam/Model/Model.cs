
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualifyingExam.Model
{
    public class Student
    {
        int Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronimic { get; set; }
        public int MathGrade { get; set; }
        public int Informatics { get; set; }
        public int Physics { get; set; }
    }
}
