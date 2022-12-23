namespace CriptText.Services
{
	public interface IFileService
	{
		void AddNewlineToFile(string fileName, string text);
		string CreateFile(string fileName, string text);
		string GetFileContent(string fileName);
	}
}