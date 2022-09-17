using GradeBook.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook.GradeBooks
{
   public class StandardGradeBook : BaseGradeBook
    {
        public StandardGradeBook(string name, bool konstbool) : base(name, konstbool)
        {
            Name = name;
            Type = GradeBookType.Standard;
            bool KB = konstbool;
        }
    }
}
