using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SportCar : MonoBehaviour
{
    [SerializeField]
    private Color _emissionColor;
    [SerializeField]
    private MeshRenderer _mesh;

    public void ChangeEmission(bool isEmitting)
    {
        if (isEmitting)
            _mesh.material.SetColor("_EmissionColor", _emissionColor);
        else
            _mesh.material.SetColor("_EmissionColor", Color.black);

    }
}
