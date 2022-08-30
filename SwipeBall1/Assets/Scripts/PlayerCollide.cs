using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollide : MonoBehaviour
{
    [SerializeField] ParticleSystem particle;
    [SerializeField] AudioClip coinSound;
    [SerializeField] AudioClip winSound;
    [SerializeField] AudioClip loseSound;
    [SerializeField] AudioClip buttonSound;
    public static bool collideWall = false;
    // private void OnCollisionEnter(Collision other) {
    //     if(other.gameObject.CompareTag("Wall")){
    //         Player.instance.playerMove = false;
            
    //         // Player.instance.rb.velocity = Vector3.zero;
    //     }
    // }
    private void OnCollisionStay(Collision other) {
        if(other.gameObject.CompareTag("Wall")){
            collideWall = true;
        }
    }
    private void OnCollisionExit(Collision other) {
        if(other.gameObject.CompareTag("Wall")){
            collideWall = false;
        }
    }

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Button")){
            GlobalEventManager.OpenDoor.Invoke();
            SoundManager.Instance.PlaySound(buttonSound);
        }

        if(other.CompareTag("EndLevel")){
            GlobalEventManager.Win.Invoke();
            SoundManager.Instance.PlaySound(winSound);
        }

        if(other.CompareTag("Coin")){
            other.gameObject.SetActive(false);
            particle.transform.position = other.transform.position;
            particle.Play();
            SoundManager.Instance.PlaySound(coinSound);
        }

        if(other.CompareTag("Enemy")){
            GlobalEventManager.Lose.Invoke();
            SoundManager.Instance.PlaySound(loseSound);
        }
    }
}
