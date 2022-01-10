using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex._2
{
    class Program
    {
        static void Main(string[] args)
        {
            string dr_json = "D:/H_W16/Log.json";
            string text = File.ReadAllText(dr_json);
            Console.WriteLine(text);
            Console.ReadKey();
        }
    }
}
