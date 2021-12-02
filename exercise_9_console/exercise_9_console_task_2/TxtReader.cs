using System;
using System.IO;
using System.Text;

namespace exercise_9_console_task_2
{
    class TxtReader
    {
        public string filePath { get; set; }
        public string result { get; set; }

        public TxtReader()
        {

        }

        public void GetAllSpacedContainsLines()
        {
            if (filePath.Substring(filePath.Length - 4, 4) == ".txt")
            {
                StringBuilder stringB = new StringBuilder();
                using (StreamReader streamReader = new StreamReader(filePath))
                {
                    foreach (var line in streamReader.ReadToEnd().Split('\n'))
                    {
                        if (line.Contains(' '))
                        {
                            stringB.Append($"{line}\n");
                        }
                    }
                }
                result = stringB.ToString();
            }
            else
            {
                throw new Exception("incorrect extension");
            }
        }
    }
}
