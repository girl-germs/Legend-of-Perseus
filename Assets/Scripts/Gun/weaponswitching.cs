using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponswitching : MonoBehaviour
{
    public int selectedweapon = 0;

    // Start is called before the first frame update
    void Start()
    {
        SelectWeapon();
    }

    // Update is called once per frame
    void Update()
    {
        int previousSelectedweapon = selectedweapon;

        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (selectedweapon >= transform.childCount - 1)
            {
                selectedweapon = 0;
            }
            else
            {
                selectedweapon++;
            }
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (selectedweapon <= 0)
            {
                selectedweapon = transform.childCount - 1;
            }
            else
            {
                selectedweapon--;
            }
        }

        // Only call SelectWeapon if the selection changed
        if (previousSelectedweapon != selectedweapon)
        {
            SelectWeapon();
        }
    }

    void SelectWeapon()
    {
        int i = 0;
        foreach (Transform weapon in transform)
        {
            weapon.gameObject.SetActive(i == selectedweapon);
            i++;
        }
    }
}
