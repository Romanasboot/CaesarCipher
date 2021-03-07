using System;

namespace CaesarCipher
{
    class Program
    {
        static void Main(string[] args)
        {
            const string alphabet = "abcdefghijklmnopqrstuvwxyz";
            
            Console.WriteLine("Hello. This is Caesar Cipher.");

            Console.WriteLine("Enter a word:");
            string inputText = Console.ReadLine();
            //inputText = inputText.ToLower();

            Console.WriteLine("Enter Key (1..10)");
            int key = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Please select: 1 - Encrypt, 2 - Decrypt or 0 - to Exit program");
            int select = Convert.ToInt32(Console.ReadLine());
            switch (select)
            {
                default:
                    Console.WriteLine("Unsupported. Exit program.");
                    break;
                case 0:
                    Console.WriteLine("Exit program.");
                    break;

                case 1:
                    Console.WriteLine("Let's encrypt...");
                    var codedText = CodeDecode(inputText, key);
                    Console.WriteLine($"Encrypted text: {codedText}");
                    break;

                case 2:
                    Console.WriteLine("Trying to decrypt..");
                    var decodedText = CodeDecode(inputText, -key);
                    Console.WriteLine($"Decrypted text: {decodedText}");
                    break;

            }

            static string CodeDecode (string text, int key)
            {
                string fullAlphabet = alphabet + alphabet.ToUpper();
                string result = "";

                for (int i = 0; i < text.Length; i++)
                {
                    var letter = text[i];
                    var index = fullAlphabet.IndexOf(letter);
                    if (index < 0 )
                    {
                        result += letter.ToString();
                    }
                    else
                    {
                        var codedIndex = (index + key);
                        result += fullAlphabet[codedIndex];
                    }
                }
                return result;
            }





        }
    }
}
