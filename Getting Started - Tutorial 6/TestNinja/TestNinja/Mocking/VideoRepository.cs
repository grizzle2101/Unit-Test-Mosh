using System.Collections.Generic;
using System.Linq;

namespace TestNinja.Mocking
{
    //Task 1 - Extract Calls to External Resources
    //When Extracting Queries, it is best practive to extra to a Reporitory Pattern.
    public class VideoRepository : IVideoRepository
    {
        public IEnumerable<Video> GetVideos()
        {
            using (var context = new VideoContext())
            {
                var videos =
                    (from video in context.Videos
                        where !video.IsProcessed
                        select video).ToList();
                return videos;
            }   
        }
    }

    //Task 2 - Program to Interface
    public interface IVideoRepository
    {
        IEnumerable<Video> GetVideos();
    }
}