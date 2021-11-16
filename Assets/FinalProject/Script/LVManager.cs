using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LVManager : MonoBehaviour
{
    private int Number_item;

    public static LVManager _instance;


    private void Awake() {
        _instance = this;
        Number_item =  GameObject.FindGameObjectsWithTag("Item").Length;
    }

    public void LVObjective(){
        Number_item -=1;

        if (Number_item == 0){
           Invoke(nameof(LoadStartScene),2);
        }
    }
    private void LoadStartScene(){
        SceneManager.LoadScene("FinalProject/Startgame");
    }
    
}
