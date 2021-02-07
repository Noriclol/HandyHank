using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public float playerSpeed = 5f;
	public Rigidbody2D rb;
	Vector2 movement;
	public Animator animator;
	public Camera cam;



	//Interactables
	bool interactableClose = false;
	public Interactable closestInteractable;

	//UI
	public GameObject InventoryPanel;
	public GameObject MessagePanel;
	public GameObject DialoguePanel;

	bool invVisibility = false;
	bool msgVisibility = false;
	bool dlgVisibility = false;

	bool dlgAvalable = false, dlgClicked = false;

	int currentdlgpage = 0;

	DialogueSysHandler dialogueHandler;

	void Update()
	{
		animator.SetFloat("Horizontal", movement.x);
		animator.SetFloat("Vertical", movement.y);
		animator.SetFloat("Speed", movement.sqrMagnitude);
		MovementListener();
		KeyListener();
		CameraInputListener();
	}
	private void FixedUpdate() { rb.MovePosition(rb.position + movement * playerSpeed * Time.fixedDeltaTime); }
	private void Start()
	{
		dialogueHandler = DialoguePanel.GetComponent<DialogueSysHandler>();
	}
	//Collision
	private void OnTriggerEnter2D(Collider2D collision)
	{
		interactableClose = true;
		closestInteractable = collision.GetComponent<Interactable>();



		//Debug.Log(closestInteractable.content);
	}
	private void OnTriggerExit2D(Collider2D collision)
	{
		interactableClose = false;
		closestInteractable = null;
	}
	void MovementListener()
	{
		//movement
		movement.x = Input.GetAxisRaw("Horizontal");
		movement.y = Input.GetAxisRaw("Vertical");
		//UI


	}
	void CameraInputListener()
	{
		float scroll = Input.GetAxisRaw("Mouse ScrollWheel");
		if (scroll == 1 || scroll == -1)
		{
			Debug.Log("Scrollwheel: " + scroll);
		}
		cam.orthographicSize = cam.orthographicSize + scroll * 1.0f;
	}
	void DialogueButtonToggle(bool openClose) // main dialogue function
	{
		int page, size = closestInteractable.realContent.dialogueSize;
		string text;
		Sprite img;
		if (openClose) //if open
		{
			page = dialogueHandler.page;
			text = closestInteractable.realContent.DialogueString[currentdlgpage];
			img = closestInteractable.realContent.DialogueImages[currentdlgpage];
			dialogueHandler.SetPageInfo(currentdlgpage, text, img);
		}
		else // if close
		{
			dialogueHandler.SetPageInfo();
		}
	}
	void KeyListener() // keylistener func, can probably be done better.
	{
		if (Input.GetKeyDown(KeyCode.I))
			{
				Debug.Log("Input.Inventory: " + invVisibility);
				if (invVisibility)//is active?
				{ // set to true
					InventoryPanel.gameObject.SetActive(false);
					invVisibility = false;
					Debug.Log("setting to: " + invVisibility);
				}
				else
				{ // set to false	
					InventoryPanel.gameObject.SetActive(true);
					invVisibility = true;
					Debug.Log("setting to: " + invVisibility);
				}
			}
		if (Input.GetKeyDown(KeyCode.M))
			{
				Debug.Log("Input.Message: " + msgVisibility);
				if (msgVisibility)//is active?
				{
					MessagePanel.gameObject.SetActive(false);
					msgVisibility = false;
					Debug.Log("setting to: " + msgVisibility);
				}// yes
				else
				{
					MessagePanel.gameObject.SetActive(true);
					msgVisibility = true;
					Debug.Log("setting to: " + msgVisibility);
				} // no	
			}
		if (Input.GetKeyDown(KeyCode.Return)/* && interactableClose == true */) //for implementation of interactables
		{
			Debug.Log("Input.Message");
			if (dlgVisibility)//is active?
			{
				DialoguePanel.gameObject.SetActive(false);
				dlgVisibility = false;
				DialogueButtonToggle(dlgVisibility);
			}// yes
			else
			{
				DialoguePanel.gameObject.SetActive(true);
				dlgVisibility = true;
				DialogueButtonToggle(dlgVisibility);
			} // no	
		}
	}
	void SetFocus()
	{
			//switches focus between UI and Character
	}
}

