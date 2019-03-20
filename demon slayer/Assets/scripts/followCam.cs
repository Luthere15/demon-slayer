using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followCam : MonoBehaviour
{
    static public GameObject POI;
    public float camY;
    [SerializeField]
    private float xMax;
    [SerializeField]
    private float yMax;
    [SerializeField]
    private float xMin;
    [SerializeField]
    private float yMin;

    private Transform target;

    void Awake()
    {
        camY = this.transform.position.y;
    }

    void FixedUpdate()
    {
        if (POI == null) return;

        Vector2 destination = POI.transform.position;

        destination.x = camY;

        transform.position = destination;
    }
    // Use this for initialization
    void Start()
    {
        target = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = new Vector3(Mathf.Clamp(target.position.x, xMin, xMax), Mathf.Clamp(target.position.y, yMin, yMax), transform.position.z);

    }
}
