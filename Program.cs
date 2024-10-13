using Commands;
class FileManager{
    static int Main(String[] args){
        bool programWork = true;
        while (programWork){
            Command com = new Command(ref programWork);
        }
        return 0;
    }
}