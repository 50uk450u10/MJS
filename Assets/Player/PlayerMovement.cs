using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem.Interactions;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] int speed;
    [SerializeField] GameObject enemyVisionArea;
    [SerializeField] GameObject enemyHearingArea;
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        StaticPlayerInput.myInput.Player0.Enable();
    }

    private void Update()
    {
        //if (StaticPlayerInput.myInput.Player0.Sneak.started)
        //{
        //    enemyVisionArea.transform.localScale /= 2;
        //    enemyHearingArea.SetActive(false);
        //}
        //else if (StaticPlayerInput.myInput.Player0.Sneak.canceled)
        //{
        //    enemyVisionArea.transform.localScale *= 2;
        //    enemyHearingArea.SetActive(true);
        //}
    }

    private void FixedUpdate()
    {
        Vector2 movementInput = StaticPlayerInput.myInput.Player0.Move.ReadValue<Vector2>().normalized;
        rb.velocity = new Vector3(movementInput.x * speed, rb.velocity.y, movementInput.y * speed);
    }
}
