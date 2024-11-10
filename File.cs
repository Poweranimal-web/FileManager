using System.IO;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Runtime.CompilerServices;
using System.Net.Cache;
namespace FileIO{
    class FileControl
{
        String sb;
        StreamReader stream;
        public FileControl(Stream str){
            stream = new StreamReader(str);
        }
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
        public void WriteFileDataToBufferInput(string path){
            FileStream file = new FileStream(path,FileMode.OpenOrCreate);
            // int height_file = CountLengthColumnFile(file);
            try{
                byte[] buffer = new byte[file.Length];
                int length = file.Read(buffer);
                if (length == file.Length){
                    string data = Encoding.Default.GetString(buffer);
                    sb = new String(data);
                }

            }
            catch(Exception e){
                Console.WriteLine(e);
            }
            finally{
                file.Close();
            }

        }
        public string? ReadLine(string path) // Not stable with large size of file!!!
        {
            FileStream file = new FileStream(path,FileMode.Truncate);
            int pos = Console.CursorLeft;
            int pos_vertical = Console.CursorTop;
            Console.Write(sb);
            ConsoleKeyInfo info;
            List<char> chars = new List<char> ();
            if (string.IsNullOrEmpty(sb) == false) {
                chars.AddRange(sb.ToCharArray());
            }
            while (true)
            {
                info = Console.ReadKey(true);
                if (info.Key == ConsoleKey.Backspace && Console.CursorLeft > pos)
                {
                    chars.RemoveAt(chars.Count - 1);
                    Console.CursorLeft -= 1;
                    Console.Write(' ');
                    Console.CursorLeft -= 1;

                }
                if (info.Key == ConsoleKey.LeftArrow && Console.CursorLeft > pos)
                {
                    Console.CursorLeft -= 1;
                }
                if (info.Key == ConsoleKey.RightArrow && Console.CursorLeft > pos)
                {
                    Console.CursorLeft += 1;
                }
                else if (info.Key == ConsoleKey.UpArrow)
                {
                    Console.CursorTop -= 1;
                }
                else if (info.Key == ConsoleKey.DownArrow)
                {
                    Console.CursorTop += 1;
                }
                else if (info.Modifiers.HasFlag(ConsoleModifiers.Control) && info.Key == ConsoleKey.S){
                    byte[] data = Encoding.Default.GetBytes(chars.ToArray());
                    file.Write(data);
                    Console.WriteLine("\nSaved");
                    file.Close();
                    break;
                }
                else if (info.Key == ConsoleKey.Enter) { Console.Write(Environment.NewLine);  break; }
                else if (char.IsLetterOrDigit(info.KeyChar))
                {
                    Console.Write(info.KeyChar);
                    chars.Add(info.KeyChar);
                }
            }
            return new string(chars.ToArray ());
        }
    }
}