namespace AAS.TwinEngine.Plugin.TestPlugin.PlaywrightTests;

/// <summary>
/// Configuration settings for API tests
/// </summary>
public static class TestConfiguration
{
    public static string DataEngineBaseUrl => Environment.GetEnvironmentVariable("DATA_ENGINE_BASE_URL") 
        ?? "http://localhost:8085";

    // Plain identifiers
    public const string AasIdentifierPlain = "https://mm-software.com/ids/aas/000-001";
    public const string SubmodelIdentifierContactPlain = "https://mm-software.com/submodel/000-001/ContactInformation";
    public const string SubmodelIdentifierNameplatePlain = "https://mm-software.com/submodel/000-001/Nameplate";
    public const string SubmodelIdentifierReliabilityPlain = "https://mm-software.com/submodel/000-001/Reliability";
}
