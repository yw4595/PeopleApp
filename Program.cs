using System;
using System.Collections.Generic;
using System.Linq;
using CourseLib;

namespace PeopleApp
     /// <summary>
    /// This program maintains a list of people (students and teachers) and their course schedules
    /// </summary>
    /// <author>Yanzhi Wang</author>
{
    class Program
    {
        static List<Person> people = new List<Person>();
        static Courses courses = new Courses();

        static void Main(string[] args)
        {
            Console.WriteLine("Add, Edit, Delete, List, Live, Quit => ");
            string response = Console.ReadLine().ToLower();
            while (response != "quit")
            {
                switch (response)
                {
                    case "add":
                        AddPerson();
                        break;
                    case "edit":
                        EditPerson();
                        break;
                    case "delete":
                        DeletePerson();
                        break;
                    case "list":
                        ListPeople();
                        break;
                    case "live":
                        Live();
                        break;
                    default:
                        Console.WriteLine("Invalid response. Please try again.");
                        break;
                }
                Console.WriteLine("Add, Edit, Delete, List, Live, Quit => ");
                response = Console.ReadLine().ToLower();
            }
        }

        static void AddPerson()
        {
            Console.WriteLine("Person type (student/teacher) => ");
            string type = Console.ReadLine().ToLower();
            if (type == "student")
            {
                Console.WriteLine("Email () => ");
                string email = Console.ReadLine();
                Console.WriteLine("Name () => ");
                string name = Console.ReadLine();
                Console.WriteLine("Age (0)=> ");
                int age = int.Parse(Console.ReadLine());
                Console.WriteLine("Drivers License ID (0) => ");
                int licenseID = int.Parse(Console.ReadLine());
                Console.WriteLine("GPA (0)=> ");
                double gpa = double.Parse(Console.ReadLine());
                List<string> courseCodes = new List<string>();
                Console.WriteLine("Course code=> ");
                string courseCode = Console.ReadLine();
                while (!string.IsNullOrEmpty(courseCode))
                {
                    courseCodes.Add(courseCode);
                    Console.WriteLine("Course code=> ");
                    courseCode = Console.ReadLine();
                }
                Student newStudent = new Student(email, name, age, licenseID, gpa, courseCodes);
                people.Add(newStudent);
            }
            else if (type == "teacher")
            {
                Console.WriteLine("Email () => ");
                string email = Console.ReadLine();
                Console.WriteLine("Name () => ");
                string name = Console.ReadLine();
                Console.WriteLine("Age (0)=> ");
                int age = int.Parse(Console.ReadLine());
                Console.WriteLine("Drivers License ID (0) => ");
                int licenseID = int.Parse(Console.ReadLine());
                Console.WriteLine("Specialization => ");
                string specialization = Console.ReadLine();
                Teacher newTeacher = new Teacher(email, name, age, licenseID, specialization);
                people.Add(newTeacher);
            }
            else
            {
                Console.WriteLine("Invalid response. Please try again.");
            }
        }

        static void EditPerson()
        {
            Console.WriteLine("Email () => ");
            string email = Console.ReadLine();
            Person person = people.FirstOrDefault(p => p.Email == email);
            if (person == null)
            {
                Console.WriteLine("Person not found. Please try again.");
                return;
            }

            if (person is Student)
            {
                Console.WriteLine("Name () => ");
                string name = Console.ReadLine();
                Console.WriteLine("Age (0)=> ");
                int age = int.Parse(Console.ReadLine());
                Console.WriteLine("Drivers License ID (0) => ");
                int licenseID = int.Parse(Console.ReadLine());
                Console.WriteLine("GPA (0)=> ");
                double gpa = double.Parse(Console.ReadLine());
                List<string> courseCodes = new List<string>();
                Console.WriteLine("Course code=> ");
                string courseCode = Console.ReadLine();
                while (!string.IsNullOrEmpty(courseCode))


                    Console.WriteLine("Add, Edit, Delete, List, Live, Quit => ");
                operation = Console.ReadLine().ToLower().Trim();

            }

            if (operation == "list")
            {
                Console.WriteLine();
                int count = 1;
                foreach (Person person in people)
                {
                    Console.WriteLine($"{count}: {person.Email} | {person.Name} | {person.Age} | {person.DriversLicenseId} | {person.GPA}");

                    // output the associated courses for this person
                    if (person.CourseCodes.Count > 0)
                    {
                        Console.WriteLine("\tCourses:");
                        foreach (string courseCode in person.CourseCodes)
                        {
                            Course thisCourse = courses.GetCourse(courseCode);

                            Console.Write($"\t{courseCode} - {thisCourse.Description} ");
                            Console.Write(string.Join(" ", thisCourse.Schedule.DaysOfWeek));
                            Console.Write($" {thisCourse.Schedule.StartTime:hh:mmtt} - {thisCourse.Schedule.EndTime:hh:mmtt}\n");
                        }
                    }

                    count++;
                }
            }

            Console.WriteLine();
        }
    }
}
        catch (Exception ex)
        {
    Console.WriteLine($"Exception: {ex.Message}");
}
    }
}
}
