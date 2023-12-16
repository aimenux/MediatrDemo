using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MediatrDemo.Api.Presentation.Controllers.V1;

[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/persons")]
public class PersonsController : ControllerBase
{
    protected readonly ISender Sender;
    protected readonly ILogger<PersonsController> Logger;

    public PersonsController(ISender sender, ILogger<PersonsController> logger)
    {
        Sender = sender ?? throw new ArgumentNullException(nameof(sender));
        Logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }
}
