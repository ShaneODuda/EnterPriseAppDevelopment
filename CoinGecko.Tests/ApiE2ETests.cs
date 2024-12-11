using System.Threading.Tasks;
using Microsoft.Playwright;
using Xunit;

namespace CoinGecko.Tests
{
    public class ApiE2ETests
    {
        [Fact]
        public async Task SearchPage_ShouldFilterCryptocurrencies()
        {
            // Initialize Playwright
            using var playwright = await Playwright.CreateAsync();
            var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = true });
            var page = await browser.NewPageAsync();

            // Navigate to the app's URL
            await page.GotoAsync("https://localhost:5001");

            // Simulate typing in the search bar
            await page.FillAsync("#search-input", "Bit");

            // Assert that the filtered results are displayed
            var results = await page.Locator(".crypto-item").AllInnerTextsAsync();
            Assert.Contains("Bitcoin", results);
            Assert.All(results, result => Assert.Contains("Bit", result));

            // Close the browser
            await browser.CloseAsync();
        }
    }
}