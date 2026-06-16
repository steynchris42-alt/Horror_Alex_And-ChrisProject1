using System.Linq.Expressions;
using UnityEngine;


public class SimplePickUp : MonoBehaviour
{
    public enum ObjectType { Item, Generator }
    public ObjectType type = ObjectType.Item;
    public Transform player;
    public float range = 3f;
    public float fillTime = 6f;
    public InventorySwitcher invenSwi;
    public GameObject streetLamp;

    public float currentFill = 0f;
    private bool isOn = false;
    private int lastLoggedPercent = -1;
    private AudioSource audioSource;

    private void Start()
    { 
       streetLamp.SetActive(false);

        audioSource = GetComponent<AudioSource>(); 
    }

    public float FillAmount()
    {
        return currentFill / fillTime;
    }

    public bool IsOn()
    {
        return isOn;
    }

    private void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);
        if (distance > range)
        {
            return;
        }

        if (type == ObjectType.Item)
        {
            UpdateItem();
        }
        else
        {
            UpdateGenerator();
        }
    }

    private void UpdateItem() // picking up batteries 
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Item " + name + " picked up");
            Destroy(gameObject);
        }
    }

    private void UpdateGenerator()
    {
        if(isOn)
        {
            return;
        }

        bool canisterEquipped = invenSwi != null && invenSwi.CanisterEquipped();//checks if flashlight is equipped, if it is then the canister is not equipped and the generator cannot be turned on

        Debug.Log("in range. invenswi set: " + (invenSwi != null) + " | canisterEquipped: " + canisterEquipped + " | E held: " + Input.GetKey(KeyCode.E));

        if (Input.GetKey(KeyCode.E) && !canisterEquipped)
        {
            Debug.Log("Equip the gasoline cansiter to use");
        }

        if (Input.GetKey(KeyCode.E) && canisterEquipped)
        {
            currentFill += Time.deltaTime;
            int percent = Mathf.RoundToInt(FillAmount() * 100f);
            if (currentFill <= fillTime)
            {
                Debug.Log(percent + "%");
                lastLoggedPercent = percent;
            }

            if (currentFill >= fillTime)
            {
                currentFill = fillTime;
                isOn = true;
                Debug.Log("Generator turned on!");

                streetLamp.SetActive(true);

                audioSource.Play(); // Play the audio clip when the generator is turned on



            }
        }
    }





}
