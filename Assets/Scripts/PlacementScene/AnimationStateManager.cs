using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStateManager : MonoBehaviour
{
    [SerializeField]
    private Animator _anim;

    private static int _randomNum;

    private void Start()
    {
        _randomNum ++;

        if (_randomNum > 3)
        {
            _randomNum = 0;
        }

        AnimationToPlay(_randomNum);
    }

    private void AnimationToPlay(int index)
    {
        _anim.SetInteger("State", index);
    }
}
