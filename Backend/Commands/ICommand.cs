namespace Backend.Commands
{
    interface ICommand
    {
        /// <summary>
        /// Вызов команды на выполнение.
        /// </summary>
        void Invoke();
    }
}
