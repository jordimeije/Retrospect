using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeAllGravity : MonoBehaviour {

    public List<Transform> Targets;

    public Transform _Gravity;
    public Transform Gravity;
    public int _radius = 5;
    public int radius = 5;
    public int _forceAmount = 100;
    public int forceAmount = 100;

    // Use this for initialization
    void OnEnable () {
        foreach (CircularGravity C in GetComponentsInChildren<CircularGravity>())
        {
            C.Targets = Targets;
            C.target = Targets[Random.Range(0,Targets.Count)];
        }
    }
	
	// Update is called once per frame
	void Update () {
		if (_Gravity != Gravity)
        {
            foreach (CircularGravity C in GetComponentsInChildren<CircularGravity>())
            {
                C.target = Gravity;
            }
            _Gravity = Gravity;
        }
        if (_radius != radius)
        {
            foreach (CircularGravity C in GetComponentsInChildren<CircularGravity>())
            {
                C.radius = radius;
            }
            _radius = radius;
        }
        if (_forceAmount != forceAmount)
        {
            foreach (CircularGravity C in GetComponentsInChildren<CircularGravity>())
            {
                C.forceAmount = forceAmount;
            }
            _forceAmount = forceAmount;
        }
    }
}
