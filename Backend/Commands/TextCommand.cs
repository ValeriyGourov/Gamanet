using System;

namespace Backend.Commands
{
    class TextCommand : ICommand
    {
        private string text;    // Выводимый текст.

        public TextCommand(string parameters)
        {
            text = parameters;
        }

        public void Invoke()
        {
            Console.WriteLine(text);
        }
    }
}
