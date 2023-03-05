using System;
using System.IO;
using System.Xml.Serialization;

[Serializable]
public class TextFile
{
    public string FileName { get; set; }
    public string Content { get; set; }

    public void SaveAsBinary(string fileName)
    {
        using (FileStream stream = new FileStream(fileName, FileMode.Create))
        {
            var serializer = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            serializer.Serialize(stream, this);
        }
    }

    public static TextFile LoadFromBinary(string fileName)
    {
        using (FileStream stream = new FileStream(fileName, FileMode.Open))
        {
            var serializer = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            return (TextFile)serializer.Deserialize(stream);
        }
    }

    public void SaveAsXml(string fileName)
    {
        using (FileStream stream = new FileStream(fileName, FileMode.Create))
        {
            var serializer = new XmlSerializer(typeof(TextFile));
            serializer.Serialize(stream, this);
        }
    }

    public static TextFile LoadFromXml(string fileName)
    {
        using (FileStream stream = new FileStream(fileName, FileMode.Open))
        {
            var serializer = new XmlSerializer(typeof(TextFile));
            return (TextFile)serializer.Deserialize(stream);
        }
    }
}
