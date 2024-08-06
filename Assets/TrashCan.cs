using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCan : MonoBehaviour
{
    void Start()
    {
        GetComponent<TriggerZone>().OnEnterEvent.AddListener( InsideTrashCan );
    }

    static void InsideTrashCan( GameObject go )
    {
        go.SetActive( false );
    }
}
