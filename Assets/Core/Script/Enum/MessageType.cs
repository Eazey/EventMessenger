using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EazeyFramework
{
    public partial class EventMessage
    {
        public enum EventType
        {
            /// <summary>
            /// An event is broadcasted,
            /// 
            /// Overview:
            ///     All listeners respond to it.
            /// Error:
            ///     There are no listeners.
            /// </summary>
            RealTime,

            /// <summary>
            /// An event is broadcasted,
            /// 
            /// Overview:
            ///     If the event listener exists,
            ///     who respond to it immediately;
            ///     otherwise the event will be cached
            ///     and pushed until a listener appears.
            /// </summary>
            Waiting,
        }

        public enum MessageType
        {

        }
    }
}

