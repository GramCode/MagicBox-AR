using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementTarget : MonoBehaviour
{
    private void Start()
    {
        PlacementManager.Instance.SetPlacementTarget(this);
    }
}
