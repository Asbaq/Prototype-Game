using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndTigger1 : MonoBehaviour
{
   void OnTriggerEnter() 
   {
        SceneManager.LoadScene("Level_1_UI");  
   }    
}
