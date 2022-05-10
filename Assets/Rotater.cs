using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotater : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Vector3 _Rotation;
    [SerializeField] private float _rotationSpeed = 3f;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(_Rotation * _rotationSpeed * Time.deltaTime);
    }
}
