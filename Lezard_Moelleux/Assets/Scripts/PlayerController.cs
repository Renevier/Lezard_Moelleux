using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] Rigidbody rb = null;
    Vector3 inputDirection;

    private void FixedUpdate()
    {
        rb.AddForce(inputDirection * speed * Time.deltaTime);
    }
    private void OnMove(InputValue _value)
    {
        Vector2 inputMouvement = _value.Get<Vector2>();
        inputDirection = new Vector3(inputMouvement.x, 0, inputMouvement.y);
    }
}
