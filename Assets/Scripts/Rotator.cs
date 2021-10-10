using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public int seed;
    static private float rand1;
    static private float rand2;
    static private float rand3;

    void start()
    {
        Random.InitState(seed);
    }

    // Update is called once per frame
    void Update()
    {
        // Rotate the game object that this script is attached to by 15 in the X axis,
        // 30 in the Y axis and 45 in the Z axis, multiplied by deltaTime in order to make it per second
        // rather than per frame.
        rand1 = Random.Range(0, 90);
        rand2 = Random.Range(0, 90);
        rand3 = Random.Range(0, 90);
        transform.Rotate (new Vector3 (rand1, rand2, rand3) * Time.deltaTime);
    }
}
