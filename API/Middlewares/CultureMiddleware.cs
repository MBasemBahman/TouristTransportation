namespace API.Middlewares
{
    public class CultureMiddleware
    {
        private readonly RequestDelegate _next;

        public CultureMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            string culture = context.Request.Headers[HeadersConstants.Culture].FirstOrDefault()?.Split(" ").Last();

            if (culture != null && Enum.IsDefined(typeof(LanguageEnum), culture))
            {
                context.Items[ApiConstants.Language] = Enum.Parse<LanguageEnum>(culture.ToLower());
            }
            else
            {
                context.Items[ApiConstants.Language] = null;
            }
            
            await _next(context);
        }
    }
}
