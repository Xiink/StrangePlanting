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
        // Container.Bind<IInput>().AsSingle();
        Container.BindInterfacesTo<InputManager_New>().AsSingle();
    }
}
