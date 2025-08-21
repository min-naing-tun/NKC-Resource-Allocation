namespace NKC_Resource_Allocation.Utilities
{
    public class KeyConfig
    {
        public string? ApiKey { get; set; }

        public string GetApiKey()
        {
            return new ConfigurationBuilder().AddJsonFile("appsettings.json").Build()["APIKey"]!;
        }
    }
}
