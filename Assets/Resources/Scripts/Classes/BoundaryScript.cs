using UnityEngine;
using System.Collections;

public class BoundaryScript : MonoBehaviour {

    //made to work like a square or rectangle
    protected bool atTopBoundary, atBottomBoundary, atLeftBoundary, atRightBoundary;
    private Vector2 TLCorner, TRCorner, BLCorner, BRCorner; //TL (Top Left) BR (Bottom Right)
    private RaycastHit2D TopBoundary, BottomBoundary, LeftBoundary, RightBoundary;
    // Use this for initialization
	void Start () {
        TLCorner = new Vector2 (GameObject.Find("TLCorner").transform.position.x, GameObject.Find("TLCorner").transform.position.y);
        TRCorner = new Vector2(GameObject.Find("TRCorner").transform.position.x, GameObject.Find("TRCorner").transform.position.y);
        BLCorner = new Vector2 (GameObject.Find("BLCorner").transform.position.x, GameObject.Find("BLCorner").transform.position.y);
        BRCorner = new Vector2(GameObject.Find("BRCorner").transform.position.x, GameObject.Find("BRCorner").transform.position.y);
        atTopBoundary = false;
        atBottomBoundary = false;
        atLeftBoundary = false;
        atRightBoundary = false;

	}
	
	void FixedUpdate ()
    {
        TopBoundary = Physics2D.Linecast(TLCorner, TRCorner); //creates a line in between 2 points and finds any colliders that cross the line
        BottomBoundary = Physics2D.Linecast(BLCorner, BRCorner);
        LeftBoundary = Physics2D.Linecast(TLCorner, BLCorner);
        RightBoundary = Physics2D.Linecast(TRCorner, BRCorner);
    }

    public void CheckBoundaryFor(string tag)
    {
        atTopBoundary = false;
        atBottomBoundary = false;
        atLeftBoundary = false;
        atRightBoundary = false;

        if (TopBoundary != false && TopBoundary.collider.name == typeof(BoxCollider2D).Name && TopBoundary.transform.tag == tag) //if collider is not null, is box collider, and tag is parameter
        {
            atTopBoundary = true;
            Debug.Log("Hit top");
        }

        if (BottomBoundary!= false && BottomBoundary.collider.name == typeof(BoxCollider2D).Name && BottomBoundary.transform.tag == tag)
        {
            atBottomBoundary = true;
            //Debug.Log("Hit bottom");
        }

        if (LeftBoundary != false && LeftBoundary.collider.name == typeof(BoxCollider2D).Name && LeftBoundary.transform.tag == tag)
        {
            atLeftBoundary = true;
            //Debug.Log("Hit left");
        }

        if (RightBoundary != false && RightBoundary.collider.name == typeof(BoxCollider2D).Name && RightBoundary.transform.tag == tag)
        {
            atRightBoundary = true;
            Debug.Log("Hit right");
        }
    }

    public RaycastHit2D getTopBoundary()
    {
        return TopBoundary;
    }

    public RaycastHit2D getBottomBoundary()
    {
        return BottomBoundary;
    }

    public RaycastHit2D getLeftBoundary()
    {
        return LeftBoundary;
    }

    public RaycastHit2D getRightBoundary()
    {
        return RightBoundary;
    }

    public Vector2 getTRCorner()
    {
        return TRCorner;
    }

    public Vector2 getTLCorner()
    {
        return TLCorner;
    }

    public Vector2 getBRCorner()
    {
        return BRCorner;
    }

    public Vector2 getBLCorner()
    {
        return BLCorner;
    }

    public bool getatTopBoundary()
    {
        return atTopBoundary;
    }

    public bool getatBottomBoundary()
    {
        return atBottomBoundary;
    }

    public bool getatLeftBoundary()
    {
        return atLeftBoundary;
    }

    public bool getatRightBoundary()
    {
        return atRightBoundary;
    }

    public void setatTopBoundary(bool b)
    {
        atTopBoundary = b;
    }

    public void setatBottomBoundary(bool b)
    {
        atBottomBoundary = b;
    }

    public void setatLeftBoundary(bool b)
    {
        atLeftBoundary = b;
    }

    public void setatRightBoundary(bool b)
    {
        atRightBoundary = b;
    }
}
