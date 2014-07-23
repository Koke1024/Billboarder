using UnityEngine;
using System.Collections;

public class Billboarder : MonoBehaviour {
	public GameObject scene;
	public Vector3 worldPosition;
	public float Z;
	public float scale = 1;

	public float width;
	public float height;
	
	public GameObject point;
	
	// Use this for initialization
	void Start () {
		Destroy (point);
	}

	public void SetZ(float z){
		Z = z;
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnGUI(){
	}
	
	public void SetPosition(Vector3 pos){
		worldPosition = pos;

		scene.guiTexture.pixelInset = new Rect(
			- width * scale / 2.0f, - height * scale / 2.0f,
			width * scale, height * scale);
		Vector3 tempPos = Camera.main.WorldToScreenPoint (worldPosition);
		
		transform.position = new Vector3(tempPos.x / Screen.width, tempPos.y / Screen.height, 0);
		Vector3 scenePos = scene.GetComponent<GUITexture> ().transform.position;
		scenePos.z = Z;
		scene.GetComponent<GUITexture>().transform.position = scenePos;
	}
	
	public void SetColor(Color color){
		scene.guiTexture.color = color;
	}

	public void SetTexture(Texture texture){
		scene.guiTexture.texture = texture;
	}
	
	public void OnPanelMouseDown(){
		transform.parent.parent.gameObject.GetComponent<Chara> ().SetStack (transform.parent.parent.gameObject.GetComponent<Chara> ().Move, 0.5f);
		transform.parent.parent.gameObject.GetComponent<Chara> ().SwitchPanels();
	}
	
	public void OnPanelMouseOver(){
		//scene.guiTexture. = new Color (1.0f, 1.0f, 1.0f, 1.0f);
	}
}
