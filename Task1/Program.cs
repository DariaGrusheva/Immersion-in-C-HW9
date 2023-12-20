
// написав утилиту которая ищет файлы определенного расширения с указанным текстом. Рекурсивно.
// Пример вызова утилиты: utility.exe txt текст.

using System.IO;

namespace Task2
{
    internal class Program
    {
        const string path = "C:\\Users\\admin\\Desktop\\GB\\GB\\HomeWork\\C# profy";
        static void Main(string[] args)
        {
            foreach (string arg in args)
            {
                Console.WriteLine(arg);
            }

            List<string> list = SearchIn(path, ext: args[0]);

            Console.WriteLine(String.Join("\n", list));

            Console.WriteLine(args[1]);
            foreach (string path  in list)
            {
                var text = ReadFrom(path);
                var filtr = Filtr(args[1], text);
                Console.WriteLine(String.Join("\n", filtr));
            }

        }

        private static List<string> SearchIn(string path, string ext) 
        {
            var list = new List<string>();
            DirectoryInfo dir = new DirectoryInfo(path);
            var directories = dir.GetDirectories();
            var fils = dir.GetFiles();
            foreach (var item in fils)
            {
                if (item.Extension.Contains(ext))
                {
                    list.Add(item.FullName);
                }
            }
            foreach (var item in directories)
            {
                list.AddRange(SearchIn(item.FullName, ext));
            }
            return list;
        }

        static List<string> ReadFrom(string path)
        {
            List<string> result = new List<string>();
            using (StreamReader sr = new StreamReader(path))
            {
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine();
                    result.Add(line);

                }

            }
            return result;
        }

        static List<string> Filtr(string word, List<string> text)
        {
            return text.Where(a => a.ToLower().Contains(word.ToLower())).Select(x => x.ToLower().Replace(word.ToLower(), word.ToUpper())).ToList();
        }
    }
}


