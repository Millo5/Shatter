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
        public Vector2 Look { get; private set; }

        public void Update()
        {
            Move = moveAction.ReadValue<Vector2>();
            Jump = jumpAction.ReadValue<float>() > 0.5f;
            Look = lookAction.ReadValue<Vector2>();
        }


        public override string ToString()
        {
            return $"Move: {Move}, Jump: {Jump}, Look: {Look}";
        }
    }
}