namespace Pet_Doc_BE
{
    public static class WebExtensions
    {
        public static async Task<IResult> SafeExecute<T>(this Task<T> requestProcessor,
            Func<IResult> responseOptions)
        {
            try 
            { 
                var result = await requestProcessor;

                return result is not null ? Results.Ok(result): responseOptions();
            }
            catch(Exception ex)
            {
                return Results.Problem("Something went wrong processing the requestse",null,200); 
            }
        }
    }
}
