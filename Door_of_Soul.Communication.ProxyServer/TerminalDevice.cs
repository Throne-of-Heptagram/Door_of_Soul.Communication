using System;

namespace Door_of_Soul.Communication.ProxyServer
{
    public abstract class TerminalDevice
    {
        public event Action<TerminalDevice, TerminalAnswer> OnAnswerLinked;
        public event Action<TerminalDevice, TerminalAnswer> OnAnswerUnlinked;

        public int DeviceId { get; private set; }
        public TerminalAnswer Answer { get; private set; }

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
