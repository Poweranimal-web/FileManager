using System.IO;
namespace Catalog{
    class DirectoryControl{
        string? directory;
        public DirectoryControl(ref string currentPath){
            currentPath = Directory.GetCurrentDirectory();
            directory = currentPath;
        }
        public void GetSubContentCurrentPath(){
            DirectoryInfo directoryInfo = new DirectoryInfo(directory);
            DirectoryInfo[] subCatalogs = directoryInfo.GetDirectories();
            FileInfo[] subFiles = directoryInfo.GetFiles();
            for (int i = 0; i < subCatalogs.Length; i++)
            {
                if (i == 0){
                    Console.WriteLine("LastWriteTime                CreationTime                Name");
                    Console.WriteLine("-------------                ------------                ----");
                }
                Console.WriteLine($"{subCatalogs[i].LastWriteTime}      {subCatalogs[i].CreationTime}        {subCatalogs[i].Name}");
            }
            for (int i = 0; i < subFiles.Length; i++)
            {
                Console.WriteLine($"{subFiles[i].LastWriteTime}        {subFiles[i].CreationTime}        {subFiles[i].Name}");
            }
        }
    }
}