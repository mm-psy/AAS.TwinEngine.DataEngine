using FluentAssertions;

using System.Text.Json;

namespace AAS.TwinEngine.Plugin.TestPlugin.PlaywrightTests.SubmodelRepository;

/// <summary>
/// Tests for Submodel endpoints
/// </summary>
public class SubmodelTests : ApiTestBase
{
    [Fact]
    public async Task GetSubmodel_Nameplate_ShouldReturnSuccess()
    {
        // Arrange
        var url = $"/submodels/{SubmodelIdentifierNameplate}/";

        // Act
        var response = await ApiContext.GetAsync(url);

        // Assert
        AssertSuccessResponse(response);
        var content = await response.TextAsync();
        content.Should().NotBeNullOrEmpty();
        
        var json = JsonDocument.Parse(content);
        json.Should().NotBeNull();
    }

    [Fact]
    public async Task GetSubmodel_ContactInfo_ShouldReturnSuccess()
    {
        // Arrange
        var url = $"/submodels/{SubmodelIdentifierContact}/";

        // Act
        var response = await ApiContext.GetAsync(url);

        // Assert
        AssertSuccessResponse(response);
        var content = await response.TextAsync();
        content.Should().NotBeNullOrEmpty();
        
        var json = JsonDocument.Parse(content);
        json.Should().NotBeNull();
    }

    [Fact]
    public async Task GetSubmodel_Reliability_ShouldReturnSuccess()
    {
        // Arrange
        var url = $"/submodels/{SubmodelIdentifierReliability}/";

        // Act
        var response = await ApiContext.GetAsync(url);

        // Assert
        AssertSuccessResponse(response);
        var content = await response.TextAsync();
        content.Should().NotBeNullOrEmpty();
        
        var json = JsonDocument.Parse(content);
        json.Should().NotBeNull();
    }
}
