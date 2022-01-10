using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using System.IO;

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
            string dr = "D:/H_W16";
            string dr_json = "D:/H_W16/Product.json";

            if (!Directory.Exists(dr))
            {
                Directory.CreateDirectory(dr);
            }
            using (StreamWriter st = new StreamWriter(dr_json, false))
            {
                st.Write(jsonString);
            }

            string text = File.ReadAllText(dr_json);
            Product[] products1 = new Product[5];
            products1 = JsonSerializer.Deserialize<Product[]>(text);
            int ind = 0;
            double MaxPrice = double.MinValue;
            for (int i = 0; i < products1.Length; i++)
            {
                
                double Value = products1[i].ProductPrice;
                if (Value>MaxPrice)
                {
                    MaxPrice = Value;
                    ind = i;
                }
            }
           
            Console.WriteLine("Самый дорогой товар {0}, с ценой {1}", products1[ind].ProductName, products1[ind].ProductPrice);
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
