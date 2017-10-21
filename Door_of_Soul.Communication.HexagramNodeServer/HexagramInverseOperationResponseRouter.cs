namespace Door_of_Soul.Communication.HexagramNodeServer
{
    public abstract class HexagramInverseOperationResponseRouter<TTerminal, TSubject, TInverseOperationCode> : SubjectInverseOperationResponseRouter<TTerminal, TSubject, TInverseOperationCode>
    {
        public static HexagramInverseOperationResponseRouter<TTerminal, TSubject, TInverseOperationCode> Instance { get; private set; }
        public static void Initialize(HexagramInverseOperationResponseRouter<TTerminal, TSubject, TInverseOperationCode> instance)
        {
            Instance = instance;
        }

        protected HexagramInverseOperationResponseRouter(string subjectName) : base(subjectName)
        {
        }
    }
}
