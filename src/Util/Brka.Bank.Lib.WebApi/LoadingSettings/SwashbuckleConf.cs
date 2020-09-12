namespace Brka.Bank.Lib.WebApi.LoadingSettings
{
    public class SwashbuckleConf
    {
        public string ApiName { get; set; }
        public string ApiDescription { get; set; }
        public string Version { get; set; }
        public string UriWebSite { get; set; }
        public string MadeBy { get; set; }
        public string Email { get; set; }

        public string ApiDefinition => ApiName + " " + Version;
        public string PathSwagger => "/swagger/v1/swagger.json";
    }
}