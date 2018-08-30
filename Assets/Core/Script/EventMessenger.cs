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

        private static Dictionary<EventMessage.ID, EventHandler> m_eventMap;

        static EventMessenger()
        {
            m_eventMap = new Dictionary<EventMessage.ID, EventHandler>(new EventIDComparer());
        }

        public static void AddListener(EventMessage.ID eventID, EventHandler callback)
        {
            if (!m_eventMap.ContainsKey(eventID))
                m_eventMap.Add(eventID, null);

            m_eventMap[eventID] += callback;
        }

        public static void RemoveListener(EventMessage.ID eventID, EventHandler callback)
        {
            if (m_eventMap.ContainsKey(eventID))
            {
                m_eventMap[eventID] -= callback;
                if (m_eventMap[eventID] == null)
                    m_eventMap.Remove(eventID);
            }
        }

        public static void Broadcast(EventMessage eventMsg)
        {
            EventMessage.ID id = eventMsg.EventID;
            if(m_eventMap.ContainsKey(id))
            {
                if (m_eventMap[id] != null)
                    m_eventMap[id](eventMsg);
            }
        }

        public static void RemoveAllListener(EventMessage.ID eventID)
        {
            if (m_eventMap.ContainsKey(eventID))
                m_eventMap.Remove(eventID);
        }

        public static void Clear()
        {
            m_eventMap.Clear();
        }
    }
}

