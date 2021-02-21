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
	public DialogueObject ownInteractable; //made 
	//UI
	public GameObject InventoryPanel;
	public GameObject MessagePanel;
	public GameObject DialoguePanel;

	bool invVisibility = false;
	bool msgVisibility = false;
	bool dlgVisibility = false;

	bool dlgAvalable = false, dlgClicked = false;

	

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
		ownInteractable = GetComponent<DialogueObject>();
	}
	//Collision
	private void OnTriggerEnter2D(Collider2D collision)
	{
		interactableClose = true;
		closestInteractable = collision.GetComponent<Interactable>();
		dialogueHandler.CollectInfo();
		//Debug.Log(closestInteractable.content);
	}
	private void OnTriggerExit2D(Collider2D collision)
	{
		interactableClose = false;
		//hanks thoughts implement route.
		closestInteractable.content = ownInteractable;
	}
	//%%Collision%%
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
	void DialogueButtonToggle(bool openClose) {  // main dialogue function

		
		if (openClose) //if open
		{
			DialoguePanel.gameObject.SetActive(false);
			dlgVisibility = false;
			int page, size = dialogueHandler.maxPage;
			string text;
			Sprite img = GetComponent<SpriteRenderer>().sprite;
			page = dialogueHandler.page;
			text = closestInteractable.content.DialogueString[page];
			img = closestInteractable.content.DialogueImages[page];
			if(/*new dialogue*/closestInteractable.content.finished) { // if dlg Finished?
				DialoguePanel.gameObject.SetActive(true);
				dlgVisibility = true;
			}
			else if(closestInteractable.content.currentPage > closestInteractable.content.dialogueSize){ // if dlg currentpage
				dialogueHandler.SetPageInfo(page, text, img);
				dialogueHandler.page += 1;
				if (dialogueHandler.page == dialogueHandler.maxPage)
				{
					dialogueHandler.finished = true;
				}
			}
			dialogueHandler.SetInfo();
		}
        else
        {
			DialoguePanel.gameObject.SetActive(true);
			dlgVisibility = true;
		}
	}
	void KeyListener() // keylistener func, can probably be done better.
	{
		if (Input.GetKeyDown(KeyCode.I)/*Inventory*/)
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
		if (Input.GetKeyDown(KeyCode.M)/*messagetab*/)
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
		if (Input.GetKeyDown(KeyCode.F)/*Talk*/) {
            if (interactableClose) {
				if (dlgVisibility) {	DialogueButtonToggle(false); }// yes
				else { DialogueButtonToggle(true); } //no
			}
			DialogueButtonToggle(false);
		}// yes
	}	
	
	void SetFocus()
	{
			//switches focus between UI and Character
	}
}

