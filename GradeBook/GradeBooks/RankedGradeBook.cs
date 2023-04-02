using GradeBook.Enums;
using GradeBook.GradeBooks;
using System.Linq;
using System;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name, bool isWeighted) : base(name, isWeighted)
        {
            Type = GradeBookType.Ranked;
            IsWeighted = isWeighted;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
            {
                throw new InvalidOperationException("Ranked grading requires at least 5 students.");
            }

            // Determine the threshold grade to earn an 'A'
            var threshold = (int)Math.Ceiling(Students.Count * 0.2);
            var grades = Students.OrderByDescending(s => s.AverageGrade).Select(s => s.AverageGrade).ToList();

            // Check the input grade against the thresholds for each letter grade
            if (averageGrade >= grades[threshold - 1])
            {
                return 'A';
            }
            else if (averageGrade >= grades[(threshold * 2) - 1])
            {
                return 'B';
            }
            else if (averageGrade >= grades[(threshold * 3) - 1])
            {
                return 'C';
            }
            else if (averageGrade >= grades[(threshold * 4) - 1])
            {
                return 'D';
            }
            else
            {
                return 'F';
            }
        }

        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students.");
                return;
            }

            base.CalculateStatistics();
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students.");
                return;
            }

            base.CalculateStudentStatistics(name);
        }
    }
}

