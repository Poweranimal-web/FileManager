using System.IO;
using System.Runtime.Intrinsics.X86;
namespace FileIO{
    class FileControl{
        public void CreateFile(string fileName, ref string currentPath){
            try{
                File.Create(currentPath+"\\"+fileName).Close();
                Console.WriteLine($"{fileName} created successfully");
            }
            catch(Exception e){
                Console.WriteLine(e);
            
            }
        }
        public void DeleteFile(string fileName, ref string currentPath){
            try{
                File.Delete(currentPath+"\\"+fileName);
                Console.WriteLine($"{fileName} delete successfully");
            }
            catch(Exception e){
                Console.WriteLine(e);
            
            }
        }
        public void CopyFileTo(string fileName, string pathCopy,ref string currentPath){
            FileInfo file = new FileInfo(currentPath+"\\"+fileName);
            try{
                Console.WriteLine(file.FullName);
                file.CopyTo(pathCopy+"\\"+$"{fileName}");
                Console.WriteLine($"{fileName} copying to {pathCopy} successfully");
            }
            catch(Exception e){
                Console.WriteLine(e);
            
            }
        }
        public void MoveFileTo(string fileName, string pathCopy, ref string currentPath){
            FileInfo file = new FileInfo(currentPath+"\\"+fileName);
            try{
                Console.Write("Do you want overwrite file, if it exists?(yes/no): ");
                string answer = Console.ReadLine();
                if (answer.Equals("yes")){
                    Console.WriteLine(pathCopy+$"{fileName}");
                    file.MoveTo(pathCopy+"\\"+$"{fileName}", true);
                    Console.WriteLine($"{fileName} moving to {pathCopy} successfully");
                }
                else{
                    file.MoveTo(pathCopy+"\\"+$"{fileName}", false);
                    Console.WriteLine($"{fileName} moving to {pathCopy} successfully");
                }
            }
            catch(Exception e){
                Console.WriteLine(e);
            
            }
        }
    }
}