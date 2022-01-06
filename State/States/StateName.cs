namespace State.States
{
    public static class StateName
    {
        public const string FREE = "СВОБОДНЫЙ";
        public const string HANDLES_CONVERSATION = "ОБСЛУЖИВАНИЕ КЛИЕНТА";
        public const string WRAP_UP = "ПОДГОТОВКА ОТЧЕТА";
        public const string BREAK = "ПЕРЕРЫВ";
        public const string LOGOUT = "ВНЕ СИСТЕМЫ";
    }
}
