using UnityEngine;

public class Position : MonoBehaviour {

    //null reference needs fixing
    private Vector2 pos;
    private float x;
    private float y;

    public Vector2 getposition()
    {
        pos = new Vector2(x, y);
        return pos;
    }

    public void setposition(float x1, float y1)
    {
        pos.Set(x1, y1);
        x = x1;
        y = y1;  
    }

    public float calculatedistance(Vector2 location1, Vector2 location2)
    {
        float distance;
        distance = Vector2.Distance(location1, location2); 
            
        return distance;
    }

}
