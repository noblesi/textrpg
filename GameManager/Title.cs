namespace MiniProject.GameManager
{
    

    public class Title
    {
        const int width = 80;
        const string title = @"
_|_|_|_|_|  _|_|_|_|  _|      _|  _|_|_|_|_|      _|_|_|    _|_|_|      _|_|_|  
    _|      _|          _|  _|        _|          _|    _|  _|    _|  _|        
    _|      _|_|_|        _|          _|          _|_|_|    _|_|_|    _|  _|_|  
    _|      _|          _|  _|        _|          _|    _|  _|        _|    _|  
    _|      _|_|_|_|  _|      _|      _|          _|    _|  _|          _|_|_|  
";

        public static void TitleAlignment()
        {
            string[] lines = title.Split('\n');
            //int width = Console.WindowWidth;
            foreach (string line in lines)
            {
                int padding = (width - line.Trim().Length) / 2;
                Console.WriteLine(line.PadLeft(padding + line.Trim().Length));
            }
        }

        

        public static void InitSetting()
        {
            Console.SetWindowSize(80, 50);
            Console.SetBufferSize(80, 50);
        }
    }
}
