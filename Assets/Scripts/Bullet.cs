using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]                          // 다른 컴포넌트에 의존하는 컴포넌트가 있을경우 무조건 포함시켜줌 -> 자동으로 rigidbody추가(지울수도없음)
public class Bullet : MonoBehaviour
{
    [SerializeField] private float bulletSpeed;

    private Rigidbody rb;

    

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        rb.velocity = transform.forward * bulletSpeed;         //불릿을 기준으로 정면으로 날아가야함
        Destroy(gameObject, 5f);                               //불릿이 오래남으면 안되므로 지연삭제

    }
}
