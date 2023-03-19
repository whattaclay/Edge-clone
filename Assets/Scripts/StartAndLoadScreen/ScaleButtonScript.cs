using UnityEngine;
using UnityEngine.EventSystems;

namespace StartAndLoadScreen
{
    public class ScaleButtonScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        public void OnPointerEnter(PointerEventData eventData)
        {
            this.transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            this.transform.localScale = new Vector3(1, 1, 1);
        }
    }
}