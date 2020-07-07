using System.ComponentModel;
using System.IO;
using Newtonsoft.Json;
using Сalory.Models;
using Container = Сalory.Models.Container;

namespace Сalory.Services
{
    public class FIOService
    {

        private readonly string path;

        public FIOService(string p)
        {
            path = p;
        }
        
        public Container LoadData()
        {
            var fileEx = File.Exists(path);
            if (!fileEx)
            {
                File.CreateText(path).Dispose();
                return new Container();
            }

            using (var reader = File.OpenText(path))
            {
                var text = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<Container>(text);
            }
        }

        public void SaveData(object item)
        {
            using (var writer = File.CreateText(path))
            {
                var output = JsonConvert.SerializeObject(item);
                writer.Write(output);
            }
        }
    }
}