using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleWheel : MonoBehaviour
{ 
    private float Axesvalue = 0.3f;
    [SerializeField]
    private GameObject ParticleEffect; 
    
    private void FixedUpdate(){
        float horizon = Input.GetAxis("Horizontal");
        float verticle = Input.GetAxis("Vertical");
        if (Mathf.Abs(horizon)>Axesvalue && Mathf.Abs(verticle)>Axesvalue){
            ParticleEffect.SetActive(true);
        }
        else{
            ParticleEffect.SetActive(false);
        }
    }
}
