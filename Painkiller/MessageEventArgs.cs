using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Painkiller
{
    public class MessageEventArgs
    {
        public String Message { get; }
        //кількість позитивних та негативних повідомлень відповідно
        public static Int32 CountPosInvoke { get; internal set; }
        public static Int32 CountNegInvoke { get; internal set; }

        public MessageEventArgs(String mess)
        {
            Message = mess;
        }
    }
}
