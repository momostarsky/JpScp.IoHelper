using System;
using System.Collections.Specialized;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace JpScp.IoHelper
{
    using  System.IO.MemoryMappedFiles;
    /// <summary>
    /// 内存池管理,可以设置自动过期时间 和过期回调函数
    /// </summary>
    public class MemPool
    {
        private const int iBufferSize = 64 * 1024;
        private readonly int  MaxSize;

        private readonly byte[][] arrayBuffer;
        private readonly System.Threading.ManualResetEventSlim mr;
        

        private int  pIndex =0;
        public MemPool(int  memSize)
        {
            MaxSize = memSize;
            mr = new ManualResetEventSlim(true);
            arrayBuffer = new byte[memSize][];
        
                
                
                
            Parallel.For(0, memSize, x =>
            {
                arrayBuffer[x] = new byte[iBufferSize];
                arrayBuffer[x] = new byte[iBufferSize];
            });
        }

        public  int  GetBuffer()
        {
            mr.Wait();
            try
            {
                mr.Reset();
                if (pIndex < MaxSize)
                {
                    pIndex++;
                }
                else
                {
                    pIndex = 0;
                }

                return pIndex;
            }
            finally
            {
                mr.Set();
            }
           
        }

        public byte[] this[int pos] => arrayBuffer[pos];


    }
}