using UnityEngine;

public class InventorySwitcher : MonoBehaviour
{
    public GameObject flashlight;
    public GameObject gasolineCanister;
    public GameObject light;

    public bool FlashlightEquipped()
    {
        if (flashlight == null) //basically checks if flashluight is equipped
        {
            return false;
        }
        return flashlight.activeSelf; //otherwise equipped when the object is switched on
        return light.activeSelf; //otherwise equipped when the object is switched on
    }

    public bool CanisterEquipped()
    {
        if (gasolineCanister == null) //basically checks if gasoline canister is equipped
        {
            return false;
        }
        return gasolineCanister.activeSelf; //otherwise equipped when the object is switched on
    }
    private void Start()
    {
        EquipFlashlight();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            EquipFlashlight();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            EquipGasolineCanister();
        }
    }

    private void EquipFlashlight()
    {
        flashlight.SetActive(true);
        light.SetActive(true);
        gasolineCanister.SetActive(false);
    }

    private void EquipGasolineCanister()
    {
        flashlight.SetActive(false);
        light.SetActive(false);
        gasolineCanister.SetActive(true);
    }
}
