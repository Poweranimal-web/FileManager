using System.IO;
namespace Catalog{
    class DirectoryControl{
        string? directory;
        List<object> matchedObject = new List<object>();
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
        public void ClearCacheSearching(){
            matchedObject.Clear();
            return;
        }
        public List<object> findFileorDirectory(string path, string nameEntity){
            DirectoryInfo directoryInfo = new DirectoryInfo(path);
            DirectoryInfo[] subCatalogs = directoryInfo.GetDirectories();
            FileInfo[] subFiles = directoryInfo.GetFiles();
            for (int i = 0; i < subFiles.Length; i++)
            {
                bool matched = nameEntity.Equals(subFiles[i].Name, StringComparison.OrdinalIgnoreCase);
                if (matched){
                    matchedObject.Add(subFiles[i]);
                }
            }
            for (int i = 0; i < subCatalogs.Length; i++)
            {
                bool matched = nameEntity.Equals(subCatalogs[i].Name, StringComparison.OrdinalIgnoreCase);
                if (matched){
                    matchedObject.Add(subCatalogs[i]);
                }
                findFileorDirectory(subCatalogs[i].FullName, nameEntity);

            }
            return matchedObject;
            
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
            DirectoryInfo directoryInfo = new DirectoryInfo(catalogPath);
            if(directoryInfo.Exists){
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
                Console.WriteLine(e);

            }
        }
        public void MoveCatalog(string catalogTargetPath,  string catalogDestinationPath){
            Console.WriteLine(catalogDestinationPath);
            DirectoryInfo directoryInfo = new DirectoryInfo(catalogTargetPath);
            try{
                Console.Write("Are you sure to want moving all files in catalog,if it doesn't exist(yes/no):");
                string deleteAllFilesInCatalog = Console.ReadLine();
                if (deleteAllFilesInCatalog == "yes"){
                    if(directoryInfo.Exists && !Directory.Exists(catalogDestinationPath)){
                        directoryInfo.MoveTo(catalogDestinationPath);
                        Console.WriteLine($"Moveing catalogs successfully");
                    }
                    else{
                        Console.WriteLine("Destination exist or target path doesn't exist");
                    }
                }
                else{
                    Console.WriteLine("Cancel moving");
                }
            }
            catch (Exception e){
                Console.WriteLine(e);

            }
        }
    }
}