using Door_of_Soul.Communication.LoginServer.Device;
using Door_of_Soul.Communication.Protocol.External.System;
using Door_of_Soul.Communication.Protocol.External.System.OperationResponseParameter;
using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.LoginServer.System
{
    public static class SystemOperationResponseApi
    {
        public static void SendOperationResponse(TerminalDevice terminal, SystemOperationCode operationCode, OperationReturnCode operationReturnCode, string operationMessage, Dictionary<byte, object> parameters)
        {
            DeviceOperationResponseApi.SystemOperationResponse(terminal, operationCode, operationReturnCode, operationMessage, parameters);
        }

        public static void Login(TerminalDevice terminal, OperationReturnCode returnCode, string operationMessage, string trinityServerAddress, int trinityServerPort, string trinityServerApplicationName, int answerId, string answerAccessToken)
        {
            Dictionary<byte, object> operationResponseParameters = new Dictionary<byte, object>
            {
                { (byte)LoginResponseParameterCode.TrinityServerAddress, trinityServerAddress },
                { (byte)LoginResponseParameterCode.TrinityServerPort, trinityServerPort },
                { (byte)LoginResponseParameterCode.TrinityServerAddress, trinityServerApplicationName },
                { (byte)LoginResponseParameterCode.AnswerId, answerId },
                { (byte)LoginResponseParameterCode.AnswerAccessToken, answerAccessToken }
            };
            SendOperationResponse(terminal, SystemOperationCode.Login, returnCode, operationMessage, operationResponseParameters);
        }
    }
}
