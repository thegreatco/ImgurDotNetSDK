using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImgurDotNetSDK;
using NUnit.Framework;

namespace ImgurDotNetSDK45.Tests
{
    [TestFixture]
    public class ImgurCredentialsTests
    {
        [Test]
        public void Create()
        {
            Assert.Throws<ArgumentNullException>(() => new ImgurCredentials(string.Empty, string.Empty, default(long)));
            Assert.Throws<ArgumentNullException>(() => new ImgurCredentials("abc", string.Empty, default(long)));
            Assert.Throws<ArgumentException>(() => new ImgurCredentials("abc", "123", default(long)));
            Assert.DoesNotThrow(() => new ImgurCredentials("abc", "123", 3600));
        }
    }
}
