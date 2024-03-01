using MediatR;
using MediatrDemo.Application.UseCases.GetPersons;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace MediatrDemo.Api.Presentation.Controllers.V1.GetPersons;

public class GetPersonsApiController : PersonsController
{
    public GetPersonsApiController(ISender sender, ILogger<PersonsController> logger) : base(sender, logger)
    {
    }

    [HttpGet]
    [SwaggerOperation("GetPersons")]
    [SwaggerResponse(statusCode: 200, type: typeof(GetPersonsApiResponse))]
    [SwaggerResponse(statusCode: 500, type: typeof(ProblemDetails))]
    public async Task<IActionResult> GetPersons(CancellationToken cancellationToken)
    {
        var query = new GetPersonsQuery();
        var queryResponse = await Sender.Send(query, cancellationToken);
        var apiResponse = queryResponse.ToApiResponse();
        return Ok(apiResponse);
    }
}
