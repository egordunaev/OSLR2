using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using System.Diagnostics;

namespace OSLR2
{
    class Program
    {
        static int Main(string[] args)
        {
            string dirpath = @"C:\OSLR2\DIR\"; // Путь рабочей папки.
            string substring = string.Empty;
            int errorcode = 0;
            if (!Directory.Exists(dirpath))
                Directory.CreateDirectory(dirpath);
            try
            {
                string[] lines = File.ReadAllLines(dirpath + args[0]);
                substring = lines[0].Substring(0, lines[0].IndexOf(" "));
                Console.WriteLine("Первое слово первой строки - " + substring);
            }
            catch (Exception e)
            {
                errorcode = 1;
                Console.WriteLine(e.Message+"\nКод ошибки: "+errorcode+"\nЗакрываю программу...");
                Thread.Sleep(5000);
                return errorcode;
            }
            
            try
            {
                string subdir = dirpath +args[1]+"\\";
                Console.WriteLine("Создаю папку: " + subdir + "...");
                if (!Directory.Exists(dirpath + args[1]))
                    Directory.CreateDirectory(subdir);
                Console.WriteLine("Создаю файл "+ subdir + substring + "...");
                File.Create(subdir+ substring);
            } catch(Exception e)
            {
                errorcode = 1;
                Console.WriteLine(e.Message + "\nКод ошибки: " + errorcode + "\nЗакрываю программу...");
                Thread.Sleep(5000);
                return errorcode;
            }
            Console.WriteLine("Программа завершена. ");
            Thread.Sleep(5000);
            return errorcode;
            
        }
    }
}
