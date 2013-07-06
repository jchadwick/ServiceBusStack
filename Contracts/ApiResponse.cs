using System.Collections.Generic;

namespace Contracts
{
    public class ApiResponse
    {
        public bool Success { get; set; }

        public ApiError[] Errors
        {
            get { return _errors.ToArray(); }
        }
        private readonly List<ApiError> _errors;

        public ApiResponse()
        {
            _errors = new List<ApiError>();
        }

        public void AddError(ApiError error)
        {
            _errors.Add(error);
        }
    }
}