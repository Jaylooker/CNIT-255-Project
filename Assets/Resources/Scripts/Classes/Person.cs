using UnityEngine;
using System.Collections;

public class Person : MonoBehaviour {

    protected float health, damage;
    protected Vector3 targetpos;
    protected NavAgent2D agent;
    protected BoundaryScript boundary;
    protected AudioClip audio1;
    protected Animation animup, animdown, animleft, animright;

    public float gethealth()
    {
        return health;
    }

    public void sethealth(float h)
    {
        health = h;
    }

}
