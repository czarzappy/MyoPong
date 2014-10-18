/// The only change in StartCommand is that we extend Command, not EventCommand

using System;
using System.Collections;
using UnityEngine;
using strange.extensions.context.api;
using strange.extensions.command.impl;
using strange.extensions.dispatcher.eventdispatcher.impl;

public class UpdateWorldSizeCommand : Command
{

    [Inject(ContextKeys.CONTEXT_VIEW)]
    public GameObject contextView { get; set; }

    [Inject]
    public IWorldModel model { get; set; }

    [Inject]
    public Vector3 size { get; set; }

    public override void Execute()
    {
        Debug.Log("Executing UpdateWorldSizeCommand - size: " + size);

        model.size = size;
    }
}

