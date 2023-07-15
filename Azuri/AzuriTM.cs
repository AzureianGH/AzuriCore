using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AzuriCore;
using AzuriCore.Logging;
namespace AzuriCore.Terrain
{
    /// <summary>
    /// Azuri Terrain Creator, used for creating terrain
    /// </summary>
    public class AzuriTM : MonoBehaviour
    {
        public AzuriLog log;
        /// <summary>
        /// Creates basic terrain based on heightmap generated at runtime
        /// </summary>

        public void CreateBasicTerrain(TerrainData terrainData, float minheight, float maxheight)
        {
            // Get the height map of the terrain
            int resolution = terrainData.heightmapResolution;
            float[,] heights = new float[resolution, resolution];

            // Set the corner heights of the terrain
            heights[0, 0] = Random.Range(minheight, maxheight);
            heights[0, resolution - 1] = Random.Range(minheight, maxheight);
            heights[resolution - 1, 0] = Random.Range(minheight, maxheight);
            heights[resolution - 1, resolution - 1] = Random.Range(minheight, maxheight);

            // Perform the diamond-square algorithm
            DiamondSquare(heights, 0, 0, resolution - 1, resolution - 1, minheight, maxheight);

            // Normalize the height map
            NormalizeHeightMap(heights, minheight, maxheight);

            // Apply the modified height map to the terrain
            terrainData.SetHeights(0, 0, heights);

            // Log the completion message
            log.InfoLog("AzuriTM", "CreateBasicTerrain: Basic terrain created successfully with values: " + minheight + " and " + maxheight);
        }

        private void DiamondSquare(float[,] heights, int startX, int startY, int endX, int endY, float minheight, float maxheight)
        {
            // Calculate the range of the diamond or square
            int range = endX - startX;
            
            if (range < 2)
                return;

            // Calculate the half range
            int halfRange = range / 2;

            // Diamond step
            for (int x = startX + halfRange; x < endX; x += range)
            {
                for (int y = startY + halfRange; y < endY; y += range)
                {
                    // Calculate the average of the four corners
                    float average = (heights[x - halfRange, y - halfRange] +
                                    heights[x - halfRange, y + halfRange] +
                                    heights[x + halfRange, y - halfRange] +
                                    heights[x + halfRange, y + halfRange]) * 0.25f;

                    // Calculate the diamond point height as the average plus a random displacement
                    float height = average + Random.Range(-range, range) * 0.1f;

                    // Set the height of the diamond point
                    heights[x, y] = height;
                }
            }

            // Square step
            for (int x = startX; x <= endX; x += halfRange)
            {
                for (int y = startY; y <= endY; y += halfRange)
                {
                    // Calculate the average of the surrounding diamond points
                    float average = 0;
                    int count = 0;

                    if (x - halfRange >= 0)
                    {
                        average += heights[x - halfRange, y];
                        count++;
                    }
                    if (x + halfRange < heights.GetLength(0))
                    {
                        average += heights[x + halfRange, y];
                        count++;
                    }
                    if (y - halfRange >= 0)
                    {
                        average += heights[x, y - halfRange];
                        count++;
                    }
                    if (y + halfRange < heights.GetLength(1))
                    {
                        average += heights[x, y + halfRange];
                        count++;
                    }

                    average /= count;

                    // Calculate the square point height as the average plus a random displacement
                    float height = average + Random.Range(-range, range) * 0.1f;

                    // Set the height of the square point
                    heights[x, y] = height;
                }
            }

            // Recursively apply the diamond-square algorithm to the four sub-quadrants
            DiamondSquare(heights, startX, startY, startX + halfRange, startY + halfRange, minheight, maxheight);
            DiamondSquare(heights, startX + halfRange, startY, endX, startY + halfRange, minheight, maxheight);
            DiamondSquare(heights, startX, startY + halfRange, startX + halfRange, endY, minheight, maxheight);
            DiamondSquare(heights, startX + halfRange, startY + halfRange, endX, endY, minheight, maxheight);
            log.InfoLog("AzuriTM", "DiamondSquare: DiamondSquare algorithm applied successfully with values: " + heights + ", " + startX + ", " + startY + ", " + endX + ", " + endY + ", " + minheight + ", " + maxheight + ", " + halfRange);
        }


        private void NormalizeHeightMap(float[,] heights, float minheight, float maxheight)
        {
            float minHeightValue = float.MaxValue;
            float maxHeightValue = float.MinValue;

            // Find the minimum and maximum height values in the height map
            for (int x = 0; x < heights.GetLength(0); x++)
            {
                for (int y = 0; y < heights.GetLength(1); y++)
                {
                    minHeightValue = Mathf.Min(minHeightValue, heights[x, y]);
                    maxHeightValue = Mathf.Max(maxHeightValue, heights[x, y]);
                }
            }

            // Normalize the height values to the specified range
            float heightRange = maxHeightValue - minHeightValue;
            float scale = (maxheight - minheight) / heightRange;

            for (int x = 0; x < heights.GetLength(0); x++)
            {
                for (int y = 0; y < heights.GetLength(1); y++)
                {
                    heights[x, y] = minheight + (heights[x, y] - minHeightValue) * scale;
                }
            }
            log.InfoLog("AzuriTM", "NormalizeHeightMap: Heightmap normalized successfully with values: " + minheight + " and " + maxheight);
        }
 
    }
}
