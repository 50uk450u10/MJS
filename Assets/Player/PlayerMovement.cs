using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;
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
        StaticPlayerInput.myInput.Player0.Sneak.started += enterSneak;
        StaticPlayerInput.myInput.Player0.Sneak.canceled += exitSneak;
    }

    private void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Vector2 movementInput = StaticPlayerInput.myInput.Player0.Move.ReadValue<Vector2>().normalized;
        rb.velocity = new Vector3(movementInput.x * speed, rb.velocity.y, movementInput.y * speed);
    }

    void enterSneak(InputAction.CallbackContext Brandon)
    {
        enemyVisionArea.transform.localScale /= 2;
        enemyHearingArea.SetActive(false);
        Debug.Log("sneak");
    }

    void exitSneak(InputAction.CallbackContext Olive)
    {
        enemyVisionArea.transform.localScale *= 2;
        enemyHearingArea.SetActive(true);
        Debug.Log("no sneak");
    }
}
