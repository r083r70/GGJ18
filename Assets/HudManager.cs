using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HudManager : MonoBehaviour {

    public GameObject[] lifes;
    public Material on;
    public Material off;

    private MeshRenderer[] power1;
    private bool power1_b;
    private MeshRenderer[] power2;
    private bool power2_b;
    private MeshRenderer[] power3;
    private bool power3_b;
    private MeshRenderer[] power4;
    private bool power4_b;

    public Piccione piccione;

    private static HudManager instance;
    public static HudManager Instance {
        get { return instance; }
    }

    private void Awake() {
        if (instance)
            Destroy(gameObject);
        else
            instance = this;
    }

    private float initialY;
    private Vector3 initialPos;

    private void Start () {
        power1 = new MeshRenderer[lifes.Length];
        power2 = new MeshRenderer[lifes.Length];
        power3 = new MeshRenderer[lifes.Length];
        power4 = new MeshRenderer[lifes.Length];
        power1_b = power2_b = power3_b = power4_b = false;
        int index = 0;
		foreach (var life in lifes) {
            power1[index] = life.GetComponent<Transform>().Find("PowerUp_01").GetComponent<MeshRenderer>();
            power2[index] = life.GetComponent<Transform>().Find("PowerUp_02").GetComponent<MeshRenderer>();
            power3[index] = life.GetComponent<Transform>().Find("PowerUp_03").GetComponent<MeshRenderer>();
            power4[index] = life.GetComponent<Transform>().Find("PowerUp_04").GetComponent<MeshRenderer>();
            index++;

            foreach (var c in life.GetComponent<Transform>().GetComponentsInChildren<MeshRenderer>())
                c.material = off;
        }
        UpdateLife(lifes.Length - 1);

        initialY = piccione.GetComponent<Transform>().position.y;
        initialPos = GetComponent<Transform>().localPosition;
    }

    public void UpdateLife(int num) {
        foreach (var l in lifes)
            l.SetActive(false);
        lifes[num].SetActive(true);
    }
	
	public void Change (int index, bool b) {
        switch (index) {
            case 1:
                Change(power1, b);
                power1_b = b;
                break;
            case 2:
                Change(power2, b);
                power2_b = b;
                break;
            case 3:
                Change(power3, b);
                power3_b = b;
                break;
            case 4:
                Change(power4, b);
                power4_b = b;
                break;
        }
	}

    private void Change(MeshRenderer[] mr, bool b) {
        foreach (MeshRenderer m in mr)
            m.material = b? on : off;
    }

    private void Update() {
        float offsetY = piccione.GetComponent<Transform>().position.y - initialY;
        GetComponent<Transform>().localPosition = initialPos + Vector3.down * offsetY;

        if (Input.GetButtonDown("Fire1") && power1_b) {
            Change(1, false);
            piccione.HighQuality();
        }

        if (Input.GetButtonDown("Fire2") && power2_b) {
            Change(2, false);
            piccione.Smaller();
        }

        if (Input.GetButtonDown("Fire3") && power3_b) {
            Change(3, false);
            piccione.Firewall();
        }

        if (Input.GetButtonDown("Fire4") && power4_b) {
            Change(4, false);
            piccione.Slowdown();
        }
    }
}
