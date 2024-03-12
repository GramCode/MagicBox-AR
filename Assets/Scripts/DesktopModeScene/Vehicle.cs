using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle : MonoBehaviour
{
    [SerializeField]
    private int _vehicleID;

    private Animator _truckAnim;
    private Animator _comancheAnim;

    private void Start()
    {
        switch (_vehicleID)
        {
            case 0:
                //truck
                _truckAnim = GetComponent<Animator>();
                break;
            case 1:
                //Comanche
                _comancheAnim = GetComponent<Animator>();
                break;
            default:
                break;
        }
    }

    public void PlayTruckAnim(bool playAnimation)
    {
        if (_truckAnim != null)
        {
            if (playAnimation == true)
            {
                _truckAnim.SetBool("Mix", true);
            }
            else
            {
                _truckAnim.SetBool("Mix", false);
            }
        }
    }

    public void PlayComancheAnim(bool playAnim)
    {
        if (_comancheAnim != null)
        {
            if (playAnim == true)
            {
                _comancheAnim.SetBool("Floating", true);
            }
            else
            {
                _comancheAnim.SetBool("Floating", false);
            }
        }
    }

    public void SelectedModel()
    {
        UIManager.Instance.SelectedObject(transform.parent.gameObject);
    }

    public void UnselectModel()
    {
        UIManager.Instance.HideRemoveButton();
    }

    public void TrackablePlanes(bool areEnabled)
    {
        DesktopManager.Instance.PlanesVisible(areEnabled);
    }
}
