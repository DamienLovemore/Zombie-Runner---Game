using System.Collections;
using UnityEngine;

public class DisplayDamage : MonoBehaviour
{
    [SerializeField] private Canvas damageReceivedCanvas;
    [SerializeField] private float damageReceivedTime = 0.3f;

    void Start() 
    {
        this.damageReceivedCanvas.enabled = false;
    }

    //Call the function that indicates that the player was damaged
    public void ShowDamageImpact()
    {
        StartCoroutine(this.ShowSplatter());
    }

    //Shows blood splatter on the screen to indicate damage, and
    //fades after a while
    private IEnumerator ShowSplatter()
    {
        this.damageReceivedCanvas.enabled = true;
        yield return new WaitForSeconds(this.damageReceivedTime);
        this.damageReceivedCanvas.enabled = false;
    }
}
