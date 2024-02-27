using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmissionManager : MonoBehaviour
{
    private static EmissionManager _instance;
    public static EmissionManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("Emission Manager is NULL");
            }

            return _instance;
        }
    }



    private void Awake()
    {
        _instance = this;
    }

    public void Emitting(bool isEmitting, Material material, Color color)
    {
        if (isEmitting == true)
        {
            //start emission
            material.SetColor("_EmissionColor", color);
        }
        else
        {
            //End emission
            material.SetColor("_EmissionColor", Color.black);
        }
    }
}
