﻿namespace Door_of_Soul.Communication.HexagramNodeServer.HexagramCentral
{
    public abstract class HexagramForwardOperationRouter<TForwardOperationCode> : BasicForwardOperationRouter<TForwardOperationCode>
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
