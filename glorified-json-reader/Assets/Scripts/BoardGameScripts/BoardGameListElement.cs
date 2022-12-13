using TMPro;
using UnityEngine;

namespace GJR
{
    public class BoardGameListElement : MonoBehaviour
    {
        [field: Header("References")]
        [field: SerializeField] public TextMeshProUGUI Number { get; private set; }
        [field: SerializeField] public TextMeshProUGUI Name { get; private set; }
        [field: SerializeField] public TextMeshProUGUI Score { get; private set; }
        [field: SerializeField] public TextMeshProUGUI Best { get; private set; }
    }
}