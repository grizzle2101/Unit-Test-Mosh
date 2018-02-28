using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace TestNinja.Mocking
{
    //Section 5 - Tutorial 3 - Refactoring towards a Loosely Coupled design.
    public class VideoService
    {
        //Method 1
        //Read the Content of a Video.txt
        //Deserialize Video as JSON Object
        //Check if Parsing complete successfully & we have our Video object.
        public string ReadVideoTitle(IFileReader reader)
        {
            //Task 1 - Extract Calls to External Resources
            //var str = File.ReadAllText("video.txt");


            //Task 2 - Extract Interface
            //var str = new FileReader().Read("video.txt");

            //Task 3 - Use Mock Object
            //There are 3 ways to pass in this Object.
            //1 - As a Parameter in ReadVideoTitle
            //2 - As a Property
            //3 - Through a Constructor Parameter
            //Finally we refactored that sigle line of code : )
            var str = reader.Read("video.txt");

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