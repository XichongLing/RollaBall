using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed = 15.0f;
    private Rigidbody rb;
    private int count;
    private float movementX;
    private float movementY;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;
    public GameObject caughtTextObject;
    private float boostTimer;
    private bool boosting;
    private float height;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winTextObject.SetActive(false);
        caughtTextObject.SetActive(false);
        boostTimer = 0;
        boosting = false;
    }



    private void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
        if((movementX != 0) || (movementY != 0)){
            caughtTextObject.SetActive(false);
        }

    }

    void SetCountText(){
        countText.text = "Count: " + count.ToString();
        if(count >= 16){
            winTextObject.SetActive(true);
        }

    }

//     void detectHeight(){
//         GameObject.Find("Your_Name_Here").transform.position
//     }



    private void FixedUpdate()
    {
        if(boosting == true){
            boostTimer += Time.deltaTime;
            if( boostTimer >= 0.5){
                speed = 15;
                boosting = false;
                boostTimer = 0;
            }
        }
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);
        if(gameObject.transform.position.y < 0){
            transform.position = new Vector3(0.0f, 0.5f, 0.0f);
        }

    }

    private void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("Pickup")){
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
        if(other.gameObject.CompareTag("SpeedBooster")){
            boosting = true;
            speed = speed * 7;
        }
        if(other.gameObject.CompareTag("Enemy")){
            caughtTextObject.SetActive(true);
            transform.position = new Vector3(0.0f, 0.5f, 0.0f);
        }
    }


}


