using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    private static AnimationManager _instance;
    public static AnimationManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("Emission Manager is NULL");
            }

            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;
    }

    private Animator _lidAnimator;

    public void SetLidAnimator(Animator anim)
    {
        _lidAnimator = anim;
    }

    public void OpenLid()
    {
        _lidAnimator.SetTrigger("Open");
    }
}
