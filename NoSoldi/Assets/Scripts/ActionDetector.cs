using TMPro;
using UnityEngine;

public class ActionDetector : MonoBehaviour
{
    public float raycastDistance = 5f;
    public TextMeshProUGUI objectNameText;
    

    public string GetObjectName()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, raycastDistance))
        {
            objectNameText.text = hit.collider.gameObject.name;
            return hit.collider.gameObject.name;
        }

        // Si no se golpeó ningún objeto, devolver:
        return "No object";
    }

    public void Interact()
    {
        Debug.Log("Interactuando...");
        if (GetObjectName() == "FoodTruck")
        {
            Debug.Log("Interactuando con el FoodTruck");
            FoodTruck foodTruck = GameObject.Find("FoodTruck").GetComponent<FoodTruck>();
            
            foodTruck.ConsumeProduct();
        }
        else if (GetObjectName() == "RentHouse")
        {
            Debug.Log("Interactuando con la RentHouse");
            RentHouse rentHouse = GameObject.Find("RentHouse").GetComponent<RentHouse>();
            
            rentHouse.ConsumeProduct();
        }else if (GetObjectName() == "Computer")
        {
            Debug.Log("Interactuando con la Computer");
            Computer computer = GameObject.Find("Computer").GetComponent<Computer>();
            
            computer.ConsumeProduct();
        }

    }



}

