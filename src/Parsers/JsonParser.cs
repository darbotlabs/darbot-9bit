using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;

namespace Parsers
{
    public class JsonParser
    {
        public static Dictionary<string, object> Parse(string filePath)
        {
            string jsonContent = File.ReadAllText(filePath);
            var data = JsonConvert.DeserializeObject<Dictionary<string, object>>(jsonContent);
            return data;
        }

        public static void Write(string filePath, Dictionary<string, object> data)
        {
            string jsonContent = JsonConvert.SerializeObject(data, Formatting.Indented);
            File.WriteAllText(filePath, jsonContent);
        }
    }
}
