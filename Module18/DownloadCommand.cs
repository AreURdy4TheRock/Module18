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
        public override void Run()
        {
            _ = DownloadVideo();
        }
        public async Task DownloadVideo()
        {
            try
            {
                var youtube = new YoutubeClient();
                var video = await youtube.Videos.GetAsync(Url);
                var streamManifest = await youtube.Videos.Streams.GetManifestAsync(video.Id);
                var streamInfo = streamManifest.GetMuxedStreams().GetWithHighestVideoQuality();
                Console.WriteLine("\nЗагрузка видео!");
                if (streamInfo != null)
                {
                    await youtube.Videos.Streams.DownloadAsync(streamInfo, OutputFilePath);
                }
                Console.WriteLine("\nЗагрузка видео завершена!");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public DownloadCommand(string url, string outputFilePath)
        {
            Url = url;
            OutputFilePath = outputFilePath;
        }
    }
}
