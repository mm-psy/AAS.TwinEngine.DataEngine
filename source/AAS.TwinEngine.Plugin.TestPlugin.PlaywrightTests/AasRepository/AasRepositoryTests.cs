using System.Text.Json;

namespace AAS.TwinEngine.Plugin.TestPlugin.PlaywrightTests.AasRepository;

/// <summary>
/// Tests for AAS Repository endpoints
/// </summary>
public class AasRepositoryTests : ApiTestBase
{
    [Fact]
    public async Task GetShellById_ShouldReturnSuccess()
    {
        // Arrange
        var url = $"/shells/{AasIdentifier}";

        // Act
        var response = await ApiContext.GetAsync(url);

        // Assert
        AssertSuccessResponse(response);
        var content = await response.TextAsync();
        Assert.False(string.IsNullOrEmpty(content));

        // Verify it's valid JSON
        var json = JsonDocument.Parse(content);
        Assert.NotNull(json);
    }

    [Fact]
    public async Task GetAssetInformationById_ShouldReturnSuccess()
    {
        // Arrange
        var url = $"/shells/{AasIdentifier}/asset-information";

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
    public async Task GetSubmodelRefById_ShouldReturnSuccess()
    {
        // Arrange
        var url = $"/shells/{AasIdentifier}/submodel-refs";

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
