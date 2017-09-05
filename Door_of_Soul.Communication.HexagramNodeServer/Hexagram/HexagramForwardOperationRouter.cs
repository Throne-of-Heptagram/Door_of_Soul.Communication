namespace Door_of_Soul.Communication.HexagramNodeServer.Hexagram
{
    public abstract class HexagramForwardOperationRouter<TForwardOperationCode> : ForwardOperationRouter<TForwardOperationCode>
    {
        public static HexagramForwardOperationRouter<TForwardOperationCode> Instance { get; private set; }
        public static void Initialize(HexagramForwardOperationRouter<TForwardOperationCode> instance)
        {
            Instance = instance;
        }

        protected HexagramForwardOperationRouter(string subjectName) : base(subjectName)
        {

        }
    }
}
