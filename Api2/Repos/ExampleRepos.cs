using Microsoft.AspNetCore.Components.RenderTree;

namespace Api2.Repos;

public class ExampleRepos
{
    public async Task<Result> ExampleMethod(CancellationToken cancellation)
    {
        try
        {
            await Task.Delay(3000, cancellation);
            return new Result
            {
                Success = true
            };
        }
        catch (OperationCanceledException ex)
        {
            return new Result
            {
                Success = false,
                ErrorType = "Cancellation"
            };
        }
        catch (Exception e)
        {
            return new Result
            {
                Success = false,
                ErrorType = "Global"
            };
        }
    }
}