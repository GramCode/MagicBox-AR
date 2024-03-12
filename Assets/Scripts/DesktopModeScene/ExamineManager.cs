using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.AR;

public class ExamineManager : MonoBehaviour
{
    private static ExamineManager _instance;
    public static ExamineManager Instance
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
    [SerializeField]
    private float _rotateSpeed = 1;

    private Examine _currentExaminableObject;
    private Vector3 _startingPosition;
    private Quaternion _startingRotation;
    private Vector3 _startingScale;

    private bool _isExamining = false;
    private Transform _parent;    

    private void Update()
    {
        if (_isExamining)
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                switch (touch.phase)
                {
                    case TouchPhase.Moved:
                        _currentExaminableObject.transform.Rotate(touch.deltaPosition.x * _rotateSpeed, touch.deltaPosition.y * _rotateSpeed, 0);
                        break;
                    case TouchPhase.Ended:
                        ARSelectionInteractable aRSelection = _parent.GetComponent<ARSelectionInteractable>();
                        aRSelection.enabled = true;
                        PerformUnexamine(_parent);
                        break;
                }
            }
        }
    }

    public void PerformExamine(Examine examinable, float examineScaleOffset)
    {
        _currentExaminableObject = examinable;

        _startingPosition = _currentExaminableObject.transform.position;
        _startingRotation = _currentExaminableObject.transform.rotation;
        _startingScale = _currentExaminableObject.transform.localScale;

        _parent = _currentExaminableObject.transform.parent;

        _currentExaminableObject.transform.position = _examineTarget.transform.position;
        _currentExaminableObject.transform.parent = _examineTarget;

        Vector3 offsetScale = _startingScale * examineScaleOffset;
        _currentExaminableObject.transform.localScale = offsetScale;

        _isExamining = true;
    }

    public void PerformUnexamine(Transform parent)
    {
        _currentExaminableObject.transform.position = _startingPosition;
        _currentExaminableObject.transform.rotation = _startingRotation;
        _currentExaminableObject.transform.localScale = _startingScale;
        _currentExaminableObject.transform.parent = parent;
        _currentExaminableObject = null;
        _isExamining = false;
    }


}
