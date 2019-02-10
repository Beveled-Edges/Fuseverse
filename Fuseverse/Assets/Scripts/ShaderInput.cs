using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaderInput : MonoBehaviour
{
    public Material gasShader;
    public Vector3 shaderOffset;

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButton(0))
        {
            HandleInput();
        }
    }

    private void HandleInput()
    {

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;

        if(Physics.Raycast(ray, out hitInfo, 100f, 9))
        {
            Debug.DrawLine(transform.position, hitInfo.transform.position);

            shaderOffset += hitInfo.point * Time.deltaTime;

            gasShader.SetFloat("_Bands", shaderOffset.y);
        }
    }
}
