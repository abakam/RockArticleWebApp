using System;
namespace RockArticleApp.Models.Responses
{
    public abstract class BaseResponse<T>
    {
        public bool Success { get; private set; }
        public string Message { get; private set; }
        public T Resource { get; private set; }

        /// <summary>
        /// Creates a success response.
        /// </summary>
        protected BaseResponse(T resource)
        {
            Success = true;
            Message = string.Empty;
            Resource = resource;
        }

        /// <summary>
        /// Creates an error response.
        /// </summary>
        protected BaseResponse(string message)
        {
            Success = false;
            Message = message;
            Resource = default;
        }
    }
}
