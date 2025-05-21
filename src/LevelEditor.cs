using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using Newtonsoft.Json;
using YamlDotNet.Serialization;

namespace LevelEditor
{
    public class LevelEditor
    {
        private List<LevelObject> levelObjects;
        private Dictionary<string, LevelObject> levelObjectCache;
        private Dictionary<string, object> levelDataCache;

        public LevelEditor()
        {
            levelObjects = new List<LevelObject>();
            levelObjectCache = new Dictionary<string, LevelObject>();
            levelDataCache = new Dictionary<string, object>();
        }

        public void AddLevelObject(LevelObject levelObject)
        {
            levelObjects.Add(levelObject);
        }

        public void RemoveLevelObject(LevelObject levelObject)
        {
            levelObjects.Remove(levelObject);
        }

        public void SaveLevel(string filePath)
        {
            string extension = Path.GetExtension(filePath).ToLower();
            switch (extension)
            {
                case ".xml":
                    SaveLevelToXml(filePath);
                    break;
                case ".yaml":
                case ".yml":
                    SaveLevelToYaml(filePath);
                    break;
                case ".json":
                    SaveLevelToJson(filePath);
                    break;
                default:
                    throw new NotSupportedException($"File format {extension} is not supported.");
            }
        }

        public void LoadLevel(string filePath)
        {
            string extension = Path.GetExtension(filePath).ToLower();
            switch (extension)
            {
                case ".xml":
                    LoadLevelFromXml(filePath);
                    break;
                case ".yaml":
                case ".yml":
                    LoadLevelFromYaml(filePath);
                    break;
                case ".json":
                    LoadLevelFromJson(filePath);
                    break;
                default:
                    throw new NotSupportedException($"File format {extension} is not supported.");
            }
        }

        private void SaveLevelToXml(string filePath)
        {
            XmlDocument xmlDoc = new XmlDocument();
            XmlElement root = xmlDoc.CreateElement("Level");
            xmlDoc.AppendChild(root);

            foreach (var levelObject in levelObjects)
            {
                XmlElement objectElement = xmlDoc.CreateElement("LevelObject");
                // Serialize level object properties to XML
                root.AppendChild(objectElement);
            }

            xmlDoc.Save(filePath);
            Console.WriteLine($"Level saved to {filePath}");
        }

        private void SaveLevelToYaml(string filePath)
        {
            var serializer = new Serializer();
            using (var writer = new StreamWriter(filePath))
            {
                serializer.Serialize(writer, levelObjects);
            }
            Console.WriteLine($"Level saved to {filePath}");
        }

        private void SaveLevelToJson(string filePath)
        {
            string jsonContent = JsonConvert.SerializeObject(levelObjects, Formatting.Indented);
            File.WriteAllText(filePath, jsonContent);
            Console.WriteLine($"Level saved to {filePath}");
        }

        private void LoadLevelFromXml(string filePath)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(filePath);
            XmlNodeList objectNodes = xmlDoc.SelectNodes("//LevelObject");

            levelObjects.Clear();
            foreach (XmlNode objectNode in objectNodes)
            {
                // Deserialize level object properties from XML
                LevelObject levelObject = new CustomLevelObject();
                levelObjects.Add(levelObject);
            }

            Console.WriteLine($"Level loaded from {filePath}");
        }

        private void LoadLevelFromYaml(string filePath)
        {
            var deserializer = new Deserializer();
            using (var reader = new StreamReader(filePath))
            {
                var yamlObjects = deserializer.Deserialize<List<LevelObject>>(reader);
                levelObjects = yamlObjects;
            }
            Console.WriteLine($"Level loaded from {filePath}");
        }

        private void LoadLevelFromJson(string filePath)
        {
            string jsonContent = File.ReadAllText(filePath);
            var jsonObjects = JsonConvert.DeserializeObject<List<LevelObject>>(jsonContent);
            levelObjects = jsonObjects;
            Console.WriteLine($"Level loaded from {filePath}");
        }

        public void Render()
        {
            // Render the level objects
            Console.WriteLine("Rendering level objects...");
        }

        private LevelObject GetLevelObjectFromCache(string key)
        {
            if (levelObjectCache.TryGetValue(key, out var levelObject))
            {
                return levelObject;
            }
            return null;
        }

        private void AddLevelObjectToCache(string key, LevelObject levelObject)
        {
            if (!levelObjectCache.ContainsKey(key))
            {
                levelObjectCache[key] = levelObject;
            }
        }

        private object GetLevelDataFromCache(string key)
        {
            if (levelDataCache.TryGetValue(key, out var levelData))
            {
                return levelData;
            }
            return null;
        }

        private void AddLevelDataToCache(string key, object levelData)
        {
            if (!levelDataCache.ContainsKey(key))
            {
                levelDataCache[key] = levelData;
            }
        }
    }

    public abstract class LevelObject
    {
        public abstract void Render();
    }

    public class CustomLevelObject : LevelObject
    {
        public override void Render()
        {
            // Custom rendering logic for the level object
        }
    }
}
