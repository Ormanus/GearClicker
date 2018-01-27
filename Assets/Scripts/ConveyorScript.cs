using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorScript : MonoBehaviour {

    public float partWidth;
    public GameObject partPrefab;
    public GameObject partBackPrefab;
    public PlayerController playerController;

    public float speed;

    List<Transform> partsRight = new List<Transform>();
    List<Transform> partsLeft = new List<Transform>();

    private float width;
    private int amount;

    void Start ()
    {
        width = (Camera.main.orthographicSize * Camera.main.aspect * 2);

        //create parts
        amount = Mathf.CeilToInt(width / partWidth) + 1;

        System.Random random = new System.Random();

        for(int i = 0; i < amount; i++)
        {
            Transform tr = Instantiate(partPrefab).transform;
            tr.name = "Belt_r_" + partsRight.Count;
            tr.position = new Vector3((width / 2) - i * partWidth, 0, 0);
            tr.rotation = Quaternion.identity;
            Transform box = tr.transform.GetChild(0);
            float height = 0.7f + (float)(random.Next(0, 4) - 2) / 10.0f;
            box.localScale = new Vector3(
                0.7f + (float)(random.Next(0, 8) - 4) / 10.0f,
                0.7f + (float)(random.Next(0, 8) - 4) / 10.0f,
                height);
            box.position = new Vector3(box.position.x, box.position.y + (height - 0.2f) / 4.0f, box.position.z);
            partsRight.Add(tr);
        }

        for (int i = 0; i < amount; i++)
        {
            Transform tr = Instantiate(partBackPrefab).transform;
            tr.name = "Belt_l_" + partsLeft.Count;
            tr.position = new Vector3((width / 2) - i * partWidth, -1, 0);
            tr.rotation = Quaternion.identity;
            tr.localEulerAngles = new Vector3(180, 0, 0);
            partsLeft.Add(tr);
        }
    }

	void Update ()
    {
        //move
		for(int i = 0; i < partsRight.Count; i++)
        {
            partsRight[i].position += new Vector3(speed * Time.deltaTime, 0, 0);
            partsLeft[i].position += new Vector3(-speed * Time.deltaTime, 0, 0);

            if (partsRight[i].position.x > width / 2 + partWidth)
            {
                partsRight[i].position += new Vector3(-(amount * partWidth), 0, 0);
                playerController.addMoney();
            }

            if (partsLeft[i].position.x < -width / 2)
            {
                partsLeft[i].position += new Vector3(amount * partWidth, 0, 0);
            }
        }

        speed *= (1f - Time.deltaTime);
    }

    public void TickFromGear()
    {
        Debug.Log("Tick from gear");
        speed += 1.0f;
    }
}
