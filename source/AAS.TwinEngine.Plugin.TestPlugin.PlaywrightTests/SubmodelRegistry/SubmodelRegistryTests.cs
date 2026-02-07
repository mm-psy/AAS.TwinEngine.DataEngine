using System.Text.Json;

using FluentAssertions;

namespace AAS.TwinEngine.Plugin.TestPlugin.PlaywrightTests.SubmodelRegistry;

/// <summary>
/// Tests for Submodel Registry endpoints
/// </summary>
public class SubmodelRegistryTests : ApiTestBase
{
    [Fact]
    public async Task GetSubmodelDescriptorById_Contact_ShouldReturnSuccess()
    {
        // Arrange
        var url = $"/submodel-descriptors/{SubmodelIdentifierContact}";

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
    public async Task GetSubmodelDescriptorById_Nameplate_ShouldReturnSuccess()
    {
        // Arrange
        var url = $"/submodel-descriptors/{SubmodelIdentifierNameplate}";

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
    public async Task GetSubmodelDescriptorById_Reliability_ShouldReturnSuccess()
    {
        // Arrange
        var url = $"/submodel-descriptors/{SubmodelIdentifierReliability}";

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
