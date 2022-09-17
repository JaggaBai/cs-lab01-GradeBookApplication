using GradeBook.Enums;// dodane
using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook.GradeBooks
{
    class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Name = name;
            Type = GradeBookType.Ranked;
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
    }
}
