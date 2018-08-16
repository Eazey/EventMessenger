using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EazeyFramework
{
    public partial class EventMessage
    {
        public MessageType MsgType { private set; get; }
        public EventType EvtType { private set; get; }

        public EventMessage(MessageType msgType, EventType evtType)
        {
            MsgType = msgType;
            EvtType = evtType;
        }
    }
}
