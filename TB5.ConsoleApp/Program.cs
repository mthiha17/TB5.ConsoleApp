// See https://aka.ms/new-console-template for more information
using Microsoft.Data.SqlClient;
using TB5.ConsoleApp.AdoDotNetSample;

Console.WriteLine("Hello, World!");

//Console.WriteLine("Create Student");

//Console.Write("Please enter student name:");
//string name = Console.ReadLine();

//Console.Write("Please enter age:");
//string age = Console.ReadLine(); // djfaidfnaidfn3r232342

//Console.Write("Please enter student no:");
//string studentNo = Console.ReadLine();

//Console.Write("Please enter marks:");
//string marks = Console.ReadLine();

//Student student = new Student();
//student.Name = name;
//student.Age = Convert.ToInt32(age);
//student.StudentNo = studentNo;  
//student.SetMark(Convert.ToInt32(marks));
//string grade = student.Grade();
//Console.Write($"this student - {grade}");

//SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=Batch5MiniPOS;User ID=sa;Password=sasa@123;Trust Server Certificate=True;");
//conn.Open();
//conn.Close();

AdoDotNetService service = new AdoDotNetService();
//service.Create();
//service.Read();
service.Edit();

Console.ReadLine();
