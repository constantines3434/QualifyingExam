
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualifyingExam.Model
{
    public class Student
    {
        public int Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronimic { get; set; }
        public int MathGrade { get; set; }
        public int Informatics { get; set; }
        public int Physics { get; set; }

        public static ObservableCollection<Student> students = new ObservableCollection<Student>()
        {
            new Student {Id= 1, Surname="Smirnov", Name="Constantine",
                         Patronimic="Vadimovich", MathGrade=3, Informatics=4,
                         Physics=4},
            new Student {Id= 2, Surname="Uber", Name="Marginal",
                         Patronimic="Anatol", MathGrade=2, Informatics=2,
                         Physics=5}
        };
    }
}
