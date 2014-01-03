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
            ImgurAccount account = null;
            Assert.Throws<ArgumentNullException>(() => _client.CreateAccount(string.Empty));
            Assert.Throws<ArgumentNullException>(() => _client.CreateAccount(null));

            _client.DebugMode = true;
            _client.DebugResponse = 200;
            Assert.DoesNotThrow(async () => account = await _client.CreateAccount("TestUsername"));
            
            _client.DebugResponse = 500;
            Assert.Throws<ImgurDownException>(async () => account = await _client.CreateAccount("TestUsername"));

            _client.DebugResponse = 400;
            Assert.Throws<ImgurException>(async () => account = await _client.CreateAccount("TestUsername"));

            _client.DebugMode = false;
        }

        [Test]
        public void DeleteAccount()
        {
            ImgurBasic response = null;
            Assert.Throws<ArgumentNullException>(() => _client.DeleteAccount(string.Empty, string.Empty));
            Assert.Throws<ArgumentNullException>(() => _client.DeleteAccount(null, string.Empty));
            Assert.Throws<ArgumentNullException>(() => _client.DeleteAccount(_client.DeleteKey, string.Empty));
            Assert.Throws<ArgumentNullException>(() => _client.DeleteAccount(_client.DeleteKey, null));
            Assert.Throws<ArgumentException>(() => _client.DeleteAccount("abc123", "TestUsername"));

            _client.DebugMode = true;
            _client.DebugResponse = 200;
            Assert.DoesNotThrow(async () => response = await _client.DeleteAccount(_client.DeleteKey, "TestUsername"));

            _client.DebugResponse = 500;
            Assert.Throws<ImgurDownException>(async () => response = await _client.DeleteAccount(_client.DeleteKey, "TestUsername"));

            _client.DebugResponse = 400;
            Assert.Throws<ImgurException>(async () => response = await _client.DeleteAccount(_client.DeleteKey, "TestUsername"));

            _client.DebugMode = false;
        }
    }
}
