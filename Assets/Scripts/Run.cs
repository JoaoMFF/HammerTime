using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Run : MonoBehaviour
{
    private bool isOn;
    public GameObject Erro1;
    public bool Error1Correct;
    private GameObject ErrorMessage;
    private SingleError singleError;
    private GameObject OutputText;

    // Start is called before the first frame update
    void Start()
    {
        isOn = false;

        ErrorMessage = GameObject.Find("Error");
        singleError = ErrorMessage.GetComponent<SingleError>();
        OutputText = GameObject.Find("OutputText");

    }

    // Update is called once per frame
    void Update()
    {
        Error1Correct = singleError.isCorrect;

        if(isOn && Input.GetKey(KeyCode.LeftControl)){

            if(!Error1Correct){
                OutputText.GetComponent<UnityEngine.UI.Text> ().text = singleError.errorMessage;
            }
            else{
                OutputText.GetComponent<UnityEngine.UI.Text> ().text = "";
            }

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
