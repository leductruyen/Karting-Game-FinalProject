using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager _instance;

    private int _score = 0;

    [SerializeField]
    private Button btn_play;
    
    [SerializeField]
    private TextMeshProUGUI Score_txts;

    [SerializeField]
    private GameObject[] listcar;
    public GameObject usedcar {private set; get;}
    private Vector3 initialcarposition = new Vector3 (31.33f,-7.72f,-27.5f); 

    private void Awake() {
        _instance = this;
        usedcar = GameObject.Instantiate(listcar[DataPlayer.GetCurrentCar()],transform);
        usedcar.transform.position = initialcarposition;
        usedcar.SetActive(false);
    }
    

    public void Enable(){
        usedcar.SetActive(true);
        btn_play.gameObject.SetActive(false);
        Score_txts.gameObject.SetActive(true);
    }

    public void add_score(int score){

       _score += score;
       
       Score_txts.text = $"Score: {_score}";
       DataPlayer.Addcoin(score);
    }
}
