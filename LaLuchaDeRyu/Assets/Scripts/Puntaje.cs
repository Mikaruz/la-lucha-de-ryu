using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Puntaje : MonoBehaviour
{
    private float puntos;
    private TextMeshProUGUI textMesh;
    public int puntoExtra = 0;


    // Start is called before the first frame update
    void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        //puntos += Time.deltaTime;
        textMesh.text = "Points: " + puntos.ToString("0");
    }

    public void SumarPuntos(float puntosEntrada)
    {
        puntos += puntosEntrada;
    }

    public void RestartPoints()
    {
        puntos = 0;
    }

    public void OneP()
    {
        puntos += 1;
    }
}
