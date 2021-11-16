using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField]
    private Transform players;

    private Vector3 fixedvecto;
    // Start is called before the first frame update
    void Start()
    {   // Get relative vecto between player and camera
        fixedvecto = players.position - transform.position;
        // Get Player Object
        players = GameManager._instance.usedcar.transform;
    }

    private void LateUpdate()
    {   // Get the followed camera vector
        Vector3 Camposition = players.position - players.rotation*fixedvecto; 
        
        // Transform camera position following to player position
        transform.position = Camposition;
        transform.LookAt(players);
    }
}
