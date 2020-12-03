using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundScale : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer st = GetComponent<SpriteRenderer>();
        Vector3 tempScale = transform.localScale;
        float width = st.sprite.bounds.size.x;
        float worldHeight = Camera.main.orthographicSize * 2f;
        float worldWidht = worldHeight / Screen.height * Screen.width;

        tempScale.x = worldWidht / width;
        transform.localScale = tempScale;
    }

    // Update is called once per frame
}
