using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Parallax : MonoBehaviour
{
    public Image image;
    public float speed;
    public bool isAutoMove;

    void Update() {
        float move = Input.GetAxis("Horizontal");

        if (isAutoMove) {
            image.material.SetTextureOffset ("_MainTex", new Vector2 (image.material.GetTextureOffset("_MainTex").x + speed, 0));
        } else if(move != 0) {
            image.material.SetTextureOffset ("_MainTex", new Vector2 (image.material.GetTextureOffset("_MainTex").x + (speed * Input.GetAxis("Horizontal")), 0));
        }
    }
}
