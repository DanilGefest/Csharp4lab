using Lab_4;
using System;
using System.Collections.Generic;

namespace Lab_4
{
    public class TextEditor
    {
        private TextFile textFile;
        private List<TextFileMemento> mementos = new List<TextFileMemento>();

        public TextEditor(TextFile textFile)
        {
            this.textFile = textFile;
            mementos.Add(new TextFileMemento(textFile.Content));
        }

        public void Write(string text)
        {
            mementos.Add(new TextFileMemento(textFile.Content));
            textFile.Content += text;
        }

        public void Backspace()
        {
            if (textFile.Content.Length > 0)
            {
                mementos.Add(new TextFileMemento(textFile.Content));
                textFile.Content = textFile.Content.Substring(0, textFile.Content.Length - 1);
            }
        }

        public void Undo()
        {
            if (mementos.Count > 1)
            {
                mementos.RemoveAt(mementos.Count - 1);
                textFile.Content = mementos[mementos.Count - 1].Content;
            }
        }

        public void Save()
        {
            textFile.SaveAsXml(textFile.FileName);
        }
    }

    public class TextFile
    {
        public string FileName { get; private set; }
        public string Content { get; set; }

        public TextFile(string fileName)
        {
            FileName = fileName;
            Content = System.IO.File.ReadAllText(fileName);
        }

        public void SaveAsXml(string fileName)
        {
            System.Xml.Serialization.XmlSerializer writer =
                new System.Xml.Serialization.XmlSerializer(typeof(TextFile));

            using (System.IO.StreamWriter file = new System.IO.StreamWriter(fileName))
            {
                writer.Serialize(file, this);
            }
        }
    }

    public class TextFileMemento
    {
        public string Content { get; private set; }

        public TextFileMemento(string content)
        {
            Content = content;
        }
    }
}
   /* public class TextEditor
    {
        private TextFile textFile;
        private List<TextFileMemento> mementos = new List<TextFileMemento>();

        public TextEditor(TextFile textFile)
        {
            this.textFile = textFile;
            mementos.Add(new TextFileMemento(textFile.Content));
        }

        public void Write(string text)
        {
            mementos.Add(new TextFileMemento(textFile.Content));
            textFile.Content += text;
        }

        public void Backspace()
        {
            if (textFile.Content.Length > 0)
            {
                mementos.Add(new TextFileMemento(textFile.Content));
                textFile.Content = textFile.Content.Substring(0, textFile.Content.Length - 1);
            }
        }

        public void Undo()
        {
            if (mementos.Count > 1)
            {
                mementos.RemoveAt(mementos.Count - 1);
                textFile.Content = mementos[mementos.Count - 1].Content;
            }
        }

        public void Save()
        {
            textFile.SaveAsXml(textFile.FileName);
        }
    }

    public class TextFileMemento
    {
        public string Content { get; private set; }

        public TextFileMemento(string content)
        {
            Content = content;
        }
    }                                                                        */
}