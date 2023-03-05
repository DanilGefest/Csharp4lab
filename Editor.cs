using System;
using System.Collections.Generic;

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

public class TextFileMemento
{
    public string Content { get; private set; }

    public TextFileMemento(string content)
    {
        Content = content;
    }
}
