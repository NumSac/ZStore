using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ZStore.WebApi;

namespace ZStore.Presentation.Controllers
{
    public class MetaController : BaseApiController
    {
        [HttpGet("/info")]
        [AllowAnonymous]
        public ActionResult<string> Info()
        {
            var assembly = typeof(Startup).Assembly;

            var lastUpdate = System.IO.File.GetLastWriteTime(assembly.Location);
            var version = FileVersionInfo.GetVersionInfo(assembly.Location).FileVersion;

            return Ok($"Version: {version}, Last Updated: {lastUpdate}");
        }
    }
}
