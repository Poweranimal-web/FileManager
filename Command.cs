using Disk;
using Catalog;
using FileIO;
using System.Text.RegularExpressions;
namespace Commands{
    class Command{
        string? command;
        static string currentPath = ""; 
        DirectoryControl dir = new DirectoryControl(ref currentPath);
        FileControl file = new FileControl();
        string[] commandArray;
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
                    commandArray = prompt.Split(" ");
                    dir.MoveCatalogs(commandArray[1], ref currentPath);
                    break;
                case string prompt when new Regex(@"cd [^:\\]*").IsMatch(command):
                    commandArray = prompt.Split(" ");
                    Console.WriteLine("fdkfdf");
                    dir.MoveSubCatalogs(commandArray[1], ref currentPath);
                    break;
                case string prompt when new Regex(@"mkdir [^:\\]*").IsMatch(command):
                    commandArray = prompt.Split(" ");
                    dir.CreateSubCatalog(commandArray[1], ref currentPath);
                    break;
                case string prompt when new Regex(@"rmdir [^:\\]*").IsMatch(command):
                    commandArray = prompt.Split(" ");
                    dir.DeleteSubCatalog(commandArray[1], ref currentPath);
                    break;
                case string prompt when new Regex(@"mv \S* -d \S*").IsMatch(command):
                    commandArray = prompt.Split(" ");
                    dir.MoveCatalog(commandArray[1], commandArray[3]);
                    break;
                case string prompt when new Regex(@"crfile [^:\\]*").IsMatch(command):
                    commandArray = prompt.Split(" ");
                    file.CreateFile(commandArray[1],ref currentPath);
                    break;
                case string prompt when new Regex(@"rmfile [^:\\]*").IsMatch(command):
                    commandArray = prompt.Split(" ");
                    file.DeleteFile(commandArray[1],ref currentPath);
                    break;
                case string prompt when new Regex(@"copy [^:\\]* -to \S*").IsMatch(command):
                    commandArray = prompt.Split(" ");
                    file.CopyFileTo(commandArray[1], commandArray[3], ref currentPath);
                    break;
                case string prompt when new Regex(@"mvfile [^:\\]* -to \S*").IsMatch(command):
                    commandArray = prompt.Split(" ");
                    file.MoveFileTo(commandArray[1], commandArray[3], ref currentPath);
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