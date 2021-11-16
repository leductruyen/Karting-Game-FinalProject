using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(Rigidbody))]

public class Players : MonoBehaviour
{
    [SerializeField]
    [Range(1,100)]
    private float speed;

    [SerializeField]
    [Range(1,100)]
    private float speedrotation;

    [SerializeField]
    [Range(1,100)]
    private float massratio;

    private Rigidbody RigidBody;

    private GameObject[] particle;
    private void Awake(){
        // Get component object's rigidbody
        RigidBody = GetComponent<Rigidbody>();

        // get particle system object with tag "effect"
        particle = GameObject.FindGameObjectsWithTag("effect");
    }
    private void FixedUpdate()
    { 
        // Get Axes input
        float verticle = Input.GetAxis("Vertical");
        float horizon = Input.GetAxis("Horizontal");
        if (Mathf.Abs(horizon)>0.3f && Mathf.Abs(verticle)>1.0f){
            foreach (var effect in particle){
                effect.SetActive(true);
            }       
        }
        else{
            foreach (var effect in particle){
                effect.SetActive(false);
            }
        }
        // Move forward
        if (verticle > 0){
            // Rotate gameobject 
            transform.Rotate(horizon*Vector3.up*speedrotation);
            // Move gameobject 
            RigidBody.AddRelativeForce(verticle*Vector3.forward*speed*massratio*(RigidBody.mass/100f));
        }
        // Move backward
        else if (verticle < 0){
            // Move gameobject 
            RigidBody.AddRelativeForce(verticle*Vector3.forward*speed*massratio*(RigidBody.mass/100f));
            // Rotate gameobject 
            transform.Rotate(-horizon*Vector3.up*speedrotation);
        }
    }
}
