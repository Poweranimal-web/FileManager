using Disk;
using Catalog;
using System.Text.RegularExpressions;
using System.Security.Cryptography.X509Certificates;
namespace Commands{
    class Command{
        string? command;
        static string currentPath = ""; 
        DirectoryControl dir = new DirectoryControl(ref currentPath);
        public void RunCommand(ref bool status){
            Console.Write($"{currentPath}>> ");
            command = Console.ReadLine();
            switch(command){
                case "disk":
                    DriveControl.GetDriver();
                    break;
                case "ls":
                    dir.GetSubContentCurrentPath();
                    break;
                case string prompt when new Regex(@"cd\s\S*\\").IsMatch(command):
                    string[] commandArray = prompt.Split(" ");
                    dir.MoveCatalogs(commandArray[1], ref currentPath);
                    break;
                case string prompt when new Regex(@"cd [^:\\]*").IsMatch(command):
                    string[] commandArray2 = prompt.Split(" ");
                    dir.MoveSubCatalogs(commandArray2[1], ref currentPath);
                    break;
                case "cd ..":
                    dir.MoveParentCatalog(ref currentPath);
                    break;
                case "exit":
                    status = false;
                    break;
                default:
                    Console.WriteLine("Unknown command!");
                    break;

            }
        }
    }
}