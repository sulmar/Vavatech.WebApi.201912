using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace Vavatech.WebApi.Api.ActionResults
{
    public class FileActionResult : IHttpActionResult
    {
        private readonly Stream stream;
        private readonly string filename;
        private readonly HttpRequestMessage httpRequestMessage;

        public FileActionResult(Stream stream, HttpRequestMessage request, string filename)
        {
            this.stream = stream;
            httpRequestMessage = request;
            this.filename = filename;
        }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            HttpResponseMessage httpResponseMessage = httpRequestMessage.CreateResponse(HttpStatusCode.OK);
            httpResponseMessage.Content = new StreamContent(stream);
            httpResponseMessage.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment");
            httpResponseMessage.Content.Headers.ContentDisposition.FileName = filename;
            httpResponseMessage.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");

            return Task.FromResult(httpResponseMessage);
        }

     
    }
}