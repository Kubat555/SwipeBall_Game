using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;
    [SerializeField] float speed;
    [SerializeField] float minSwipeLength;
    [SerializeField] float maxVelocity;
    float horizontal;
    float vertical;
    [HideInInspector] public Rigidbody rb;
    [HideInInspector] public bool playerMove;
    private Vector3 startTouchPosition, endTouchPosition;

    private void Awake() {
        if(instance == null){
            instance = this;
        }
    }
    private void Start() {
        rb = GetComponent<Rigidbody>();
        playerMove = false;
    }
    private void Update() {

        // if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began){
        //     startTouchPosition = Input.GetTouch(0).position;

        // }

        // if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended){
        //     endTouchPosition = Input.GetTouch(0).position;

        //     if(startTouchPosition.x < endTouchPosition.x){
        //         horizontal = 1;
        //     }
        //     else if(startTouchPosition.x > endTouchPosition.x){
        //         horizontal = -1;
        //     }

        //     if(startTouchPosition.y < endTouchPosition.y){
        //         vertical = 1;
        //     }
        //     else if(startTouchPosition.y > endTouchPosition.y){
        //         vertical = -1;
        //     }

        //     transform.TransformDirection(new Vector3(horizontal * speed * Time.deltaTime, 0, vertical * speed * Time.deltaTime));
        //     // horizontal = 0;
        //     // vertical = 0;
        // }
       

        if (Input.GetMouseButtonDown(0) && GameManager.inGame && !playerMove)
        {
            Vector3 mouse = Input.mousePosition;
            Ray castPoint = Camera.main.ScreenPointToRay(mouse);
            RaycastHit hit;
            if (Physics.Raycast(castPoint, out hit, Mathf.Infinity))
            {
                startTouchPosition = hit.point;
            }
            Debug.Log("StartPosition " + startTouchPosition);
        }

         if (Input.GetMouseButtonUp(0) && GameManager.inGame && !playerMove)
        {
            Vector3 mouse = Input.mousePosition;
            Ray castPoint = Camera.main.ScreenPointToRay(mouse);
            RaycastHit hit;
            if (Physics.Raycast(castPoint, out hit, Mathf.Infinity))
            {
                endTouchPosition = hit.point;
            }

            if(startTouchPosition.x < endTouchPosition.x && Mathf.Abs(Mathf.Abs(startTouchPosition.z) - Mathf.Abs(endTouchPosition.z)) < Mathf.Abs(Mathf.Abs(startTouchPosition.x) - Mathf.Abs(endTouchPosition.x))){
                horizontal = 1;
                vertical = 0;
            }
            else if(startTouchPosition.x > endTouchPosition.x && Mathf.Abs(Mathf.Abs(startTouchPosition.z) - Mathf.Abs(endTouchPosition.z)) < Mathf.Abs(Mathf.Abs(startTouchPosition.x) - Mathf.Abs(endTouchPosition.x))){
                horizontal = -1;
                vertical = 0;
            }

            else if(startTouchPosition.z < endTouchPosition.z && Mathf.Abs(Mathf.Abs(startTouchPosition.x) - Mathf.Abs(endTouchPosition.x)) < Mathf.Abs(Mathf.Abs(startTouchPosition.z) - Mathf.Abs(endTouchPosition.z))){
                vertical = 1;
                horizontal = 0;
            }
            else if(startTouchPosition.z > endTouchPosition.z && Mathf.Abs(Mathf.Abs(startTouchPosition.x) - Mathf.Abs(endTouchPosition.x)) < Mathf.Abs(Mathf.Abs(startTouchPosition.z) - Mathf.Abs(endTouchPosition.z))){
                vertical = -1;
                horizontal = 0;
            }
            Debug.Log("EndPosition " + endTouchPosition);
            
            // horizontal = 0;
            // vertical = 0;
        }

        print("move: " + playerMove);
        print("collide: " + PlayerCollide.collideWall);

        if(rb.velocity != Vector3.zero){
            playerMove = true;
        }else{
            playerMove = false;
        }

    }
    

    private void FixedUpdate() {
        
        if(!playerMove && GameManager.inGame){
            // if (rb.velocity.magnitude >= maxVelocity)
            // {
            //     rb.velocity = rb.velocity.normalized * maxVelocity;
            // }
            rb.velocity = new Vector3(horizontal * speed * Time.deltaTime, 0, vertical * speed * Time.deltaTime);
        }
        
        // if(rb.velocity == Vector3.zero && PlayerCollide.collideWall){
        //     playerMove = false;
        // }
    }

    public void DisactrivateVectors(){
        horizontal = 0;
        vertical = 0;
    }

}
