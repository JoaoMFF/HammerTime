using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpDown : MonoBehaviour
{

    public GameObject Platform;
    public bool isOn;
    public bool isOn2;
    
    void Awake()
    {
        isOn = false;
        isOn2 = false;
    }

    void Start()
    {
        isOn2 = false;
        isOn = false;
    }

    void Update()
    {
        if(isOn && Input.GetKey("s")){
            Platform.GetComponent<BoxCollider2D> ().enabled = false;
            StartCoroutine(waitEnable());
        }
        else if( isOn2 && Input.GetKey("down")){
            Platform.GetComponent<BoxCollider2D> ().enabled = false;
            StartCoroutine(waitEnable());
        }
    }

    IEnumerator waitEnable()
    {
        yield return new WaitForSeconds(0.3f);

        Platform.GetComponent<BoxCollider2D> ().enabled = true;
    }

    void OnTriggerStay2D(Collider2D col){
        if(col.tag == "Player"){
            isOn = true;
        }
        else if(col.tag == "Player2"){
            isOn2 = true;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if(col.tag == "Player"){
            isOn = false;
        }else if(col.tag == "Player2"){
            isOn2 = false;
        }
    }
}