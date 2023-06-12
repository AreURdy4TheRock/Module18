using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeExplode;

namespace Module18
{
    class GetInfoCommand : Command
    {
        public string Url;

        public override void Run()
        {
            var youtube = new YoutubeClient();
            var video = youtube.Videos.GetAsync(Url).Result;
            Console.WriteLine($"Название видео: {video.Title}");
            Console.WriteLine($"Описание: {video.Description}");

        }
        public GetInfoCommand(string url)
        {
            Url = url;
        }
    }
}
