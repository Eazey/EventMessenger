using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using EazeyFramework;

public class EventListener : MonoBehaviour {

    public Button RegisterBtn;
    public Button UnRegisterBtn;

    private EventHandler m_eventCallback;

    private void Awake()
    {
        m_eventCallback = OnMyEventMessageCallback;

        if (RegisterBtn == null)
            throw new System.Exception(string.Format("RegisterBtn is null"));

        if (UnRegisterBtn == null)
            throw new System.Exception(string.Format("UnRegisterBtn is null"));
    }

    private void Start()
    {
        RegisterBtn.onClick.AddListener(RegisterEvent);
        UnRegisterBtn.onClick.AddListener(UnRegisterEvent);
    }

    private void RegisterEvent()
    {
        Debug.Log("Start Listening...");
        EventMessenger.AddListener(EventMessage.ID.MyEventID, m_eventCallback);
    }

    private void UnRegisterEvent()
    {
        Debug.Log("Stop Listening!");
        EventMessenger.RemoveListener(EventMessage.ID.MyEventID, m_eventCallback);
    }

    private void OnMyEventMessageCallback(EventMessage eventMessage)
    {
        Debug.Log("Receive Event!");

        MyEventMessage msg = eventMessage as MyEventMessage;
        string msgContent = string.Format("The event title is {0}\nData: {1}\nThe data use {2} size in memory", msg.Title, msg.Data, msg.Size);

        Debug.Log(msgContent);
    }
}
