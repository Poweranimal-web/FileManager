using System.IO;
namespace Disk{
    class DriveControl{
        public static void GetDriver(){
        DriveInfo[] driveInfo = DriveInfo.GetDrives();
        for (int i = 0; i < driveInfo.Length; i++)
        {   
            Console.WriteLine($"Driver: {driveInfo[i].Name}");
            Console.WriteLine($"Available Free Space: {driveInfo[i].AvailableFreeSpace}");
            Console.WriteLine($"Available Free Space: {driveInfo[i].TotalSize}");
            Console.WriteLine(" ");
            
        }
    }
    }
}