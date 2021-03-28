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

	//Gameplay
	public Inventory inventory;

	//Interactables
	bool interactableClose = false;
	public Interactable ci; //Closest Interactable
	//public DialogueObject ownInteractable; //made 
	//UI
	public GameObject GameUI;
	GameObject InventoryPanel, MessagePanel;

	bool invVisibility = false;
	bool msgVisibility = false;
	bool dlgVisibility = false;

	public DialogueSysHandler dialogueHandler;
	public InventorySysHandler inventoryHandler;


	void Update() {
		animator.SetFloat("Horizontal", movement.x);
		animator.SetFloat("Vertical", movement.y);
		animator.SetFloat("Speed", movement.sqrMagnitude);
		MovementListener();
		KeyListener();
		CameraInputListener();
	}
	private void FixedUpdate() { 
		rb.MovePosition(rb.position + movement * playerSpeed * Time.fixedDeltaTime); 
	}
	private void Start()
	{
		dialogueHandler = GameUI.GetComponent<DialogueSysHandler>();
		inventoryHandler = GameUI.GetComponent<InventorySysHandler>(); 
		InventoryPanel = GameUI.transform.Find("InventorySys").gameObject;
		MessagePanel = GameUI.transform.Find("MessageSys").gameObject;
		//ownInteractable = GetComponent<DialogueObject>();
	}
	//Collision
	private void OnTriggerEnter2D(Collider2D collision)
	{
        if (collision.tag == "ItemPickup") {
			//Debug.Log("oink oink");
			collision.GetComponent<ItemInstance>().player = gameObject;
			collision.GetComponent<ItemInstance>().OnPickup();
		}
		else if(collision.tag == "Interactable") {
			interactableClose = true;
			ci = collision.GetComponent<Interactable>();
			dialogueHandler.maxPage = ci.content.DialogueText.Count;
			dialogueHandler.page = 0;
			//Debug.Log("maxpage = " + dialogueHandler.maxPage);
		}
        else {
			Debug.LogError("No recognized tag");
        }
        
		

	}
	private void OnTriggerExit2D(Collider2D collision)
	{

		if (collision.tag == "ItemPickup") {
			Debug.Log("oink");
		}
		else if (collision.tag == "Interactable") {
			interactableClose = false;
			dlgVisibility = false;
			dialogueHandler.ToggleWindowVisibility(false);
			dialogueHandler.ClearPageInfo();
		}
		else {
			Debug.LogError("No recognized tag");
		}
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

	void KeyListener() // keylistener func, can probably be done better.
	{
		if (Input.GetKeyDown(KeyCode.I)/*Inventory*/)
		{
				if (invVisibility)//is active?
				{ // set to true
					InventoryPanel.gameObject.SetActive(false);
					invVisibility = false;
				}
				else
				{ // set to false	
					InventoryPanel.gameObject.SetActive(true);
					invVisibility = true;
					inventoryHandler.Populate();
				}
			}
		if (Input.GetKeyDown(KeyCode.M)/*messagetab*/)
		{
				if (msgVisibility)//is active?
				{
					MessagePanel.gameObject.SetActive(false);
					msgVisibility = false;
				}// yes
				else
				{
					MessagePanel.gameObject.SetActive(true);
					msgVisibility = true;
				} // no	
			}
		if (Input.GetKeyDown(KeyCode.F)/*Talk*/) {

            if (interactableClose) {
				if (dlgVisibility) {
					dialogueHandler.ToggleWindowVisibility(false);
					dlgVisibility = false;
				}
				else {
					dialogueHandler.ToggleWindowVisibility(true);
					dlgVisibility = true;
				}
			}
		}
        if (Input.GetKeyDown(KeyCode.Return)/*Talk/Next Page*/) {
			if (interactableClose) {
                if (dlgVisibility) //window open
                {
					if (dialogueHandler.page >= dialogueHandler.maxPage - 1)
					{
						dialogueHandler.page = 0;
						dialogueHandler.ToggleWindowVisibility(false);
						dlgVisibility = false;
					}
					else
					{
						dialogueHandler.NextPage();
					}
				}
            }
        }
	}	
	
	void SetFocus()
	{
			//switches focus between UI and Character
	}
}

