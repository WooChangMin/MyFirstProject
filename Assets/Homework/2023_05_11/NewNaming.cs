using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewNaming : MonoBehaviour
{
    private void Awake()
    {
        gameObject.name = "Player";
        Debug.Log("Awake");
    }
}