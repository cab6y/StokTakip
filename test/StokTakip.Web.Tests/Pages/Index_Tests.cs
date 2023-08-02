using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace StokTakip.Pages;

public class Index_Tests : StokTakipWebTestBase
{
    [Fact]
    public async Task Welcome_Page()
    {
        var response = await GetResponseAsStringAsync("/");
        response.ShouldNotBeNull();
    }
}
