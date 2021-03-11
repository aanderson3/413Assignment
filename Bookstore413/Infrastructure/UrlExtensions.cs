using System;
using Microsoft.AspNetCore.Http;

namespace Bookstore413.Infrastructure
{
    public static class UrlExtensions
    {
        //generate a url to return to the browser after the cart is updated
        public static string PathAndQuery(this HttpRequest request) =>
            request.QueryString.HasValue ? $"{request.Path}{request.QueryString}" : request.Path.ToString();
    }
}
