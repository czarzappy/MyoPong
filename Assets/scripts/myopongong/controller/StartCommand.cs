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
        player.transform.position = new Vector3(0, 0, -model.size.z / 2);

        GameObject myo = GameObject.Find("MyoArm");
        myo.transform.position = new Vector3(0, 0, -model.size.z / 2);

        GameObject cv = (GameObject)GameObject.Instantiate(Resources.Load("OVRCameraController"));
        cv.name = "CameraView";
        cv.AddComponent<CameraView>();
        cv.transform.position = new Vector3(0, 0, -model.size.z/2 - 10);

        GameObject surface = GameObject.Find("Surface");
        surface.transform.position = new Vector3(0, 0, -model.size.z / 2 + 10);

        //GameObject p1barrier = (GameObject)GameObject.Instantiate(Resources.Load("PlayerBarrier"));
        //p1barrier.name = "Player1Barrier";
        //p1barrier.AddComponent<Player1BarrierView>();
        //p1barrier.transform.position = new Vector3(0, 0, 0);
        //p1barrier.transform.position = new Vector3(0, 0, -model.size.z / 2);

        //GameObject p2barrier = (GameObject)GameObject.Instantiate(Resources.Load("PlayerBarrier"));
        //p2barrier.name = "Player2Barrier";
        //p2barrier.AddComponent<Player2BarrierView>();
        //p2barrier.transform.position = new Vector3(0, 0, model.size.z / 2);
    }
}

