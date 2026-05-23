using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class PlayerInput
    {
        private readonly InputAction moveAction;
        private readonly InputAction jumpAction;
        private readonly InputAction lookAction;

        public PlayerInput(InputActionAsset actions)
        {
            moveAction = actions.FindAction("Move");
            jumpAction = actions.FindAction("Jump");
            lookAction = actions.FindAction("Look");

            Update();
        }

        public Vector2 Move { get; private set; }
        public bool Jump { get; private set; }
        public bool JumpPressed { get; private set; }
        public Vector2 Look { get; private set; }

        public void Update()
        {
            Move = moveAction.ReadValue<Vector2>();
            Look = lookAction.ReadValue<Vector2>();
            JumpPressed = jumpAction.WasPressedThisFrame();
            Jump = jumpAction.IsPressed();
        }


        public override string ToString()
        {
            return $"Move: {Move}, Jump: {Jump}, Look: {Look}";
        }
    }
}