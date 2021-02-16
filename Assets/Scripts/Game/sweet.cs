using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sweet : MonoBehaviour
{
    [SerializeField]
    private GameObject myObjectInScene;


    private void OnEnable()
    {
        myObjectInScene.GetComponent<BoxCollider2D>().enabled = true; 
    }


}
