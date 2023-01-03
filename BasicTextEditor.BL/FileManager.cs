using System.IO;
using System.Text;

namespace BasicTextEditor.BL
{
    public interface IFileManager
    {
        bool IsExist(string filePath);
        string GetContent(string filePath);
        string GetContent(string filePath, Encoding encodind);
        void SaveContent(string content, string filePath);
        void SaveContent(string content, string filePath, Encoding encoding);
        int GetSymbolCount(string content);
        
    }
    public class FileManager: IFileManager
    {
        private readonly Encoding _defaultEncoding = Encoding.GetEncoding(1251);

        public bool IsExist(string filePath)
        {
            bool isExist = File.Exists(filePath);
            return isExist;
        }

        //Open text file
        //default
        public string GetContent(string filePath)
        {
            return GetContent(filePath, _defaultEncoding);
        }
        //Open text file
        //with specific encoding
        public string GetContent(string filePath, Encoding encoding)
        {
            string content = File.ReadAllText(filePath, encoding);
            return content;
        }

        //Save text file
        //default
        public void SaveContent(string content, string filePath)
        {
            SaveContent(content, filePath, _defaultEncoding);
        }
        //Save text file
        //with spicific encoding
        public void SaveContent(string content, string filePath, Encoding encoding)
        {
            File.WriteAllText(filePath, content, encoding);
        }

        public int GetSymbolCount(string content)
        {
            int count = content.Length;
            return count;
        }
    }
}
