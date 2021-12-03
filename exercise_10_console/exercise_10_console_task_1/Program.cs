using System;
using System.Text;

namespace exercise_10_console_task_1
{
    class Program
    {
        static ProgramFileDirectoryManager programFDManager;
        static void Main(string[] args)
        {
            programFDManager = new ProgramFileDirectoryManager();
            UserInput();
        }
        static void UserInput()
        {
            StringBuilder data=new StringBuilder();
            do
            {
                Console.Write($"{programFDManager.m_currentManagerDirectory}:~@ ");
                string buf;
                if ((buf = ProcessUserInput(Console.ReadLine(), ref data)) == "exit")
                {
                    break;
                }
                else
                {
                    Console.Write($"LOG::{buf}\n\n");
                    Console.WriteLine($"{data.ToString()}\n");
                    if (data.Length > 0)
                    {
                        data.Clear();
                    }
                }
            } while (true);
        }
        static string ProcessUserInput(string userInput,ref StringBuilder data)
        {
            string[] inputParts = userInput.Split(' ');
            if (inputParts.Length >= 1)
            {
                switch (inputParts[0])
                {
                    case "cd":
                        {
                            // cd ..
                            if (inputParts.Length == 2 && inputParts[1] == "..")
                            {
                                return DecryptStatusCode(programFDManager.GoBackDirectory());
                            }
                            // cd directory_name
                            else if(inputParts.Length==2)
                            {
                                return DecryptStatusCode(programFDManager.GoToDirectory(inputParts[1]));
                            }
                        }break;
                        // mk dir directory_name
                    case "mkdir":
                        {
                            if (inputParts.Length == 2)
                            {
                                return DecryptStatusCode(programFDManager.CreateDirectory(inputParts[1]));
                            }
                        }break;
                    case "ls":
                        {
                            // ls
                            return DecryptStatusCode(programFDManager.ShowAllCurrentDirectoryFD(ref data));
                        }
                    case "echo":
                        {
                            // echo "text" > filename.extension
                            if (inputParts.Length >= 4 && inputParts[inputParts.Length - 2] == ">")
                            {
                                return DecryptStatusCode(programFDManager.CreateFile(inputParts[inputParts.Length - 1], GetStringFormStringArrayRange(inputParts, 1, inputParts.Length - 3)));
                            }
                        }break;
                    case "cat":
                        {
                            // cat file1 >> file2
                            if (inputParts.Length==4&&inputParts[2]==">>")
                            {
                                return DecryptStatusCode(programFDManager.AppendTextToFile(inputParts[3], inputParts[1]));
                            }
                            // cat file1
                            else if(inputParts.Length==2)
                            { 
                                return DecryptStatusCode(programFDManager.ReadFile(inputParts[1],ref data));
                            }
                        }break;
                    case "rm":
                        {
                            if (inputParts.Length == 2)
                            {
                                return DecryptStatusCode(programFDManager.DeleteFileOrDirectory(inputParts[1]));
                            }
                        }break;

                }
            }
            return "unknown command";
        }
        static string GetStringFormStringArrayRange(string[] array, int startIndex, int stopIndex)
        {
            StringBuilder returnableData= new StringBuilder();

            try
            {
                for (int i = startIndex; i < stopIndex+1; i++)
                {
                    returnableData.Append($"{array[i]} ");
                }
                return returnableData.ToString();
            }
            catch
            {
                return "";
            }

        }
        static string DecryptStatusCode(ProgramFileDirectoryManager.StatusCode statusCode)
        {
            switch(statusCode)
            {
                case ProgramFileDirectoryManager.StatusCode.AlreadyCreated:return "already created";
                case ProgramFileDirectoryManager.StatusCode.DirectoryNotFound: return "directroty not found";
                case ProgramFileDirectoryManager.StatusCode.FileNotFound: return "file not found";
                case ProgramFileDirectoryManager.StatusCode.SomeError: return "some error";
                case ProgramFileDirectoryManager.StatusCode.SuccessfullyAppended: return "successfully appended";
                case ProgramFileDirectoryManager.StatusCode.SuccessfullyCreated: return "successfully created";
                case ProgramFileDirectoryManager.StatusCode.SuccessfullyStepped: return "successfully stepped";
                case ProgramFileDirectoryManager.StatusCode.SuccessfullyGet: return "successfully get";
                case ProgramFileDirectoryManager.StatusCode.SuccessfullyRead: return "successfully read";
                case ProgramFileDirectoryManager.StatusCode.SuccessfullyDelete: return "successfully delete";
                case ProgramFileDirectoryManager.StatusCode.ElementNotFound: return "element not found";
                default:return "unknown code";
            }
        }
    }
}
