using System;
using System.Text;
using Backend.Commands;

namespace Backend
{
    class Program
    {
        private const int minCharCode = 32, maxCharCode = 127;
        private const int sequenceBeginCharCode = 80;
        private const int sequenceEndCharCode = 69;

        static void Main(string[] args)
        {
            StringBuilder commandText = null;
            CommandParser commandParser = new CommandParser();
            ConsoleKeyInfo keyInfo;

            do
            {
                keyInfo = Console.ReadKey(true);

                char keyChar = keyInfo.KeyChar;
                int keyCharCode = keyChar;
                if (minCharCode < keyCharCode && keyCharCode <= maxCharCode)
                {
                    Console.Write(keyChar);

                    switch (keyCharCode)
                    {
                        case sequenceBeginCharCode:
                            commandText = new StringBuilder();
                            break;

                        case sequenceEndCharCode:
                            if (commandText != null)
                            {
                                Console.WriteLine("ACK");

                                try
                                {
                                    ICommand command = commandParser.Parse(commandText.ToString());
                                    command.Invoke();
                                }
                                catch (Exception)
                                {
                                    Console.WriteLine("NACK");
                                }
                                commandText = null;
                            }
                            break;

                        default:
                            if (commandText != null)
                            {
                                commandText.Append(keyChar);
                            }
                            break;
                    }
                }
            } while (keyInfo.Key != ConsoleKey.Escape);
        }
    }
}
