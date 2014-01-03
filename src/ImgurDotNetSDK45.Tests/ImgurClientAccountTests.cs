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
            ImgurAccount account = null;
            Assert.Throws<ArgumentNullException>(() => _client.AccountBase(string.Empty));
            Assert.Throws<ArgumentNullException>(() => _client.AccountBase(null));
            Assert.DoesNotThrow(async () => account = await _client.AccountBase());
            Assert.IsNotNull(account);
            Assert.IsTrue(account.Id != default(long));
            Assert.IsTrue(!string.IsNullOrWhiteSpace(account.Url));
            Assert.IsTrue(account.Created != default(DateTime));
        }

        [Test]
        public void CreateAccount()
        {
            _client.DebugMode = true;
            _client.DebugResponse = 200;

            ImgurAccount account = null;
            Assert.Throws<ArgumentNullException>(() => _client.CreateAccount(string.Empty));
            Assert.Throws<ArgumentNullException>(() => _client.CreateAccount(null));
            Assert.DoesNotThrow(async () => account = await _client.CreateAccount("TestUsername"));
            
            _client.DebugResponse = 500;
            Assert.Throws<ImgurDownException>(async () => account = await _client.CreateAccount("TestUsername"));

            _client.DebugResponse = 400;
            Assert.Throws<ImgurException>(async () => account = await _client.CreateAccount("TestUsername"));
        }
    }
}
