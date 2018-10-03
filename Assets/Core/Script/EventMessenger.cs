using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EazeyFramework
{
    public static class EventMessenger
    {
        public class EventIDComparer : IEqualityComparer<EventMessage.ID>
        {
            public bool Equals(EventMessage.ID x, EventMessage.ID y)
            {
                return (int)x == (int)y;
            }

            public int GetHashCode(EventMessage.ID obj)
            {
                return (int)obj;
            }
        }

        private static Dictionary<EventMessage.ID, EventHandler> m_eventHandlerMap;

        private static Dictionary<EventMessage.ID, EventMessage> m_eventPool;

        static EventMessenger()
        {
            m_eventHandlerMap = new Dictionary<EventMessage.ID, EventHandler>(new EventIDComparer());
            m_eventPool = new Dictionary<EventMessage.ID, EventMessage>(new EventIDComparer());
        }

        public static void AddListener(EventMessage.ID eventID, EventHandler callback)
        {
            if (!m_eventHandlerMap.ContainsKey(eventID))
                m_eventHandlerMap.Add(eventID, null);

            m_eventHandlerMap[eventID] += callback;
        }

        public static void RemoveListener(EventMessage.ID eventID, EventHandler callback)
        {
            if (m_eventHandlerMap.ContainsKey(eventID))
            {
                m_eventHandlerMap[eventID] -= callback;
                if (m_eventHandlerMap[eventID] == null)
                    m_eventHandlerMap.Remove(eventID);
            }
        }

        public static void Broadcast(EventMessage eventMsg)
        {
            EventMessage.ID id = eventMsg.EventID;
            if(m_eventHandlerMap.ContainsKey(id))
            {
                if (m_eventHandlerMap[id] != null)
                    m_eventHandlerMap[id](eventMsg);
            }
        }

        public static void RemoveAllListener(EventMessage.ID eventID)
        {
            if (m_eventHandlerMap.ContainsKey(eventID))
                m_eventHandlerMap.Remove(eventID);
        }

        public static void Clear()
        {
            m_eventHandlerMap.Clear();
        }
    }
}

