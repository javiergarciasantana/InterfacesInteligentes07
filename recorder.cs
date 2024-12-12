using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recorder : MonoBehaviour
{
    private AudioSource audioSource; // Variable para el AudioSource
    private string microphone; // Nombre del micrófono
    private bool isRecording = false; // Estado de grabación

    void Start()
    {
        // Obtener el componente AudioSource
        audioSource = GetComponent<AudioSource>();

        // Verificar si hay micrófonos disponibles
        if (Microphone.devices.Length > 0)
        {
            microphone = Microphone.devices[0]; // Usar el primer micrófono disponible
        }
        else
        {
            Debug.LogError("No se detectó ningún micrófono en el dispositivo.");
        }
    }

    void Update()
    {
        // Iniciar grabación al presionar la tecla R
        if (Input.GetKeyDown(KeyCode.R) && !isRecording)
        {
            StartRecording();
        }

        // Detener grabación al soltar la tecla R
        if (Input.GetKeyUp(KeyCode.R) && isRecording)
        {
            StopRecording();
            audioSource.Play(); 
        }
    }

    void StartRecording()
    {
        if (microphone != null)
        {
            isRecording = true;
            audioSource.clip = Microphone.Start(microphone, true, 10, 44100); // Grabar hasta 10 segundos
            audioSource.loop = true;

            while (!(Microphone.GetPosition(microphone) > 0)) { } // Esperar a que comience la grabación
            // Reproducir lo que se graba en tiempo real
            Debug.Log("Grabación iniciada...");
        }
    }

    void StopRecording()
    {
        if (microphone != null)
        {
            isRecording = false;
            Microphone.End(microphone); // Detener el micrófono
            audioSource.Stop(); // Detener la reproducción
            Debug.Log("Grabación detenida.");
        }
    }
}
