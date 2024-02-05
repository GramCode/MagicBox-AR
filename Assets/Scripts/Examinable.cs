using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Examinable : MonoBehaviour
{
    [SerializeField]
    private float _examineScaleOffset = 1;
    [SerializeField]
    private Transform _parent;

    public void RequestExamine()
    {
        ExaminableManager.Instance.PerformExamine(this, _examineScaleOffset);
    }

    public void RequestUnexamine()
    {
        ExaminableManager.Instance.PerformUnexamine(_parent);
    }
}
