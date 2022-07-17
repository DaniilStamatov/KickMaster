using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Scripts
{
    public class HeroInputReader : MonoBehaviour
    {
        [SerializeField] private Hero _hero;

        public void OnMovement(InputAction.CallbackContext context)
        {
            var direction = context.ReadValue<Vector2>();
            _hero.SetDirection(direction);
            if (context.canceled)
            {
                _hero.Kick();
            }
        }

        //public void OnKick(InputAction.CallbackContext context)
        //{
        //    if (context.performed)
        //    {
        //        _hero.Kick();
        //    }
        //}

        public void OnLoadMenu(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                _hero.LoadMenu();
            }
        }
    }
}
