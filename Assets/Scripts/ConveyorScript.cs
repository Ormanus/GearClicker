using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConveyorScript : MonoBehaviour {

    public float partWidth;
    public GameObject partPrefab;
    public GameObject partBackPrefab;

    //+++TEMP
    public Text money;
    //---TEMP

    public float speed;

    List<Transform> partsRight = new List<Transform>();
    List<Transform> partsLeft = new List<Transform>();

    float width;
    int amount;

    //TROLL
    float angleStep;

    void Start ()
    {
        width = (Camera.main.orthographicSize * Camera.main.aspect * 2);

        //create parts
        amount = Mathf.CeilToInt(width / partWidth) + 1;


        for(int i = 0; i < amount; i++)
        {
            Transform tr = Instantiate(partPrefab).transform;
            tr.name = "Belt_" + partsRight.Count;
            tr.position = new Vector3((width / 2) - i * partWidth, 0, 0);
            tr.rotation = Quaternion.identity;
            partsRight.Add(tr);
        }

        for (int i = 0; i < amount; i++)
        {
            Transform tr = Instantiate(partBackPrefab).transform;
            tr.name = "Belt_" + partsRight.Count;
            tr.position = new Vector3((width / 2) - i * partWidth, -1, 0);
            tr.rotation = Quaternion.identity;
            tr.localEulerAngles = new Vector3(180, 0, 0);
            partsLeft.Add(tr);
        }

        angleStep = Mathf.PI * 2.0f / amount;
    }

	void Update ()
    {
		for(int i = 0; i < partsRight.Count; i++)
        {
            partsRight[i].position += new Vector3(speed * Time.deltaTime, 0, 0);
            partsLeft[i].position += new Vector3(-speed * Time.deltaTime, 0, 0);

            if (partsRight[i].position.x > width / 2 + partWidth)
            {
                partsRight[i].position += new Vector3(-(amount * partWidth), 0, 0);
                //partsRight[i].position = new Vector3(partsRight[i].position.x, Mathf.Sin(i * angleStep) / 10.0f, 0);
                Player.money++;
                money.text = "Money: " + Player.money;
            }

            if (partsLeft[i].position.x < -width / 2)
            {
                partsLeft[i].position += new Vector3(amount * partWidth, 0, 0);
            }
        }
	}
}
