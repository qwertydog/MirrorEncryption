using System;

namespace MirrorEncryption
{
    class Program
    {
        static void Main(string[] args)
        {
            string file = @"C:\Users\campb\Documents\Visual Studio 2015\Projects\MirrorEncryption\MirrorEncryption\input.txt";

            InputReader input = new InputReader();
            input.Parse(file);

            MirrorEncryption me = new MirrorEncryption(input.MirrorLines);

            me.Print();

            Console.WriteLine("Encoded input string: {0}", input.EncryptedString);

            Console.Write("Decoded input string: ");
            foreach (var letter in input.EncryptedString)
            {
                Console.Write(me.Decode(letter));
            }
            Console.WriteLine();

            Console.Write("Enter string to encode: ");
            string testString = Console.ReadLine();
            Console.WriteLine("Encoded string: " + me.Encode(testString));

            Console.Write("Encode string on the fly: ");

            var key = Console.ReadKey(true);

            while (key.Key != ConsoleKey.Enter)
            {
                Console.Write(me.Encode(key.KeyChar));
                key = Console.ReadKey(true);
            }
            Console.WriteLine();
        }
    }
}
