using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundScript : MonoBehaviour
{
    void Update()
    {

        if (PlayerScript.PlayerPos.x - transform.position.x >= 10.0f) 
        {
            Destroy(gameObject);
        }
    }
}
