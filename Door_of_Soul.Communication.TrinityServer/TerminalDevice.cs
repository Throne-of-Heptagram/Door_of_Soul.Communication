using Door_of_Soul.Communication.Protocol.External.Device;
using Door_of_Soul.Core.Protocol;
using System;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.TrinityServer
{
    public class TerminalDevice
    {
        public delegate void SendEventDelegate(DeviceEventCode eventCode, Dictionary<byte, object> parameters);
        public delegate void SendOperationResponseDelegate(DeviceOperationCode operationCode, OperationReturnCode returnCode, string operationMessage, Dictionary<byte, object> parameters);

        public event Action<TerminalDevice, TerminalAnswer> OnAnswerLinked;
        public event Action<TerminalDevice, TerminalAnswer> OnAnswerUnlinked;

        public int DeviceId { get; private set; }
        public TerminalAnswer Answer { get; private set; }
        public SendEventDelegate SendEvent { get; private set; }
        public SendOperationResponseDelegate SendOperationResponse { get; private set; }

        public TerminalDevice(int deviceId, SendEventDelegate sendEventMethod, SendOperationResponseDelegate sendOperationResponseMethod)
        {
            DeviceId = deviceId;
            SendEvent = sendEventMethod;
            SendOperationResponse = sendOperationResponseMethod;
        }

        public bool IsAnswerLinked(int answerId)
        {
            return Answer?.AnswerId == answerId;
        }
        public bool LinkAnswer(TerminalAnswer answer)
        {
            if (Answer != answer)
            {
                if (Answer != null)
                {
                    UnlinkAnswer();
                }
                Answer = answer;
                if (!Answer.IsDeviceLinked(this))
                {
                    Answer.LinkDevice(this);
                }
                OnAnswerLinked?.Invoke(this, Answer);
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool UnlinkAnswer()
        {
            if (Answer != null)
            {
                if (Answer.IsDeviceLinked(this))
                {
                    Answer.UnlinkDevice(this);
                }
                TerminalAnswer answer = Answer;
                Answer = null;
                OnAnswerUnlinked?.Invoke(this, answer);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
