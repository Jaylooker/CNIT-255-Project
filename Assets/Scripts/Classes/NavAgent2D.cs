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
        float changeinposition;
        float totaldistance;
        Vector3 nextposition;
        path.origin = new Vector2(transform.position.x, transform.position.y); //starting point is where the gameobject is
        path.direction = new Vector2(targetdestination.x, targetdestination.y); //create a ray intersecting the origin and the target destination
        totaldistance = Vector2.Distance(path.origin, path.direction); //calculate distance between origin and destination
        changeinposition = velocity / Time.deltaTime; //calculate change in distance 
        nextposition = new Vector3(path.GetPoint(changeinposition).x, path.GetPoint(changeinposition).y); //gets point along ray to move
        transform.Translate(nextposition, Space.Self); //moves gameobject

        //can add avoidance if needed
    }
    

}
