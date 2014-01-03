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
    public class ImgurSettingsTests
    {
        [Test]
        public void Create()
        {
            Assert.Throws<ArgumentNullException>(() => new ImgurSettings(string.Empty, string.Empty));
            Assert.Throws<ArgumentNullException>(() => new ImgurSettings("abc", string.Empty));
            Assert.DoesNotThrow(() => new ImgurSettings("abc", "123"));
        }
    }
}
