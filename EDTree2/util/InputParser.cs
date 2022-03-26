using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace EDTree2
{
    enum Stage
    {
        None, Label, Header, Data
    }
    
    public class InputParser
    {
        public static Input Parse(string filename)
        {
            Stage stage = Stage.None;
            Input input = new Input();
            try
            {
                using (StreamReader sr = new StreamReader(filename))
                {
                    string line;

                    while ((line = sr.ReadLine()) != null)
                    {
                        line = line.Trim();
                        
                        // make stage with TAG.
                        switch (line)
                        {
                            case "[label]":
                                stage = Stage.Label;
                                continue;
                            case "[header]":
                                stage = Stage.Header;
                                continue;
                            case "[data]":
                                stage = Stage.Data;
                                continue;
                        }

                        // After TAG was assigned.
                        if (stage == Stage.None)
                        {
                            throw new Exception("The file starts without TAG.");
                        }
                        
                        if (stage == Stage.Label)
                        {
                            string[] p = line.Split(':');
                            if (p[0] == "x") input.LabelX = p[1].Trim();
                            if (p[0] == "y") input.LabelY = p[1].Trim();

                        } else if (stage == Stage.Header)
                        {
                            string[] p = line.Split(';');
                            input.Header = p.Select(x => x.Trim()).ToArray();
                        }
                        else
                        {
                            double[] p = line.Split(';').Select(double.Parse).ToArray();

                            for (int i = 0; i < p.Length; i++)
                            {
                                if (input.Data.Count <= i)
                                {
                                    input.Data.Add(new List<double>());
                                }

                                input.Data[i].Add(p[i]);
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("This file could not be read.");
                Console.WriteLine(e.Message);
            }

            if (Validate(input))
                return input;
            throw new Exception("The file does not matched with format.");
        }

        private static bool Validate(Input input)
        {
            // [label]
            // x 1개, y 1개만 존재.
            // 길이 1 이상
            if (string.IsNullOrEmpty(input.LabelX)) return false;
            if (string.IsNullOrEmpty(input.LabelY)) return false;
            
            // [header]
            // 1개 이상
            if (input.Header.Length == 0) return false;
            
            // [data]
            // cols가 header의 개수와 맞아야함.
            if (input.Header.Length != input.Data.Count) return false;
            
            // row의 개수가 맞아야함.
            var l = input.Data[0].Count;
            return input.Data.All(line => line.Count == l);
        }

        public static void IntensityValidate(Input input)
        {
            // [data]
            // cols가 4줄이어야 함.
            if (input.Data.Count != 4)
            {
                throw new FormatException("intensity input column length must be 4.");
            }
        }
    }

    public class Input
    {
        public string LabelX { get; set; }
        public string LabelY { get; set; }
        public string[] Header { get; set; }
        public List<List<double>> Data { get; set; }

        public Input()
        {
            Data = new List<List<double>>();
        }
    }
}