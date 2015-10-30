using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
	private int cont;
    public float speed;
	public Text countText;
	public Text winText;

	public float force;
	private bool changeDir;
	private Vector3 dir;
    private Rigidbody rb;

	// Use this for initialization
	void Start () {
		changeDir = false;
        rb = GetComponent<Rigidbody>();
		dir = new Vector3 (0, 0, 0);
		cont = 0;
		SetCountText ();
		winText.text = "";
	}
	void Update(){
		if (transform.position.y < -1) {
			this.transform.position= new Vector3(4,0.5f,4);
			rb.Sleep();
			dir= new Vector3(0,0,0);
		}
		if (Input.GetMouseButtonDown (0)) {
			rb.Sleep ();
			if(changeDir){
				dir= new Vector3(0,0,1);
				changeDir= false;
				
			}else{
				dir= new Vector3(1,0,0);
				changeDir=true;
			}
		}
	}
	// Update is called once per frame
	void FixedUpdate () {

		rb.MovePosition (transform.position + dir * Time.deltaTime * force);
        /*float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * speed);*/

    }
	public void OnCollisionEnter(Collision node)
	{
		if(node.gameObject.tag == "destruye")
		{
			Destroy(node.gameObject);
			cont++;
			SetCountText();

		}
		if(node.gameObject.tag == "abismo")
		{
			Application.LoadLevel(Application.loadedLevelName);
			
		}
		if(node.gameObject.tag == "final")
		{
			Application.LoadLevel("zigzag2");
			
		}
		if(node.gameObject.tag == "final2")
		{
			Application.LoadLevel("zigzag3");
			
		}
	}

	void SetCountText()
	{
		countText.text = "Marcador: " + cont.ToString ();

	}
}
