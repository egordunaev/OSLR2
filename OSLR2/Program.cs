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
            string dirpath = @"C:\OSLR2\"; // Путь рабочей папки.
            string subdirpath = dirpath + args[1] + @"\";
            string substring = string.Empty;
            int errorcode = 0;
            
            try
            {
                string[] lines = File.ReadAllLines(dirpath + args[0]);
                substring = lines[0].Substring(0, lines[0].IndexOf(" "));
                Console.WriteLine("Первое слово первой строки - " + substring);
            }
            catch (Exception e)
            {
                errorcode = 1;
                Console.WriteLine(e.Message+"\nКод ошибки: "+errorcode+ "\nНажмите любую клавишу...");
                Console.ReadKey();
                return errorcode;
            }
            
            try
            {
                string subdir = subdirpath +args[1]+"\\";
                
                if (!Directory.Exists(subdirpath + args[2] + "\\"))
                    Directory.CreateDirectory(subdirpath+ args[2]+"\\");
                Console.WriteLine("Создаю файл "+ subdirpath + args[2] + "\\"+substring + "...");
                File.Create(subdirpath+args[2]+ "\\" + substring);
            } catch(Exception e)
            {
                errorcode = 1;
                Console.WriteLine(e.Message + "\nКод ошибки: " + errorcode + "\nНажмите любую клавишу...");
                Console.ReadKey();
                return errorcode;
            }
            Console.WriteLine("Программа завершена. Нажмите любую клавишу...");
            Console.ReadKey();
            return errorcode;
            
        }
    }
}
