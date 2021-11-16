using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    [SerializeField] private float rotationspeed;

    // Update is called once per frame
    private void Update() {
        var time =+ Time.deltaTime; 
        transform.Rotate((time % 360)*rotationspeed*Vector3.up);
    }
}
