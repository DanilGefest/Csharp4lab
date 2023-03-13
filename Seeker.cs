using System.Collections.Generic;
using System.IO;

namespace Lab_4
{
    public class TextFileSearcher
    {
        public List<string> SearchFiles(string directoryPath, List<string> keywords)
        {
            List<string> result = new List<string>();
            foreach (string filePath in Directory.GetFiles(directoryPath, "*.txt"))
            {
                string fileContent = File.ReadAllText(filePath);
                foreach (string keyword in keywords)
                {
                    if (fileContent.Contains(keyword))
                    {
                        result.Add(filePath);
                        break;
                    }
                }
            }
            return result;
        }
    }
}