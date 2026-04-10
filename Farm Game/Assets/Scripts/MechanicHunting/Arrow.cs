using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float arrowTurnFrequency;
    [SerializeField] private float arrowTurnAmount;
    [SerializeField] private float aliveTime;

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.up * speed, ForceMode.Impulse);
        InvokeRepeating(nameof(TurnDownwards), arrowTurnFrequency, arrowTurnFrequency);
        Destroy(transform.parent.gameObject, aliveTime);
    }

    private void TurnDownwards()
    {
        transform.Rotate(new Vector3(arrowTurnAmount, 0, 0));
    }
}
