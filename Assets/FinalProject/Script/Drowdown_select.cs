using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Drowdown_select: MonoBehaviour
{

    private List<string> carlist = new List<string>{"Gray car","Modern car","Truck car", "Racing car"};

    [SerializeField]
    private Dropdown select;

    private void Awake() {
        Instantiate();
    }
    private void Instantiate(){
        foreach (var car in carlist){
            select.options.Add(new Dropdown.OptionData(){
                text=car
            });
        }
    }
}
