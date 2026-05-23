using UnityEngine;

namespace Player
{
    public class PlayerMovement
    {
        
        private readonly PlayerController controller;
        private readonly Rigidbody rigidbody;
        private readonly PlayerInput playerInput;

        private float jumpCooldown = 0f;
        
        public PlayerMovement(PlayerController playerController)
        {
            controller = playerController;
            rigidbody = controller.Rigidbody;
            playerInput = controller.PlayerInput;
        }

        public void Update()
        {
            if (jumpCooldown > 0f) jumpCooldown -= Time.deltaTime;
            
            Debug.DrawRay(controller.transform.position, Vector3.down * 0.5f, controller.IsGrounded ? Color.green : Color.red);
            Debug.DrawRay(controller.transform.position, controller.transform.forward * 0.5f, Color.blue);
            
            Vector3 forward = controller.transform.forward;
            Vector3 right = controller.transform.right;
            Vector3 move = (forward * playerInput.Move.y + right * playerInput.Move.x) * 5f;
            Debug.DrawRay(controller.transform.position, move, Color.yellow); // Target velocity
            
            Debug.DrawRay(controller.transform.position, rigidbody.linearVelocity, Color.aquamarine);
                
        }

        public void FixedUpdate()
        {
            Vector3 forward = controller.transform.forward;
            Vector3 right = controller.transform.right;
            
            if (controller.IsGrounded) groundMovement();
            else airMovement();
            
            if (playerInput.Jump && controller.IsGrounded)
            {
                rigidbody.AddForce(Vector3.up * 2f, ForceMode.Impulse);
            }
        }

        private void groundMovement()
        {
            Vector3 forward = controller.transform.forward;
            Vector3 right = controller.transform.right;
            
            Vector3 move = (forward * playerInput.Move.y + right * playerInput.Move.x) * 5f;
            Vector3 velocityChange = (move - rigidbody.linearVelocity) * 300f;
                
            rigidbody.AddForce(velocityChange * Time.fixedDeltaTime, ForceMode.Acceleration);

            if (playerInput.Jump && jumpCooldown <= 0f)
            {
                Vector3 vel = rigidbody.linearVelocity;
                vel.y = 0;
                rigidbody.linearVelocity = vel;
                rigidbody.AddForce(Vector3.up * 2f, ForceMode.Impulse);
                
                jumpCooldown = 0.1f;
            }
        }
        
        private void airMovement()
        {
            Vector3 forward = controller.transform.forward;
            Vector3 right = controller.transform.right;
            Vector3 move = (forward * playerInput.Move.y + right * playerInput.Move.x) * 5f;
            
            Vector3 vel = rigidbody.linearVelocity;
            vel.y = 0;
            float similarity = Vector3.Dot(move, vel) / 5f;
            
            float force = 3f;
            if (similarity < 0) force = 4f;
            if (similarity > move.magnitude) force = 0.2f;
            rigidbody.AddForce(move.normalized * (force * Time.fixedDeltaTime * 300f), ForceMode.Acceleration);
                
            
            if (rigidbody.linearVelocity.y > 0 && !playerInput.Jump)
            {
                rigidbody.AddForce(Vector3.down * (10f * Time.fixedDeltaTime), ForceMode.Acceleration);
            }
        }
        
    }
}