using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExaminableManager : MonoBehaviour
{
    private static ExaminableManager _instance;
    public static ExaminableManager Instance
    {
        get
        {
            if (_instance == null)
                Debug.LogError("Examinable Manager is NULL");

            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;
    }

    [SerializeField]
    private Transform _examineTarget;
    private Examinable _currentExaminableObject;
    private Vector3 _startingPosition;
    private Quaternion _startingRotation;

    public void PerformExamine(Examinable examinable)
    {
        _currentExaminableObject = examinable;

        _startingPosition = _currentExaminableObject.transform.position;
        _startingRotation = _currentExaminableObject.transform.rotation;

        _currentExaminableObject.transform.position = _examineTarget.transform.position;
        _currentExaminableObject.transform.parent = _examineTarget;        
    }

    public void PerformUnexamine()
    {
        _currentExaminableObject.transform.position = _startingPosition;
        _currentExaminableObject.transform.rotation = _startingRotation;
        _currentExaminableObject.transform.parent = null;
    }

}
