using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableScript : MonoBehaviour
{
    void OnEnable()
    {
        Invoke("DestroyComponent", 6f);
    }

    void DestroyComponent()
    {
        gameObject.SetActive(false);
    }
}
