using System;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;

namespace GJR
{
    /// <summary>
    /// A static class for reading files
    /// </summary>
    public static class FileReader
    {
        /// <summary>
        /// Reads from a json named "input.json" from the same directory
        /// as the executable
        /// </summary>
        /// <returns></returns>
        public static string ReadFile()
        {
            var path = Directory.GetParent(
                           Directory.GetParent(Application.dataPath)?.ToString() ?? string.Empty)
                       + "/input.json";

#if UNITY_EDITOR
            path = "Assets/ExampleJSON/input.json";
#endif

            if (!File.Exists(path))
            {
                var errorMessage = "The input.json file does not exist on the following path: " + path;
                MessageBus.Publish(new OnErrorOccured(errorMessage));
                return null;
            }
            
            var contents = "";
            try
            {
                var reader = new StreamReader(path);
                contents = reader.ReadToEnd();
                reader.Close();
            }
            catch (Exception e)
            {
                var errorMessage = "The reading process failed: " + e;
                MessageBus.Publish(new OnErrorOccured(errorMessage));
                throw;
            }

            return contents;
        }

        /// <summary>
        /// Converts a string to a class of type T
        /// </summary>
        /// <param name="text"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T ParseJSON<T>(string text)
        {
            try
            {
                var parsedObject = JsonConvert.DeserializeObject<T>(text);
                return parsedObject;
            }
            catch (Exception e)
            {
                // TODO: Handle this with a pop-up, then quit the application.
                Debug.LogError("The process of parsing the JSON has failed: " + e);
                throw;
            }
        }
    }
}
