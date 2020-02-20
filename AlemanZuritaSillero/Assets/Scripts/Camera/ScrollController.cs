using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollController : MonoBehaviour
{
    //public PlayerModel player;
    public CameraController cam;

    SpriteRenderer[] sprs;
    float xCamLeft, imageHalfWidth;

    // Start is called before the first frame update
    void Start()
    {
        sprs = GetComponentsInChildren<SpriteRenderer>();
        xCamLeft = -Camera.main.orthographicSize * Camera.main.aspect;
        imageHalfWidth = sprs[0].sprite.bounds.size.x * 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        
        //float deltaX = player.horizontalSpeed * Time.deltaTime;
        float deltaX = cam.smoothed * Time.deltaTime;

        foreach (SpriteRenderer spr in sprs)
        {
            float newPosX = spr.transform.position.x + deltaX;

            //Si la imagen se sale de cámara por la izquierda
            if (newPosX + imageHalfWidth < xCamLeft)
                spr.transform.Translate(new Vector3(imageHalfWidth * 4f, 0f, 0f));


            spr.transform.Translate(new Vector3(deltaX, 0f, 0f));
        }
    }
}
