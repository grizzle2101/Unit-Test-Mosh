using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace TestNinja.Mocking
{
    //Tutorial 5 - Dependency Injection via Constructor
    public class VideoService
    {
        private IFileReader _fileReader;

        //Task 2 - Seperate Default Constructor - Avoids Breaking Production Code.
        public VideoService()
        {
            _fileReader = new FileReader();
        }



        ////Task 1 - Changing the Constructor Signature - Breaks Existing Code.
        //public VideoService(IFileReader reader)
        //{
        //    _fileReader = reader;
        //}

        //Constructor Injection.
        //Task 3 - Constructor w Set value
        public VideoService(IFileReader reader = null)
        {
            _fileReader = reader ?? new FileReader();
        }

        public string ReadVideoTitle()
        {
            var str = _fileReader.Read("video.txt");

            var video = JsonConvert.DeserializeObject<Video>(str);
            if (video == null)
                return "Error parsing the video.";
            return video.Title;
        }

        public string GetUnprocessedVideosAsCsv()
        {
            var videoIds = new List<int>();
            
            using (var context = new VideoContext())
            {
                var videos = 
                    (from video in context.Videos
                    where !video.IsProcessed
                    select video).ToList();
                
                foreach (var v in videos)
                    videoIds.Add(v.Id);

                return String.Join(",", videoIds);
            }
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