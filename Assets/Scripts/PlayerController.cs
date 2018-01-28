using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public int money;
    public GameObject gear1;
    public GameObject gear2;
    public GameObject gear3;
    public Text moneyUI;

    private bool engine;
    private float enginePower = 1.0f;
    private MasterGearController masterGearController;

    void Start()
    {
        money = 0;
        masterGearController = gear1.GetComponent<MasterGearController>();
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
                    masterGearController.ApplyImpulse(2);
                }
            }
        }

        if(engine)
        {
            masterGearController.ApplyImpulse(Time.deltaTime * enginePower);
        }

    }

    public void UpgradeGear(int gearNum)
    {
        switch (gearNum)
        {
            case 1:
                {
                    int teeth = gear1.GetComponent<GearController>().gearTeeths;
                    switch (teeth)
                    {
                        case 8:
                            changeGear(1, 11);
                            break;
                        case 11:
                            changeGear(1, 17);
                            break;
                        default:
                            break;
                    }
                    break;
                }
            case 2:
                {
                    int teeth = gear2.GetComponent<GearController>().gearTeeths;
                    switch (teeth)
                    {
                        case 8:
                            changeGear(2, 11);
                            break;
                        case 11:
                            changeGear(2, 17);
                            break;
                        default:
                            break;
                    }
                    break;
                }
            case 3:
                {
                    int teeth = gear3.GetComponent<GearController>().gearTeeths;
                    switch (teeth)
                    {
                        case 17:
                            changeGear(3, 11);
                            break;
                        case 11:
                            changeGear(3, 8);
                            break;
                        default:
                            break;
                    }
                    break;
                }
            default:
                return;
        }
    }

    public void changeGear(int num, int size)
    {
        var dest = new GameObject[3] { gear1, gear2, gear3 };

        if (num < 1 || num > 3)
            return;

        // Change mesh
        dest[num-1].GetComponent<GearController>().changeGear(size);

        // Move gear1 into position
        if(num==1 || num==2)
            gear1.transform.position = new Vector3( 
                determineX(
                    gear1.GetComponent<GearController>().gearTeeths,
                    gear2.GetComponent<GearController>().gearTeeths
                ) , 
                gear1.transform.position.y, 
                gear1.transform.position.z
                );

        // Move gear2 into position
        if (num == 2 || num == 3)
            gear3.transform.position = new Vector3( 
                -determineX(
                    gear2.GetComponent<GearController>().gearTeeths,
                    gear3.GetComponent<GearController>().gearTeeths
                ), 
                gear3.transform.position.y, 
                gear3.transform.position.z
                );
    }

    private float determineX(int size1,int size2)
    {
        if (size1 == 8 && size2 == 8)
            return 1.74f;
        if (size1 == 11 && size2==11)
            return 2.95f;
        if (size1 == 17 && size2 == 17)
            return 4.58f;
        if (size1 == 11 && size2 == 8 || size1 == 8 && size2 == 11)
            return 2.39f;
        if (size1 == 11 && size2 == 17 || size1 == 17 && size2 == 11)
            return 3.78f;
        if (size1 == 8 && size2 == 17 || size1 == 17 && size2 == 8)
            return 3.15f;

        return 0.0f;
    }

    //TODO: create buttons procedurally & assign events in a menu controller

    public void BuyEngine()
    {
        if(engine)
        {
            enginePower *= 1.5f;
        }
        else
        {
            engine = true;
        }
        //deactivate Buy Engine Button
    }
}
