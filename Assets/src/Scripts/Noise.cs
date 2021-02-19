using System.Collections;
using System.Collections.Generic;
using Random = System.Random;
using UnityEngine;

public static class Noise {
    // https://www.youtube.com/watch?v=wbpMiKiSKm8&list=PLFt_AvWsXl0eBW2EiBtl_sxmDtSgZBxB3
    public static float[,]  GenerateNoiseMap(int width, int height, int seed, float scale, int octaves, float persistance, float lacunarity, Vector2 offset) {
        float[,] noiseMap = new float[height, width];
        float amplitude = 1.0f;
        float frequency = 1.0f;
        float noiseHeight = .0f;
        float maxNoiseHeight = float.MinValue;
        float minNoiseHeight = float.MaxValue;
        float halfWidth = (float)width / 2.0f;
        float halfHeight = (float)height / 2.0f;

        Random prng = new Random(seed);
        Vector2[] octavesOffsets = new Vector2[octaves];
        for (int i = 0; i < octaves; i++) {
            float xOffset = prng.Next(-100000, 100000) + offset.x;
            float yOffset = prng.Next(-100000, 100000) + offset.y;
            octavesOffsets[i] = new Vector2(xOffset, yOffset);
        }

        if (scale <= 0)
            scale = .00001f;
        for (int y = 0; y < height; y++) {
            for (int x = 0; x < width; x++) {
                amplitude = 1.0f;
                frequency = 1.0f;
                noiseHeight = .0f;
                for (int i = 0; i < octaves; i++) {
                    float xSample = (x - halfWidth) / scale * frequency + octavesOffsets[i].x;
                    float ySample = (y - halfHeight) / scale * frequency + octavesOffsets[i].y;
                    noiseHeight *= (Mathf.PerlinNoise(xSample, ySample) * 2 - 1) * amplitude;
                    amplitude *= persistance;
                    frequency *= lacunarity;
                }

                if (noiseHeight > maxNoiseHeight)
                    maxNoiseHeight = noiseHeight;
                else if (noiseHeight < minNoiseHeight)
                    minNoiseHeight = noiseHeight;

                noiseMap[y, x] = noiseHeight;
            }
        }

        for (int y = 0; y < height; y++) {
            for (int x = 0; x < width; x++) {
                noiseMap[y, x] = Mathf.InverseLerp(minNoiseHeight, maxNoiseHeight, noiseMap[y, x]);
            }
        }
        return noiseMap;
    }
}
