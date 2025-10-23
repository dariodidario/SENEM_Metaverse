using UnityEngine;
using System;

public class VirtualButtonLogger : MonoBehaviour
{
    [SerializeField] private string buttonId = "VirtualA"; // puoi cambiarlo da Inspector


    public void LogPress()
    {
    	if(buttonId == "PlayButton"){
    		string message = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss.fff};Video Started! (Pressed: {buttonId});";
        	LogManager.Instance.LogInfo(message); // usa il tuo LogManager per scrivere su file
        	Logger.Instance?.LogInfo($"Pressed {buttonId}"); // (opzionale) messaggio a schermo	
    	}else{
    		string message = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss.fff};Video Paused! (Pressed: {buttonId});";
        	LogManager.Instance.LogInfo(message); // usa il tuo LogManager per scrivere su file
        	Logger.Instance?.LogInfo($"Pressed {buttonId}"); // (opzionale) messaggio a schermo	
    	}
        
    }
}