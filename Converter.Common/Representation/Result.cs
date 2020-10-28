using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Converter.Common.Representation
{
    public class Result<T> where T : class
    {
        public Result() { }

        public Result(T data)
        {
            Data = data;
            Messages = null;
            Error = null;
        }

        public Result(ResultErrorCode errorCode) : this(errorCode, null)
        {
        }

        public Result(IEnumerable<ResultMessage> messages)
        {
            Data = null;
            
            Messages = messages;
            Error = new ResultError(ResultErrorCode.UnprocessableData);
        }

        public Result(ResultErrorCode errorCode, IEnumerable<ResultMessage> messages)
        {
            Data = null;
          
            Messages = messages;
            Error = new ResultError(errorCode);
        }

        public object FirstOrDefault()
        {
            throw new NotImplementedException();
        }

        public Result(ResultErrorCode errorCode, IEnumerable<ResultMessage> messages, T data)
        {
            Data = data;
            Messages = messages;
            Error = new ResultError(errorCode);
        }

        [JsonProperty]
        public bool Success
        {
            get
            {
                return this.Error == null && (this.Messages == null || this.Messages.Count() == 0) ? true : false;
            }
        }


        [JsonProperty]
        public IEnumerable<ResultMessage> Messages { get; private set; }

        [JsonProperty]
        public ResultError Error { get; private set; }

        [JsonProperty]
        public T Data { get; private set; }
    }

    public class ResultMessage
    {
        public ResultMessage(int index, string message)
        {
            Index = index;
            Message = message;
        }

        [JsonProperty]
        public int Index { get; }

        [JsonProperty]
        public string Message { get; }
    }

    public class ResultError
    {
        public ResultError(ResultErrorCode code)
        {
            this.Code = code;
        }

        [JsonProperty]
        public ResultErrorCode Code { get; }

    }

    public enum ResultErrorCode
    {
        [Description("Informação não encontrada")]
        NotFound = 404,

        [Description("Informação não processada")]
        UnprocessableData = 422,

        [Description("Ocorreu um erro interno")]
        InternalServerError = 500,

        [Description("Tipo de Token inválido")]
        InvalidTokenType = 411,

        [Description("Acesso não autorizado")]
        Unauthorized = 401,

        [Description("Token inválido")]
        InvalidToken = 402,

        [Description("Repositório apenas de leitura")]
        ReadOnlyRepository = 461,

        [Description("Acesso Negado")]
        Forbidden = 403,

        [Description("Método não permitido")]
        NotAllowed = 405,

        [Description("Cliente não possui benefício ativo/válido")]
        BenefitNotAvailable = 407,

        [Description("Acesso expirado")]
        Expired = 410,

        [Description("Usuário bloqueado")]
        UserBlocked = 423,

        [Description("Usuário sem acesso na data")]
        UserAccessPeriodInvalid = 451,

        [Description("CNPJ divergente")]
        InvalidCnpj = 406,

        [Description("Conflito de informações")]
        Conflict = 409
    }
}
