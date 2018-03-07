using System.Net;

namespace TestNinja.Mocking
{

    //Section 6 Excercise 2 - Insaller Helper
    //Task 1 - Extract External Resource Calls
    //Task 2 - Program to Interface
    //Task 3 - Refactor Class
    public class InstallerHelper
    {
        private string _setupDestinationFile = "C/Test";
        private readonly IFileDownloader _fileDownloader;

        //Poor Mans Dependency Injection
        public InstallerHelper(IFileDownloader fileDownloader = null)
        {
            _fileDownloader = fileDownloader ?? new FileDownloader();
        }


        //Task 3 - Refactor Method
        public bool DownloadInstaller(string customerName, string installerName)
        {
            ////My Design
            //return _fileDownloader.GetFile(customer);

            //Mosh Design - Extract only the Downloading part
            try
            {
                _fileDownloader.DownloadFile(
                    string.Format("http://example.com/{0}/{1}",
                        customerName,
                        installerName),
                    _setupDestinationFile);

                return true;
            }
            catch (WebException)
            {
                return false;
            }
        }
    }

    public class ClientCustomer
    {
        public string Name { get; set;}
        public string Installer { get; set; }
        public string Location { get; set; }
    }
}