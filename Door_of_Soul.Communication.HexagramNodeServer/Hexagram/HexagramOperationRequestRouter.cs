namespace Door_of_Soul.Communication.HexagramNodeServer.Hexagram
{
    public abstract class HexagramOperationRequestRouter<TEventCode, TOperationCode, TSubject> : OperationRequestRouter<TerminalHexagramEntrance<TEventCode, TOperationCode>, int, int, TSubject, TOperationCode>
    {
        public static HexagramOperationRequestRouter<TEventCode, TOperationCode, TSubject> Instance { get; private set; }
        public static void Initialize(HexagramOperationRequestRouter<TEventCode, TOperationCode, TSubject> instance)
        {
            Instance = instance;
        }
    }
}
