using Belli.Forms.FileExplorer.Droid.Service;
using Belli.Forms.FileExplorer.Service;
using System;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(FileStorage))]
namespace Belli.Forms.FileExplorer.Droid.Service
{

    public class FileStorage : IFileStorage
    {
        public string DocumentsPath => throw new NotImplementedException();

        public string ImagesPath => throw new NotImplementedException();

        public string PersonalPath => throw new NotImplementedException();

        public string GetLocalFilePath(string filename)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            return Path.Combine(path, filename);
        }

        public string ReadAsString(string filename)
        {
            throw new NotImplementedException();
        }

        public string SaveAsString(string filename, string content)
        {
            throw new NotImplementedException();
        }
    }
}