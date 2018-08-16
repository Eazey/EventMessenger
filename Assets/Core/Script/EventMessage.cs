using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EazeyFramework
{
    public partial class EventMessage
    {
        public MessageType Type { private set; get; }

        public EventMessage(MessageType type)
        {
            Type = type;
        }
    }
}
