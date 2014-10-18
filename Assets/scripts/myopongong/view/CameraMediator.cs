using System;
using UnityEngine;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;

public class CameraMediator : EventMediator
{
    //This is how your Mediator knows about your View.
    [Inject]
    public CameraView view { get; set; }

    public override void OnRegister()
    {
        Debug.Log("CameraMediator OnRegister");
        view.init();
    }

    public override void OnRemove()
    {
        Debug.Log("Mediator OnRemove");
    }
}

