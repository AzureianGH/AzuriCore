# AzuriCore for Unity

AzuriCore for Unity is a collection of scripts that simplifies coding in Unity projects, developed by Azureian. It provides various functionalities and tools to streamline development processes and enhance productivity.

## Features

- **AzuriLog**: A logging utility to easily display log messages, warnings, and errors in the Unity console.
- **AzuriOD**: Object detection and retrieval functions for finding objects in the scene based on tags, layers, names, and more.
- **AzuriSM**: Sound management utilities for creating and modifying sound instances in the game.
- **AzuriTM**: Terrain creation tools for generating basic terrains based on heightmaps.
- **AzuriCD**: Collision detection and interaction functions for checking collisions between objects, tags, and layers.
- **AzuriPM**: Portal management class for handling portals in the game.

## Usage

1. Import the AzuriCore package into your Unity project.
2. Attach the necessary scripts to the appropriate game objects in your scene.
3. Access the functionalities provided by each script through their respective methods and properties.

## Examples

Here's a simple example of how to use the AzuriOD script to retrieve all objects in the scene:

```csharp
using UnityEngine;
using AzuriCore.Collision.Objects;

public class ExampleScript : MonoBehaviour
{
    private AzuriOD od;

    private void Start()
    {
        GameObject[] allObjects = od.AllObjects();

        foreach (GameObject obj in allObjects)
        {
            Debug.Log("Object name: " + obj.name);
        }
    }
}
```
## Limitations
- AzuriCore is currently in active development and may have some limitations and bugs.
- Make sure to review the documentation and examples provided for each script to understand their proper usage and constraints.

## License
AzuriCore for Unity is released under the MIT License.

## Credits
AzuriCore for Unity is developed by Azureian.

## Contact
If you have any questions or feedback, feel free to contact me at azureian@bingchilling.com.

## Extra Info
Feel free to customize and modify the README.md file according to your project's specific details and requirements.
Credit me if possible.
