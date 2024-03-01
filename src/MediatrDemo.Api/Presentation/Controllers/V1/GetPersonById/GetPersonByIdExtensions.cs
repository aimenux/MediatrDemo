using MediatrDemo.Application.UseCases.GetPersonById;

namespace MediatrDemo.Api.Presentation.Controllers.V1.GetPersonById;

public static class GetPersonByIdExtensions
{
    public static GetPersonByIdApiResponse ToApiResponse(this GetPersonByIdQueryResponse queryResponse)
    {
        return new GetPersonByIdApiResponse
        {
            Id = queryResponse.Id, 
            FullName = queryResponse.FullName, 
            Email = queryResponse.Email
        };
    }
}
