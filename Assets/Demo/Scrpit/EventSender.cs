using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using EazeyFramework;
using UnityEngine.Events;

public class EventSender : MonoBehaviour {

    public Button BrocastEventBtn;

    private UnityAction m_brocastAction;

    private void Awake()
    {
        if (BrocastEventBtn == null)
            throw new System.Exception(string.Format("BrocastEventBtn is null"));
    }

    void Start () {

        BrocastEventBtn.onClick.AddListener(BrocastData);
    }

    private void BrocastData()
    {
        Debug.Log("Brocast Event!");

        string title = "MyEventMessage"; 
        string data = "That's a new event be brocast!";
        int size = 1024;
        MyEventMessage msg = new MyEventMessage(EventMessage.ID.MyEventID, title, data, size);
        EventMessenger.Broadcast(msg);
    }
}
