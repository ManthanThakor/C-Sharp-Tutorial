using System;
using System.Threading.Tasks;

namespace StudentInformation
{
    class StudentDetails
    {
        public async Task<string> GetStudentName(int Delay, string name)
        {
            await Task.Delay(Delay);
            return name;
        }

        public async Task<string> GetStudentGreade(int Delay, string Greade)
        {
            await Task.Delay(Delay);
            return Greade;
        }

        public async Task<int> GetStudentAge(int Delay, int age)
        {
            await Task.Delay(Delay);
            return age;
        }
    }

    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Fetching student information...");

            StudentDetails studentDetails = new StudentDetails();

            // Start all tasks concurrently
            var task1 =  studentDetails.GetStudentName(1000, "Xyz");
            var task2 =  studentDetails.GetStudentGreade(1000, "A");
            var task3 =  studentDetails.GetStudentAge(1000, 18);

            // Await all tasks concurrently
            await Task.WhenAll(task1, task2, task3);

            // Fetch results
            var studentName = await task1;
            var studentGrade = await task2;
            var studentAge = await task3;

            Console.WriteLine($"Student Name: {studentName}");
            Console.WriteLine($"Student Age: {studentAge}");
            Console.WriteLine($"Student Grade: {studentGrade}");

            Console.WriteLine("All student data fetched.");
            Console.ReadLine();
        }
    }
}
