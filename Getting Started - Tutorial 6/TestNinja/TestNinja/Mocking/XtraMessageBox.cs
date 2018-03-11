namespace TestNinja.Mocking
{
    //Refactor Four
    //Task 2 - Program to Interface
    public interface IXtraMessageBox
    {
        void Show(string s, string housekeeperStatements, MessageBoxButtons ok);
    }

    //Task 1 - Extract Call to External Resources
    public class XtraMessageBox : IXtraMessageBox
    {
        public void Show(string s, string housekeeperStatements, MessageBoxButtons ok)
        {
        }
    }
}