using Belli.Forms.SQLite.Droid.Util;
using Belli.Forms.SQLite.Util;
using System;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(FileHelper))]
namespace Belli.Forms.SQLite.Droid.Util
{

    public class FileHelper : IFileHelper
    {
        public string GetLocalFilePath(string filename)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            return Path.Combine(path, filename);
        }


        private FileHelper() { }
    }

}