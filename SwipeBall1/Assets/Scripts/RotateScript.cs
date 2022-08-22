using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateScript : MonoBehaviour
{
    [SerializeField] float speed;
    void Update()
    {
        transform.RotateAround(transform.position,Vector3.up * Time.deltaTime * speed, 0.5f);
    }

    private void Awake() {
        GlobalEventManager.RefreshCoin.AddListener(Refresh);
    }

    void Refresh(){
        gameObject.SetActive(true);
    }
}
