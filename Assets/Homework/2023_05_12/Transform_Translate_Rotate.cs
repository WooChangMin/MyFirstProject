using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class Transform_Translate_Rotate : MonoBehaviour
{
    private Vector3 moveDir;
    [SerializeField]
    private float power = 5f;
    
    public void Awake()
    {
    }
    public void Update()
    {
        TransformMove();
    }

    public void TransformMove()
    {
        transform.Translate(moveDir * power*Time.deltaTime, Space.World);
    }


    public void OnMove(InputValue value)
    {
        Debug.Log("´­¸²");
        moveDir.x = value.Get<Vector2>().x;
        moveDir.z = value.Get<Vector2>().y;
    }
}
