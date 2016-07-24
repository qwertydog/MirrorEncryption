using System;
using System.IO;

namespace MirrorEncryption
{
    class InputReader
    {
        private string[] mirrorLines = new string[13];
        public string[] MirrorLines {
            get
            {
                return mirrorLines;
            }
        }
        private string encryptedString;
        public string EncryptedString
        {
            get
            {
                return encryptedString;
            }
        }
        public void Parse(string fileName)
        {
            try
            {
                string[] input = File.ReadAllLines(fileName);
                for (int i = 0; i < 14; i++)
                {
                    if (i < 13)
                    {
                        mirrorLines[i] = input[i];
                    }
                    else
                    {
                        encryptedString = input[i];
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File not found");
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("Directory not found");
            }
        }
    }
}
