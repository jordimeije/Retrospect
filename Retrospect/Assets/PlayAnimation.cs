using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnimation : MonoBehaviour {

    public bool PlayForward;
    public bool PlayBackward;
    public bool Pause;
    public List<GameObject> Ropes;
    bool IsGoingForward;
    bool Hovering;

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



    public void PlayHovering() {
        if (!UnityEngine.XR.XRDevice.isPresent)
        {
            PlayBackward = false;
            PlayForward = true;
            Hovering = true;
        }

    }
    public void PlayBackwardsHovering()
    {
        if (!UnityEngine.XR.XRDevice.isPresent)
        {
            PlayForward = false;
            PlayBackward = true;
            Hovering = true;
        }
    }
    public void Play()
    {
        PlayForward = true;
    }
    public void PlayBackwards()
    {
        PlayBackward = true;
    }
    public void StopPlay()
    {
        PlayForward = false;
        PlayBackward = false;
        Pause = true;
        Hovering = false;
    }

    // Update is called once per frame
    void Update () {
        if (PlayForward && (Input.GetKeyDown(KeyCode.Mouse0) || UnityEngine.XR.XRDevice.isPresent))
        {
            GetComponent<Animation>()["BucketClimb"].speed = 1;
            GetComponent<Animation>().Play();
            PlayForward = false;
            IsGoingForward = true;
        }
        if (PlayBackward && (Input.GetKeyDown(KeyCode.Mouse0) || UnityEngine.XR.XRDevice.isPresent))
        {
            if (!GetComponent<Animation>().IsPlaying("BucketClimb") && IsGoingForward)
                GetComponent<Animation>()["BucketClimb"].normalizedTime = 1;

            GetComponent<Animation>()["BucketClimb"].speed = -1;
            GetComponent<Animation>().Play();
            PlayBackward = false;
            IsGoingForward = false;
        }
        if (Pause || (Input.GetKeyUp(KeyCode.Mouse0) && !UnityEngine.XR.XRDevice.isPresent))
        {
            if (Hovering)
            {
                if (IsGoingForward && !PlayBackward)
                    PlayForward = true;
                else if (!PlayForward)
                    PlayBackward = true;
            }
            GetComponent<Animation>()["BucketClimb"].speed = 0;
            Pause = false;
        }
    }
}
