using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private GameObject cameraObject;
    [SerializeField] private float lerpSpeed;

    public static CameraController Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null & Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        FocusOnPlayer();
    }

    private void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, cameraObject.transform.position, lerpSpeed * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, cameraObject.transform.rotation, lerpSpeed * Time.deltaTime);
    }

    public void FocusOnPlayer()
    {
        cameraObject = Player.Instance.cameraObject;
    }

    public void FocusOnObject(GameObject obj)
    {
        cameraObject = obj;
    }
}
