using UnityEngine;
using UnityEngine.Events;

public class TriggerZone : MonoBehaviour
{
    public string TargetTag;
    public UnityEvent<GameObject> OnEnterEvent;
    void OnTriggerEnter( Collider other )
    {
        if ( other.gameObject.CompareTag( TargetTag ) )
        {
            OnEnterEvent.Invoke( other.gameObject );
        }
    }
}
