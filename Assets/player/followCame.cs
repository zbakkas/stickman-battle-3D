using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followCame : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform player;
    public float x ,z;
    public float minX, maxX, minZ, maxZ;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void LateUpdate()
    {
        Vector3 vv = new Vector3(player.position.x + x, transform.position.y, player.position.z + z);
        vv.x = Mathf.Clamp(vv.x, minX, maxX);
        vv.z = Mathf.Clamp(vv.z, minZ, maxZ);
        transform.position = vv;
    }
}
