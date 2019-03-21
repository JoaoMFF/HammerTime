using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpDown : MonoBehaviour
{

    public GameObject Platform;
    private bool keyDown;
    private bool isOn;
    
    void Awake()
    {
        keyDown = false;
        isOn = false;
    }

    void Start()
    {
        keyDown = false;
        isOn = false;
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
        yield return new WaitForSeconds(0.3f);

        Platform.GetComponent<BoxCollider2D> ().enabled = true;
    }

    void LateUpdate(){
        keyDown = false;
    }

    void OnTriggerStay2D(Collider2D col){
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