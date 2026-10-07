using UnityEngine;

[CreateAssetMenu(fileName = "AttackProfile", menuName = "Scriptable Objects/AttackProfile")]
public class AttackProfile : ScriptableObject
{
    public int damage = 10;
    public Vector2 knockback = new Vector2(1f, 1f);
    public Vector2 size = new Vector2(2f, 1f);
    public Vector2 offset = new Vector2(1.5f, 1f);
}
