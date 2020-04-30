using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Написати статичний метод ReadFiles, що виконує вказані дії над вмістом файлу.
Формальні параметри : файл, задана дія – об'єкт Action/Func.
Використовуючи написаний метод:
 вивести вміст файлу на екран;
 вивести на екран всі числа! (числа складаються с цифр);
 замінити у файлі всі коми/крапки/* /
() на пробіли.
Після виклику останньої дії – вивести вміст файлу на екран.*/
namespace lab8_2
{
    class ZV2
    {
        public static void Main()
        {
            Console.WriteLine("FILE:");
            ReadFiles("text.txt", Show);
            Console.WriteLine("NUMBERS:");
            ReadFiles("text.txt", ShowNumbers);
            Console.WriteLine("REWRITTEN FILE:");
            ReadFiles("text.txt", Replace);
            ReadFiles("text.txt", Show);
            Console.ReadKey();
        }

        public static void ReadFiles(String path, Action<String> act)
        {
            act(path);
        }

        public static void Show(String path)
        {
            StringBuilder file = new StringBuilder();
            string line;
            using (StreamReader MyFile = new StreamReader(path))
            {
                while ((line = MyFile.ReadLine()) != null)
                    file.Append(line + "\n");
            }
            Console.WriteLine(file);
        }

        public static void ShowNumbers(String path)
        {
            StringBuilder numbers = new StringBuilder();
            string line;
            using (StreamReader MyFile = new StreamReader(path))
            {
                while ((line = MyFile.ReadLine()) != null)
                {
                    int i = 0;
                    while (i < line.Length)
                    {
                        while (i != line.Length && !Char.IsDigit(line[i]))
                        {
                            i++;
                        }
                        int j = i;
                        while (j != line.Length && Char.IsDigit(line[j]))
                        {
                            j++;
                        }
                        if (i != j)
                        {
                            numbers.Append(line.Substring(i, j - i) + " ");
                        }
                        i = j;
                    }
                }
            }
            Console.WriteLine(numbers);
        }

        public static void Replace(String path)
        {
            StringBuilder file = new StringBuilder();
            string line;
            using (StreamReader MyFile = new StreamReader(path))
            {
                while ((line = MyFile.ReadLine()) != null)
                    file.Append(line + "\n");
            }
            file.Replace('(', ' ');
            file.Replace(')', ' ');
            file.Replace('.', ' ');
            file.Replace(',', ' ');
            file.Replace('*', ' ');
            using (StreamWriter MyFile = new StreamWriter(path))
            {
                MyFile.WriteLine(file);
            }

        }
    }
}
