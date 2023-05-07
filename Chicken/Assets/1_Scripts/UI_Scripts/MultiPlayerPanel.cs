using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.AssemblyQualifiedNameParser;
using UnityEngine;
using UnityEngine.UI;

public class MultiPlayerPanel : MonoBehaviourPunCallbacks
{
    public Button createRoom, joinRoom;

    public GameObject createRoomPanel;
    public GameObject joinRoomPanel;
    public GameObject mainButtons;

    private void Start()
    {
        createRoom.interactable = false;
    }



    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        Debug.Log("cambiio");
    
    }
        public void CreateRoomPanel()
    {

        createRoomPanel.SetActive(!createRoomPanel.activeSelf);
        joinRoomPanel.SetActive(!joinRoomPanel.activeSelf);

        createRoom.interactable = false;
        joinRoom.interactable = true;

    }
    public void JoinRoomPanel()
    {

        joinRoomPanel.SetActive(!joinRoomPanel.activeSelf);
        createRoomPanel.SetActive(!createRoomPanel.activeSelf);

        createRoom.interactable = true;
        joinRoom.interactable = false;
    }
    public void Back() {
        mainButtons.SetActive(true);
        gameObject.SetActive(false);
    
    }

    /// <summary>
    /// ///////////////
    /// </summary>



    public Button JoinRoomButton;
    public GameObject textoAlerta;
        
    public InputField createInput;
    public Dropdown cantPlayersDropdown;
    public InputField nicknameInputCreate;

    public InputField joinInput;
    public InputField nicknameInputJoin;
    // Start is called before the first frame update
    private void Update()
    {
        /*if (PhotonNetwork.CountOfRooms == 0)
        {
            JoinRoomButton.interactable = false;
            textoAlerta.SetActive(true);
        }
        else
        {
            JoinRoomButton.interactable = true;
            textoAlerta.SetActive(false);

        }
        */
    }


    public void CreateRoom()
    {
        RoomOptions roomOptions = new RoomOptions();
        PhotonNetwork.NickName = nicknameInputCreate.text;
        Debug.Log(cantPlayersDropdown.captionText.text);
        Debug.Log((byte)int.Parse(cantPlayersDropdown.captionText.text));
        roomOptions.MaxPlayers = (byte)int.Parse(cantPlayersDropdown.captionText.text);
        if (createInput.text == "")
        { //Crea una sala con la cantidad de salas + 1, en el caso de que no haya ninguno se llamaría sala "1", esto va a servir para la build final
            PhotonNetwork.CreateRoom(1.ToString(), roomOptions, TypedLobby.Default);
        }
        else  //Esto para el modo dev
        {
            PhotonNetwork.CreateRoom(createInput.text, roomOptions, TypedLobby.Default);
        }
    }

    public void JoinRoom()
    {

        if (joinInput.text == "")
        {
            PhotonNetwork.JoinRoom(1.ToString());
        }
        else
        {
            PhotonNetwork.NickName = nicknameInputJoin.text;
            PhotonNetwork.JoinRoom(joinInput.text);
        }
        //PhotonNetwork.JoinRoom(1.ToString());
        //
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("LobbyRoom");

    }



}
