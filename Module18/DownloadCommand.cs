using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeExplode;
using YoutubeExplode.Converter;
using YoutubeExplode.Videos.Streams;

namespace Module18
{
    class DownloadCommand : Command
    {
        public string Url;
        public string OutputFilePath;
        public async override void Run()
        {
            var youtube = new YoutubeClient();
            var video = youtube.Videos.GetAsync(Url).Result;
            var streamManifest = youtube.Videos.Streams.GetManifestAsync(video.Id).Result;
            var streamInfo = streamManifest.GetMuxedStreams().GetWithHighestVideoQuality();
            Console.WriteLine("\nЗагрузка видео!");
            await youtube.Videos.Streams.DownloadAsync(streamInfo, OutputFilePath);
            
        }
        public override void Cancel()
        {

        }
        public DownloadCommand(string url, string outputFilePath)
        {
            Url = url;
            OutputFilePath = outputFilePath;
        }
    }
}
