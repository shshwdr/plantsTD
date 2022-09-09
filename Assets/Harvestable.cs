using UnityEngine;

public interface Harvestable
{
    public void harvest(Human human);
    Transform transform { get; }
}