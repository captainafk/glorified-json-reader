using System;
using System.IO;
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
            var path = Application.persistentDataPath + "/input.json";

#if UNITY_EDITOR
            path = "Assets/ExampleJSON/input.json";
#endif

            if (!File.Exists(path))
            {
                // TODO: Handle this with a pop-up, then quit the application.
                Debug.LogError("The file does not exist.");
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
                // TODO: Handle this with a pop-up, then quit the application.
                Debug.LogError("The reading process failed: " + e);
                throw;
            }

            return contents;
        }
    }
}
