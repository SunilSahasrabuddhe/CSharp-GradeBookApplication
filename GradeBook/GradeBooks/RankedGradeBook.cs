using GradeBook.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook: BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name) { Type = GradeBookType.Ranked; }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
                throw new InvalidOperationException("Ranked-grading requires a minimum of 5 students to work");

            List<double> studentAverages = Students.OrderByDescending(s => s.AverageGrade).Select(s => s.AverageGrade).ToList();
            int studentCountForGradeBucket = (int)(Students.Count * 0.2);

            if (averageGrade >= studentAverages[(studentCountForGradeBucket * 1)-1])
                return 'A';

            if (averageGrade >= studentAverages[(studentCountForGradeBucket * 2)-1])
                return 'B';

            if (averageGrade >= studentAverages[(studentCountForGradeBucket * 3)- 1])
                return 'C';

            if (averageGrade >= studentAverages[(studentCountForGradeBucket * 4)- 1])
                return 'D';

            return 'F';
        }
        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                Console.WriteLine(@"Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }
            base.CalculateStatistics();

        }
        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                Console.WriteLine(@"Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }
            base.CalculateStudentStatistics(name);
        }
    }
}
