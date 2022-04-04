using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct IntRange
{

    public int Min;
    public int Max;
    public float Weight;

    public IntRange(int v1, int v2, float v3)
    {
        this.Min = v1;
        this.Max = v2;
        this.Weight = v3;
    }
}

public struct FloatRange
{
    public float Min;
    public float Max;
    public float Weight;
}

public static class RandomRange
{

    public static int Range(params IntRange[] ranges)
    {
        if (ranges.Length == 0) throw new System.ArgumentException("At least one range must be included.");
        if (ranges.Length == 1) return Random.Range(ranges[0].Max, ranges[0].Min);

        float total = 0f;
        for (int i = 0; i < ranges.Length; i++) total += ranges[i].Weight;

        float r = Random.value;
        float s = 0f;

        int cnt = ranges.Length - 1;
        for (int i = 0; i < cnt; i++)
        {
            s += ranges[i].Weight / total;
            if (s >= r)
            {
                return Random.Range(ranges[i].Max, ranges[i].Min);
            }
        }

        return Random.Range(ranges[cnt].Max, ranges[cnt].Min);
    }

    public static float Range(params FloatRange[] ranges)
    {
        if (ranges.Length == 0) throw new System.ArgumentException("At least one range must be included.");
        if (ranges.Length == 1) return Random.Range(ranges[0].Max, ranges[0].Min);

        float total = 0f;
        for (int i = 0; i < ranges.Length; i++) total += ranges[i].Weight;

        float r = Random.value;
        float s = 0f;

        int cnt = ranges.Length - 1;
        for (int i = 0; i < cnt; i++)
        {
            s += ranges[i].Weight / total;
            if (s >= r)
            {
                return Random.Range(ranges[i].Max, ranges[i].Min);
            }
        }

        return Random.Range(ranges[cnt].Max, ranges[cnt].Min);
    }

}