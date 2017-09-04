namespace Door_of_Soul.Communication.HexagramNodeServer.Hexagram
{
    public abstract class HexagramOperationRequestRouter<TEventCode, TOperationCode> : OperationRequestRouter<TerminalHexagramEntrance<TEventCode, TOperationCode>, TOperationCode>
    {
        public static HexagramOperationRequestRouter<TEventCode, TOperationCode> Instance { get; private set; }
        public static void Initial(HexagramOperationRequestRouter<TEventCode, TOperationCode> instance)
        {
            Instance = instance;
        }

        protected HexagramOperationRequestRouter(string subjectName) : base(subjectName)
        {

        }
    }
}
