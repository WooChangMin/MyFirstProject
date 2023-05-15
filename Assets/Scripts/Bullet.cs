using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]                          // �ٸ� ������Ʈ�� �����ϴ� ������Ʈ�� ������� ������ ���Խ����� -> �ڵ����� rigidbody�߰�(�����������)
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
        rb.velocity = transform.forward * bulletSpeed;         //�Ҹ��� �������� �������� ���ư�����
        Destroy(gameObject, 5f);                               //�Ҹ��� ���������� �ȵǹǷ� ��������

    }
}
