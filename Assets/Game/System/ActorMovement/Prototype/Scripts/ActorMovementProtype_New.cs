using UnityEngine;
using Zenject;

namespace Game.System.ActorMovement.Prototype.Scripts
{
    public class ActorMovementPrototypeNew : ITickable
    {
        [Inject(Optional = true)]
        private IInputSystem _inputManager;
        
        [Inject(Id = "MainPlayer", Optional = true)]
        private Transform _transform;

        [Inject]
        private ITimeSystem _timeSystem;

        public void Tick()
        {
            var h = _inputManager.GetHorizontal();
            var v = _inputManager.GetVertical();

            float moveX = 0;
            float moveY = 0;

            if (h > 0 && v > 0)
            {
                moveX = 1f;
                moveY = 1f;
            }
            else if (h > 0 && v < 0)
            {
                moveX = 1f;
                moveY = -1f;
            }

            else if (h < 0 && v > 0)
            {
                moveX = -1f;
                moveY = 1f;
            }

            else if (h < 0 && v < 0)
            {
                moveX = -1f;
                moveY = -1f;
            }

            else if (v > 0)
            {
                moveY = 1f;
                moveX = 0f;
            }

            else if (v < 0)
            {
                moveY = -1f;
                moveX = 0f;
            }

            else if (h < 0)
            {
                moveY = 0f;
                moveX = -1f;
            }

            else if (h > 0)
            {
                moveY = 0f;
                moveX = 1f;
            }
            else
            {
                moveX = 0f;
                moveY = 0f;
            }

            // if (moveX == 0 && moveY == 0)
            //     ChangeState(MovementState.Idle);
            // else
            //     ChangeState(MovementState.Moving);

            // 取得移動方向
            // Vector3 movement = new Vector3(moveX, moveY).normalized;
            // 乘上速度，使人物移動
            // _rigidbody2D.velocity = movement * 5;

            var deltaTime = _timeSystem.GetDeltaTime();
            var newPosH = Vector3.right * (h * deltaTime) * 5;
            var newPosV = Vector3.up * (v * deltaTime) * 5;
            _transform.position += newPosH;
            _transform.position += newPosV;
        }
    }
}