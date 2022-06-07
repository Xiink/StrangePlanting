using System;
using Game.System.ActorMovement.Prototype.Scripts;
using NSubstitute;
using NUnit.Framework;
using UnityEngine;
using Zenject;

namespace Game.System.ActorMovement.Prototype.Tests
{
    public class ActorMovementPrototypeTest : ZenjectUnitTestFixture
    {
        // A Test behaves as an ordinary method
        [Test]
        public void ActorMovementPrototypeTestSimplePasses()
        {
            var mainplayer = new GameObject("MainPlayer").transform;
            // var input = NSubstitute.Substitute.For<IInputSystem>();
            // input.GetHorizontal().Returns(1);
            // input.GetVertical().Returns(1);
            Container.BindInstance(mainplayer);
            // Container.Bind<IInputSystem>().FromInstance(input).AsSingle();
            Container.Bind<IInputSystem>().FromSubstitute().AsSingle();
            Container.Bind<ActorMovementPrototypeNew>().AsSingle();
            var actor = Container.Resolve<ActorMovementPrototypeNew>();
            var inputSystem = Container.Resolve<IInputSystem>();
            inputSystem.GetHorizontal().Returns(1);
            inputSystem.GetVertical().Returns(1);
            // var actor = new ActorMovementPrototypeNew(input, mainplayer);
            actor.Tick();
            var pos = mainplayer.position;
            var deltaTime = Time.deltaTime;
            var expectPos = new Vector3(5f, 5f);
            pos = new Vector2((float)Math.Round(pos.x, 2), (float)Math.Round(pos.x, 2));
            Assert.AreEqual(pos, expectPos, "Are equal");
        }
    }
}
