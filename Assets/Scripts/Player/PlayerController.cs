using System;
using Player;
using UnityEngine;
using UnityEngine.InputSystem;
using PlayerInput = Player.PlayerInput;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Transform cameraTransform;
    
    public PlayerInput PlayerInput { get; private set; }
    public Rigidbody Rigidbody { get; private set; }
    private PlayerMovement playerMovement;
    private PlayerCameraController playerCameraController;

    private bool isGrounded;
    public bool IsGrounded => isGrounded;

    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody>();
        PlayerInput = new PlayerInput(InputSystem.actions);
        playerMovement = new PlayerMovement(this);
        playerCameraController = new PlayerCameraController(this, cameraTransform);
    }

    private void Update()
    {
        PlayerInput.Update();
        playerCameraController.Update();
        playerMovement.Update();
    }

    private void FixedUpdate()
    {
        Collider[] points = new Collider[8];
        int hit = Physics.OverlapSphereNonAlloc(transform.position + Vector3.up * 0.1f, 0.22f, points);
        isGrounded = false; 
        for (int i = 0; i < hit; i++)
        {
            if (!points[i].TryGetComponent(out Tags tags) || !tags.IsGround) continue;
            
            isGrounded = true;
            break;
        }
        
        playerMovement.FixedUpdate();
    }
    
}
