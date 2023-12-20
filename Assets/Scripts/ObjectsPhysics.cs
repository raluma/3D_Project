using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsPhysics : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Game Over!");
    }
}
