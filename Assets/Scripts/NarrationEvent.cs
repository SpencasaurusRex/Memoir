using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class NarrationEvent : MonoBehaviour, IGameEvent 
{
    public TextMeshProUGUI Text;
    
    public string FinalText;
    public float RevealSpeed; // Characters per second
    // public bool ClickToContinue;
    
    public float characterIndex; 
    
    public void EventStart()
    {
        Text.text = string.Empty;
    }

    public bool EventUpdate()
    {
        characterIndex += RevealSpeed * Time.deltaTime;
        int actualIndex = Mathf.Clamp((int)characterIndex, 0, FinalText.Length);

        Text.text = FinalText.Substring(0, actualIndex) + "<alpha=#00>" + FinalText.Substring(actualIndex, FinalText.Length - actualIndex);
        
        if (/*ClickToContinue &&*/ characterIndex > FinalText.Length && Input.GetMouseButtonDown((int)MouseButton.LeftMouse))
        {
            return true;
        }
        return false;
    }
}