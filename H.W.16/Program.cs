using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Encodings.Web;
using System.Text.Unicode;

namespace H.W._16
{
    class Program
    {
        static void Main(string[] args)
        {
            Product[] products = new Product[5];
            for (int i = 0; i < products.Length; i++)
            {
                Console.WriteLine("Введите код товара, название товара, цену товара {0}", i+1);
                products[i] = new Product()
                {
                    DataProduct = Convert.ToInt32(Console.ReadLine()),
                    ProductName = Console.ReadLine(),
                    ProductPrice = Convert.ToDouble(Console.ReadLine())
                };
            }
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            };
            string jsonString = JsonSerializer.Serialize(products, options);
            Console.WriteLine(jsonString);
            Console.ReadKey();
        }
    }
    class Product
    {
        [JsonPropertyName("Код товара")]
        public int DataProduct { get; set; }
        [JsonPropertyName("Название товара")]
        public string ProductName { get; set; }
        [JsonPropertyName("Цена товара")]
        public double ProductPrice { get; set; }
    }
}
