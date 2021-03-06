﻿using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PTCollection.TowerDefense
{
    public class TowerSlot : MonoBehaviour
    {
        public static event Action<Tower> BuildTower;

        [SerializeField] private List<GameObject> towerPrefabs = null;

        public static Tower SelectedTowerDummy { get; set; }

        private TowerCurrency currency;
        private Image image;

        private void Awake()
        {
            currency = FindObjectOfType<TowerCurrency>();
            image = GetComponentInChildren<Image>();
        }

        public void OnPointerEnter()
        {
            if (SelectedTowerDummy == null)
                return;

            SelectedTowerDummy.transform.position = transform.position;
        }

        public void OnPointerExit()
        {
            if (SelectedTowerDummy == null)
                return;

            SelectedTowerDummy.transform.localPosition = Vector3.zero;
        }

        public void OnPointerClick()
        {
            if (SelectedTowerDummy == null || SelectedTowerDummy.Cost > currency.TotalLights)
                return;

            SelectedTowerDummy.transform.localPosition = Vector3.zero;

            var towerObject = Instantiate(towerPrefabs.Find(x => x.name == SelectedTowerDummy.name), transform.parent);
            var towerComponent = towerObject.GetComponent<Tower>();

            towerObject.transform.position = transform.position;

            BuildTower?.Invoke(towerComponent);
            gameObject.SetActive(false);
        }
    }
}
