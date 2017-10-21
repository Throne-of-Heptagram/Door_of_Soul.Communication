namespace Door_of_Soul.Communication.HexagramNodeServer
{
    public abstract class HexagramInverseEventRouter<TTerminal, TSubject, TInverseEventCode> : SubjectInverseEventRouter<TTerminal, TSubject, TInverseEventCode>
    {
        public static HexagramInverseEventRouter<TTerminal, TSubject, TInverseEventCode> Instance { get; private set; }
        public static void Initialize(HexagramInverseEventRouter<TTerminal, TSubject, TInverseEventCode> instance)
        {
            Instance = instance;
        }

        protected HexagramInverseEventRouter(string subjectName) : base(subjectName)
        {
        }
    }
}
