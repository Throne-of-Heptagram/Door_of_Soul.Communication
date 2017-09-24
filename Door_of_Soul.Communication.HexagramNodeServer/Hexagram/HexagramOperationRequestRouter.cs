namespace Door_of_Soul.Communication.HexagramNodeServer.Hexagram
{
    public abstract class HexagramOperationRequestRouter<TEventCode, TOperationCode, TSubject> : SubjectOperationRequestRouter<TerminalHexagramEntrance<TEventCode, TOperationCode>, TSubject, TOperationCode>
    {
        public static HexagramOperationRequestRouter<TEventCode, TOperationCode, TSubject> Instance { get; private set; }
        public static void Initialize(HexagramOperationRequestRouter<TEventCode, TOperationCode, TSubject> instance)
        {
            Instance = instance;
        }

        protected HexagramOperationRequestRouter(string subjectName) : base(subjectName)
        {
        }
    }
}
