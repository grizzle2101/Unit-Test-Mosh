using System.Net;

namespace TestNinja.Mocking
{
    //Mosh Design
    public class FileDownloader : IFileDownloader
    {
        WebClient client = new WebClient();

        public void DownloadFile(string url, string path)
        {
            var client = new WebClient();
            client.DownloadFile(url, path);
        }
    }

    ///Task 1 - Extrace Call to External Resources
    ////My Design
    //public class FileDownnloaderrr : IFileDownloader
    //{
    //    WebClient client = new WebClient();

    //    public bool GetFile(ClientCustomer customer)
    //    {
    //        try
    //        {
    //            client.DownloadFile(
    //                string.Format("http://example.com/{0}/{1}",
    //                    customer.Name,
    //                    customer.Installer),
    //                customer.Location);

    //            return true;
    //        }
    //        catch (WebException)
    //        {
    //            return false;
    //        }
    //    }
    //}

   
    //Some 3rd party librarys have their own interfaces, so we can sometimes use that.
    public interface IFileDownloader
    {
        void DownloadFile(string url, string path);
    }
    ////Task 2 - Program to Interface
    ////My Design
    //public interface IFileDownloader
    //{
    //    bool GetFile(ClientCustomer customer);
    //}
}