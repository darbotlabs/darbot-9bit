using System;
using System.Collections.Generic;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;
using System.IO;

namespace Parsers
{
    public class YamlParser
    {
        public static Dictionary<string, object> Parse(string filePath)
        {
            var deserializer = new DeserializerBuilder()
                .WithNamingConvention(CamelCaseNamingConvention.Instance)
                .Build();

            using (var reader = new StreamReader(filePath))
            {
                var yamlObject = deserializer.Deserialize<Dictionary<string, object>>(reader);
                return yamlObject;
            }
        }

        public static void Write(string filePath, Dictionary<string, object> data)
        {
            var serializer = new SerializerBuilder()
                .WithNamingConvention(CamelCaseNamingConvention.Instance)
                .Build();

            using (var writer = new StreamWriter(filePath))
            {
                serializer.Serialize(writer, data);
            }
        }
    }
}
