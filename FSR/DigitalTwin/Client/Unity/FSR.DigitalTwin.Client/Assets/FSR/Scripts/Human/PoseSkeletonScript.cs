using UnityEngine;

public class PoseSkeleton : MonoBehaviour
{
    // Array to hold all the cubes representing each landmark
    private GameObject[] landmarkCubes = new GameObject[33];

    // Scale of the cubes
    public Vector3 cubeScale = new Vector3(0.1f, 0.1f, 0.1f); // Small cube size
    public Material cubeMaterial;
    void Start()
    {
        for (int i = 0; i < landmarkCubes.Length; i++)
        {
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);

            cube.transform.localScale = cubeScale;

            // Name the cube based on the landmark index
            cube.name = GetLandmarkName(i);

            // TODO: Set a material (to change color, etc.)
            if (cubeMaterial != null)
            {
                cube.GetComponent<Renderer>().material = cubeMaterial;
            }

            // Parent the cube to the PoseSkeleton GameObject
            cube.transform.SetParent(this.transform);

            // Store the cube in the array
            landmarkCubes[i] = cube;
        }
    }

    // Update the positions of the cubes based on incoming pose landmark data
    public void UpdatePose(Vector3[] landmarkPositions)
    {
        for (int i = 0; i < landmarkCubes.Length; i++)
        {
            // Check if the landmark position is valid and update the position of the cube
            if (i < landmarkPositions.Length)
            {
                landmarkCubes[i].transform.position = landmarkPositions[i];
            }
        }
    }

    // Utility function to name the cubes based on landmark index
    private string GetLandmarkName(int index)
    {
        switch (index)
        {
            case 0: return "Nose";
            case 1: return "LeftEyeInner";
            case 2: return "LeftEye";
            case 3: return "LeftEyeOuter";
            case 4: return "RightEyeInner";
            case 5: return "RightEye";
            case 6: return "RightEyeOuter";
            case 7: return "LeftEar";
            case 8: return "RightEar";
            case 9: return "MouthLeft";
            case 10: return "MouthRight";
            case 11: return "LeftShoulder";
            case 12: return "RightShoulder";
            case 13: return "LeftElbow";
            case 14: return "RightElbow";
            case 15: return "LeftWrist";
            case 16: return "RightWrist";
            case 17: return "LeftPinky";
            case 18: return "RightPinky";
            case 19: return "LeftIndex";
            case 20: return "RightIndex";
            case 21: return "LeftThumb";
            case 22: return "RightThumb";
            case 23: return "LeftHip";
            case 24: return "RightHip";
            case 25: return "LeftKnee";
            case 26: return "RightKnee";
            case 27: return "LeftAnkle";
            case 28: return "RightAnkle";
            case 29: return "LeftHeel";
            case 30: return "RightHeel";
            case 31: return "LeftFootIndex";
            case 32: return "RightFootIndex";
            default: return "UnknownLandmark";
        }
    }
}
