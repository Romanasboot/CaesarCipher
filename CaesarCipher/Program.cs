using System;

namespace CaesarCipher
{
    class Program
    {
        static void Main()
        {
            const string alphabet = "abcdefghijklmnopqrstuvwxyz";

            static string CryptDecrypt (string text, int key)
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
                        int codedIndex = (index + key);
                        if (codedIndex > 50)
                        {
                            result += fullAlphabet[codedIndex-50];
                            return result;
                        }
                        result += fullAlphabet[codedIndex];
                    }
                }
                return result;
            }
            
            Console.WriteLine("Hello. This is Caesar Cipher.");

            Start:
                Console.WriteLine("Enter text:\n");
                string inputText = Console.ReadLine();
                //inputText = inputText.ToLower();

                Console.WriteLine("Enter Key (1..10)\n");
                int key = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Please select: E - Encrypt, D - Decrypt.\n");
                string select = Console.ReadLine().ToUpper();

                switch (select)
                {
                    default:
                        Console.WriteLine("Unsupported. Please select E or D.\n");
                        goto Start;

                    case "E":
                        Console.WriteLine("Let's encrypt...\n");
                        var codedText = CryptDecrypt(inputText, key);
                        Console.WriteLine($"    Plain text: {inputText}");
                        Console.WriteLine($"Encrypted text: {codedText}\n");
                        break;

                    case "D":
                        Console.WriteLine("Trying to decrypt..\n");
                        var decodedText = CryptDecrypt(inputText, -key);
                        Console.WriteLine($"Encrypted text: {inputText}");
                        Console.WriteLine($"Decrypted text: {decodedText}\n");
                        break;
                }
            Console.WriteLine("Press X to Exit or any key to Start again.\n");
            string answer = Console.ReadLine().ToUpper();
            if (answer != "X") goto Start;
            else Console.WriteLine("Bye..");


        }
    }
}
