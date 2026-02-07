using System.Text.Json;

namespace AAS.TwinEngine.Plugin.TestPlugin.PlaywrightTests.SubmodelRepository;

/// <summary>
/// Tests for appropriate serialization endpoints
/// </summary>
public class SerializationTests : ApiTestBase
{
    [Fact]
    public async Task GetAppropriateSerialization_WithMultipleSubmodels_ShouldReturnSuccess()
    {
        // Arrange
        var url = $"/serialization" +
                  $"?aasIds={AasIdentifier}" +
                  $"&submodelIds={SubmodelIdentifierContact}" +
                  $"&submodelIds={SubmodelIdentifierNameplate}" +
                  $"&submodelIds={SubmodelIdentifierReliability}" +
                  $"&includeConceptDescriptions=false";

        // Act
        var response = await ApiContext.GetAsync(url);

        // Assert
        AssertSuccessResponse(response);
        var content = await response.TextAsync();
        Assert.False(string.IsNullOrEmpty(content));
        
        var json = JsonDocument.Parse(content);
        Assert.NotNull(json);
    }

    [Fact]
    public async Task GetAppropriateSerialization_WithSingleSubmodel_ShouldReturnSuccess()
    {
        // Arrange
        var url = $"/serialization" +
                  $"?aasIds={AasIdentifier}" +
                  $"&submodelIds={SubmodelIdentifierNameplate}" +
                  $"&includeConceptDescriptions=false";

        // Act
        var response = await ApiContext.GetAsync(url);

        // Assert
        AssertSuccessResponse(response);
        var content = await response.TextAsync();
        Assert.False(string.IsNullOrEmpty(content));
        
        var json = JsonDocument.Parse(content);
        Assert.NotNull(json);
    }

    [Fact]
    public async Task GetAppropriateSerialization_WithConceptDescriptions_ShouldReturnSuccess()
    {
        // Arrange
        var url = $"/serialization" +
                  $"?aasIds={AasIdentifier}" +
                  $"&submodelIds={SubmodelIdentifierNameplate}" +
                  $"&includeConceptDescriptions=true";

        // Act
        var response = await ApiContext.GetAsync(url);

        // Assert
        AssertSuccessResponse(response);
        var content = await response.TextAsync();
        Assert.False(string.IsNullOrEmpty(content));
        
        var json = JsonDocument.Parse(content);
        Assert.NotNull(json);
    }

    [Fact]
    public async Task GetAppropriateSerialization_OnlyAasId_ShouldReturnSuccess()
    {
        // Arrange
        var url = $"/serialization?aasIds={AasIdentifier}&includeConceptDescriptions=false";

        // Act
        var response = await ApiContext.GetAsync(url);

        // Assert
        AssertSuccessResponse(response);
        var content = await response.TextAsync();
        Assert.False(string.IsNullOrEmpty(content));
        
        var json = JsonDocument.Parse(content);
        Assert.NotNull(json);
    }
}
