using System;

namespace CaesarCipher
{
    class Program
    {
        static void Main()
        {
            const string alphabet = "abcdefghijklmnopqrstuvwxyz";

            static string CryptoDecrypt (string text, int key)
            {
                string fullAlphabet = alphabet + alphabet.ToUpper(); //addind uppercase letters to fullAlphabet
                string result = "";

                for (int i = 0; i < text.Length; i++)
                {
                    var letter = text[i];
                    var index = fullAlphabet.IndexOf(letter);
                    if (index < 0 ) //(index not found) if no such letter in fullAlphabet then add as entered.
                    {
                        result += letter.ToString();
                    }
                    else
                    {
                        int codedIndex = (index + key);
                        if (codedIndex > 51) //checking if new index is out of fullAlphabet range and correcting.
                        {
                            codedIndex -= 51;
                        }
                        if (codedIndex <= 0)
                        {
                            codedIndex += 51;
                        }
                        result += fullAlphabet[codedIndex];
                    }
                }
                return result.ToString();
            }
            Console.WriteLine("Hello. This is Caesar Cipher.");

        Start:
                Console.WriteLine("Enter text:\n");
                string inputText = Console.ReadLine();

                Console.WriteLine("Enter Key (1..10)\n");
                int key = Convert.ToInt32(Console.ReadLine()); //need validation check

                Console.WriteLine("Please select: E - Encrypt, D - Decrypt.\n");
                string select = Console.ReadLine().ToUpper(); //need validation check

                switch (select)
                {
                    default:
                        Console.WriteLine("Unsupported. Please select E or D.\n");
                        goto Start;

                    case "E":
                        Console.WriteLine("Let's encrypt...\n");
                        string codedText = CryptoDecrypt(inputText, key);
                        Console.WriteLine($"    Plain text: {inputText}");
                        Console.WriteLine($"Encrypted text: {codedText}\n");
                        break;

                    case "D":
                        Console.WriteLine("Trying to decrypt...\n");
                        string decodedText = CryptoDecrypt(inputText, -key);
                        Console.WriteLine($"Encrypted text: {inputText}");
                        Console.WriteLine($"Decrypted text: {decodedText}\n");
                        break;
                }
            Console.WriteLine("Press X to Exit or any key to Start again.\n");
            string answer = Console.ReadLine().ToUpper();
            if (answer != "X") goto Start;
            else Console.WriteLine("Bye...");
        }
    }
}
