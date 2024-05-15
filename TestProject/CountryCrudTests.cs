namespace TestProject
{
    public class CountryCrudTests : ApiTestBase
    {
        public record CountryTestModel(string Id, string Code, string Name, string DefaultCurrency, string DefaultLocale);

        [Fact]
        public async Task GivenImplementedCountryCrud_WhenDoingCrud_ThenItShouldSucceed()
        {
            // Arrange
            var country = new
            {
                Code = "US",
                Name = "United States of America",
                DefaultLocale = "en-US",
                DefaultCurrency = "USD"
            };

            void AssertCountry(CountryTestModel target)
            {
                Assert.Equal(country.Code, target.Code);
                Assert.Equal(country.Name, target.Name);
                Assert.Equal(country.DefaultCurrency, target.DefaultCurrency);
                Assert.Equal(country.DefaultLocale, target.DefaultLocale);
            }

            // Act
            // Create Country
            var createResult = await Client.PostAsJsonAsync(UrlBuilders.CreateCountryUrl(), country);
            Assert.Equal(HttpStatusCode.Created, createResult.StatusCode);

            var location = createResult.Headers.Location;

            // Get Country
            var getResult = await Client.GetFromJsonAsync<CountryTestModel>(location);
            Assert.NotNull(getResult);
            AssertCountry(getResult);

            // Get All Countries
            var getAllResult = await Client.GetFromJsonAsync<List<CountryTestModel>>(UrlBuilders.GetAllCountriesUrl());
            Assert.NotNull(getAllResult);
            Assert.Single(getAllResult);
            AssertCountry(getAllResult[0]);

            // Update
            country = new
            {
                Code = "IR",
                Name = "Iran",
                DefaultLocale = "fa-IR",
                DefaultCurrency = "IRR"
            };

            var updateResult = await Client.PostAsJsonAsync(UrlBuilders.UpdateCountryUrl(getResult.Id), country);
            Assert.Equal(HttpStatusCode.OK, updateResult.StatusCode);

            // Get Country After Update
            var getAfterUpdateResult =
                await Client.GetFromJsonAsync<CountryTestModel>(UrlBuilders.GetCountryByIdUrl(getResult.Id));
            Assert.NotNull(getAfterUpdateResult);
            AssertCountry(getAfterUpdateResult);

            // Get All Countries After Update
            var getAllAfterUpdateResult =
                await Client.GetFromJsonAsync<List<CountryTestModel>>(UrlBuilders.GetAllCountriesUrl());
            Assert.NotNull(getAllAfterUpdateResult);
            Assert.Single(getAllAfterUpdateResult);
            AssertCountry(getAllAfterUpdateResult[0]);

            // Delete Country
            var deleteResult = await Client.DeleteAsync(UrlBuilders.DeleteCountryUrl(getResult.Id));
            Assert.Equal(HttpStatusCode.OK, deleteResult.StatusCode);

            // Get Country After Delete
            var getAfterDeleteResult = await Client.GetAsync(UrlBuilders.GetCountryByIdUrl(getResult.Id));
            Assert.Equal(HttpStatusCode.NotFound, getAfterDeleteResult.StatusCode);

            // Get All Countries After Delete
            var getAllAfterDeleteResult =
                await Client.GetFromJsonAsync<List<CountryTestModel>>(UrlBuilders.GetAllCountriesUrl());
            Assert.NotNull(getAllAfterDeleteResult);
            Assert.Empty(getAllAfterDeleteResult);
        }
    }

}
