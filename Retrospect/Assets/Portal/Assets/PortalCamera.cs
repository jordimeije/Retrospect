using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCamera : MonoBehaviour {

	public Transform playerCamera;
	public Transform portal;
	public Transform otherPortal;
    // follows the player from the other side
    public Transform PlayerFollower;

    // Update is called once per frame
    void Update () {

        PlayerFollower.transform.position = playerCamera.position;
        PlayerFollower.transform.eulerAngles = playerCamera.localEulerAngles;//playerCamera.eulerAngles - CameraRig.transform.eulerAngles;

        Vector3 playerOffsetFromPortal = PlayerFollower.localPosition - otherPortal.localPosition;
		transform.localPosition = portal.localPosition + playerOffsetFromPortal;

		float angularDifferenceBetweenPortalRotations = Quaternion.Angle(portal.localRotation, otherPortal.localRotation);

		Quaternion portalRotationalDifference = Quaternion.AngleAxis(angularDifferenceBetweenPortalRotations, Vector3.up);
        Vector3 newCameraDirection = portalRotationalDifference * PlayerFollower.transform.forward;

        transform.localRotation = Quaternion.LookRotation(newCameraDirection, Vector3.up);
	}
}
