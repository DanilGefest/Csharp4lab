using System.Collections.Generic;
using System.IO;
using System;
using Lab_4;
using static System.Net.Mime.MediaTypeNames;

namespace Lab_4
{
    class Program
    {
        public static void Main(string[] args)
        {
            // создание объекта текстового файла
            TextFile textFile = new TextFile
            {
                FileName = "file.txt",
                Content = "Hello, world!"
            };

            Console.WriteLine("What do you wish to do? ");
            Console.WriteLine("1. BIN Serialize\n2. XML Serialize \n3. Text file finder\n4. Concole text editor\n5. Keyword indexing ");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    // бинарная сериализация    '
                    // Сериализация представляет процесс преобразования какого-либо объекта в поток байтов.
                    // После преобразования мы можем этот поток байтов или записать на диск или сохранить его
                    // временно в памяти. А при необходимости можно выполнить обратный процесс - десериализацию,
                    // то есть получить из потока байтов ранее сохраненный объект.
                    textFile.SaveAsBinary("file.bin");
                    TextFile loadedFile1 = TextFile.LoadFromBinary("file.bin");
                    Console.WriteLine(loadedFile1.Content); // Hello, world!;
                    break;
                case "2":
                    // XML сериализация
                    textFile.SaveAsXml("file.xml");
                    TextFile loadedFile2 = TextFile.LoadFromXml("file.xml");
                    Console.WriteLine(loadedFile2.Content); // Hello, world!
                    break;
                case "3":
                    // поиск текстовых файлов по ключевым словам
                    TextFileSearcher searcher = new TextFileSearcher();
                    Console.WriteLine(" Enter keyword ");
                    string keyword = "";
                    keyword = Console.ReadLine();
                    List<string> files = searcher.SearchFiles(@"C:\Users\ZemelyaD\Desktop", new List<string> { keyword });
                    foreach (string file in files)
                    {
                        Console.WriteLine(Path.GetFullPath(file)); // вывод полного пути к файлу
                    }

                    break;
                case "4":
                    // консольный редактор текстовых файлов
                    // Предполагается, что у пользователя есть файл с именем "test.txt"
                    // и его содержимое будет загружено в редактор
                    TextFile textFile = new TextFile("test.txt");
                    TextEditor editor = new TextEditor(textFile);

                    bool quit = false;
                    while (!quit)
                    {
                        Console.WriteLine("Текст: ");
                        Console.WriteLine(textFile.Content);
                        Console.WriteLine("Введите команду: (w - написать, b - стереть, u - отменить, s - сохранить, q - выйти)");

                        string input = Console.ReadLine();
                        switch (input)
                        {
                            case "w":
                                Console.WriteLine("Введите текст для добавления:");
                                string textToAdd = Console.ReadLine();
                                editor.Write(textToAdd);
                                break;
                            case "b":
                                editor.Backspace();
                                break;
                            case "u":
                                editor.Undo();
                                break;
                            case "s":
                                editor.Save();
                                Console.WriteLine($"Сохранено в файле {textFile.FileName}");
                                break;
                            case "q":
                                quit = true;
                                break;
                            default:
                                Console.WriteLine("Неверная команда");
                                break;


                                /* TextEditor editor = new TextEditor(textFile);
                                   editor.Write(", C#");
                                   Console.WriteLine(textFile.Content); // Hello, world!, C#
                                   editor.Backspace();
                                   Console.WriteLine(textFile.Content); // Hello, world!
                                   editor.Undo();
                                   Console.WriteLine(textFile.Content); // Hello, world! */
                                break;
                case "5":
                    // индексация текстовых файлов по ключевым словам
                    Console.WriteLine("Enter first keyword:");
                    string keyword1 = Console.ReadLine();
                    Console.WriteLine("Enter second keyword:");
                    string keyword2 = Console.ReadLine();

                    TextFileIndexer indexer = new TextFileIndexer();
                    Dictionary<string, List<string>> index = indexer.IndexFiles(@"C:\Users\ZemelyaD\Desktop", new List<string> { keyword1, keyword2 });

                    foreach (KeyValuePair<string, List<string>> entry in index)
                    {
                        Console.WriteLine("Index for keyword: " + entry.Key);
                        int i = 1;
                        foreach (string file in entry.Value)
                        {
                            Console.WriteLine(i++ + ". " + file); // вывод индекса и пути к файлу
                        }
                    }
                    break;
                default:
                    Console.WriteLine("Document not Found.");
                    break;
            }









            // создание объекта текстового файла
           // TextFile textFile = new TextFile
           // {
           //     FileName = "file.txt",
           //     Content = "Hello, world!"
           // };

          //  // бинарная сериализация
          //  textFile.SaveAsBinary("file.bin");
          //  TextFile loadedFile1 = TextFile.LoadFromBinary("file.bin");
          //  Console.WriteLine(loadedFile1.Content); // Hello, world!

          //  // XML сериализация
          //  textFile.SaveAsXml("file.xml");
          //  TextFile loadedFile2 = TextFile.LoadFromXml("file.xml");
          //  Console.WriteLine(loadedFile2.Content); // Hello, world!

          // // поиск текстовых файлов по ключевым словам
          // TextFileSearcher searcher = new TextFileSearcher();
          // List<string> files = searcher.SearchFiles(".", new List<string> { "world" });
          // foreach (string file in files)
          // {
          //     Console.WriteLine(file); // вывод пути к файлу
          // }

          // // консольный редактор текстовых файлов
          // TextEditor editor = new TextEditor(textFile);
          // editor.Write(", C#");
          // Console.WriteLine(textFile.Content); // Hello, world!, C#
          // editor.Backspace();
          // Console.WriteLine(textFile.Content); // Hello, world!
          // editor.Undo();
          // Console.WriteLine(textFile.Content); // Hello, world!

         //   // индексация текстовых файлов по ключевым словам
         //   TextFileIndexer indexer = new TextFileIndexer();
         //   Dictionary<string, List<string>> index = indexer.IndexFiles(".", new List<string> { "world", "C#" });
         //   foreach (KeyValuePair<string, List<string>> entry in index)
         //   {
         //       Console.WriteLine(entry.Key); // вывод ключевого слова
         //       foreach (string file in entry.Value)
         //       {
         //           Console.WriteLine(file); // вывод пути к файлу
         //       }
         //   }
         //
         //   Console.ReadKey();
        }
    }
}