using System.Text.Json;

using FluentAssertions;

namespace AAS.TwinEngine.Plugin.TestPlugin.PlaywrightTests.AasRegistry;

/// <summary>
/// Tests for AAS Registry endpoints
/// </summary>
public class AasRegistryTests : ApiTestBase
{
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
        content.Should().NotBeNullOrEmpty();
        
        var json = JsonDocument.Parse(content);
        json.Should().NotBeNull();
    }

    [Fact]
    public async Task GetAllShellDescriptors_WithPagination_ShouldReturnSuccess()
    {
        // Arrange
        var url = "/shell-descriptors?limit=10";

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
    public async Task GetShellDescriptorById_ShouldReturnSuccess()
    {
        // Arrange
        var url = $"/shell-descriptors/{AasIdentifier}";

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
