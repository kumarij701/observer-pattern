using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObServerEX
{
    internal class ObserverE
    {
        public interface ISubject
        {
            public void Attach(IObserver o);
            public void Detach(IObserver o);
            public void NotifyUpdate(Message m);
        }
        public class MessagePublisher : ISubject
        {
            private List<IObserver> observers = new List<IObserver>();
            public void Attach(IObserver o)
            {
                observers.Add(o);
            }
            public void Detach(IObserver o)
            {
                observers.Remove(o);
            }
            public void NotifyUpdate(Message m)
            {
                foreach (IObserver o in observers)
                {
                    o.Update(m);
                }
            }
        }
        public interface IObserver

        {
            public void Update(Message m);
        }
        public class MessageSubscriberOne : IObserver

        {
            public void Update(Message m)
            {
                Console.WriteLine("MessageSubscriberOne :: " + m.GetMessageContent());
            }
        }
        public class MessageSubscriberTwo : IObserver
        {
            public void Update(Message m)
            {
                Console.WriteLine("MessageSubscriberTwo :: " + m.GetMessageContent());
            }
        }
        public class MessageSubscriberThree : IObserver
        {
            public void Update(Message m)
            {
                Console.WriteLine("MessageSubscriberThree :: " + m.GetMessageContent());
            }
        }
        public class Message
        {
            readonly String messageContent;
            public Message(String m)
            {
                this.messageContent = m;
            }
            public String GetMessageContent()
            {
                return messageContent;
            }
        }
        static void Main(String[] args)

        {

            MessageSubscriberOne s1 = new MessageSubscriberOne();
            MessageSubscriberTwo s2 = new MessageSubscriberTwo();
            MessageSubscriberThree s3 = new MessageSubscriberThree();
            MessagePublisher p = new MessagePublisher();
            p.Attach(s1);
            p.Attach(s2);
            p.NotifyUpdate(new Message("First Message")); //s1 and s2 will receive the update
            p.Detach(s1);
            p.Attach(s3);
            p.NotifyUpdate(new Message("Second Message")); //s2 and s3 will receive the update

        }

    }
}
