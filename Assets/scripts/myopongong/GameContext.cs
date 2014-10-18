using UnityEngine;
using System.Collections;
using strange.extensions.context.api;
using strange.extensions.context.impl;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.dispatcher.eventdispatcher.impl;
using strange.extensions.command.api;
using strange.extensions.command.impl;

public class GameContext : MVCSContext
{
    public GameContext(MonoBehaviour view)
        : base(view)
    {
        Debug.Log("GameContext construct - basic");
    }

    public GameContext(MonoBehaviour view, ContextStartupFlags flags)
        : base(view, flags)
    {
        Debug.Log("GameContext construct - flags");
    }

    // Unbind the default EventCommandBinder and rebind the SignalCommandBinder
    protected override void addCoreComponents()
    {
        base.addCoreComponents();
        injectionBinder.Unbind<ICommandBinder>();
        injectionBinder.Bind<ICommandBinder>().To<SignalCommandBinder>().ToSingleton();
    }

    // Override Start so that we can fire the StartSignal 
    override public IContext Start()
    {
        base.Start();
        StartSignal startSignal = (StartSignal)injectionBinder.GetInstance<StartSignal>();
        startSignal.Dispatch();
        return this;
    }

    protected override void mapBindings()
    {
        Debug.Log("GameContext - mapBindings");
        //Injection binding.
        //injectionBinder.Bind<IMouseModel>().To<MouseModel>().ToSingleton();
        injectionBinder.Bind<IWorldModel>().To<WorldModel>().ToSingleton();
        //injectionBinder.Bind<IExampleService>().To<ExampleService>().ToSingleton();

        //View/Mediator binding
        //This Binding instantiates a new ExampleMediator whenever as ExampleView
        //Fires its Awake method. The Mediator communicates to/from the View
        //and to/from the App. This keeps dependencies between the view and the app
        //separated.
        mediationBinder.Bind<WorldView>().To<WorldMediator>();
        mediationBinder.Bind<CameraView>().To<CameraMediator>();
        mediationBinder.Bind<Player1View>().To<Player1Mediator>();
        mediationBinder.Bind<Player1BarrierView>().To<Player1BarrierMediator>();
        mediationBinder.Bind<Player2BarrierView>().To<Player2BarrierMediator>();
        mediationBinder.Bind<HallwayView>().To<HallwayMediator>();


        //StartSignal is now fired instead of the START event.
        //Note how we've bound it "Once". This means that the mapping goes away as soon as the command fires.
        commandBinder.Bind<StartSignal>().To<StartCommand>().Once();
        commandBinder.Bind<RequestWorldSizeUpdateSignal>().To<UpdateWorldSizeCommand>();
        //commandBinder.Bind<RequestBallCreationSignal>().To<CreateBallCommand>();
        //commandBinder.Bind<NotifyBallClickedSignal>().To<UpdateMouseCommand>();
        //Event/Command binding
        //commandBinder.Bind(ExampleEvent.REQUEST_WEB_SERVICE).To<CallWebServiceCommand>();
        //The START event is fired as soon as mappings are complete.
        //Note how we've bound it "Once". This means that the mapping goes away as soon as the command fires.
        //commandBinder.Bind(ContextEvent.START).To<StartCommand>().Once ();
        //commandBinder.Bind<RequestMouseUpdateSignal>().To<MouseUpdateCommand>();
    }
}
