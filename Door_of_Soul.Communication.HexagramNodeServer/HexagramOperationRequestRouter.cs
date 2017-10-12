namespace Door_of_Soul.Communication.HexagramNodeServer
{
    public abstract class HexagramOperationRequestRouter<TTerminal, TSubject, TOperationCode> : SubjectOperationRequestRouter<TTerminal, TSubject, TOperationCode>
    {
        public static HexagramOperationRequestRouter<TTerminal, TSubject, TOperationCode> Instance { get; private set; }
        public static void Initialize(HexagramOperationRequestRouter<TTerminal, TSubject, TOperationCode> instance)
        {
            Instance = instance;
        }

        protected HexagramOperationRequestRouter(string subjectName) : base(subjectName)
        {
        }
    }
}
