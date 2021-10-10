using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    private float x = 0f;
    private float y = 1f;
    private float z = -9f;
    private float time = 0f;
    public float speed = 6f;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {   time += Time.deltaTime;
        z = -9 + time * speed;
        transform.position = new Vector3(x, y, z);
    }
}
