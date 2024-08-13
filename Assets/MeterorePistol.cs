using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class MeterorePistol : MonoBehaviour
{
    [SerializeField] XRGrabInteractable GrabInteractable;
    [SerializeField] ParticleSystem ParticleSystem;

    void Start()
    {
        GrabInteractable.activated.AddListener(StartShoot );
        GrabInteractable.deactivated.AddListener( StopShoot );
    }

    void StopShoot( DeactivateEventArgs arg0 )
    {
        ParticleSystem.Play();
    }

    void StartShoot( ActivateEventArgs arg0 )
    {
        ParticleSystem.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
    }
}
