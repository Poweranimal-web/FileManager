using Disk;
using Catalog;
namespace Commands{
    class Command{
        string? command; 
        public Command(ref bool status){
            string currentPath = "";
            DirectoryControl dir = new DirectoryControl(ref currentPath);
            Console.Write($"{currentPath}>> ");
            command = Console.ReadLine();
            switch(command){
                case "disk":
                    DriveControl.GetDriver();
                    break;
                case "ls":
                    dir.GetSubContentCurrentPath();
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