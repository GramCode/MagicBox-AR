using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Examine : MonoBehaviour
{
    [SerializeField]
    private float _examineScaleOffset = 1;
    [SerializeField]
    private Transform _parent;

    public void RequestExamine()
    {
        ExamineManager.Instance.PerformExamine(this, _examineScaleOffset);
    }

    public void RequestUnexamine()
    {
        ExamineManager.Instance.PerformUnexamine(_parent);
    }
}
