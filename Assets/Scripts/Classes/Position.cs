using UnityEngine;

public class Position : MonoBehaviour {

    Vector2 pos;

    public Vector2 getposition()
    {
        pos = new Vector2(transform.position.x, transform.position.y);
        return pos;
    }

    public void setposition(float x, float y)
    {
        pos.Set(x, y);
        
    }

    public float calculatedistance(Vector2 location1, Vector2 location2)
    {
        float distance;
        distance = Vector2.Distance(location1, location2); 
            
        return distance;
    }

}
