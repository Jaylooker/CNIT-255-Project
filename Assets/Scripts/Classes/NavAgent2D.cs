using UnityEngine;
using System.Collections;

public class NavAgent2D : MonoBehaviour
{
    private Vector3 destination = Vector3.zero;
    private Ray path;
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
        //maybe try using rigidbodies with .Addforce()
        float totaldistance;
        destination = targetdestination;
        if (transform.position != destination) //if not at destination
        {
            Vector3 nextposition;
            path.origin = new Vector3(transform.position.x, transform.position.y); //starting point is where the gameobject is
            path.direction = new Vector3(destination.x, destination.y); //create a ray intersecting the origin and the target destination
            totaldistance = Vector3.Distance(path.origin, path.direction); //calculate distance between origin and destination
            nextposition = new Vector3(path.GetPoint(velocity).x, path.GetPoint(velocity).y); //gets point along ray to move
            //transform.LookAt(path.direction);
            transform.Translate(nextposition); //moves gameobject
            //gameObject.GetComponent<Rigidbody2D>().MovePosition(nextposition);
        }
        //Debug.Log(destination);

        //can add avoidance if needed
    }
    

}
