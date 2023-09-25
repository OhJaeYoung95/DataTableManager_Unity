using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 moveMent = new Vector3 (h,0f, v);

        if(moveMent.magnitude > 1f)
        {
            moveMent.Normalize();
        }

        transform.position += moveMent * speed * Time.deltaTime;
    }
}
