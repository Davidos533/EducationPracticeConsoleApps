using System;
using System.IO;
using System.Reflection;
using System.Text;

namespace exercise_10_console_task_1
{
    class ProgramFileDirectoryManager
    {
        public enum StatusCode
        {
            SuccessfullyCreated,
            AlreadyCreated,
            SuccessfullyAppended,
            SuccessfullyStepped,
            SuccessfullyGet,
            SuccessfullyRead,
            SuccessfullyDelete,
            SomeError,
            DirectoryNotFound,
            FileNotFound,
            ElementNotFound,
        }
        public string m_currentManagerDirectory { get; private set; }

        public ProgramFileDirectoryManager()
        {
            m_currentManagerDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        }
        public StatusCode DeleteFileOrDirectory(string name)
        {
            try
            {
                if (File.Exists($"{m_currentManagerDirectory}\\{name}"))
                {
                    File.Delete($"{m_currentManagerDirectory}\\{name}");
                    return StatusCode.SuccessfullyDelete;
                }
                else if (Directory.Exists($"{m_currentManagerDirectory}\\{name}"))
                {
                    Directory.Delete($"{m_currentManagerDirectory}\\{name}",true);
                    return StatusCode.SuccessfullyDelete;
                }
                else
                {
                    return StatusCode.ElementNotFound;
                }
            }
            catch (Exception e)
            {
                return StatusCode.SomeError;
            }
        }
        public StatusCode ReadFile(string filename,ref StringBuilder fileData)
        {
            try
            {
                if (!File.Exists($"{m_currentManagerDirectory}\\{filename}"))
                {
                    return StatusCode.FileNotFound;
                }
                else
                {
                    fileData=new StringBuilder(File.ReadAllText($"{m_currentManagerDirectory}\\{filename}"));
                    return StatusCode.SuccessfullyRead;
                }
            }
            catch
            {
                return StatusCode.SomeError;
            }
        }
        public StatusCode ShowAllCurrentDirectoryFD(ref StringBuilder directoryEntries)
        {
            try
            {
                if(m_currentManagerDirectory.Length<3)
                {
                    m_currentManagerDirectory += "\\";
                }
                foreach (var systemEntry in Directory.GetFileSystemEntries(m_currentManagerDirectory))
                {
                    int finalDirectoryPathLength = systemEntry.LastIndexOf('\\');
                    directoryEntries.Append($"{systemEntry.Substring(finalDirectoryPathLength+1,systemEntry.Length-finalDirectoryPathLength-1)}\n");
                }
                return StatusCode.SuccessfullyGet;
            }
            catch(Exception ex)
            {
                return StatusCode.SomeError;
            }
        }
        public StatusCode GoBackDirectory()
        {
            try
            {
                int finalDirectoryPathLength = m_currentManagerDirectory.LastIndexOf('\\');
                if (!Directory.Exists(m_currentManagerDirectory.Substring(0, finalDirectoryPathLength)))
                {
                    return StatusCode.DirectoryNotFound;
                }
                else
                {
                    m_currentManagerDirectory = m_currentManagerDirectory.Substring(0, finalDirectoryPathLength);
                    return StatusCode.SuccessfullyStepped;
                }
            }
            catch 
            {
                return StatusCode.SomeError;
            }
        }
        public StatusCode GoToDirectory(string directory)
        {
            try
            {
                // если указанна дерикория отсутствует
                if (!Directory.Exists($"{m_currentManagerDirectory}\\{directory}"))
                {
                    return StatusCode.DirectoryNotFound;
                }
                else
                {
                    m_currentManagerDirectory = $"{m_currentManagerDirectory}\\{directory}";
                    return StatusCode.SuccessfullyStepped;
                }
            }
            catch
            {
                return StatusCode.SomeError;
            }

        }
        public StatusCode AppendTextToFile(string editableFile, string appendFile)
        {
            try
            {
                string readenData=File.ReadAllText($"{m_currentManagerDirectory}\\{appendFile}");

                File.AppendAllText($"{m_currentManagerDirectory}\\{editableFile}",readenData);

                return StatusCode.SuccessfullyAppended;
            }
            catch
            {
                return StatusCode.SomeError;
            }
        }
        // метод для слздания файла
        public StatusCode CreateFile(string fileName,string data)
        {
            try
            {
                // если файл отсутствует
                if(!File.Exists($"{m_currentManagerDirectory}\\{fileName}"))
                {
                    File.Create($"{m_currentManagerDirectory}\\{fileName}").Close();    // создание файла
                    if (data != String.Empty)
                    { 
                        File.AppendAllText($"{m_currentManagerDirectory}\\{fileName}", data);
                    }
                    return StatusCode.SuccessfullyCreated;
                }
                else
                { 
                    return StatusCode.AlreadyCreated;
                }
            }
            catch(Exception ex)
            {
                return StatusCode.SomeError;
            }
        }
        // метод для создание дирекории с заданным именем в папке текущей сборки
        public StatusCode CreateDirectory(string directoryName)
        {
            try
            {
                // если дикректория отсутствует
                if (!Directory.Exists($"{m_currentManagerDirectory}\\{directoryName}"))
                {
                    Directory.CreateDirectory($"{m_currentManagerDirectory}\\{directoryName}");   // создание директории
                    return StatusCode.SuccessfullyCreated;
                }
                // иначе если директория уже существует
                else
                {
                    return StatusCode.AlreadyCreated;
                }
            }
            catch
            {
                return StatusCode.SomeError;
            }

        }
    }
}
