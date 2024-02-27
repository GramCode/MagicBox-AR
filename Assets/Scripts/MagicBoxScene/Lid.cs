using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lid : MonoBehaviour
{
    [SerializeField]
    private Animator _anim;

    private void Start()
    {
        AnimationManager.Instance.SetLidAnimator(_anim);
    }
}
