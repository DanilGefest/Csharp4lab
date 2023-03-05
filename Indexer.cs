using System;
using System.Collections.Generic;
using System.IO;

public class TextFileIndexer
{
    public Dictionary<string, List<string>> IndexFiles(string directoryPath, List<string> keywords)
    {
        Dictionary<string, List<string>> result = new Dictionary<string, List<string>>();
        foreach (string filePath in Directory.GetFiles(directoryPath, "*.txt"))
        {
            string fileContent = File.ReadAllText(filePath);
            foreach (string keyword in keywords)
            {
                if (fileContent.Contains(keyword))
                {
                    if (!result.ContainsKey(keyword))
                    {
                        result[keyword] = new List<string>();
                    }
                    result[keyword].Add(filePath);
                    break;
                }
            }
        }
        return result;
    }
}
