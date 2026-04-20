using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skybox : MonoBehaviour
{
    [SerializeField] private Material[] skyboxes;
    [SerializeField] private float timeSpeed;

    private float time;
    private int numOfSkyboxes;

    // Start is called before the first frame update
    void Awake()
    {
        time = 0;
        numOfSkyboxes = skyboxes.Length;
    }

    private void OnEnable()
    {
        InvokeRepeating(nameof(UpdateTime), 0.1f, timeSpeed * Time.deltaTime);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }

    private void UpdateTime()
    {
        time += Time.deltaTime;
        RenderSettings.skybox = skyboxes[(int)(time * numOfSkyboxes)];

        if (time >= 1) { time = 0; }
    }
}
