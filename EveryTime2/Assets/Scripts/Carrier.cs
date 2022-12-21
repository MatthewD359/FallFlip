using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Carrier : MonoBehaviour
{
    public ConstraintSource constraint;

    void Awake()
    {
        constraint.sourceTransform = transform;
        constraint.weight = 1;
    }
}