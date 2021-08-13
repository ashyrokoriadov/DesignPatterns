using System;
using System.Collections.Generic;
using System.IO;

namespace Adapter.FileWriter
{
    public class TextFileWriter : IFileWriter
    {
        public string Path { get; init; }
        
        public TextFileWriter(string path)
        {
            Path = path;
        }

        public bool Write(IEnumerable<string> contents)
        {
            try
            {
                Console.WriteLine($"Вызов метода {nameof(Write)} класса {nameof(TextFileWriter)}.");

                File.WriteAllLines(Path, contents);
                return true;
            }            
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
