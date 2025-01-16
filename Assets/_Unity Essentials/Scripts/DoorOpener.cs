using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DoorOpener : MonoBehaviour
{
    private Animator doorAnimator;
    private TMP_Text hintText;
    private bool isPlayerInRange = false;
    private bool hasOpen = false;
    private float lastActionTime = 0f;
    public float debounceTime = 1f;

    public GameObject hint = null;


    void Start()
    {
        doorAnimator = GetComponent<Animator>();
        hintText = hint.GetComponent<TMP_Text>();
        hintText.enabled = false;
    }

    void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E) && Time.time - lastActionTime >= debounceTime)
        {
            lastActionTime = Time.time;
            PerformAction();
        }
    }

    private void PerformAction()
    {
        if (!hasOpen)
        {
            doorAnimator.Play("Door_Open");
        }
        else
        {
            doorAnimator.Play("Door_Close");
        }
        hasOpen = !hasOpen;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            hintText.enabled = true;
            isPlayerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
            hintText.enabled = false;
        }
    }
}
