using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField]
    private Rigidbody _rigid;
    [SerializeField]
    private float _jumpForce = 4f;

    void Start()
    {
        CubeBehavior();
    }

    private void CubeBehavior()
    {
        _rigid.AddForce(Vector2.up * _jumpForce * Time.deltaTime, ForceMode.Force);
    }
}
