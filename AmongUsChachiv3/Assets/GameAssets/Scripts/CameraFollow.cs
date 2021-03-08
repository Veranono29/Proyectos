using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    Transform target;
    [SerializeField]
    Vector3 offset;
    [SerializeField]
    float damping;
   
    void LateUpdate()
    {
        if (target != null) {

            float posX = Mathf.Lerp(transform.position.x, target.position.x + offset.x,Time.deltaTime *damping);
            float posY= Mathf.Lerp(transform.position.y, target.position.y + offset.y, Time.deltaTime * damping); 
            float posZ= Mathf.Lerp(transform.position.z, target.position.z + offset.z, Time.deltaTime * damping);

            transform.position = new Vector3(posX, posY, posZ);
            transform.LookAt(target);
        }
        
    }

    public void FollowMe(Transform me) {
        if (target == null) {
            target = me;
        }
    }

}
