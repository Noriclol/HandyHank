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
	
	public GameObject InventoryPanel;
	public GameObject MessagePanel;
	public GameObject DialoguePanel;

	bool interactableClose = false;
	bool invVisibility = false;
	bool msgVisibility = false;
	bool dlgVisibility = false;

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
	void KeyListener()
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
		if (Input.GetKeyDown(KeyCode.Return)/* && interactableClose == true*/) //for implementation of interactables
		{
			Debug.Log("Input.Message");
			if (dlgVisibility)//is active?
			{
				DialoguePanel.gameObject.SetActive(false);
				dlgVisibility = false;
			}// yes
			else
			{
				DialoguePanel.gameObject.SetActive(true);
				dlgVisibility = true;
			} // no	
		}

	}
	void SetFocus()
	{
		//switches focus between UI and Character
	}
}
