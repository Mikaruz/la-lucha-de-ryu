using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Restart : MonoBehaviour
{
    public GameObject horda1;
    public GameObject horda2;
    public GameObject horda3;
    public GameObject horda4;
    public GameObject horda5;
    public GameObject horda6;
    public GameObject horda7;




    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void RestartHordes()
    {
        horda1 = GameObject.Find("ObjetoPadre");
        Transform[] hijos = horda1.GetComponentsInChildren<Transform>();


        for (int i = 1; i < hijos.Length; i++)
        {
            // Destruimos cada hijo
            Destroy(hijos[i].gameObject);
        }
    }
   



}
