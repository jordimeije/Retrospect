using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnimation : MonoBehaviour
{
    public bool Click;
    public bool Ishovering;
    public bool GoForward;
    public bool GoBackward;
    public List<GameObject> Ropes;

    private void Start()
    {
        GetComponent<Animation>().Play();
        GetComponent<Animation>()["BucketClimb"].speed = 0;
        //GetComponent<Animation>()["BucketClimb"].normalizedTime = 1;
        foreach (GameObject Rope in Ropes)
        {
            Rope.GetComponent<WrappingRopeLibrary.Scripts.Rope>().enabled = true;
        }
    }

    public void HoverEvent(int i)
    {
        Ishovering = true;
        if (i == 0)
        {
            GoForward = true;
            GoBackward = false;
        }
        if (i == 1)
        {
            GoBackward = true;
            GoForward = false;
        }
    }

    public void UnHoverEvent(int i)
    {
        Ishovering = false;
    }

    public void SetClick()
    {
        Click = true;
    }

    public void ReleaseClick()
    {
        Click = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
            SetClick();

        if (Click && Ishovering && GoForward)
        {
            if (GetComponent<Animation>()["BucketClimb"].normalizedTime < 0.99f)
            {
                GetComponent<Animation>()["BucketClimb"].speed = 1;
                GetComponent<Animation>().Play();
            }

        }
        if (Click && Ishovering && GoBackward)
        {
            if (GetComponent<Animation>()["BucketClimb"].normalizedTime > 0.01f)
            {
                GetComponent<Animation>()["BucketClimb"].speed = -1;
                GetComponent<Animation>().Play();
            }
        }

        if (Input.GetKeyUp(KeyCode.Mouse0))
            ReleaseClick();

        if (GetComponent<Animation>()["BucketClimb"].speed != 0 && (!Ishovering || Click == false))
        {
            GetComponent<Animation>()["BucketClimb"].speed = 0;
        }
    }
}
