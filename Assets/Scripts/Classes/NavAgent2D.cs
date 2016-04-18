using UnityEngine;
using System.Collections;

public class NavAgent2D : MonoBehaviour
{
    private Vector3 destination;
    private Ray2D path;
    private float velocity;

    public float getvelocity()
    {
        return velocity;
    }
    public void setvelocity(float v)
    {
        velocity = v;
    }

    public void SetDestination(Vector3 targetdestination) //linear movement
    {
        destination = targetdestination;
            path.origin = new Vector2(transform.position.x, transform.position.y); //starting point of where the gameobject is
            path.direction = new Vector2(destination.x, destination.y); //create a 2d ray intersecting the origin and the target destination
                                                                        //Vector3
            transform.position = Vector3.MoveTowards(transform.position, destination, Time.deltaTime * velocity);
            //transform.position = Vector2.MoveTowards(path.origin, path.direction, Time.deltaTime * velocity);
            //transform.position = Vector2.MoveTowards(transform.position, destination, Time.deltaTime * velocity);
            transform.LookAt(transform.position); // rotate towards direction of movement
            //Debug.Log(destination);
        //Debug.Log(path.origin);
        //Debug.Log(path.direction);

        //can add avoidance if needed
    }
    

}
