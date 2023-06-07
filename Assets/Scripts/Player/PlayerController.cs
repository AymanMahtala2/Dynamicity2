using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(PlayerInput))]
public class PlayerController : Character
{
    public static PlayerController instance;

    public GameObject inventory;

    public GameObject journal;

    public string playerName = "Ayman";

    public VectorValue startingPosition;

    public bool hasJournal;

    [SerializeField]
    private CinemachineVirtualCamera vcamTalking;
    [SerializeField]
    private CinemachineVirtualCamera vcamFighting;
    [SerializeField]
    private CinemachineVirtualCamera vcamNormal;

    public void SwitchToTalkingCam(bool switchToTalkingCam)
    {
        if(switchToTalkingCam)
        {
            vcamTalking.Priority = 12;
        } else
        {
            vcamTalking.Priority = 1;
        }
    }

    public void SwitchToFightingCam(bool switchToFightingCam)
    {
        if (switchToFightingCam)
        {
            vcamTalking.Priority = 14;
        }
        else
        {
            vcamTalking.Priority = 1;
        }
    }

    private void Start()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else
        {
            Destroy(gameObject);
        }
    }

    public void SetStartingPosition()
    {
        transform.position = startingPosition.initialValue;
    }

    public void OpenInventory()
    {
        if(!inventory.activeSelf)
        {
            InventorySystem.instance.ListItems();
            PlayerInput.instance.CannotMoveOrAttack();
        } else
        {
            InventorySystem.instance.Clean();
            PlayerInput.instance.CanMoveOrAttack();
        }
        inventory.SetActive(!inventory.activeSelf);
    }

    public void OpenJournal()
    {

        if(!journal.activeSelf)
        {
            journal.SetActive(true);
            PlayerInput.instance.CannotMoveOrAttack();
        } else
        {
            if(!Journal.instance.inputField.isFocused)
            {
                PlayerInput.instance.journalOpen = false;
                journal.SetActive(false);
                PlayerInput.instance.CanMoveOrAttack();
            }

        }
    }

    public override void Die()
    {
        SceneManager.LoadScene(0);
    }

    private void Update()
    {
        direction = (int)PlayerInput.instance.horizontalInput;
    }

    public override void FightingMode()
    {
        state = State.Fighting;
    }

    public void IdleMode()
    {
        state = State.Idle;
    }

    public void Talk()
    {
        if(di != null)
        {
            di.StartTalking();
        }
    }

    public void Jump()
    {
        rb.AddForce(new Vector2(0, 25), ForceMode2D.Impulse);
    }

    public string sceneName = "noscene";
    public void Transport()
    {
        if(sceneName != "noscene")
        {
            SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
            SetStartingPosition();
        }
    }
}
