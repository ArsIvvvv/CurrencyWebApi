using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CurrencyTerminal.App.Common
{
    public class Result
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Error { get; }
        public bool IsSuccess { get; }

        protected Result()
        {
            IsSuccess = true;
            Error = default;
        }

        protected Result(string error)
        {
            IsSuccess = false;
            Error = error;
        }

        public static Result Success() => new();
        public static Result Failure(string error) => new(error);
    }

    public sealed class Result<TValue> : Result
    {
        private readonly TValue? _value;

        public TValue Value =>
            IsSuccess ? _value!
            : throw new InvalidOperationException("Значение не может быть получено при отрицательном флаге IsSuccess");

        private Result(TValue value) : base() => _value = value;
        private Result(string error) : base(error) => _value = default;

        public static Result<TValue> Success(TValue value) => new(value);
        public static Result<TValue> Failure(string error) => new(error);
    }
}
