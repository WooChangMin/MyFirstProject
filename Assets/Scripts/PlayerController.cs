using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 moveDir;

    [SerializeField]
    private float movePower;
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float rotateSpeed;
    [SerializeField]
    private float jumpPower;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        //Rotate();
        Move();
        LookAt();
    }
    private void Move()
    {
        // transform.position += moveDir*moveSpeed * Time.deltaTime;               // 단위시간 한프레임당 걸리는시간.
        transform.Translate(moveDir * moveSpeed * Time.deltaTime, Space.World);
        // x : 1/s
        
    }

    public void Rotate()
    {
        transform.Rotate(Vector3.up, moveDir.x* rotateSpeed * Time.deltaTime, Space.Self);
        
        //transform.rotation = Quaternion.Euler(0, 90, 0);
        
        //Vector3 rotation = transform.rotation.ToEulerAngles();
    }

    public void LookAt()
    {
        // 특정위치를 보면서 회전이 가능함 
        transform.LookAt(new Vector3(0, 0, 0));
    }
    private void OnMove(InputValue value)
    {
        Debug.Log(moveDir);
        moveDir.x = value.Get<Vector2>().x;
        moveDir.z = value.Get<Vector2>().y;
    }

    public void Rotation()
    {
        transform.position = new Vector3(0,0,0);
        transform.rotation = Quaternion.Euler(0,0,0);

    }
    private void Jump()
    {
        //rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
    }
    private void OnJump(InputValue value)
    {
        Jump();
    }
}
