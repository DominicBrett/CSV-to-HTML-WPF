using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class DataLayer
    {
        public List<string> readCSVHead(string filepath)
        {
                StreamReader strReader = new StreamReader(filepath);
            string headingsString = strReader.ReadLine();

            return headingsString.Split(',').ToList<string>();
        }
    


        public List<List<string>> readCSVBody(string filepath)
        {

            List<List<string>> body = new List<List<string>>();
            using (StreamReader sr = new StreamReader(@filepath))
            {
                while (sr.Peek() >= 0)
                {

                    body.Add((sr.ReadLine()).Split(',').ToList<string>());
                }
            }
            return body;
        }
        public void writeHTML(string filepath, string content)
        {
            File.WriteAllText(@filepath, content);
        }
       
    }
}
