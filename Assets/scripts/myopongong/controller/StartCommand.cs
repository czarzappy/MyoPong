/// The only change in StartCommand is that we extend Command, not EventCommand

using System;
using System.Collections;
using UnityEngine;
using strange.extensions.context.api;
using strange.extensions.command.impl;
using strange.extensions.dispatcher.eventdispatcher.impl;

public class StartCommand : Command
{

    [Inject(ContextKeys.CONTEXT_VIEW)]
    public GameObject contextView { get; set; }

    [Inject]
    public IWorldModel model { get; set; }

    public override void Execute()
    {
        Debug.Log("Executing StartCommand");
        Debug.Log("Size: " + model.size);

        GameObject wv = new GameObject();
        wv.name = "WorldView";
        wv.AddComponent<WorldView>();

        GameObject player = new GameObject();
        player.name = "Player";
        player.AddComponent<Player1View>();
        player.transform.parent = wv.transform;
        player.transform.position = new Vector3(0, 0, -model.size.z / 2);

        GameObject cv = (GameObject)GameObject.Instantiate(Resources.Load("CameraView"));
        cv.name = "CameraView";
        cv.AddComponent<CameraView>();
        cv.transform.parent = player.transform;
        cv.transform.position = new Vector3(0, 0, -5);

        GameObject p1barrier = (GameObject)GameObject.Instantiate(Resources.Load("PlayerBarrier"));
        p1barrier.name = "Player1Barrier";
        p1barrier.AddComponent<Player1BarrierView>();
        p1barrier.transform.parent = player.transform;
        p1barrier.transform.position = new Vector3(0, 0, 0);

        GameObject p2barrier = (GameObject)GameObject.Instantiate(Resources.Load("PlayerBarrier"));
        p2barrier.name = "Player2Barrier";
        p2barrier.AddComponent<Player2BarrierView>();
        p2barrier.transform.parent = wv.transform;
        p2barrier.transform.position = new Vector3(0, 0, model.size.z / 2);
    }
}

