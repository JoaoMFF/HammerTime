using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class countdown_timer : MonoBehaviour
{
     public int  Minutes = 5;
     public int  Seconds = 0;
 
     private TextMesh    m_text;
     private float   m_leftTime;
 
     private void Awake()
     {
         m_text = GetComponent<TextMesh>();
         m_leftTime = GetInitialTime();
     }
 
     private void Update()
     {
         if (m_leftTime > 0f)
         {
             //  Update countdown clock
             m_leftTime -= Time.deltaTime;
             Minutes = GetLeftMinutes();
             Seconds = GetLeftSeconds();
 
             //  Show current clock
             if (m_leftTime > 0f)
             {
                 m_text.text = Minutes + ":" + Seconds.ToString("00");
             }
             else
             {
                 //  The countdown clock has finished
                 m_text.text = "Time : 0:00";
             }
         }
     }
 
     private float GetInitialTime()
     {
         return Minutes * 60f + Seconds;
     }
 
     private int GetLeftMinutes()
     {
         return Mathf.FloorToInt(m_leftTime / 60f);
     }
 
     private int GetLeftSeconds()
     {
         return Mathf.FloorToInt(m_leftTime % 60f);
     }
}
