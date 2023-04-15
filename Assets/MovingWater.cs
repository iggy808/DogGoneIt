using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingWater : MonoBehaviour
{
    [SerializeField] float flowSpeed = 1f;
    [SerializeField] float upDownMoveSpeed = 1f;

    MeshRenderer meshRenderer;
    // Start is called before the first frame update
    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        meshRenderer.material.mainTextureOffset = new Vector2(Mathf.Sin(Time.time * flowSpeed), 0f);
    }
}
