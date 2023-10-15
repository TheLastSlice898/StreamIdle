using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChatBox : MonoBehaviour
{
    public TMP_Text chatBox;
    public TMP_InputField messageSend;
    public Button sendButton;

    private bool bannedUser = false; //if a person in chat has been banned
    private string[] chatMessages = new string[6]; //where the messages will be stored
    private int messageCount = 0; //records the number of messages
    private string[] users = { "MeowCats12", "SmartPlant", "IlikeCheese", "BananaMan", "FriendlyGuy", "CoolDude" };

    // Start is called before the first frame update
    void Start()
    {
        sendButton.onClick.AddListener(SendMessage);
        AddMessage("Streamer: Welcome to the chat.");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SendMessage()
    {
        string message = messageSend.text.Trim();

        if (message == "")
            return;
        
        if (!bannedUser)
        {
            string userMessage = "Moderator: " + message;
            AddMessage(userMessage);
            messageSend.text = "";
            AddRandomMessage();
        }

        if (message.StartsWith("!ban") && !bannedUser)
        {
            bannedUser = true;
            AddMessage("Moderator: Moderator has banned the rude user.");
            messageSend.text = "";
            return;
        }

        if (message.StartsWith("!ban") && bannedUser)
        {
            AddMessage("Moderator: The user is already banned.");
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

        string userMessage = randomUser + ": " + randomMessage;
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

