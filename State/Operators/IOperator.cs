namespace State.Operators
{
    public interface IOperator
    {
        void AnswerCall();

        void RejectCall();

        void EndCall();

        void EndCreatingReport();

        void MakeBreak();

        void EndBreak();

        void LogIn();

        void LogOut();
    }
}
