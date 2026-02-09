using System.Text.Json;

namespace AAS.TwinEngine.Plugin.TestPlugin.PlaywrightTests.AasRegistry;

/// <summary>
/// Tests for AAS Registry endpoints
/// </summary>
public class AasRegistryTests : ApiTestBase
{
    private static readonly JsonSerializerOptions JsonSerializerOptions = new() { WriteIndented = false };

    [Fact]
    public async Task GetAllShellDescriptors_ShouldReturnSuccess()
    {
        // Arrange
        var url = "/shell-descriptors";

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
    public async Task GetAllShellDescriptors_WithPagination()
    {
        // Arrange
        var urlLimit2 = "/shell-descriptors?limit=2";
        var urlLimit3 = "/shell-descriptors?limit=3";

        // Act
        var responseLimit2 = await ApiContext.GetAsync(urlLimit2);
        var responseLimit3 = await ApiContext.GetAsync(urlLimit3);

        // Assert
        AssertSuccessResponse(responseLimit2);
        AssertSuccessResponse(responseLimit3);
        
        var contentLimit2 = await responseLimit2.TextAsync();
        var contentLimit3 = await responseLimit3.TextAsync();
        
        Assert.False(string.IsNullOrEmpty(contentLimit2));
        Assert.False(string.IsNullOrEmpty(contentLimit3));
        
        var jsonLimit2 = JsonDocument.Parse(contentLimit2);
        var jsonLimit3 = JsonDocument.Parse(contentLimit3);
        
        Assert.NotNull(jsonLimit2);
        Assert.NotNull(jsonLimit3);
        
        // Verify that limit 3 contains one more element than limit 2
        var resultLimit2 = jsonLimit2.RootElement.GetProperty("result");
        var resultLimit3 = jsonLimit3.RootElement.GetProperty("result");
        
        var countLimit2 = resultLimit2.GetArrayLength();
        var countLimit3 = resultLimit3.GetArrayLength();
        
        Assert.Equal(countLimit2 + 1, countLimit3);
    }

    [Fact]
    public async Task GetShellDescriptorById_ShouldReturnSuccess_ContentAsExpected()
    {
        // Arrange
        var url = $"/shell-descriptors/{AasIdentifier}";
        var fullPath = Path.Combine(Directory.GetCurrentDirectory(), "AasRegistry", "TestData", "GetShellDescriptorById_Expected.json");

        // Act
        var response = await ApiContext.GetAsync(url);

        // Assert
        AssertSuccessResponse(response);
        var content = await response.TextAsync();
        Assert.False(string.IsNullOrEmpty(content));
        
        // Load expected test data and compare
        var expectedJson = await File.ReadAllTextAsync(fullPath);
        
        var expectedDoc = JsonDocument.Parse(expectedJson);
        var actualDoc = JsonDocument.Parse(content);
        
        Assert.NotNull(expectedDoc);
        Assert.NotNull(actualDoc);
        
        // Compare JSON content (normalize formatting for comparison)
        var expectedNormalized = JsonSerializer.Serialize(expectedDoc, JsonSerializerOptions);
        var actualNormalized = JsonSerializer.Serialize(actualDoc, JsonSerializerOptions);
        Assert.Equal(expectedNormalized, actualNormalized);
    }
}
