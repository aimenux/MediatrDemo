using MediatrDemo.Application.UseCases.GetPersons;

namespace MediatrDemo.Api.Presentation.Controllers.V1.GetPersons;

public static class GetPersonsExtensions
{
    public static GetPersonsApiResponse ToApiResponse(this GetPersonsQueryResponse queryResponse)
    {
        return new GetPersonsApiResponse(queryResponse
            .Select(x => new GetPersonApiResponse
            {
                Id = x.Id,
                FullName = x.FullName,
                Email = x.Email
            }));
    }
}
