using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{
    [Header("General")]
    public List<itemType> inventoryList;
    public int selectedItem;
    public float playerReach;

    [Space(20)]
    [Header("Keys")]
    [SerializeField] KeyCode pickItemKey;

    [Space(20)]
    [Header("Item gameObjects")]
    [SerializeField] public GameObject camera_item;
    [SerializeField] public GameObject shovel_item;
    [SerializeField] public GameObject conchShell_item;
    [SerializeField] public GameObject photo_item;
    [SerializeField] public GameObject tablet1_item;
    [SerializeField] public GameObject tablet2_item;
    [SerializeField] public GameObject tablet3_item;
    [SerializeField] public GameObject tablet4_item;

    [Space(20)]
    [Header("UI")]
    [SerializeField] Image[] inventorySlotImage = new Image[8];
    [SerializeField] Image[] inventoryBackgroundImage = new Image[8];
    [SerializeField] Sprite emptySlotSprite;

    [SerializeField] Camera cam;
    [SerializeField] GameObject pickUpItem_gameObject;

    private Dictionary<itemType, GameObject> itemSetActive = new Dictionary<itemType, GameObject>() { };
    
    void Start()
    {
        itemSetActive.Add(itemType.Camera, camera_item);
        itemSetActive.Add(itemType.Shovel, shovel_item);
        itemSetActive.Add(itemType.ConchShell, conchShell_item);
        itemSetActive.Add(itemType.Photo, photo_item);
        itemSetActive.Add(itemType.Tablet, tablet1_item);
        itemSetActive.Add(itemType.Tablet2, tablet2_item);
        itemSetActive.Add(itemType.Tablet3, tablet3_item);
        itemSetActive.Add(itemType.Tablet4, tablet4_item);

        NewItemSelected();
    }

    void Update()
    {
        //Items Pickup
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;
        
        if(Physics.Raycast(ray, out hitInfo, playerReach))
        {
            IPickable item = hitInfo.collider.GetComponent<IPickable>();
            if (item != null)
            {
                pickUpItem_gameObject.SetActive(true);
                if (Input.GetKey(pickItemKey))
                {
                    inventoryList.Add(hitInfo.collider.GetComponent<ItemPickable>().itemScriptableObject.item_type);
                    item.PickItem();
                }
                else
                {
                    pickUpItem_gameObject.SetActive(false);
                }
            }
            else
            {
                pickUpItem_gameObject.SetActive(false);
            }
        }
        // UI

        for (int i = 0; i <8; i++)
        {
            if (i < inventoryList.Count)
            {
                inventorySlotImage[i].sprite = itemSetActive[inventoryList[i]].GetComponent<Item>().itemScriptableObject.item_sprite;
            }
            else
            {
                inventorySlotImage[i].sprite = emptySlotSprite;
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha1)  && inventoryList.Count > 0)
        {
            selectedItem = 0;
            NewItemSelected();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) && inventoryList.Count > 1)
        {
            selectedItem = 1;
            NewItemSelected();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3) && inventoryList.Count > 2)
        {
            selectedItem = 2;
            NewItemSelected();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4) && inventoryList.Count > 3)
        {
            selectedItem = 3;
            NewItemSelected();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5) && inventoryList.Count > 4)
        {
            selectedItem = 4;
            NewItemSelected();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha6) && inventoryList.Count > 5)
        {
            selectedItem = 5;
            NewItemSelected();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha7) && inventoryList.Count > 6)
        {
            selectedItem = 6;
            NewItemSelected();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha8) && inventoryList.Count > 7)
        {
            selectedItem = 7;
            NewItemSelected();
        }
    }

    private void NewItemSelected()
    {
        camera_item.SetActive(false);
        shovel_item.SetActive(false);
        conchShell_item.SetActive(false);
        photo_item.SetActive(false);
        tablet1_item.SetActive(false);
        tablet2_item.SetActive(false);
        tablet3_item.SetActive(false);
        tablet4_item.SetActive(false);

        GameObject selectedItemGameObject = itemSetActive[inventoryList[selectedItem]];
        selectedItemGameObject.SetActive(true);
    }
}

public interface IPickable
{
    
    void PickItem();
}
// video used: https://www.youtube.com/watch?v=HGol5qhqjOE