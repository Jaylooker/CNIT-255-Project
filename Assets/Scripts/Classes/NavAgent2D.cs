using UnityEngine;
using System.Collections;

public class NavAgent2D : MonoBehaviour
{
    private Vector3 destination;
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
        const float NaN = float.NaN;
        Vector3 NaV = new Vector3(NaN, NaN, NaN);
        if (transform.position != NaV) //if statement fixes errors but not movment
        {
            float changeinposition;
            float totaldistance;
            Vector3 nextposition;
            path.origin = new Vector3(transform.position.x, transform.position.y); //starting point is where the gameobject is
            path.direction = new Vector3(targetdestination.x, targetdestination.y); //create a ray intersecting the origin and the target destination
            totaldistance = Vector3.Distance(path.origin, path.direction); //calculate distance between origin and destination
            changeinposition = velocity / Time.deltaTime; //calculate change in distance 
            nextposition = new Vector3(path.GetPoint(changeinposition).x, path.GetPoint(changeinposition).y); //gets point along ray to move
            transform.LookAt(path.direction);
            transform.Translate(nextposition); //moves gameobject
        }

        //can add avoidance if needed
    }
    

}
