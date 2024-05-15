using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TestProjectMultipleApp
{
    public class UnitTest : TestBase
    {
        [Fact]
        public async Task StringPaddingTest()
        {

            var lResult = await ClientX.GetAsync(UrlBuilders.DN7Test());
            Assert.Equal("OK", lResult.StatusCode.ToString());

            
            var rResult = await ClientY.GetAsync(UrlBuilders.DN5Test());
            Assert.Equal("OK", rResult.StatusCode.ToString());

        }
    }
}
