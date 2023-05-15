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

    private void Update()  // 업데이트 메시지함수 -> 게임의 매프레임마다 호출되어 사용 프레임마다 호출되므로 내가 800프레임에서 1초만 눌렀다가 때도 800번이입력됨
    {                      // 프레임별로 이동거리에 차이가 나므로 
        // transform과 addforce 차이-> transform은 누르자마자 해당위치로 이동 -> 탄막게임에 주로사용  
        // Addforce의 경우 폴가이즈와 같이 물리엔진의 가속 영향이 필요할경우에 리지드바디와 함께 사용

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

    private void OnMove(InputValue value)   //인풋값이 들어올때마다 변함
    {
        moveDir.x = value.Get<Vector2>().x;
        moveDir.z = value.Get<Vector2>().y;
    }
    
    private void OnFire(InputValue value)
    {
        // Instantiate(bulletPrefab, bulletPoint.position, bulletPoint.rotation);   //인스턴트화
        
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
            Debug.Log("누를때");
        }
        else
        {
            StopCoroutine(bulletRoutine);
            Debug.Log("안누를떄");

        }
    }

    // <트랜스폼 부모-자식 상태>
    // 트랜스폼은 부모 트랜스폼을 가질 수 있음
    // 부모 트랜스폼이 있는 경우 부모 트랜스폼의 위치, 회전, 크기 변경이 같이 적용됨
    // 이를 이용하여 계층적 구조를 정의하는데 유용함 (ex. 팔이 움직이면, 손가락도 같이 움직임)
    // 하이어라키 창 상에서 드래그 & 드롭을 통해 부모-자식 상태를 변경할 수 있음
    
    /*private void TransformParent()
    {
        // 자식 / 부모를 가지고 부모가 움직일경우 자식은 부모위치의 기준을 가지는 상대위치로 표시가 됨
        GameObject newGameObject = new GameObject() { name = " New Game Obejct" };

        // 부모지정
        transform.parent = newGameObject.transform;

        // 부모를 기준으로 한 트랜스폼
        // transform.localPosition : 부모트랜스폼이 있는 경우 부모를 기준으로 한 위치
        // transform.localRotation : 부모트랜스폼이 있는 경우 부모를 기준으로 한 회전
        // transform.localScale    : 부모트랜스폼이 있는 경우 부모를 기준으로 한 크기

        // 부모 해제
        transform.parent = null;   // 부모트랜스폼이 없는 모든 게임 오브젝트는 월드를 기준으로 잡힘.

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
    */
}
