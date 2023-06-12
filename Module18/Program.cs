using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module18
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            //Ссылка на видео
            var url = "https://www.youtube.com/watch?v=DUrLB-8EBFs";
            var outPath = "video.mp4";
            // создадим отправителя 
            var sender = new Sender();
            // создадим получателя 
            var receiver = new Receiver();
            // создадим команду получения описания
            var getInfo = new GetInfoCommand(url);
            //создадим команду скачивания видео
            var downloadVideo = new DownloadCommand(url, outPath);

            // инициализация команды
            sender.SetCommand(getInfo);
            sender.Run();
            sender.SetCommand(downloadVideo);
            sender.Run();

            //  выполнение



            Console.ReadKey();
        }
    }
}
