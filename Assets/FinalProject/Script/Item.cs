using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField]
    private int score;
    
    [SerializeField]
    private float destime;
    private int check = 1;
    private void OnTriggerEnter(Collider other) {
      if (other.gameObject.CompareTag("Player")){
        check -=1;
        if (check >= 0){
          GameManager._instance.add_score(score);
          Destroy(gameObject,destime);
          LVManager._instance.LVObjective();
        }
        }
    }
}
