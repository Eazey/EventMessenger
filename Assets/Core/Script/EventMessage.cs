﻿
namespace EazeyFramework
{
    public partial class EventMessage
    {
        public enum Type
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


        /// <summary>
        /// Event message unique identification.
        /// </summary>
        public ID EventID { private set; get; }

        /// <summary>
        /// Event message type.
        /// </summary>
        public Type EventType { private set; get; }

        public EventMessage(ID eventID, Type eventType)
        {
            EventID = eventID;
            EventType = eventType;
        }
    }
}
