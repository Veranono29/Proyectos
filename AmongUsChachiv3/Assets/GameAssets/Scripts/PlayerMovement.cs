using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerMovement : NetworkBehaviour
{
    
    [SerializeField]
    private float movementSpeed = 3f;

    protected CharacterController controller;
    protected Animator animator;

    float horizontal;
    float vertical;

    // Start is called before the first frame update
    void Awake()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    public override void OnStartLocalPlayer()
    {
        Camera.main.GetComponent<CameraFollow>().FollowMe(transform);
    }

    // Update is called once per frame
    void Update() {
        if (isLocalPlayer) {
            Move();
        }
    }

    void Move()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        var movement = new Vector3(horizontal, 0, vertical).normalized;
        animator.SetFloat("Speed", new Vector2(horizontal, vertical).magnitude);

        controller.SimpleMove(movement * movementSpeed); // Pide vector de velocidad de movimiento
        //controller.Move(new Vector3(h, 0, v).normalized * movementSpeed * Time.deltaTime); // Pide el vector de desplazamiento
        if (movement.magnitude > 0)
        {
            transform.forward = Vector3.Slerp(transform.forward, movement, 0.1f);
        }

    }

   
}
