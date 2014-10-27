#pragma strict
var img1:Texture;
var img2:Texture;


function Start () {
  guiTexture.texture=img1;
}

function Update () {


}
function OnMouseDown (){
  var gd :GameObject = GameObject.Find("GameData");
  if(gd!=null){
  GameObject.Destroy(gd);
  
  }
  Application.LoadLevel ("Main");
}
function OnMouseEnter () {
  guiTexture.texture=img2;
}
function OnMouseExit () {
  guiTexture.texture=img1;
}
