using Service;
using UnityEngine;

namespace Player
{
    public class PlayerCameraController
    {
        private readonly PlayerController controller;
        private readonly PlayerInput playerInput;
        private readonly Transform cameraTransform;
        
        private float yaw;
        private float pitch;
        
        public PlayerCameraController(PlayerController playerController, Transform cameraTransform)
        {
            controller = playerController;
            playerInput = controller.PlayerInput;
            this.cameraTransform = cameraTransform;
            
            Cursor.lockState = CursorLockMode.Locked;
        }

        public void Update()
        {
            float sensitivity = Services.Settings.Input.MouseSensitivity;
            yaw += playerInput.Look.x * Time.deltaTime * sensitivity;
            pitch -= playerInput.Look.y * Time.deltaTime * sensitivity;
            pitch = Mathf.Clamp(pitch, -90f, 90f);
            
            controller.transform.rotation = Quaternion.Euler(0, yaw, 0);
            cameraTransform.localRotation = Quaternion.Euler(pitch, 0, 0);
        }
    }
}