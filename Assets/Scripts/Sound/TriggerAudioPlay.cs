using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerAudioPlay : MonoBehaviour
{
    public bool playOnlyOneTime;
    [Space]
    public UnityEvent onTrigger;

    private void OnTriggerEnter(Collider other)
    {
        if (playOnlyOneTime)
        {
            onTrigger.Invoke();
            Destroy(gameObject);
        }
        else onTrigger.Invoke();
    }
}
