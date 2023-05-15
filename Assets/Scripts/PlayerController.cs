using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
using System.Reflection;
using UnityEngine.Experimental.AI;


public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotatespeed;

    [Header ("shooter")]
    [SerializeField] private Transform bulletPoint;
    [SerializeField] private Bullet bulletPrefab;
    [SerializeField] private float repeatTime;

    private Vector3 moveDir;

    private void Update()  // ������Ʈ �޽����Լ� -> ������ �������Ӹ��� ȣ��Ǿ� ��� �����Ӹ��� ȣ��ǹǷ� ���� 800�����ӿ��� 1�ʸ� �����ٰ� ���� 800�����Էµ�
    {                      // �����Ӻ��� �̵��Ÿ��� ���̰� ���Ƿ� 
        // transform�� addforce ����-> transform�� �����ڸ��� �ش���ġ�� �̵� -> ź�����ӿ� �ַλ��  
        // Addforce�� ��� ��������� ���� ���������� ���� ������ �ʿ��Ұ�쿡 ������ٵ�� �Բ� ���

        //transform.position += 10f * moveDir * Time.deltaTime;     
        Move();
        Rotate();
    }

    
    public void Move()
    {
        transform.Translate(Vector3.forward * 10f * Time.deltaTime * moveDir.z);
        transform.Translate(Vector3.right * 10f * Time.deltaTime * moveDir.x);
    }

    public void Rotate()
    {
        transform.Rotate(Vector3.up, 90f * Time.deltaTime * moveDir.x);
    }

    private void OnMove(InputValue value)   //��ǲ���� ���ö����� ����
    {
        moveDir.x = value.Get<Vector2>().x;
        moveDir.z = value.Get<Vector2>().y;
    }
    
    private void OnFire(InputValue value)
    {
        // Instantiate(bulletPrefab, bulletPoint.position, bulletPoint.rotation);   //�ν���Ʈȭ
        
    }

    private Coroutine bulletRoutine;

    IEnumerator BulletMakeRoutine()
    {
        while (true)
        {
            Instantiate(bulletPrefab, bulletPoint.position, bulletPoint.rotation);
            yield return new WaitForSeconds(repeatTime);
        }
    }

    private void OnRepeatFire(InputValue value)
    {
        if (value.isPressed)
        {
            bulletRoutine = StartCoroutine(BulletMakeRoutine());
            Debug.Log("������");
        }
        else
        {
            StopCoroutine(bulletRoutine);
            Debug.Log("�ȴ�����");

        }
    }

    // <Ʈ������ �θ�-�ڽ� ����>
    // Ʈ�������� �θ� Ʈ�������� ���� �� ����
    // �θ� Ʈ�������� �ִ� ��� �θ� Ʈ�������� ��ġ, ȸ��, ũ�� ������ ���� �����
    // �̸� �̿��Ͽ� ������ ������ �����ϴµ� ������ (ex. ���� �����̸�, �հ����� ���� ������)
    // ���̾��Ű â �󿡼� �巡�� & ����� ���� �θ�-�ڽ� ���¸� ������ �� ����
    
    /*private void TransformParent()
    {
        // �ڽ� / �θ� ������ �θ� �����ϰ�� �ڽ��� �θ���ġ�� ������ ������ �����ġ�� ǥ�ð� ��
        GameObject newGameObject = new GameObject() { name = " New Game Obejct" };

        // �θ�����
        transform.parent = newGameObject.transform;

        // �θ� �������� �� Ʈ������
        // transform.localPosition : �θ�Ʈ�������� �ִ� ��� �θ� �������� �� ��ġ
        // transform.localRotation : �θ�Ʈ�������� �ִ� ��� �θ� �������� �� ȸ��
        // transform.localScale    : �θ�Ʈ�������� �ִ� ��� �θ� �������� �� ũ��

        // �θ� ����
        transform.parent = null;   // �θ�Ʈ�������� ���� ��� ���� ������Ʈ�� ���带 �������� ����.

    }
    */
    


    /*
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
        // transform.position += moveDir*moveSpeed * Time.deltaTime;               // �����ð� �������Ӵ� �ɸ��½ð�.
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
        // Ư����ġ�� ���鼭 ȸ���� ������ 
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
    */
}
