namespace WebApiCopyPastUtils.CopyPastUtils.CreateMinimalApiEndpointUtil
{
    /// <summary>
    /// Создание эндпоинт для minimal api
    /// #minimal-api #endpoint
    /// </summary>

    public static class CHANGE_NAME_Endpoint
    {
        public static IEndpointConventionBuilder CHANGE_NAME_(this IEndpointRouteBuilder builder)
        {
            return builder.MapGet("CHANGE_NAME", () => 
            {

            });
        }
    }
}
