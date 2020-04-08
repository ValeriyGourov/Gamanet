using System;

namespace Backend.Commands
{
    class CommandParser
    {
        private const char colonChar = (char)58;

        public ICommand Parse(string commandText)
        {
            var commandParts = commandText.Split(colonChar, StringSplitOptions.RemoveEmptyEntries);
            if (commandParts.Length != 2)
            {
                throw new ArgumentException("Некорректные данные пакета команды.");
            }

            ICommand command = null;
            string commandParameters = commandParts[1];
            switch (commandParts[0])
            {
                case "T":
                    command = new TextCommand(commandParameters);
                    break;

                case "S":
                    try
                    {
                        command = new SoundCommand(commandParameters);
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                    break;

                default:
                    throw new ArgumentException("Неизвестная команда.");
            }

            return command;
        }
    }
}
