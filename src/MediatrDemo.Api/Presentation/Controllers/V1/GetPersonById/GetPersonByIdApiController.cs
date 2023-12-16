using MediatR;
using MediatrDemo.Application.UseCases.GetPersonById;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace MediatrDemo.Api.Presentation.Controllers.V1.GetPersonById;

public class GetPersonByIdApiController : PersonsController
{
    public GetPersonByIdApiController(ISender sender, ILogger<PersonsController> logger) : base(sender, logger)
    {
    }

    [HttpGet("{personId}")]
    [SwaggerOperation("GetPersonById")]
    [SwaggerResponse(statusCode: 200, type: typeof(GetPersonByIdApiResponse))]
    [SwaggerResponse(statusCode: 400, type: typeof(ValidationProblemDetails))]
    [SwaggerResponse(statusCode: 500, type: typeof(ProblemDetails))]
    public async Task<IActionResult> GetPersonById(string personId, CancellationToken cancellationToken)
    {
        var query = new GetPersonByIdQuery(personId);
        var queryResponse = await Sender.Send(query, cancellationToken);
        var apiResponse = new GetPersonByIdApiResponse
        {
            Id = queryResponse.Id,
            FullName = queryResponse.FullName,
            Email = queryResponse.Email
        };
        return Ok(apiResponse);
    }
}
