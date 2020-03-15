using System;
using System.Drawing;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace dotnet
{
    class Program
    {
        public Path item;
        public Bitmap bitmapImage;
        public List<List<RGBA>> matrix = new List<List<RGBA>>();

        public void LoadJsonFile()
        {
            using (StreamReader r = new StreamReader("config.json"))
            {
                string json = r.ReadToEnd();
                item = JsonConvert.DeserializeObject<Path>(json);
            }
        }

        public void CreateJSONOutput(string data, string loc)
        {
            loc = loc + "output.json";
            using (StreamWriter file = new StreamWriter(loc))
            {
                foreach (char c in data)
                {
                    file.Write(c);
                }
            }
        }

        public void GenerateTileArray()
        {
            bitmapImage = new Bitmap(item.path);
            Image dimensions = new Image(bitmapImage.Width, bitmapImage.Height);

            for (int i = 0; i < dimensions.Width; i++)
            {
                matrix.Add(new List<RGBA>(new RGBA[dimensions.Height]));
            }

            for (int i = 0; i < dimensions.Width; i++)
            {
                for (int j = 0; j < dimensions.Height; j++)
                {
                    Color pixel = bitmapImage.GetPixel(i, j);
                    matrix[i][j] = new RGBA(pixel.R, pixel.G, pixel.B, pixel.A);
                }
            }
            string output = JsonConvert.SerializeObject(matrix);
            CreateJSONOutput(output, item.outFilePath);
        }
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            var instance = new Program();
            instance.LoadJsonFile();
            instance.GenerateTileArray();
        }
    }
}
