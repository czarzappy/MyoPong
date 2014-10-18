using System;
using UnityEngine;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;

public class WorldMediator : EventMediator
{
    //This is how your Mediator knows about your View.
    [Inject]
    public WorldView view { get; set; }

    public override void OnRegister()
    {
        Debug.Log("WorldMediator OnRegister");
        view.init();
    }

    public override void OnRemove()
    {
        Debug.Log("Mediator OnRemove");
    }
}

