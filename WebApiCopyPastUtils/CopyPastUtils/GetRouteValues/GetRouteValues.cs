namespace WebApiCopyPastUtils.CopyPastUtils.GetRouteValues
{
    //#minimal api #controllers #mvc
    public static class GetRouteValues
    {
        /// <summary>
        /// Возвращает в виде словаря параметры из маршрута
        /// </summary>
        /// <param name="httpContext">Контекст текущего запроса</param>
        /// <returns></returns>
        public static IDictionary<string, string> GetBadrequestParameters(HttpContext httpContext)
        {
            var result = httpContext.Request.RouteValues
                .Select(p => new KeyValuePair<string, string>
                    (p.Key, p.Value?.ToString() ?? string.Empty))
                //Нужно чтобы убрать лишние параметры
                .Where(p => p.Key != "action" && p.Key != "controller")
                .ToDictionary();
            return result;
        }


        /// <summary>
        /// Возвращает в виде словаря параметры из маршрута
        /// </summary>
        /// <param name="httpContext">Контекст текущего запроса</param>
        /// <param name="parametersName">Параметры для текущего запроса</param>
        /// <returns></returns>
        public static IDictionary<string, string> GetBadrequestParameters(HttpContext httpContext, params string[] parametersName)
        {
            var result = httpContext.Request.RouteValues
                .Select(p => new KeyValuePair<string, string>
                    (p.Key, p.Value?.ToString() ?? string.Empty))
                //Нужно чтобы убрать лишние параметры
                .Where(p => parametersName.Contains(p.Key))
                .ToDictionary();
            return result;
        }
    }
}
