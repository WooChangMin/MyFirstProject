using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityTransform : MonoBehaviour
{
    /************************************************************************
        * 트랜스폼 (Transform)
        * 
        * 게임오브젝트의 위치, 회전, 크기를 저장하는 컴포넌트
        * 게임오브젝트의 부모-자식 상태를 저장하는 컴포넌트
        * 게임오브젝트는 반드시 하나의 트랜스폼 컴포넌트를 가지고 있으며 추가 & 제거할 수 없음
        ************************************************************************/

    private void Start()
    {
        TranslateMove();
    }

    // <Quarternion & Euler>
    // Quarternion	: 유니티의 게임오브젝트의 3차원 방향을 저장하고 이를 방향에서 다른 방향으로의 상대 회전으로 정의
    //				  기하학적 회전으로 짐벌락 현상이 발생하지 않음
    // EulerAngle	: 3축을 기준으로 각도법으로 회전시키는 방법
    //				  직관적이지만 짐벌락 현상이 발생하여 회전이 겹치는 축이 생길 수 있음
    // 짐벌락		: 같은 방향으로 오브젝트의 두 회전 축이 겹치는 현상

    // Quarternion을 통해 회전각도를 계산하는 것은 직관적이지 않고 이해하기 어려움
    // 보통의 경우 쿼터니언 -> 오일러각도 -> 연산진행 -> 결과오일러각도 -> 결과쿼터니언 과 같이 연산의 결과 쿼터니언을 사용함

    private void TranslateMove()
    {
        
        transform.position = new Vector3(0,10,0);            // 위치 이동시켜주는 함수 transform의 경우 바로 가져올수 있음 -> 무조건 붙어있기때문
        transform.localScale = new Vector3(3, 3, 3);
    }

}
