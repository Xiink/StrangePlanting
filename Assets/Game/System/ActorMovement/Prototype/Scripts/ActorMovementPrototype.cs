using rStarUtility.Util.Extensions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.System.ActorMovement.Prototype.Scripts
{
    enum  MovementState
    {
        Idle,
        Moving
    }

    public class ActorMovementPrototype : MonoBehaviour
    {
        #region Private Variables

        private MovementState state;
        [SerializeField] private TMP_Text text;
        [SerializeField] private Button buttonMove;
        [SerializeField] private Rigidbody2D _rigidbody2D;

        #endregion

        #region Unity events

        private void Start()
        {
            text.text = "Idle";
            ChangeState(MovementState.Idle);
            buttonMove.BindClick(MoveToward);
        }

        #endregion

        #region Private Methods

        private void ChangeState(MovementState newState)
        {
            state = newState;
            HandleStateChange();
        }

        private void FixedUpdate()
        {
            var h = Input.GetAxisRaw("Horizontal");
            var v = Input.GetAxisRaw("Vertical");
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

            if (moveX == 0 && moveY == 0)
                ChangeState(MovementState.Idle);
            else
                ChangeState(MovementState.Moving);

            // ??????????????????
            Vector3 movement = new Vector3(moveX, moveY).normalized;
            // ??????????????????????????????
            _rigidbody2D.velocity = movement * 5;
        }

        private void HandleStateChange()
        {
            text.text = state.ToString();
        }

        private void MoveToward()
        {
            var transform1 = transform;
            transform1.position += transform1.right;
        }

        #endregion
    }
}