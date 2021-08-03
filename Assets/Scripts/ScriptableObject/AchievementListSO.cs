using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Achievement/AchievementList")]
public class AchievementListSO : ScriptableObject
{
    public List<Achievements> achievementList;
}
