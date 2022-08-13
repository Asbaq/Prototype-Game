using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndTrigger2 : MonoBehaviour
{
   void OnTriggerEnter() 
   {
        SceneManager.LoadScene("Level_2_UI");  
   }  
}

