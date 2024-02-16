using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.AR;

public class PlacementInteractableSelector : MonoBehaviour
{
    [SerializeField]
    private ARPlacementInteractable _arPlacementInteractable;
    [SerializeField]
    private GameObject[] _objectsToPlace;

    private static int _index;

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            _index++;

            if (_index > _objectsToPlace.Length - 1)
            {
                _index = 0;
            }

            _arPlacementInteractable.placementPrefab = _objectsToPlace[_index];
        }
    }

}
