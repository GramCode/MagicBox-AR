using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Examinable : MonoBehaviour
{

    public void RequestExamine()
    {
        ExaminableManager.Instance.PerformExamine(this);
    }

    public void RequestUnexamine()
    {
        ExaminableManager.Instance.PerformUnexamine();
    }
}
