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
        private string transformId = "MainPlayer";
        private ActorMovementPrototypeNew actor;
        private ITimeSystem timesystem;
        private IInputSystem inputSystem;
        private Transform mainplayer;

        public override void Setup()
        {
            base.Setup();
            // arrange // given
            Container.Bind<Transform>().WithId(transformId).FromNewComponentOnNewGameObject().AsSingle();
            Container.Bind<IInputSystem>().FromSubstitute().AsSingle();
            Container.Bind<ITimeSystem>().FromSubstitute().AsSingle();
            Container.Bind<ActorMovementPrototypeNew>().AsSingle();

            actor = Container.Resolve<ActorMovementPrototypeNew>();
            timesystem = Container.Resolve<ITimeSystem>();
            inputSystem = Container.Resolve<IInputSystem>();
            mainplayer = Container.ResolveId<Transform>(transformId);
        }

        // A Test behaves as an ordinary method
        [Test]
        public void ActorMovementPrototypeTestSimplePasses()
        {
            // arrange //given
            GivenHorzontalValue(1);
            GivenVerticalValue(1);
            GiveDeltaTime(1);

            // var actor = new ActorMovementPrototypeNew(input, mainplayer);
            actor.Tick();
            var pos = mainplayer.position;
            var deltaTime = Time.deltaTime;
            var expectPos = new Vector3(5f, 5f);
            pos = new Vector2((float)Math.Round(pos.x, 2), (float)Math.Round(pos.x, 2));
            Assert.AreEqual(pos, expectPos, "Are equal");
        }

        private void GiveDeltaTime(int deltatime)
        {
            timesystem.GetDeltaTime().Returns(deltatime);
        }

        private void GivenHorzontalValue(int horizontal)
        {
            inputSystem.GetHorizontal().Returns(horizontal);
        }

        private void GivenVerticalValue(int vertical)
        {
            inputSystem.GetVertical().Returns(vertical);
        }
    }
}
