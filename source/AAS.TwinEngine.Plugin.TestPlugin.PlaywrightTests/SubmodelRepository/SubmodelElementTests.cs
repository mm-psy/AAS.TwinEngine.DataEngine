using System.Text.Json;

namespace AAS.TwinEngine.Plugin.TestPlugin.PlaywrightTests.SubmodelRepository;

/// <summary>
/// Tests for Submodel Element endpoints
/// </summary>
public class SubmodelElementTests : ApiTestBase
{
    [Theory]
    [InlineData("ManufacturerName")]
    [InlineData("ManufacturerProductDesignation")]
    [InlineData("Address")]
    public async Task GetSubmodelElement_Nameplate_ShouldReturnSuccess(string idShortPath)
    {
        // Arrange
        var url = $"/submodels/{SubmodelIdentifierNameplate}/submodel-elements/{idShortPath}";

        // Act
        var response = await ApiContext.GetAsync(url);

        // Assert
        AssertSuccessResponse(response);
        var content = await response.TextAsync();
        Assert.False(string.IsNullOrEmpty(content));
        
        var json = JsonDocument.Parse(content);
        Assert.NotNull(json);
    }

    [Theory]
    [InlineData("ContactInformation")]
    [InlineData("ContactInformation.RoleOfContactPerson")]
    public async Task GetSubmodelElement_ContactInfo_ShouldReturnSuccess(string idShortPath)
    {
        // Arrange
        var url = $"/submodels/{SubmodelIdentifierContact}/submodel-elements/{idShortPath}";

        // Act
        var response = await ApiContext.GetAsync(url);

        // Assert
        AssertSuccessResponse(response);
        var content = await response.TextAsync();
        Assert.False(string.IsNullOrEmpty(content));
        
        var json = JsonDocument.Parse(content);
        Assert.NotNull(json);
    }

    [Theory]
    [InlineData("MTTF")]
    [InlineData("MTBF")]
    public async Task GetSubmodelElement_Reliability_ShouldReturnSuccess(string idShortPath)
    {
        // Arrange
        var url = $"/submodels/{SubmodelIdentifierReliability}/submodel-elements/{idShortPath}";

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
    public async Task GetSubmodelElement_Markings_ShouldReturnSuccess()
    {
        // Arrange
        var idShortPath = "Markings";
        var url = $"/submodels/{SubmodelIdentifierNameplate}/submodel-elements/{idShortPath}";

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
