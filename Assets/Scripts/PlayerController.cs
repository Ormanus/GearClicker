using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public int money;
    public GameObject gear1;
    public GameObject gear2;
    public GameObject gear3;
    public Text moneyUI;

    void Start()
    {
        money = 0;
    }

    public void addMoney()
    {
        money++;
        moneyUI.text = "Money: " + money;
    }

    public void addMoney(int amount)
    {
        money += amount;
        moneyUI.text = "Money: " + money;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 1000.0f))
            {
                if (hit.collider.gameObject.name == "Gear1")
                {
                    gear1.GetComponent<MasterGearController>().ApplyClickToGear();
                }
            }
        }

        // ******************************
        if (Input.GetKeyUp("1"))
            changeGear(1, 8);
        if (Input.GetKeyUp("2"))
            changeGear(1, 11);
        if (Input.GetKeyUp("3"))
            changeGear(1, 17);
        if (Input.GetKeyUp("4"))
            changeGear(2, 8);
        if (Input.GetKeyUp("5"))
            changeGear(2, 11);
        if (Input.GetKeyUp("6"))
            changeGear(2, 17);
        if (Input.GetKeyUp("7"))
            changeGear(3, 8);
        if (Input.GetKeyUp("8"))
            changeGear(3, 11);
        if (Input.GetKeyUp("9"))
            changeGear(3, 17);

    }

    public void changeGear(int num, int size)
    {
        GameObject dest = null;

        switch(num)
        {
            case 1:
                dest = gear1;
                break;
            case 2:
                dest = gear2;
                break;
            case 3:
                dest = gear3;
                break;
            default:
                return;
        }

        // Change mesh
        dest.GetComponent<GearController>().changeGear(size);

        // Fetch gear teeth count
        int g1size = gear1.GetComponent<GearController>().gearTeeths;
        int g2size = gear2.GetComponent<GearController>().gearTeeths;
        int g3size = gear3.GetComponent<GearController>().gearTeeths;

        // Move gear1 into position
        if(num==1 || num==2)
        {
            gear1.transform.position = new Vector3( determineX(g1size, g2size) , gear1.transform.position.y, gear1.transform.position.z);
        }

        // Move gear2 into position
        if (num == 2 || num == 3)
        {
            gear3.transform.position = new Vector3( -determineX(g2size, g3size), gear3.transform.position.y, gear3.transform.position.z);

        }
    }

    private float determineX(int size1,int size2)
    {
        if (size1 == 8 && size2 == 8)
            return 1.73f;
        if (size1 == 11 && size2==11)
            return 2.95f;
        if (size1 == 17 && size2 == 17)
            return 4.58f;
        if (size1 == 11 && size2 == 8 || size1 == 8 && size2 == 11)
            return 2.39f;
        if (size1 == 11 && size2 == 17 || size1 == 17 && size2 == 11)
            return 3.78f;
        if (size1 == 8 && size2 == 17 || size1 == 17 && size2 == 8)
            return 3.2f;

        return 0.0f;
    }
}
