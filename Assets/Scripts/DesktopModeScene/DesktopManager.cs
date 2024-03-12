using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class DesktopManager : MonoBehaviour
{
    private static DesktopManager _instance;
    public static DesktopManager Instance
    {
        get
        {
            if (_instance == null)
                Debug.LogError("Desktop Manager is NULL");

            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;
    }

    [SerializeField]
    private ARPlaneManager _planeManager;

    public void PlanesVisible(bool isActive)
    {
        foreach (var plane in _planeManager.trackables)
        {
            plane.gameObject.SetActive(isActive);
        }
    }
}
