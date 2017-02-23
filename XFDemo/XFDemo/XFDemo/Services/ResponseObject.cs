using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;
using Newtonsoft.Json;

namespace XFDemo.Services
{
    public class ResponseObject
    {
        public ResponseObject()
        { }

        private bool isSuccessResponse;
        private object content;
        private HttpStatusCode statusCode;
        private string statusMessage;

        public bool IsSuccessResponse
        {
            get
            {
                return isSuccessResponse;
            }

            set
            {
                isSuccessResponse = value;
            }
        }

        public object Content
        {
            get
            {
                return content;
            }

            set
            {
                content = value;
            }
        }

        public HttpStatusCode StatusCode
        {
            get
            {
                return statusCode;
            }

            set
            {
                statusCode = value;
            }
        }

        [JsonProperty("message")]
        public string StatusMessage
        {
            get
            {
                return statusMessage;
            }

            set
            {
                statusMessage = value;
            }
        }
    }

    public class ResponseMessage
    {
        private string message;

        public string Message
        {
            get
            {
                return message;
            }

            set
            {
                message = value;
            }
        }
    }
}
