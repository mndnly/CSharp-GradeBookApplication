﻿using GradeBook.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name, bool isWeighted) : base(name, isWeighted)
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
        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
            else
                base.CalculateStatistics();
            return;
        }
        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
            else
                base.CalculateStudentStatistics(name);
            return;
        }
    }
}
