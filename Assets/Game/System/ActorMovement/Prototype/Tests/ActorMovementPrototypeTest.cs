using System;
using Game.System.ActorMovement.Prototype.Scripts;
using NSubstitute;
using NUnit.Framework;
using UnityEngine;
using Zenject;


namespace Game.System.ActorMovement.Prototype.Tests
{
    public class ActorMovementPrototypeTest : ZenjectIntegrationTestFixture
    {
        [Test]
        public void ActorMovement()
        {
            var mainplayer = new GameObject("MainPlayer").transform;
            var input = NSubstitute.Substitute.For<IInputSystem>();
            input.GetHorizontal().Returns(-1);
            input.GetVertical().Returns(1);
            var actor = new ActorMovementPrototypeNew(input, mainplayer);
            actor.Tick();
            var pos = mainplayer.position;
            var deltaTime = Time.deltaTime;
            var expectPos = new Vector2(1f, 1f);
            pos = new Vector2((float)Math.Round(pos.x, 2), (float)Math.Round(pos.x, 2));
            Assert.AreEqual(pos, expectPos, "Are equal");
        }
    }
}