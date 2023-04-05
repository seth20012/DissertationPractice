using SequenceLogic;
using UnityEngine;

namespace UX
{
    public class SkipMenu : MonoBehaviour
    {
        [SerializeField] private MRTKInteractableSequenceInstance mrtkInteractableSequenceInstance;

        // Start is called before the first frame update
        void Start()
        {
            mrtkInteractableSequenceInstance.OnSequenceInstanceEnded?.AddListener(() => gameObject.SetActive(false));
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
