using System;
using UnityEngine;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;

public class Player2BarrierMediator : EventMediator
{
    //This is how your Mediator knows about your View.
    [Inject]
    public Player2BarrierView view { get; set; }

    public override void OnRegister()
    {
        Debug.Log("Player2Mediator OnRegister");
        view.init();
    }

    public override void OnRemove()
    {
        Debug.Log("Mediator OnRemove");
    }
}

