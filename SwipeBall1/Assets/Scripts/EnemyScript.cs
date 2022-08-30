using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    Animator anim;
    SphereCollider collide;
    private void Awake() {
        anim = GetComponent<Animator>();
        collide = GetComponent<SphereCollider>();
        GlobalEventManager.RefreshCoin.AddListener(Refresh);
        GlobalEventManager.OpenDoor.AddListener(TransformToWall);
    }

    void Refresh(){
        anim.SetBool("Transform", false);
        gameObject.SetActive(true);
        collide.enabled = true;
    }

    void TransformToWall(){
        collide.enabled = false;
        anim.SetBool("Transform", true);
    }
}
