using UnityEngine;
using System.Collections;

public class BoundaryScript : MonoBehaviour {

    private Vector2 TLCorner, TRCorner, BLCorner, BRCorner; //TL (Top Left) BR (Bottom Right)
    private RaycastHit2D TopBoundary, BottomBoundary, LeftBoundary, RightBoundary;
    // Use this for initialization
	void Start () {
        TLCorner = new Vector2 (GameObject.Find("TLCorner").transform.position.x, GameObject.Find("TLCorner").transform.position.y);
        TRCorner = new Vector2(GameObject.Find("TRCorner").transform.position.x, GameObject.Find("TRCorner").transform.position.y);
        BLCorner = new Vector2 (GameObject.Find("BLCorner").transform.position.x, GameObject.Find("BLCorner").transform.position.y);
        BRCorner = new Vector2(GameObject.Find("BRCorner").transform.position.x, GameObject.Find("BRCorner").transform.position.y);

        TopBoundary = Physics2D.Linecast(TLCorner, TRCorner);
        BottomBoundary = Physics2D.Linecast(BLCorner, BRCorner);
        LeftBoundary = Physics2D.Linecast(TLCorner, BLCorner);
        RightBoundary = Physics2D.Linecast(TRCorner, BRCorner);
	}
	
	// Update is called once per frame
	void Update () {
	
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
}
