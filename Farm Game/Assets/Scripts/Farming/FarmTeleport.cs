using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class FarmTeleport : MonoBehaviour
{
    private GameObject farmSet;
    private bool inFarm;

    private Vector3 worldScenePosition;
    [SerializeField] private Vector3 farmScenePosition;

    private void Awake()
    {
        LevelLoading.Instance.LoadScene(LevelLoading.Instance.farmAreaBuildIndex, LoadSceneMode.Additive);
        inFarm = false;
    }

    private void OnEnable()
    {
        Player.Instance.input.actions["TeleportFarm"].performed += TeleportToFarm;
    }

    private void OnDisable()
    {
        Player.Instance.input.actions["TeleportFarm"].performed -= TeleportToFarm;
    }

    private void TeleportToFarm(InputAction.CallbackContext context)
    {
        if(inFarm)
        {
            //currently in farm so leave farm
            transform.position = worldScenePosition;
            //remove held item
            Player.Instance.inventory.SetHeldItem(null);
        }
        else
        {
            //record current scene info and tp to farm
            worldScenePosition = transform.position;
            transform.position = farmScenePosition;
        }

        inFarm = !inFarm; //toggle infarm since weve teleported

        //set farmset active based on if weve entered farm
        if(farmSet == null) { farmSet = GameObject.FindGameObjectWithTag("FarmSet"); }
        else { farmSet.SetActive(inFarm); }
    }
}
