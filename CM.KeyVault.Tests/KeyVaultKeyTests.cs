using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace CM.KeyVault.Tests
{
    public class KeyVaultKeyTests
    {
        private const string clientId = "1bbb4fd3-e903-4b00-afcb-afb9582b68b8";
        private const string clientSecret = "9wDEgDndxLkxvZzuVm78Ux4cUcY/sYTt3kW77N3SLSA=";
        private const string keyVaultUri = @"https://CmTestVault1.vault.azure.net";

        private const string testKeyName = "unitTestKey";

        [Fact]
        public void Should_Construct()
        {
            var kvService = new KeyVaultService(clientId, clientSecret, keyVaultUri);
        }

        [Fact]
        public async Task Should_CreateKey()
        {
            var kvService = new KeyVaultService(clientId, clientSecret, keyVaultUri);
            var keyBundle = await kvService.CreateKey(testKeyName);

            Assert.NotNull(keyBundle);
        }

        [Fact]
        public async Task Should_RetrieveKey()
        {
            var kvService = new KeyVaultService(clientId, clientSecret, keyVaultUri);
            var keyBundle = await kvService.GetKey(testKeyName);
        }

        [Fact]
        public async Task Should_RetrieveAllkeys()
        {
            var kvService = new KeyVaultService(clientId, clientSecret, keyVaultUri);
            var keys = await kvService.GetKeys();

            Assert.True(keys.ToList().Count > 0);
        }

        [Fact]
        public async Task Should_DeleteKey()
        {
            var keyToDelete = "mySampleKeyToDelete";
            var kvService = new KeyVaultService(clientId, clientSecret, keyVaultUri);
            var keyBundle = await kvService.CreateKey(keyToDelete);

            var result = await kvService.DeleteKey(keyToDelete);

            Assert.NotNull(result);
        }
    }
}
