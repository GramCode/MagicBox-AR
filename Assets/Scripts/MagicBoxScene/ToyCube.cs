using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToyCube : MonoBehaviour
{
    [SerializeField]
    private int _id;
    [SerializeField]
    private Color _emissionColor;
    
    private Material _targetMaterial;

    private Renderer _renderer;

    private void Start()
    {
        _renderer = GetComponent<Renderer>();

        if (_renderer == null)
        {
            Debug.Log("Renderer in ToyCube is NULL");
        }

        PlacementManager.Instance.SetCube(this, _id);
        _targetMaterial = _renderer.material;
    }

    public int CubeID()
    {
        return _id;
    }

    public void PlaceObject()
    {
        ExaminableManager.Instance.PlaceOnTarget(this);
    }

    public void ChangeEmission(bool isEmitting)
    {
        if (isEmitting == true)
        {
            _targetMaterial.SetColor("_EmissionColor", _emissionColor);
        }
        else
        {
            _targetMaterial.SetColor("_EmissionColor", Color.black);
        }
    }
}
