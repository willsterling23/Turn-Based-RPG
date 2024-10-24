using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDestroyGameObject : MonoBehaviour
{
    public void DestroyMe()
    {
        Destroy(gameObject);
    }
}
