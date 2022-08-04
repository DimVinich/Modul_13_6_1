using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace Modul_13_6_1
{
    class Program
    {
        static void Main(string[] args)
        {

            // Считываем файл в массив, с него будем рабоать с коллекциями
            // Не будем произоводить очистку памяти,  считаем
            // что памяти системного блока достаточно для обеих коллекций

            string nFile = @"D:\\Text1.txt";
            string[] arrText;


            List<string> lList = new List<string>();
            LinkedList<string> lLinkedList = new LinkedList<string>();
            int iCount = 0;

            try
            {
                arrText = File.ReadAllLines(nFile);
            }
            catch (Exception ex)
            {
                Console.WriteLine("При считывании файла случились проблемы \n" +ex.Message );
                Console.ReadKey();
                return;
            }

            //  Обработка связанного списка
            iCount = 0;
            var watchLinckedList = Stopwatch.StartNew();

            foreach (string lsTemp in arrText)
            {
                iCount++;
                lLinkedList.AddLast(lsTemp);
            }

            Console.WriteLine($"Заполнение связанного списка заняло: {watchLinckedList.Elapsed.TotalMilliseconds}  мс  для {iCount} записей");

            //  Обработка для списка
            var watchList = Stopwatch.StartNew();

            foreach(string lsTemp in arrText)
            {
                iCount++;
                lList.Add(lsTemp);
            }

            Console.WriteLine($"Заполнение списка заняло: {watchList.Elapsed.TotalMilliseconds}  мс  для {iCount} записей");


            Console.ReadKey();
        }
    }
}
