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
				sw.WriteLine(text);
			}

			return path;
		}

		public string GetFileContent(string fileName)
		{
			var path = GetFilePath(fileName);

			var lines = File.ReadAllLines(path);

			var text = lines.Length > 0 ? lines[0] : string.Empty;

			return text;
		}

		public void AddNewlineToFile(string fileName, string text)
		{
			var filePath = GetFilePath(fileName);

			using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Write))
			{
				StreamWriter write = new StreamWriter(fs);
				write.BaseStream.Seek(0, SeekOrigin.End);
				write.WriteLine(text);
				write.Flush();
				write.Close();
				fs.Close();
			}
		}

		private string GetFilePath(string fileName)
		{
			var userFolder = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);

			var path = @$"{userFolder}\{fileName}.txt";

			return path;
		}
	}
}


