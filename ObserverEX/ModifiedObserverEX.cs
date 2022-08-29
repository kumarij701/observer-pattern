using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObServerEG
{
    internal class ObserverE
    {
        public  abstract class  Subject
        {
            public abstract void  Attach(IObserver o);
            public abstract void Detach(IObserver o);
            public void ChangeState()
            {
                Message m1 = new Message("Hello There!!");
            }
            public abstract void NotifyUpdate(Message m, Message m1);

        }
        public class MessagePublisher : Subject
        {
            private List<IObserver> observers = new List<IObserver>();
            public override void  Attach(IObserver o)
            {
                observers.Add(o);
            }
            public override void Detach(IObserver o)
            {
                observers.Remove(o);
            }
            public override  void NotifyUpdate(Message m, Message m1)
            {
                foreach (IObserver o in observers)
                {
                    o.Update(m);
                    o.Update(m1);
                }
            }
        }
        public interface IObserver

        {
            public void Update(Message m);
            public void Update1(Message m1);
        }
        public class MessageSubscriberOne : IObserver

        {
            public void Update(Message m)
            {
                Console.WriteLine("MessageSubscriberOne :: " + m.GetMessageContent());
                
            }
            public void Update1(Message m1)
            {
                Console.WriteLine("MessageSubscriberOne Change State::" + m1.GetMessageContent());
            }
        }
        public class MessageSubscriberTwo : IObserver
        {
            public void Update(Message m)
            {
                Console.WriteLine("MessageSubscriberTwo :: " + m.GetMessageContent());
            }
            public void Update1(Message m1)
            {
                Console.WriteLine("MessageSubscriberTwo Change State::" + m1.GetMessageContent());
            }
        }
        public class MessageSubscriberThree : IObserver
        {
            public void Update(Message m)
            {
                Console.WriteLine("MessageSubscriberThree :: " + m.GetMessageContent());
            }
            public void Update1(Message m1)
            {
                Console.WriteLine("MessageSubscriberThree Change State::" + m1.GetMessageContent());
            }
        }
        public class Message
        {
            private String messageContent;
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
            p.NotifyUpdate(new Message("First Message"), new Message("FChange State")); //s1 and s2 will receive the update
            p.Detach(s1);
            p.Attach(s3);
            p.NotifyUpdate(new Message("Second Message"), new Message("Change State")); //s2 and s3 will receive the update

        }

    }
}
