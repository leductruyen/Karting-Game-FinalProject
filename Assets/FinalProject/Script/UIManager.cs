using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using TMPro;
public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Button[] PickLVButton;
    
    [SerializeField]
    private Button StartButton;
    
    [SerializeField]
    private Button PopupStart;

    [SerializeField]
    private Dropdown dropdowncar;
    
    [SerializeField]
    private GameObject[] listcar;
    private GameObject OwnCar;

    [SerializeField]
    private TextMeshProUGUI Coin;
    
    private void Start() {
        StartButton.onClick.AddListener(PopupStartOpen);
    
        PickLVButton[0].onClick.AddListener(()=>
            {
                LoadGameScene(1);
            });
           
        PickLVButton[1].onClick.AddListener(()=>
            {
                LoadGameScene(2);
            });
        Coin.text = $"{DataPlayer.Getcoin()}";
        OwnCar = listcar[DataPlayer.GetCurrentCar()];
        OwnCar.SetActive(true);
        dropdowncar.value = DataPlayer.GetCurrentCar();
        dropdowncar.onValueChanged.AddListener(SelectCar);     
    }

    public void SelectCar(int index){
        for (int i = 0; i < listcar.Length; i++)
        {
            if (i == index)
            {
                listcar[i].SetActive(true);
                OwnCar = listcar[i];
                DataPlayer.SetCurrentCar(index);
            }
            else
            {
                listcar[i].SetActive(false);
            }
        }
    }
    
    private void PopupStartOpen(){
        OwnCar.SetActive(false);
        PopupStart.gameObject.SetActive(true);
        PopupStart.onClick.AddListener(PopupStartClose);
    }

    private void PopupStartClose(){
        Invoke(nameof(ClosePopupStatrt),1);
    }
    
    private void ClosePopupStatrt(){
        PopupStart.gameObject.SetActive(false);
        OwnCar.SetActive(true);
    }

    private void LoadGameScene(int LevelIndex){
        SceneManager.LoadScene("FinalProject/MainScene");
        SceneManager.LoadScene("FinalProject/Enviroment",LoadSceneMode.Additive);
        SceneManager.LoadScene($"FinalProject/Level{LevelIndex}",LoadSceneMode.Additive);
    }
}
