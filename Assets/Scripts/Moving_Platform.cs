using Unity.VisualScripting;
using UnityEngine;

public class Moving_Platform : MonoBehaviour
{
    public float movingPlatform_Speed;
    public Transform[] points;
    private int i;
    public bool trigger = false;
    public bool destroy = false; 

    void Start()
    {
        transform.position = points[0].position;
    }


    void Update()
    {
        if (trigger == true)
        {
            if (Vector2.Distance(transform.position, points[i].position) < 0.01f)
            {
                i++;
                if (i == points.Length)
                {
                    trigger = false;
                }
            }
            transform.position = Vector2.MoveTowards(transform.position, points[i].position, movingPlatform_Speed * Time.deltaTime);
        }
    }
}
