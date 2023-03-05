static void Main(string[] args)
{
    // создание объекта текстового файла
    TextFile textFile = new TextFile
    {
        FileName = "file.txt",
        Content = "Hello, world!"
    };

    // бинарная сериализация
    textFile.SaveAsBinary("file.bin");
    TextFile loadedFile1 = TextFile.LoadFromBinary("file.bin");
    Console.WriteLine(loadedFile1.Content); // Hello, world!

    // XML сериализация
    textFile.SaveAsXml("file.xml");
    TextFile loadedFile2 = TextFile.LoadFromXml("file.xml");
    Console.WriteLine(loadedFile2.Content); // Hello, world!

    // поиск текстовых файлов по ключевым словам
    TextFileSearcher searcher = new TextFileSearcher();
    List<string> files = searcher.SearchFiles(".", new List<string> { "world" });
    foreach (string file in files)
    {
        Console.WriteLine(file); // вывод пути к файлу
    }

    // консольный редактор текстовых файлов
    TextEditor editor = new TextEditor(textFile);
    editor.Write(", C#");
    Console.WriteLine(textFile.Content); // Hello, world!, C#
    editor.Backspace();
    Console.WriteLine(textFile.Content); // Hello, world!
    editor.Undo();
    Console.WriteLine(textFile.Content); // Hello, world!

    // индексация текстовых файлов по ключевым словам
    TextFileIndexer indexer = new TextFileIndexer();
    Dictionary<string, List<string>> index = indexer.IndexFiles(".", new List<string> { "world", "C#" });
    foreach (KeyValuePair<string, List<string>> entry in index)
    {
        Console.WriteLine(entry.Key); // вывод ключевого слова
        foreach (string file in entry.Value)
        {
            Console.WriteLine(file); // вывод пути к файлу
        }
    }

    Console.ReadKey();
}
