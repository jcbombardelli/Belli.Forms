using Belli.Forms.FileExplorer.iOS.Service;
using Belli.Forms.FileExplorer.Service;
using System;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(FileStorage))]
namespace Belli.Forms.FileExplorer.iOS.Service
{
    public class FileStorage : IFileStorage
    {
        public string DocumentsPath => throw new NotImplementedException();

        public string ImagesPath => throw new NotImplementedException();

        public string PersonalPath => throw new NotImplementedException();

        public string GetLocalFilePath(string filename)
        {
            string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libFolder = Path.Combine(docFolder, "..", "Library", "Databases");

            if (!Directory.Exists(libFolder))
            {
                Directory.CreateDirectory(libFolder);
            }

            return Path.Combine(libFolder, filename);
        }

        public string ReadAsString(string filename)
        {
            throw new NotImplementedException();
        }

        public string SaveAsString(string filename, string content)
        {
            throw new NotImplementedException();
        }

        private FileStorage() { }
    }
}