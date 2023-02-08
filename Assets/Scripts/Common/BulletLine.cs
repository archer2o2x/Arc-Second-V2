using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class BulletLine : MonoBehaviour
{
    public float FadeLength;
    private float Timer = -1;

    private LineRenderer line;

    public void Setup(Vector3 HitPoint, Vector3 StartPoint)
    {
        line = GetComponent<LineRenderer>();
        line.material = new Material(Shader.Find("Sprites/Default"));

        line.SetPosition(0, StartPoint);
        line.SetPosition(1, HitPoint);

        Timer = FadeLength;
    }

    private void Update()
    {
        if (Timer == -1) return;

        Timer -= Time.deltaTime;

        /*for (int i = 0; i < line.colorGradient.alphaKeys.Length; i++)
        {
            line.colorGradient.alphaKeys[i].alpha = (Timer / FadeLength) * 255;
            //line.startColor = line.startColor - new Color(0, 0, 0, Timer / FadeLength);
        }*/

        Color color = line.material.color;
        line.material.color = new Color(color.r, color.g, color.b, Timer / FadeLength);

        if (Timer > 0) return;

        Destroy(this.gameObject);
    }
}
