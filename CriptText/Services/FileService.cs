using System;
using System.IO;

namespace CriptText.Services
{
    public class FileService : IFileService
    {
        public string CreateFile(string fileName, string text)
        {
            var path = GetFilePath(fileName);

            using (StreamWriter sw = File.CreateText(path))
            {
                sw.Write(text);
            }

            return path;
        }

        public string GetUserFileContent(string fileName)
        {
            var path = GetFilePath(fileName);

			return GetFileContent(path);
        }

		public string GetFileContent(string filePath)
		{
			var text = string.Empty;

			if (File.Exists(filePath))
			{
				text = File.ReadAllText(filePath);
			}

			return text;
		}

		public void AddNewlineToFile(string fileName, string text)
        {
            var filePath = GetFilePath(fileName);

            using FileStream fs = new(filePath, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter write = new(fs);
            write.BaseStream.Seek(0, SeekOrigin.End);
            write.WriteLine(text);
            write.Flush();
            write.Close();
            fs.Close();
        }

        private string GetFilePath(string fileName)
        {
            var userFolder = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);

            var path = @$"{userFolder}\{fileName}.txt";

            return path;
        }
    }
}


