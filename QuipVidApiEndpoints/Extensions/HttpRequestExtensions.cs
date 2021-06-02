using System.Text;
using Microsoft.AspNetCore.Http;

namespace QuipVidApiEndpoints.Extensions
{
    public static class HttpRequestExtensions
    {
        private const string SchemeDelimiter = "://";

        public static string GetAbsoluteUrl(this HttpRequest request)
        {
            var scheme = request.Scheme ?? string.Empty;
            var host = request.Host.Value ?? string.Empty;
            var pathBase = request.PathBase.Value ?? string.Empty;
            var path = request.Path.Value ?? string.Empty;

            // PERF: Calculate string length to allocate correct buffer size for StringBuilder.
            var length = scheme.Length + SchemeDelimiter.Length + host.Length
                         + pathBase.Length + path.Length;

            return new StringBuilder(length)
                .Append(scheme)
                .Append(SchemeDelimiter)
                .Append(host)
                .Append(pathBase)
                .Append(path)
                .ToString();
        }
    }
}
