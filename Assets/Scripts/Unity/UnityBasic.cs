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
        // <���� ������Ʈ ����>
        // ������Ʈ�� �پ��ִ� ���ӿ�����Ʈ�� gameObject �Ӽ��� �̿��Ͽ� ���� ����

        // ������Ʈ�� �پ��ִ� ���ӿ�����Ʈ

        // gameObject.name = "Player";
        // gameObject.SetActive(false);
        // gameObject.tag = "";
        // gameObject.layer;

        // player = GameObject.Find("Player");  // �̸����� �ٸ� object�� ã�� ���
        GameObject obj = GameObject.FindGameObjectWithTag("Player");
        GameObject.FindGameObjectsWithTag("Player");  // �±׷� ��� ã��

        // <���ӿ�����Ʈ ����>
        GameObject newObject = new GameObject();      // ���ο� ���ӿ�����Ʈ ����
        newObject.name = "New Game Object";
        // GameObject newObject = new GameObject("New Game Object");

        // <���ӿ�����Ʈ ����>
        // Destroy(obj, 5f);
    }

    public void ComponentBasic()
    {
        // <���ӿ�����Ʈ �� ������Ʈ ����>
        audioSource = GetComponent<AudioSource>();
        audioSource = gameObject.GetComponent<AudioSource>();     //���Ʒ��� ������!

        gameObject.GetComponent<AudioSource>();  //���ӿ�����Ʈ�� ������Ʈ ����.
        gameObject.GetComponents<AudioSource>(); //���ӿ�����Ʈ�� �ټ��� ������Ʈ ����.

        body = GetComponentsInChildren<Rigidbody>();                      // �ڽ��� ���۳�Ʈ ã��
        GetComponentsInChildren<Rigidbody>();
        

        GetComponentInParent<Rigidbody>();                         // �ڽ��������ؼ� �θ𿡼� ���۳�Ʈ��ã�°��

        // <������Ʈ Ž��>
        FindObjectOfType<Rigidbody>();                             // �� ���� ������Ʈ Ž��

        // <������Ʈ �߰�>
        // Rigidbody rigid = new Rigidbody();                      // ������ ���������� �ǹ̰� ����, ������Ʈ�� ���� ������Ʈ�� �����Ǿ� �����Կ� �ǹ̰� ����.
        Rigidbody rigid = gameObject.AddComponent<Rigidbody>();                      // �������Ʈ�� ���۳�Ʈ�� ������ �����־����.
        //
        // <������Ʈ ����>
        Destroy(rigid);                                             // ������Ʈ�� ������ �����ϰ� ����ϸ��.
        Destroy(GetComponent<Rigidbody>());                         // Ư�� ���۳�Ʈ�� getcomponent�� ã�Ƽ� ������� ����
    }

}