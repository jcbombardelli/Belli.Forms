using Belli.Forms.FileExplorer.Service;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace Belli.Forms.MVVM.Service
{
    public interface IPreferenceService<E>
    {
        object GetPreferences();
        object SetPreferences(E preferences);

    }

    public class PreferenceService<E> : IPreferenceService<E>
    {

        private const string FILE_NAME = "preferences.json";

        public object GetPreferences()
        {
            var fileLoadedInString = DependencyService.Get<IFileStorage>().ReadAsString(FILE_NAME);
            return JsonConvert.DeserializeObject<E>(fileLoadedInString);
        }

        public object SetPreferences(E preferences)
        {
            DependencyService.Get<IFileStorage>().SaveAsString(FILE_NAME, JsonConvert.SerializeObject(preferences));
            return GetPreferences();

        }


        public override bool Equals(object obj) => base.Equals(obj);

        public override int GetHashCode() => base.GetHashCode();

        public override string ToString() => base.ToString();
    }
}
