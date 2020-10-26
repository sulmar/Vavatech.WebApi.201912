using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Http;
using Vavatech.WebApi.Api.ActionResults;

namespace Vavatech.WebApi.Api.Controllers
{
    [RoutePrefix("api/files")]
    public class FilesController : ApiController
    {
        [HttpGet]
        [Route("{filename}.{ext}")]
        [Route("{filename}")]
        public IHttpActionResult Get(string filename)
        {
            filename += ".zip";

            string directory = HttpContext.Current.Server.MapPath("~/");

            string path = Path.Combine(directory, "StaticFiles", filename);

            var bytes = File.ReadAllBytes(path);

            Stream stream = new MemoryStream(bytes);

            return new FileActionResult(stream, this.Request, filename);
        }
    }
}