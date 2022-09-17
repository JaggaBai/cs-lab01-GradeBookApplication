using GradeBook.Enums;// dodane
using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name, bool konstbool) : base(name, konstbool)
        {
            Name = name;
            Type = GradeBookType.Ranked;
         IsWeighted = konstbool;
        }

        //Override  RankedGradeBook 's  GetLetterGrade  method zadanie 3cie
        public override char GetLetterGrade(double averageGrade)
        {

            if (Students.Count < 5) { throw new InvalidOperationException(); }
            else
            {
                double twentyBest = (int)(Students.Count / 5);
                int totnumber = 0;
                foreach (var student in Students)
                {

                    if (student.AverageGrade > averageGrade)
                    {
                        totnumber += 1;
                    }
                }
                if (totnumber < twentyBest)
                    return 'A';
                else if (totnumber < twentyBest * 2)
                    return 'B';
                else if (totnumber < twentyBest * 3)
                    return 'C';
                else if (totnumber < twentyBest * 4)
                    return 'D';
                else
                    return 'F';
            }
        }
        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
                Console.WriteLine("Ranked grading requires at least 5 students.");
            else base.CalculateStatistics();

        }
        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count<5)
                Console.WriteLine("Ranked grading requires at least 5 students.");
            else base.CalculateStudentStatistics(name);
        }
    }
}
