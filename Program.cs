using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var sourcePath = args[0];
            var destinationPath = args[1];

            using var mediaStream = File.OpenRead(Path.Join(sourcePath, "media"));
            var doc = JsonDocument.Parse(mediaStream);

            foreach (var item in doc.RootElement.EnumerateObject())
            {
                var filePath = Path.Join(sourcePath, item.Name);
                var newFilePath = Path.Join(destinationPath, item.Value.GetString());
                File.Copy(filePath, newFilePath);
                Console.WriteLine($"{filePath} => {newFilePath}");
            }

            Console.WriteLine("Done");
        }
    }
}
