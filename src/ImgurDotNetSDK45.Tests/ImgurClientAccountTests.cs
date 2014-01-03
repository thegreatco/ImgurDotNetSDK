using System;
using System.Threading.Tasks;
using ImgurDotNetSDK;
using NUnit.Framework;

namespace ImgurDotNetSDK45.Tests
{
    [TestFixture]
    public class ImgurClientAccountTests
    {
        private ImgurClient _client;

        [TestFixtureSetUp]
        public void SetUp()
        {
            _client = new ImgurClient(TestSettings.Settings, TestSettings.Credentials);
        }

        [Test]
        public void AccountBase()
        {
            Assert.Throws<ArgumentNullException>(() => _client.AccountBase(string.Empty));
            Assert.Throws<ArgumentNullException>(() => _client.AccountBase(null));
            Assert.DoesNotThrow(async () => await _client.AccountBase());
        }
    }
}
