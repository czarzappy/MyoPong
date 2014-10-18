using System;
using UnityEngine;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;

public class Player1Mediator : EventMediator
{
    //This is how your Mediator knows about your View.
    [Inject]
    public Player1View view { get; set; }

    public override void OnRegister()
    {
        Debug.Log("Player1Mediator OnRegister");
        view.init();
    }

    public override void OnRemove()
    {
        Debug.Log("Mediator OnRemove");
    }
}

