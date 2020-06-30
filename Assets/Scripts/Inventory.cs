using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private GameController gameController;
    private ThirdPersonCharacterController playerController;

    GameObject inventoryPanel;
    GameObject slotPanel;
    public GameObject slotPrefab;
    public GameObject itemPrefab;
    //public List<Item> items = new List<Item>();
    public GameObject[] slots;
    public int slotAmount;
    public bool[] isFull;

    private bool isOpen;

    private void Start()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
        playerController = GameObject.Find("Player").GetComponent<ThirdPersonCharacterController>();

        slots = new GameObject[slotAmount];
        isFull = new bool[slotAmount];
        inventoryPanel = GameObject.Find("Inventory Panel");
        slotPanel = inventoryPanel.transform.GetChild(0).gameObject;

        for(int x = 0; x < slotAmount; x++)
        {
            slots[x] = Instantiate(slotPrefab);
            slots[x].transform.SetParent(slotPanel.transform, false);
        }

        isOpen = false;
        inventoryPanel.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (isOpen)
            {
                closeInventory();  
            }
            else
            {
                openInventory();
            }
        }
    }

    private void openInventory()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        inventoryPanel.SetActive(true);
        isOpen = true;
        Time.timeScale = 0.25f;
        gameController.allowCameraControl = false;
        playerController.allowMovement = false;
    }

    private void closeInventory()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        inventoryPanel.SetActive(false);
        isOpen = false;
        Time.timeScale = 1f;
        gameController.allowCameraControl = true;
        playerController.allowMovement = true;
    }
}
