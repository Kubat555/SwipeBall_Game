using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] float speed;
    bool move = false;
    void Start()
    {
        GlobalEventManager.OpenDoor.AddListener(Open);
        GlobalEventManager.CloseDoor.AddListener(Close);
        GlobalEventManager.RefreshDoor.AddListener(Refresh);
        move = false;
    }

    void Open(){
        LeanTween.moveLocalY(gameObject, -0.46f, 1f);
    }

    void Close(){
        LeanTween.moveLocalY(gameObject, 0.5f, 1f);
    }

    void Refresh(){
        transform.position = new Vector3(transform.position.x, 0.5f, transform.position.z);
    }
}
