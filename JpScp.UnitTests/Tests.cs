using System;
using NUnit.Framework;

namespace JpScp.UnitTests
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void Test1()
        {
            var mp = new JpScp.IoHelper.MemPool(1024);
            var b = mp.GetBuffer();
            Assert.IsNull( b ,"FirstCall size is zero!");
        }
    }
}