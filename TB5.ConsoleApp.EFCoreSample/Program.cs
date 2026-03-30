// See https://aka.ms/new-console-template for more information
using TB5.ConsoleApp.EFCoreSample;

Console.WriteLine("Hello, World!");

EFCoreService service = new EFCoreService();
service.Create();
//service.Read();
//service.Update();
//service.Edit();
//service.Delete();


Console.ReadLine();
