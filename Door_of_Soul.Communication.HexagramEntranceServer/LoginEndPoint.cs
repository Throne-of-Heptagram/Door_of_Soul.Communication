namespace Door_of_Soul.Communication.HexagramEntranceServer
{
    public class LoginEndPoint : TerminalEndPoint
    {
        internal LoginEndPoint(int endPointId, SendEventDelegate sendEventMethod, SendOperationResponseDelegate sendOperationResponseMethod, SendInverseOperationRequestDelegate sendInverseOperationRequestMethod) : base(endPointId, sendEventMethod, sendOperationResponseMethod, sendInverseOperationRequestMethod)
        {
        }

        public override string ToString()
        {
            return $"{base.ToString()} Type: Login";
        }
    }
}
