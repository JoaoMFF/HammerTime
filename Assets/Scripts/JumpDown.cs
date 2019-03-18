using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpDown : MonoBehaviour
{

    public GameObject Platform;
    public bool keyDown;
    public bool isOn;
    
    void Awake()
    {
        keyDown = false;
        isOn = false;
    }

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKey("down") || Input.GetKey("s"))
        {
            keyDown = true;
        }

        if(keyDown && isOn){
            Platform.GetComponent<BoxCollider2D> ().enabled = false;
            StartCoroutine(waitEnable());
        }

    }

    IEnumerator waitEnable()
    {
        yield return new WaitForSeconds(0.5f);

        Platform.GetComponent<BoxCollider2D> ().enabled = true;
    }

    void LateUpdate(){
        keyDown = false;
    }

    // when the GameObjects collider arrange for this GameObject to travel to the left of the screen
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player"){
            isOn = true;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if(col.tag == "Player"){
            isOn = false;
        }
    }
}