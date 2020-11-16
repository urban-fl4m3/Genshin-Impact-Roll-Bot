using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using GenshinImpactRollBot.Exceptions;
using Newtonsoft.Json;

namespace GenshinImpactRollBot.Client
{
    public static class JsonReader
    {
        public static async Task<T> PathToGenericObject<T>(string path, bool emitUTF8,
            bool continueOnCapturedContext)
        {
            string json;
            
            await using (var fs = File.OpenRead(path))
            {
                using (var sr = new StreamReader(fs, new UTF8Encoding(emitUTF8)))
                {
                    json = await sr.ReadToEndAsync().ConfigureAwait(continueOnCapturedContext);
                }
            }

            if (string.IsNullOrEmpty(json))
            {
                throw new JsonObjectNotFoundException();
            }

            var result = JsonConvert.DeserializeObject<T>(json);
            return result;
        } 
    }
}