using System;
using System.Collections.Generic;

namespace MirrorEncryption
{
    class MirrorEncryption
    {
        char[,] mirrors;
        Dictionary<char, char> dictionary;

        private enum Direction
        {
            Up, Left, Down, Right
        }

        public MirrorEncryption(string[] mirrorLines)
        {
            mirrors = new char[13, 13];
            dictionary = new Dictionary<char, char>();

            for (int i = 0; i < 13; i++) 
            {
                for (int j = 0; j < 13; j++)
                {
                    mirrors[i, j] = mirrorLines[i][j];
                }
            }
            GenerateEncryptedLetters();
        }

        private void GenerateEncryptedLetters()
        {
            for (char i = 'A'; i <= 'Z'; i++)
            {
                if (i < 'N')
                {
                    dictionary.Add(i, FindLetter(i - 'A', 0, Direction.Right));
                }
                else
                {
                    dictionary.Add(i, FindLetter(12, i - 'N', Direction.Up));
                }
            }

            for (char i = 'a'; i <= 'z'; i++)
            {
                if (i < 'n')
                {
                    dictionary.Add(i, FindLetter(0, i - 'a', Direction.Down));
                }
                else
                {
                    dictionary.Add(i, FindLetter(i - 'n', 12, Direction.Left));
                }
            }
        }

        private char FindLetter(int row, int col, Direction direction)
        {
            if (direction == Direction.Down)
            {
                if (mirrors[row, col] == '/')
                {
                    if ((col - 1) < 0)
                    {
                        return (char)(row + 'A');
                    }
                    else
                    {
                        return FindLetter(row, col - 1, Direction.Left);
                    }
                }
                else if (mirrors[row, col] == '\\')
                {
                    if ((col + 1) > 12)
                    {
                        return (char)(row + 'n');
                    }
                    else
                    {
                        return FindLetter(row, col + 1, Direction.Right);
                    }
                }
                else
                {
                    if ((row + 1) > 12)
                    {
                        return (char)(col + 'N');
                    }
                    else
                    {
                        return FindLetter(row + 1, col, direction);
                    }
                }
            }
            else if (direction == Direction.Up)
            {
                if (mirrors[row, col] == '/')
                {
                    if ((col + 1) > 12)
                    {
                        return (char)(row + 'n');
                    }
                    else
                    {
                        return FindLetter(row, col + 1, Direction.Right);
                    }
                }
                else if (mirrors[row, col] == '\\')
                {
                    if ((col - 1) < 0)
                    {
                        return (char)(col + 'A');
                    }
                    else
                    {
                        return FindLetter(row, col - 1, Direction.Left);
                    }
                }
                else
                {
                    if ((row - 1) < 0)
                    {
                        return (char)(col + 'a');
                    }
                    else
                    {
                        return FindLetter(row - 1, col, direction);
                    }
                }
            }
            else if (direction == Direction.Right)
            {
                if (mirrors[row, col] == '/')
                {
                    if ((row - 1) < 0)
                    {
                        return (char)(row + 'a');
                    }
                    else
                    {
                        return FindLetter(row - 1, col, Direction.Up);
                    }
                }
                else if (mirrors[row, col] == '\\')
                {
                    if ((row + 1) > 12)
                    {
                        return (char)(row + 'N');
                    }
                    else
                    {
                        return FindLetter(row + 1, col, Direction.Down);
                    }
                }
                else // if (direction == Direction.Left)
                {
                    if ((col + 1) > 12)
                    {
                        return (char)(row + 'n');
                    }
                    else
                    {
                        return FindLetter(row, col + 1, direction);
                    }
                }
            }
            else
            {
                if (mirrors[row, col] == '/')
                {
                    if ((row + 1) > 12)
                    {
                        return (char)(row + 'N');
                    }
                    else
                    {
                        return FindLetter(row + 1, col, Direction.Down);
                    }
                }
                else if (mirrors[row, col] == '\\')
                {
                    if ((row - 1) < 0)
                    {
                        return (char)(col + 'a');
                    }
                    else
                    {
                        return FindLetter(row - 1, col, Direction.Up);
                    }
                }
                else
                {
                    if ((col - 1) < 0)
                    {
                        return (char)(row + 'A');
                    }
                    else
                    {
                        return FindLetter(row, col - 1, direction);
                    }
                }
            }
        }

        public char Decode(char input)
        {
            return dictionary[input];
        }

        public string Decode(string input)
        {
            string output = string.Empty;

            foreach (var letter in input)
            {
                output += Decode(letter);
            }
            return output;
        }

        public char Encode(char input)
        {
            return Decode(input);
        }

        public string Encode(string input)
        {
            return Decode(input);
        }

        public void Print()
        {
            for (int i = 0; i < 13; i++)
            {
                if (i == 0)
                {
                    Console.WriteLine("  a b c d e f g h i j k l m");
                }
                for (int j = 0; j < 14; j++)
                {
                    if (j == 0)
                    {
                        Console.Write((char)('A' + i));
                    }

                    if (j < 13)
                    {
                        Console.Write(" " + mirrors[i, j]);
                    }
                    else
                    {
                        Console.WriteLine(" " + (char)('n' + i));
                    }
                }
            }
            Console.WriteLine("  N O P Q R S T U V W X Y Z");
        }
    }
}
