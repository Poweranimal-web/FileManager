using Disk;
namespace Commands{
    class Command{
        string? command; 
        public Command(ref bool status){
            Console.Write(">> ");
            command = Console.ReadLine();
            switch(command){
                case "disk":
                    DriveControl.GetDriver();
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