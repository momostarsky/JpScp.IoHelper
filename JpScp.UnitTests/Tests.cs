using System;
using System.IO;
using System.Threading.Tasks;
using NUnit.Framework;
using JpScp.IoHelper;
namespace JpScp.UnitTests
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public async  Task Test1()
        {
            using (var fr=System.IO.File.OpenRead("/home/dhz/dcmdata/1.dcm"))
            using (var fw = File.OpenWrite("/home/dhz/dcmdata/1-A.dcm"))
            {
               await   fr.CopyToAsync(fw); 
         
                fr.Close();
                fw.Close();
            } 
           
            
        }
    }
}