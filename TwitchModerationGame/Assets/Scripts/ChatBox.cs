using System.Collections;
using System.Collections.Generic;
using Random = UnityEngine.Random;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class ChatBox : MonoBehaviour
{
    public TMP_Text chatBox;
    public TMP_InputField messageSend;
    public Button sendButton;

    public static event Action OnBanned;
    

    public bool bannedUser = false; //if a person in chat has been banned
    public string[] chatMessages = new string[6]; //where the messages will be stored
    public int messageCount = 0; //records the number of messages
    public string[] users = { "MeowCats12", "SmartPlant", "IlikeCheese", "BananaMan", "FriendlyGuy", "CoolDude" };

    // Start is called before the first frame update
    void Start()
    {
        sendButton.onClick.AddListener(SendMessage);
        AddMessage($"<color=blue>Streamer:</color> Welcome to the chat.");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SendMessage();
        }
    }

    void SendMessage()
    {

        string message = messageSend.text.Trim();

        if (message == "")
            return;
        
        if (!bannedUser)
        {
            string userMessage = $"<color=red>Moderator:</color> {message}";
            AddMessage(userMessage);
            messageSend.text = "";
            AddRandomMessage();
        }

        if (message.StartsWith("!ban") && !bannedUser)
        {
            bannedUser = false;
            AddMessage("Moderator has banned the rude user.");
            OnBanned?.Invoke();
            messageSend.text = "";
            return;
        }

        if (message.StartsWith("!ban") && bannedUser)
        {
            AddMessage("The user is already banned.");
            messageSend.text = "";
        }
    }

    void AddRandomMessage()
    {
        string randomUser = users[Random.Range(0, users.Length)];
        string randomMessage;

        if (Random.value < 0.7f)
        {
            string[] compliments = { "You are an amazing streamer!", "I love cat videos.", "Haha funny.", "Hello this stream is cool.", "I love talking here." };
            randomMessage = compliments[Random.Range(0, compliments.Length)];
        }
        else
        {
            randomMessage = "Hehehe Im going to say bad words :)";
        }

        string userMessage = $"<color=purple>{randomUser}</color>: {randomMessage}";
        AddMessage(userMessage);
    }

    void AddMessage(string message)
    {
        if (messageCount >= chatMessages.Length)
        {
            // if array is full, removes the latest message.
            for (int i = 0; i < chatMessages.Length - 1; i++)
            {
                chatMessages[i] = chatMessages[i + 1];
            }
            chatMessages[chatMessages.Length - 1] = message;
        }
        else
        {
            chatMessages[messageCount] = message;
            messageCount++;
        }
       
        UpdateChatBox();
    }

    void UpdateChatBox()
    {
        chatBox.text = string.Join("\n", chatMessages);
    }
}

