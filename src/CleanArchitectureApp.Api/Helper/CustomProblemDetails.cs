using Microsoft.AspNetCore.Mvc;

namespace CleanArchitectureApp.Api.Helper
{
    public class CustomProblemDetails : ProblemDetails
    {
        public IDictionary<string, string[]> Errors { get; set; } =
            new Dictionary<string, string[]>();
    }
}
