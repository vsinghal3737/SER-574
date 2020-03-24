using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DovesUpdateController : MonoBehaviour
{

    public float speed;

    private Rigidbody rb;
    //private Vector3 temp;

    void Start()
    {

        rb = GetComponent<Rigidbody>();
        FixedUpdate();

    }

    void FixedUpdate()
    {
        //temp = transform.position;
        //transform.position = new Vector3(temp.x - 0.5f, temp.y + 0.5f, 0);
        Debug.Log("Hi from inside");
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Food");
        Debug.Log(gos.Length);
        GameObject closest = null;
        float distance = 0.25f;
        Vector3 position = rb.transform.position;
        foreach (GameObject go in gos)

        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;



            if (curDistance < distance)
            {
                Debug.Log(go.tag);
                closest = go;
                distance = curDistance;
                rb.transform.position = closest.transform.position;

                Destroy(closest);

            }

        }



    }
}
