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
        public void MoveCatalogs(string pathMoveTo, ref string currentPath){
            Console.WriteLine(pathMoveTo);
            DirectoryInfo directoryInfo = new DirectoryInfo(pathMoveTo);
            if(directoryInfo.Exists){
                directory = directoryInfo.FullName;
                currentPath = directoryInfo.FullName;
            }
            else{
                Console.WriteLine("Invalid Path!");
            }

        }
        public void MoveSubCatalogs(string catalogName, ref string currentPath){
            string catalogPath =  @$"{currentPath}\{catalogName}";
            Console.WriteLine(catalogPath);
            DirectoryInfo directoryInfo = new DirectoryInfo(catalogPath);
            if(directoryInfo.Exists){
                Console.WriteLine(directoryInfo.FullName);
                directory = directoryInfo.FullName;
                currentPath = directoryInfo.FullName;
            }
            else{
                Console.WriteLine("Invalid Path!");
            }

        }
        public void MoveParentCatalog(ref string currentPath){
            DirectoryInfo directoryInfo = new DirectoryInfo(currentPath);
            if(directoryInfo.Exists){
                directory = directoryInfo.Parent.FullName;
                currentPath = directoryInfo.Parent.FullName;
            }
            else{
                Console.WriteLine("Invalid Path!");
            }

        }
        public void CreateSubCatalog(string catalogName, ref string currentPath){
            DirectoryInfo directoryInfo = new DirectoryInfo(currentPath);
            try{
                directoryInfo.CreateSubdirectory(catalogName);
                Console.WriteLine($"Created {catalogName} successfully");
            }
            catch (Exception e){
                Console.WriteLine("Invalid name, pls choose another one!");
                Console.WriteLine(e);

            }
        }
        public void DeleteSubCatalog(string catalogName, ref string currentPath){
            string catalogPath =  @$"{currentPath}\{catalogName}";
            DirectoryInfo directoryInfo = new DirectoryInfo(catalogPath);
            try{
                Console.Write("Are you sure to want delete all files in catalog,if they exist(yes/no):");
                string deleteAllFilesInCatalog = Console.ReadLine();
                if (deleteAllFilesInCatalog == "yes"){
                    directoryInfo.Delete();
                    Console.WriteLine($"Deleted {catalogName} successfully");
                }
                else{
                    Console.WriteLine("Cancel deletion");
                }
            }
            catch (Exception e){
                Console.WriteLine("Invalid name, pls choose another one!");
                Console.WriteLine(e);

            }
        }
    }
}