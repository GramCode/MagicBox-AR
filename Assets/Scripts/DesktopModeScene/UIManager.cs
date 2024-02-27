using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private static UIManager _instance;
    public static UIManager Instance
    {
        get
        {
            if (_instance == null)
                Debug.LogError("PlacementManager is NULL");

            return _instance;
        }
    }

    [SerializeField]
    private GameObject[] _buttons;
    [SerializeField]
    private GameObject _addButton;
    [SerializeField]
    private GameObject _removeButton;

    private int _modelsPlaced;
    private int _currentButtonID;
    private int _removedModelsCount;
    private GameObject _currentSelectedObject;

    private void Awake()
    {
        _instance = this;
    }

    public void ButtonPressedID(int buttonID)
    {
        _currentButtonID = buttonID;
    }

    public void HideButton()
    {
        _buttons[_currentButtonID].SetActive(false);
    }

    private bool AnyButtonToShow()
    {
        bool anyButtonActive = false;

        foreach (var button in _buttons)
        {
            if (button.activeInHierarchy == true)
            {
                anyButtonActive = true;
            }

        }

        return anyButtonActive;
    }

    public void DisplayAddButton()
    {
        /*
        if (AnyButtonToShow() == true)
        {
            _addButton.SetActive(true);
        }
        */

        if (_modelsPlaced < 3)
        {
            _addButton.SetActive(true);
        }
        else
        {
            _addButton.SetActive(false);
        }
    }

    public void PlaceModel()
    {
        _modelsPlaced += 1;
    }

    public void SelectedObject(GameObject obj)
    {
        _currentSelectedObject = obj;
        _removeButton.SetActive(true);
    }

    public void RemoveSelectedModel()
    {
        _removedModelsCount += 1;
        Destroy(_currentSelectedObject);

        if (_removedModelsCount == 3)
        {
            _removedModelsCount = 0;
            _modelsPlaced = 0;
            _addButton.SetActive(true);

            foreach (var button in _buttons)
            {
                button.SetActive(true);
            }
        }
    }

    public void HideRemoveButton()
    {
        _removeButton.SetActive(false);
    }
}
