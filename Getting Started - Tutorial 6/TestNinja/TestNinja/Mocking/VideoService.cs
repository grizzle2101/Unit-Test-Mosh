using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace TestNinja.Mocking
{

    public class VideoService
    {
        private IFileReader _fileReader;
        private IVideoRepository _videoRepository;

        //Poor Mans Dependency Injection
        public VideoService(IFileReader reader = null, IVideoRepository repository = null)
        {
            _fileReader = reader ?? new FileReader();
            _videoRepository = repository ?? new VideoRepository();
        }

        public string ReadVideoTitle()
        {
            var str = _fileReader.Read("video.txt");

            var video = JsonConvert.DeserializeObject<Video>(str);
            if (video == null)
                return "Error parsing the video.";
            return video.Title;
        }

        //Tutorial 6 - Excercises - Tutorial 2 - Refactor for Testability.
        //Task 1 - Extract Calls to External Resources
        //Task 2 - Program to Interface
        //Task 3 - Refactor for Dependency Injection
        public string GetUnprocessedVideosAsCsv()
        {
            var videoIds = new List<int>();
            var videos = _videoRepository.GetVideos();

            foreach (var v in videos)
                videoIds.Add(v.Id);

            //return"1"; Sanity Check
            return String.Join(",", videoIds);
        }
    }


    public class Video
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsProcessed { get; set; }
    }

    public class VideoContext : DbContext
    {
        public DbSet<Video> Videos { get; set; }
    }
}