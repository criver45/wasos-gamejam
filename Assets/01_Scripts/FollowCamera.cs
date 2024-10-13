using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public GameObject target;
    float target_posX;
    float target_posY;
    float posX;
    float posY;
    public float rigthMax;
    public float leftMax;
    public float heightMax;
    public float heightMin;
    public float speed;
    public bool onCamera = true;

    void Awake()
    {
        posX = target_posX + rigthMax;
        posY = target_posY + heightMax;
        transform.position = Vector3.Lerp(transform.position, new Vector3(posX, posY, -1), 1);
    }


    void Update()
    {
        Move_Cam();
    }

    void Move_Cam()
    {
        if (onCamera)
        {
            if (target)
            {
                target_posX = target.transform.position.x;
                target_posY = target.transform.position.y;

                if(target_posX > rigthMax && target_posX < leftMax)
                {
                    posX = target_posX;
                }

                if(target_posY < heightMax && target_posY > heightMin)
                {
                    posY = target_posY;
                }
            }

            transform.position = Vector3.Lerp(transform.position, new Vector3(posX, posY, -1), speed * Time.deltaTime);
        }
    }
}
