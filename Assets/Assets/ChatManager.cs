using UnityEngine;
using UnityEngine.Networking;
using TMPro;
using System.Collections;
using Newtonsoft.Json;
using System.Collections.Generic;

public class Dialogo : MonoBehaviour
{
    public TMP_InputField inputField;
    public TextMeshProUGUI chatDisplay;
    public string userName = "Usuario";

    void Start()
    {
        if (inputField == null || chatDisplay == null)
        {
            Debug.LogError("inputField o chatDisplay no están asignados. Por favor, configúralos en el Inspector.");
            enabled = false; // Desactiva el script si no están asignados.
        }
    }

    public void SendMessage()
    {
        if (inputField != null && chatDisplay != null)
        {
            string message = inputField.text;

            if (!string.IsNullOrEmpty(message))
            {
                AddMessageToChat("<b>" + userName + ":</b> " + message);
                inputField.text = "";

                StartCoroutine(EnviarSolicitud(message));
            }
        }
        else
        {
            Debug.LogWarning("inputField o chatDisplay no están asignados en el Inspector de Unity.");
        }
    }

    IEnumerator EnviarSolicitud(string mensaje)
    {
        string url = "http://localhost:5005/webhooks/rest/webhook";

        var data = new
        {
            sender = userName,
            message = mensaje
        };

        string jsonData = JsonConvert.SerializeObject(data);

        UnityWebRequest request = new UnityWebRequest(url, "POST");
        byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(jsonData);
        request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = new DownloadHandlerBuffer();

        request.SetRequestHeader("Content-Type", "application/json");

        Debug.Log("Enviando datos: " + jsonData);

        yield return request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError("Error al enviar el mensaje: " + request.error);
            AddMessageToChat("<b>Error:</b> " + request.error);
        }
        else
        {
            string responseFromServer = request.downloadHandler.text;
            Debug.Log("Respuesta: " + responseFromServer);

            try
            {
                var messages = JsonConvert.DeserializeObject<List<ResponseMessage>>(responseFromServer);
                if (messages != null)
                {
                    foreach (var msg in messages)
                    {
                        if (!string.IsNullOrEmpty(msg.text))
                        {
                            AddMessageToChat("<b>Server:</b> " + msg.text);
                        }
                    }
                }
                else
                {
                    Debug.LogWarning("El servidor respondió, pero no se pudieron procesar los datos.");
                    AddMessageToChat("<b>Error:</b> Respuesta no válida del servidor.");
                }
            }
            catch (System.Exception e)
            {
                Debug.LogError("Error al procesar la respuesta del servidor: " + e.Message);
                AddMessageToChat("<b>Error:</b> No se pudo procesar la respuesta.");
            }
        }
    }

    void AddMessageToChat(string message)
    {
        chatDisplay.text += message + "\n";

        var scrollView = chatDisplay.GetComponentInParent<UnityEngine.UI.ScrollRect>();
        if (scrollView != null)
        {
            Canvas.ForceUpdateCanvases();
            scrollView.verticalNormalizedPosition = 0;
            Canvas.ForceUpdateCanvases();
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && inputField.isFocused)
        {
            SendMessage();
        }
    }

    [System.Serializable]
    public class ResponseMessage
    {
        public string recipient_id;
        public string text;
    }
}
