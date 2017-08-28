namespace Door_of_Soul.Communication.HexagramNodeServer.Hexagram
{
    public abstract class HexagramOperationRequestRouter<TOperationCode> : OperationRequestRouter<TerminalHexagramEntrance, TOperationCode>
    {
        public static HexagramOperationRequestRouter<TOperationCode> Instance { get; private set; }
        public static void Initial(HexagramOperationRequestRouter<TOperationCode> instance)
        {
            Instance = instance;
        }

        protected HexagramOperationRequestRouter(string subjectName) : base(subjectName)
        {

        }
    }
}
