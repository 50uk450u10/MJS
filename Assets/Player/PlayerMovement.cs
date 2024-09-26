using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] int speed;
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        StaticPlayerInput.myInput.Player0.Enable();
    }

    private void FixedUpdate()
    {
        Vector2 movementInput = StaticPlayerInput.myInput.Player0.Move.ReadValue<Vector2>().normalized;
        rb.velocity = new Vector3(movementInput.x * speed, rb.velocity.y, movementInput.y * speed);
    }
}
