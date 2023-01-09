using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuPointLight : MonoBehaviour
{
    [SerializeField] private float minZ;
    [SerializeField] private float maxZ;
    private float speed = 0.1f;
    private Vector3 endPos;
    
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, endPos, speed);
        if (transform.position.z == endPos.z)
        {
            ChangeEndPos();
        }
    }

    void ChangeEndPos()
    {
        endPos = new Vector3(transform.position.x, transform.position.y, Random.Range(minZ, maxZ));
        speed = Random.Range(0.01f, 0.05f);
    }
}
