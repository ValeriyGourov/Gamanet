using System;

namespace Backend.Commands
{
    class SoundCommand : ICommand
    {
        #region Private Fields

        /// <summary>
        /// Разделитель параметров команды.
        /// </summary>
        private const char parameterSeparator = ',';

        /// <summary>
        /// Длительность воспроизводимого звука.
        /// </summary>
        private int duration;

        /// <summary>
        /// Частота воспроизводимого звука.
        /// </summary>
        private int frequency;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Конструктор команды. Команда должны иметь два обязательных параметра, разделённых символом ",".
        /// </summary>
        /// <param name="parameters">Параметры команды, разделённые символом ",". Каждый параметр представляет из себя целое число. Первый параметр представляет собой частоту воспроизводимого звука, а второй - его длительность.</param>
        public SoundCommand(string parameters)
        {
            var paramsArray = parameters.Split(parameterSeparator);
            if (paramsArray.Length != 2)
            {
                throw new ArgumentException("Для команды предусмотрено только два параметра, разделённые запятой.");
            }

            try
            {
                frequency = int.Parse(paramsArray[0]);
            }
            catch (Exception e)
            {
                throw new ArgumentException("Указано некорректное значение для частоты.", e);
            }

            try
            {
                duration = int.Parse(paramsArray[1]);
            }
            catch (Exception e)
            {
                throw new ArgumentException("Указано некорректное значение для длительности.", e);
            }
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        /// Выполнение команды.
        /// </summary>
        public void Invoke()
        {
            Console.Beep(frequency, duration);
        }

        #endregion Public Methods
    }
}
