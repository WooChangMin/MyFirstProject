using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class UnityBasic : MonoBehaviour
{
    public AudioSource audioSource;
    public GameObject player;
    public Rigidbody[] body;
    public Rigidbody body1;

    public void Start()
    {
        GameObjectBasic();
        ComponentBasic();
    }
    public void GameObjectBasic()
    {
        // <게임 오브젝트 접근>
        // 컴포넌트가 붙어있는 게임오브젝트는 gameObject 속성을 이용하여 접근 가능

        // 컴포넌트가 붙어있는 게임오브젝트

        // gameObject.name = "Player";
        // gameObject.SetActive(false);
        // gameObject.tag = "";
        // gameObject.layer;

        // player = GameObject.Find("Player");  // 이름으로 다른 object를 찾는 방법
        GameObject obj = GameObject.FindGameObjectWithTag("Player");
        GameObject.FindGameObjectsWithTag("Player");  // 태그로 모두 찾기

        // <게임오브젝트 생성>
        GameObject newObject = new GameObject();      // 새로운 게임오브젝트 생성
        newObject.name = "New Game Object";
        // GameObject newObject = new GameObject("New Game Object");

        // <게임오브젝트 삭제>
        // Destroy(obj, 5f);
    }

    public void ComponentBasic()
    {
        // <게임오브젝트 내 컴포넌트 접근>
        audioSource = GetComponent<AudioSource>();
        audioSource = gameObject.GetComponent<AudioSource>();     //위아래는 동일함!

        gameObject.GetComponent<AudioSource>();  //게임오브젝트의 컴포넌트 접근.
        gameObject.GetComponents<AudioSource>(); //게임오브젝트의 다수의 컴포넌트 접근.

        body = GetComponentsInChildren<Rigidbody>();                      // 자식의 컴퍼넌트 찾기
        GetComponentsInChildren<Rigidbody>();
        

        GetComponentInParent<Rigidbody>();                         // 자신을포함해서 부모에서 컴퍼넌트를찾는경우

        // <컴포넌트 탐색>
        FindObjectOfType<Rigidbody>();                             // 씬 내의 컴포넌트 탐색

        // <컴포넌트 추가>
        // Rigidbody rigid = new Rigidbody();                      // 생성은 가능하지만 의미가 없음, 컴포넌트는 게임 오브젝트에 부착되어 동작함에 의미가 있음.
        Rigidbody rigid = gameObject.AddComponent<Rigidbody>();                      // 어떤오브젝트에 컴퍼넌트를 붙일지 정해주어야함.
        //
        // <컴포넌트 삭제>
        Destroy(rigid);                                             // 오브젝트의 삭제와 동일하게 사용하면됨.
        Destroy(GetComponent<Rigidbody>());                         // 특정 컴퍼넌트를 getcomponent로 찾아서 지울수도 있음
    }

}