using System.Collections;
using System.Collections.Generic;
using Game.System.ActorMovement.Prototype.Scripts;
using UnityEngine;
using Zenject;

public class SampleInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.BindInterfacesTo<ActorMovementPrototypeNew>().AsSingle();
        Container.Bind<IInputSystem>().To<InputManager_New>().AsSingle();
        Container.Bind<ITimeSystem>().To<TimeSystem>().AsSingle();
    }
}
