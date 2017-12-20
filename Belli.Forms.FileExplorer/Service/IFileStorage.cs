namespace Belli.Forms.FileExplorer.Service
{
    public interface IFileStorage
    {
        string GetLocalFilePath(string filename);
        string ReadAsString(string filename);
        string SaveAsString(string filename, string content);

        string DocumentsPath { get; }
        string ImagesPath { get; }
        string PersonalPath { get; }
    }
}
