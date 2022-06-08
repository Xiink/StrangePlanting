using UnityEngine;

namespace Game.System.ActorMovement.Prototype.Scripts
{
    public interface IInputSystem
    {
        float GetHorizontal();
        float GetVertical();
    }

    public class InputManager_New : IInputSystem
    {
        public float GetHorizontal()
        {
            return Input.GetAxisRaw("Horizontal");
        }

        public float GetVertical()
        {
            return Input.GetAxisRaw("Vertical");
        }
    }
}