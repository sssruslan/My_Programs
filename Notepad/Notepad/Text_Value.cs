using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Notepad
{
    class Text_Value
    {
        string[] text;
        string fileName;
        public string[] Text
        {
            get { return text; }
            set { text = value; }
        }
        public string FileName
        {
            get { return fileName; }
            set { fileName = value; }
        }

        public Text_Value(string fileName, string[] text)
        {
            this.fileName = fileName;
            this.text = text;
        }
        public Text_Value(string fileName)
        {
            this.fileName = fileName;
            text = new string[1];
        }

        public void Save()
        {
            StreamWriter fStream = new StreamWriter(fileName, false, Encoding.Default);
            foreach (var item in text)
            {
                fStream.Write(item);
            }            
            fStream.Close();
        }
        public void Load()
        {
            StreamReader fStream = new StreamReader(File.OpenRead(fileName), Encoding.Default);
            text = File.ReadAllLines(fileName, Encoding.Default);
            fStream.Close();
        }
    }
}
