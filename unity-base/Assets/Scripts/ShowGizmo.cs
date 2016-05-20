﻿using UnityEngine;
using System.Collections;

public class ShowGizmo : MonoBehaviour
{
    public bool ShowGizmos = true;

    public string IconStr = string.Empty;

    [Range(0f, 100f)]
    public float Range = 10f;


    void OnDrawGizmos ()
    {
        if (!ShowGizmos)
        {
            return;
        }

        Gizmos.DrawIcon(transform.position, IconStr, true);

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, Range);

        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, transform.position + transform.forward * Range);

	}
}