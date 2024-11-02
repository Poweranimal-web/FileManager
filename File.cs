using System.IO;
namespace FileIO{
    class FileControl{
        public void CreateFile(string filenName){
            try{
                File.Create(filenName).Close();
                Console.WriteLine($"{filenName} created successfully");
            }
            catch(Exception e){
                Console.WriteLine(e);
            
            }
        }
        // public void DeleteFile(string filenName){
        //     try{
        //         File.Create(filenName).Close();
        //         Console.WriteLine($"{filenName} created successfully");
        //     }
        //     catch(Exception e){
        //         Console.WriteLine(e);
            
        //     }
        // }
    }
}