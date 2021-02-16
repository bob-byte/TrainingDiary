using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Painkiller.PresentationModels
{
    public class Notification
    {
        private event Message messagePositive;
        private event Message messageNegative;

        public delegate void Message(Object sender, MessageEventArgs e);

        public event Message MessagePositive
        {
            add
            {
                messagePositive += value;
                MessageEventArgs.CountPosInvoke++;
            }
            remove
            {
                messagePositive -= value;
                MessageEventArgs.CountPosInvoke--;
            }
        }

        public event Message MessageNegative
        {
            add
            {
                messageNegative += value;
                MessageEventArgs.CountNegInvoke++;
            }
            remove
            {
                messageNegative -= value;
                MessageEventArgs.CountNegInvoke--;
            }
        }

        internal void MessageInvoke(Boolean isPositive, String mess)
        {
            if (isPositive)
            {
                messagePositive?.Invoke(this, new MessageEventArgs(mess));
            }
            else
            {
                messageNegative?.Invoke(this, new MessageEventArgs(mess));
            }
        }
    }
}
