using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScene : MonoBehaviour
{
    private float speed = 80.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (GetComponent<RectTransform>().anchoredPosition.y < 0)
        {
            transform.Translate(Vector3.up * Time.fixedDeltaTime * speed);
        }
    }
   
}
