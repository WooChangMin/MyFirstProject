using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class AddForce_Jump : MonoBehaviour
{

    private Vector3 moveDir;

    public Rigidbody rb;

    [SerializeField]
    float power;

   

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Update()
    {
        Move();
    }

    public void OnMove(InputValue value)
    {
        // Debug.Log("����");
        moveDir.x = value.Get<Vector2>().x;
        moveDir.z = value.Get<Vector2>().y;
    }

    public void Jump()
    {
        rb.AddForce(Vector3.up * power, ForceMode.Impulse);
    }

    public void OnJump(InputValue value)
    {
        Jump();
        Debug.Log("����");
    }
    

    
    public void Move()
    {
        rb.AddForce(moveDir * power, ForceMode.Force);
    }
}
