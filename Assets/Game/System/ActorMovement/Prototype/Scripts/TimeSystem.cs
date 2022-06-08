using UnityEngine;

namespace Game.System.ActorMovement.Prototype.Scripts
{
    public interface ITimeSystem
    {
        float GetDeltaTime();
    }

    public class TimeSystem : ITimeSystem
    {
        public float GetDeltaTime()
        {
            var deltaTime = Time.deltaTime;
            return deltaTime;
        }
    }
}