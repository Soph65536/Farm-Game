using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CinemachineFreeLook))]
public class CameraController : MonoBehaviour
{
    private GameObject followObject;
    private CinemachineFreeLook freeLook;

    private bool lookingAtPlayer;

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

        freeLook = GetComponent<CinemachineFreeLook>();
    }

    private void Start()
    {
        FocusOnPlayer();
    }

    private void FixedUpdate()
    {
        if (lookingAtPlayer) { Player.Instance.movement.rotation = new Vector3(0, transform.rotation.eulerAngles.y, 0); }
    }

    private void UpdateCinemachineFollow()
    {
        lookingAtPlayer = followObject == Player.Instance.gameObject; //update player bool

        //set cinemachine camera values
        freeLook.Follow = followObject.transform;
        freeLook.LookAt = followObject.transform;
    }

    public void FocusOnPlayer()
    {
        followObject = Player.Instance.gameObject;
        UpdateCinemachineFollow();
    }

    public void FocusOnObject(GameObject obj)
    {
        followObject = obj;
        UpdateCinemachineFollow();
    }
}
