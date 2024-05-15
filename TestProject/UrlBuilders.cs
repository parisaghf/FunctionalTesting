namespace TestProject
{
    public static class UrlBuilders
    {
        public static string CreateCountryUrl() => "/api/countries";
        public static string GetCountryByIdUrl(string id) => $"/api/countries/{id}";
        public static string GetAllCountriesUrl() => "/api/countries";
        public static string UpdateCountryUrl(string id) => $"/api/countries/{id}";
        public static string DeleteCountryUrl(string id) => $"/api/countries/{id}";

    }
}
