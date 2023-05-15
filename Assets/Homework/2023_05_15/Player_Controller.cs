using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Controller : MonoBehaviour
{

    [SerializeField] private Bullet bullet;
    [SerializeField] private float RepeatTime;
    private void OnFire(InputValue value)
    {
        Instantiate(bullet, transform.forward, transform.rotation);
    }

    private Coroutine Rapidroutine;

    IEnumerator Rapidbullet()
    {
        while (true)
        {
            Instantiate(bullet, transform.forward, transform.rotation);
            yield return new WaitForSeconds(RepeatTime);
        }
    }
    private void RapidFire(InputValue value)
    {
        if (value.isPressed)
        {
            Rapidroutine = StartCoroutine(Rapidbullet());
            Debug.Log("´­¸²");
        }
        else
        {
            StopCoroutine(Rapidroutine);
            Debug.Log("¶À");
        }
    }
}