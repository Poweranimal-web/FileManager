using Commands;
using System.Text;
using FileIO;
class FileManager{
    static int Main(String[] args){
        bool programWork = true;
        Console.InputEncoding = System.Text.Encoding.Unicode;
        Command com = new Command();
        while (programWork){
            com.RunCommand(ref programWork);
        }
        return 0;
    }
}