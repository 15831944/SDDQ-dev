using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IOCommon
{
    public static  class FileOperate
    {
        static public List<string> OpenFile(string fileTitle)
        {
            Stream DataStream;
            StreamReader StreamReader;
            List<string> fileData = new List<string>();
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            openFileDialog.Filter = "Text files (*.txt)|*.txt|dat files (*.dat)|*.dat|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = false;
            openFileDialog.Title = fileTitle;
            do
            {
                if (openFileDialog.ShowDialog() ==DialogResult.OK)
                {
                    DataStream = openFileDialog.OpenFile();

                    StreamReader = new StreamReader(DataStream);
                    string Line;
                    do
                    {
                        Line = StreamReader.ReadLine();
                        if (Line != null)
                        {
                            fileData.Add(Line);
                        }
                    } while (Line != null);
                    DataStream.Close();
                }
                else
                {
                    break;
                }
            } while (fileData.Count == 0);
            return fileData;
        }
        static public List<string> ReadFile(string filepath)
        {
            List<string> fileData = new List<string>();
            try
            {
                // Create an instance of StreamReader to read from a file.
                // The using statement also closes the StreamReader.
                using (StreamReader sr = new StreamReader(filepath,Encoding.Default))
                {
                    string line;
                    // Read and display lines from the file until the end of 
                    // the file is reached.
                    while ((line = sr.ReadLine()) != null)
                    {                       
                        fileData.Add(line);
                    }                   
                }               
            }
            catch (Exception e)
            {
                // Let the user know what went wrong.
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
            return fileData;

        }
        static public List<string[]> ReadFile(string filepath,char split)
        {
            var data = ReadFile(filepath);
            return      (from s in data
                        let t = s.Split(split).Where(i=>i!=string.Empty).ToArray()                       
                         select t).ToList();
        }
        static public void SaveFile(string fileData)
        {
            Stream myStream;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "Text files (*.txt)|*.txt|dat files (*.dat)|*.dat|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if ((myStream = saveFileDialog1.OpenFile()) != null)
                {
                    using (StreamWriter sw = new StreamWriter(myStream))
                    {
                        sw.Write(fileData);
                    }
                }
            }

        }
        static public void WriteFile(List<string> fileData, string filepath)
        {
            using (StreamWriter sw = new StreamWriter(File.OpenWrite(filepath)))
            {
                foreach (var line in fileData)
                {
                    sw.WriteLine(line);
                }                
            }
        }
    }
}
