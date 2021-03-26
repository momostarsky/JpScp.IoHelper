using System;
using System.IO;
using System.Threading.Tasks;

namespace JpScp.IoHelper
{

    class CopyState
    {
        public const int BUFFER_SIZE = 8192;
        public readonly long FileLength;
        public readonly Stream From;
        public readonly Stream To;
        public readonly byte[] Buffer;
        public readonly byte[] Data;

        public long ReadSize
        {
            get;
            set;
        }
        public long WriteSize
        {
            get;
            set;
        }
        public CopyState(  Stream frm, Stream to)
        {
            FileLength = frm.Length;
            From = frm;
            To = to;
            Buffer = new byte[BUFFER_SIZE];
            Data = new byte[BUFFER_SIZE];
            ReadSize = 0;
            WriteSize = 0;
        }

    }
    public class StreamUtils
    {
        private static void writeCallback(IAsyncResult ar)
        {
            CopyState state = ar.AsyncState as CopyState;
            state.To.EndWrite(ar); 
        }

        private static void readCallback(IAsyncResult ar)
        {
            CopyState state = ar.AsyncState as CopyState;
            var rlen = state.From.EndRead(ar);
            state.ReadSize += rlen;
            state.To.Write(state.Buffer,0, rlen);
            state.WriteSize += rlen;  
        }
        public static void StreamCopy(Stream from, Stream to)
        {
            
            CopyState cstate = new CopyState(from, to);
            do
            {
                var aresult = from.BeginRead(cstate.Buffer, 0, CopyState.BUFFER_SIZE, readCallback, cstate);
                aresult.AsyncWaitHandle.WaitOne();
            } while (cstate.ReadSize != cstate.FileLength && cstate.WriteSize != cstate.FileLength);
            to.Flush();


        }
    }
}