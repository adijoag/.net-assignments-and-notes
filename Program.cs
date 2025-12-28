using System;
using Services;
class Program
{
 static UserService userService = new UserService();
 static bool isLoggedIn = false;
 static void Main()
 {
 while (true)
 {
 Console.Clear();
 Console.WriteLine("1. Login");
 Console.WriteLine("2. Create User");
 Console.WriteLine("3. Exit");
 Console.Write("Choice: ");
 int choice;
 int.TryParse(Console.ReadLine(), out choice);
 switch (choice)
 {
 case 1:
 Login();
 break;
 case 2:
 if (isLoggedIn)
 CreateUser();
 else
 ShowError("Please login first.");
 Pause();
 break;
 case 3:
 return;
 default:
 ShowError("Invalid choice.");
 Pause();
 break;
 }
 }
 }
 static void Login()
 {
 Console.Write("Username: ");
 string username = Console.ReadLine();
 Console.Write("Password: ");
 string password = Console.ReadLine();
 if (userService.Login(username, password)){
 isLoggedIn = true;
 Console.WriteLine("Welcome " + username);
 }
 else
 {
 ShowError("Incorrect username or password.");
 }
 Pause();
 }
 static void CreateUser()
 {
 Console.Write("New Username: ");
 string username = Console.ReadLine();
 Console.Write("New Password: ");
 string password = Console.ReadLine();
 if (userService.Register(username, password))
 Console.WriteLine("User created successfully.");
 else
 ShowError("Username already exists.");
 }
 static void ShowError(string msg)
 {
 Console.ForegroundColor = ConsoleColor.Red;
 Console.WriteLine(msg);
 Console.ResetColor();
 }
 static void Pause()
 {
 Console.WriteLine("Press any key...");
 Console.ReadKey();
 }
}
