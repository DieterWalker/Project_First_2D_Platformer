using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowLevelName : MonoBehaviour
{
    [SerializeField] private Text mainLevelTitle;
    [SerializeField] private Text subLevelTitle;
    [SerializeField] private string title;
    [SerializeField] private string subTitle;
    [SerializeField] private float moveDuration = 0.25f;

    [SerializeField, ReadOnly] private Vector3 startPos;
    [SerializeField, ReadOnly] private Vector3 endPos;
      private Vector3 velocity = Vector3.zero;
    
    #region Unity Method 
        private void Start(){
            float canvasWidth = GetComponentInParent<Canvas>().GetComponent<RectTransform>().rect.width;
            startPos = new Vector3(-((Screen.width/ 2) + 200) , transform.position.y, transform.position.z);
            endPos = new Vector3(-((Screen.width/ 2) - 200), transform.position.y, transform.position.z);

            Color mainColor = mainLevelTitle.color;
            Color subColor = subLevelTitle.color;
            mainColor.a = 0f;
            subColor.a = 0f;
            mainLevelTitle.text = title;
            subLevelTitle.text = subTitle;
            transform.localPosition = new Vector3(startPos.x + 100, startPos.y, startPos.z);
            StartCoroutine(ShowAndHideLevelName());
            Debug.Log("Current Position: " + transform.localPosition);

        }
    #endregion

    private IEnumerator ShowAndHideLevelName(){
        yield return StartCoroutine(MoveObject(startPos, endPos, moveDuration, 0f, 1f));

        yield return new WaitForSeconds(2f);

        yield return StartCoroutine(MoveObject(endPos, startPos, moveDuration, 1f, 0f));
        gameObject.SetActive(false);
    }

    private IEnumerator MoveObject(Vector3 from, Vector3 to, float duration, float startAlpha, float endAlpha)
    {
        Color mainColor = mainLevelTitle.color;
        Color subColor = subLevelTitle.color;
        float elapsed = 0f;
        while (elapsed < duration)
        {
            transform.localPosition = Vector3.SmoothDamp(transform.localPosition, to, ref velocity, duration);
            // Debug.Log("Current Position: " + transform.localPosition);

            float alpha = Mathf.Lerp(startAlpha, endAlpha, elapsed / duration);
            
            mainLevelTitle.color = new Color(mainLevelTitle.color.r, mainLevelTitle.color.g, mainLevelTitle.color.b, alpha);
            subLevelTitle.color = new Color(subLevelTitle.color.r, subLevelTitle.color.g, subLevelTitle.color.b, alpha);
            elapsed += Time.deltaTime;
            yield return null;
        }
        // transform.localPosition = to;
        mainLevelTitle.color = new Color(mainLevelTitle.color.r, mainLevelTitle.color.g, mainLevelTitle.color.b, endAlpha);
        subLevelTitle.color = new Color(subLevelTitle.color.r, subLevelTitle.color.g, subLevelTitle.color.b, endAlpha);
    }
}
