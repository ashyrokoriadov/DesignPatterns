namespace State.States
{
    public interface IOperatorState
    {
        /// <summary>
        /// Оператор делает перерыв в работе.
        /// </summary>
        bool MakeBreak();

        /// <summary>
        /// Оператор отвечает на звонок.
        /// </summary>
        bool Answer();

        /// <summary>
        /// Оператор сбрасывает звонок.
        /// </summary>
        bool Reject();

        /// <summary>
        /// Оператор делает короткий отчет после звонка.
        /// </summary>
        bool WrapUp();

        /// <summary>
        /// Оператор заканчивает звонок.
        /// </summary>
        bool End();

        /// <summary>
        /// Название состояния
        /// </summary>
        string Name { get; }
    }
}
