using System.Net;
using System.Text.Json;

namespace MyTheFourth.Frontend.Http.Handlers;


public class BackendHandler : DelegatingHandler
{
    protected override async Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        try
        {
            return await base.SendAsync(request, cancellationToken);
        }
        catch (System.Exception ex)
        {

            var errorResponse = new HttpResponseMessage(HttpStatusCode.InternalServerError)
            {
                Content = new StringContent(JsonSerializer.Serialize(new
                {
                    error = ex.Message,
                }))
            };

            return errorResponse;
        }


    }

}