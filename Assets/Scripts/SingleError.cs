using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SingleError : MonoBehaviour
{
    public string Error;
    public string Correct;
    public bool isCorrect;
    public string errorMessage;
    private bool isOn;
    public GameObject TextToDisplay;
     
    // Start is called before the first frame update
    void Start()
    {
        TextToDisplay.GetComponent<UnityEngine.UI.Text> ().text = Error;
        isCorrect = false;
        isOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(isOn && Input.GetKey(KeyCode.LeftControl)){
            TextToDisplay.GetComponent<UnityEngine.UI.Text> ().text = Correct;
            isCorrect = true;
        }
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Hammer"){
            isOn = true;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if(col.tag == "Hammer"){
            isOn = false;
        }
    }
}
