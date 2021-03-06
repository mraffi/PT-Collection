﻿using UnityEngine;

namespace PTCollection.EndlessRunner
{
    public class WorldRandomizer : MonoBehaviour
    {
        [SerializeField] private int worldSeed = 13;

        public int WorldSeed => worldSeed;

        private System.Random random;

        public float Value => (float)random.NextDouble();

        private void Awake() => random = new System.Random(worldSeed);

        public float Range(float min, float max) => (min + Value * (max - min));
    }
}
