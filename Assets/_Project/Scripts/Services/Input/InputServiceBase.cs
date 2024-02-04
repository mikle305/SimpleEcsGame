using Additional.Constants;
using UnityEngine;

namespace Services.Input
{
    public abstract class InputServiceBase : IInputService
    {
        public Vector2 GetMoveDirection()
            => new(
                UnityEngine.Input.GetAxisRaw(InputConstants.Horizontal), 
                UnityEngine.Input.GetAxisRaw(InputConstants.Vertical));
    }
}