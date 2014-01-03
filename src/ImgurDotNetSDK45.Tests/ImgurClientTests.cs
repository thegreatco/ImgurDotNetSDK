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
    class ImgurClientTests
    {
        [Test]
        public void Create()
        {
            Assert.Throws<ArgumentNullException>(() =>
                                                 {
                                                     var client = new ImgurClient(null);
                                                 });

            Assert.Throws<ArgumentNullException>(() =>
                                                 {
                                                     var client = new ImgurClient(new ImgurSettings("abc", "123"), null);
                                                 });


            Assert.DoesNotThrow(() =>
                                {
                                    var client = new ImgurClient(new ImgurSettings("abc", "123"));
                                });

            Assert.DoesNotThrow(() =>
                                {
                                    var client = new ImgurClient(new ImgurSettings("abc", "123"), new ImgurCredentials("abc", "123", 3600));
                                });
        }
    }
}
