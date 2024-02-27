using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.AR;
using UnityEngine.Events;

public class PlacementManager : MonoBehaviour
{
    private static PlacementManager _instance;
    public static PlacementManager Instance
    {
        get
        {
            if (_instance == null)
                Debug.LogError("PlacementManager is NULL");

            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;
    }

    private List<PlacementTarget> _placementTargets = new List<PlacementTarget>(3);

    private int _cubesPlaced;
    private int _placedCorrectly;
    private const int AMOUNTOFTARGETS = 3;

    private Vector3[] _originPosition = new Vector3[3];
    private ToyCube[] _cubes = new ToyCube[3];

    public UnityEvent gameIsWon;

    public void CubePlaced()
    {
        _cubesPlaced++;
    }

    public int CubesPlaced()
    {
        return _cubesPlaced;
    }

    public void AreCubesPlacedCorrectly()
    {

        if (_cubesPlaced == AMOUNTOFTARGETS && _placedCorrectly != AMOUNTOFTARGETS)
        {
            ResetGame();
        }
        else if (_cubesPlaced == AMOUNTOFTARGETS && _placedCorrectly == AMOUNTOFTARGETS)
        {
            GameComplete();
        }
    }

    private void ResetGame()
    {
        _placedCorrectly = 0;
        _cubesPlaced = 0;
        ResetCubesPostition();

        Invoke("EnableARSelectionInteractable", 1f);

        foreach (var cube in _cubes)
        {
            cube.ChangeEmission(false);
        }
    }

    private void GameComplete()
    {
        //AnimationManager.Instance.OpenLid();
        gameIsWon.Invoke();
    }

    public void PlacedCorrectly()
    {
        _placedCorrectly++;
    }

    public void SetCube(ToyCube cube, int index)
    {
        _originPosition[index] = cube.transform.position;
        _cubes[index] = cube;
    }

    public void SetPlacementTarget(PlacementTarget placementTarget)
    {
        _placementTargets.Add(placementTarget);
    }

    public void SetCubePosition(ToyCube cube, int index)
    {
        cube.transform.position = _placementTargets[index].transform.position;
    }

    private void ResetCubesPostition()
    {
        int index = 0;
        foreach (var cube in _cubes)
        {
            cube.transform.position = _originPosition[index];
            index++;
        }
    }

    private void EnableARSelectionInteractable()
    {
        foreach (var cube in _cubes)
        {
            ARSelectionInteractable cubeSeletor = cube.transform.parent.GetComponent<ARSelectionInteractable>();

            if (cubeSeletor != null)
                cubeSeletor.enabled = true;
        }
    }

    
}
