using UnityEngine;
using System.Collections;

public class Person : MonoBehaviour {

    protected float health;
    protected bool atTopBoundary, atBottomBoundary, atLeftBoundary, atRightBoundary;
    protected Vector3 targetpos;
    protected NavAgent2D agent;
    protected BoundaryScript boundary;
    protected AudioClip audio1;

}
