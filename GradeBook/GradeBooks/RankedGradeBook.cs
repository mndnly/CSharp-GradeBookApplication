using GradeBook.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            // first get all average grades of all students and order them
            // student.AverageGrade
            // ListOfStudents

            var orderByDescendingGrade = from s in Students
                                         orderby s.AverageGrade descending
                                         select s.AverageGrade;

            var list = orderByDescendingGrade.ToList();
            // now 'orderByDescendingGrade' is a sorted list of grades with highest grades on top
            var noOfStudentsToDrop = (int)Math.Ceiling(Students.Count * 0.2);

            if (Students.Count < 5)
                throw new InvalidOperationException("Ranked grading requires at least 5 students.");
            if (averageGrade >= list[noOfStudentsToDrop - 1])
                return 'A';
            else if (averageGrade >= list[(noOfStudentsToDrop * 2) - 1])
                return 'B';
            else if (averageGrade >= list[(noOfStudentsToDrop * 3) - 1])
                return 'C';
            if (averageGrade >= list[(noOfStudentsToDrop*4) - 1])
                return 'D';
            return 'F';
        }
    }
}
