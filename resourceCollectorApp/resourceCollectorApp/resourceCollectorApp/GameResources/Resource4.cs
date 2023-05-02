namespace resourceCollectorApp.GameResources
{
    public class Resource4
    {

        public double PerClick { get; set; }
        public double PerSecond { get; set; }
        public double Count { get; set; }
        public double PerClickUpgradeCost { get; set; }
        public double PerSecondUpgrade1Cost { get; set; }
        public double PerSecondUpgrade2Cost { get; set; }
        public double PerSecondUpgrade3Cost { get; set; }
        public int PerSecondUpgrade1Count { get; set; }
        public int PerSecondUpgrade2Count { get; set; }
        public int PerSecondUpgrade3Count { get; set; }
        public int PerClickUpgradeCount { get; set; }
        public double resource4ToRocket { get; set; }
        public double resource4Needed { get; set; }
        public double perSecond1 { get; set; }
        public double perSecond2 { get; set; }
        public double perSecond3 { get; set; }
        public double perSecond1UpgradeCost { get; set; }
        public double perSecond2UpgradeCost { get; set; }
        public double perSecond3UpgradeCost { get; set; }
        public double increasePerSecond1UpgradeCount { get; set; }
        public double increasePerSecond2UpgradeCount { get; set; }
        public double increasePerSecond3UpgradeCount { get; set; }

        public Resource4(double perClick, double perSecond, double count, double perClickUpgradeCost,
            double perSecondUpgrade1Cost, double perSecondUpgrade2Cost, double perSecondUpgrade3Cost)
        {
            PerClick = perClick;
            PerSecond = perSecond;
            Count = count;
            PerClickUpgradeCost = perClickUpgradeCost;
            PerSecondUpgrade1Cost = perSecondUpgrade1Cost;
            PerSecondUpgrade2Cost = perSecondUpgrade2Cost;
            PerSecondUpgrade3Cost = perSecondUpgrade3Cost;
            PerSecondUpgrade1Count = 0;
            PerSecondUpgrade2Count = 0;
            PerSecondUpgrade3Count = 0;
            PerClickUpgradeCount = 0;
            resource4ToRocket = 0;
            resource4Needed = 100000;
            perSecond1 = 1;
            perSecond2 = 2;
            perSecond3 = 3;
            perSecond1UpgradeCost = 1250;
            perSecond2UpgradeCost = 2450;
            perSecond3UpgradeCost = 3650;
            increasePerSecond1UpgradeCount = 0;
            increasePerSecond2UpgradeCount = 0;
            increasePerSecond3UpgradeCount = 0;
        }

        public void IncreasePerClick()
        {
            if (Count >= PerClickUpgradeCost)
            {
                Count -= PerClickUpgradeCost;
                PerClick *= 2;
                PerClickUpgradeCost *= 2;
                PerClickUpgradeCount++;
            }
        }

        public void IncreasePerSecond1()
        {
            if (Count >= PerSecondUpgrade1Cost)
            {
                Count -= PerSecondUpgrade1Cost;
                PerSecond += perSecond1;
                PerSecondUpgrade1Cost *= 2;
                PerSecondUpgrade1Count++;
            }
        }

        public void IncreasePerSecond2()
        {
            if (Count >= PerSecondUpgrade2Cost)
            {
                Count -= PerSecondUpgrade2Cost;
                PerSecond += perSecond2;
                PerSecondUpgrade2Cost *= 2.25;
                PerSecondUpgrade2Count++;
            }
        }

        public void IncreasePerSecond3()
        {
            if (Count >= PerSecondUpgrade3Cost)
            {
                Count -= PerSecondUpgrade3Cost;
                PerSecond += perSecond3;
                PerSecondUpgrade3Cost *= 2.5;
                PerSecondUpgrade3Count++;
            }
        }
        public void ContributeToRocket()
        {
            if (resource4ToRocket >= resource4Needed)
            {
                // gold needed has already been met, do nothing
                return;
            }

            double remainingNeeded = resource4Needed - resource4ToRocket;

            if (Count >= remainingNeeded)
            {
                resource4ToRocket += remainingNeeded;
                Count -= remainingNeeded;
            }
            else
            {
                resource4ToRocket += Count;
                Count = 0;
            }
        }
        public void IncreasePerSecond1Upgrade()
        {
            if (Count >= perSecond1UpgradeCost)
            {
                for (int i = 0; i < PerSecondUpgrade1Count; i++)
                {
                    PerSecond += perSecond1;
                }
                perSecond1 *= 2;
                Count -= perSecond1UpgradeCost;
                perSecond1UpgradeCost *= 2;
                increasePerSecond1UpgradeCount++;
            }
        }
        public void IncreasePerSecond2Upgrade()
        {
            if (Count >= perSecond2UpgradeCost)
            {
                for (int i = 0; i < PerSecondUpgrade2Count; i++)
                {
                    PerSecond += perSecond2;
                }
                perSecond2 *= 2;
                Count -= perSecond2UpgradeCost;
                perSecond2UpgradeCost *= 2;
                increasePerSecond2UpgradeCount++;
            }
        }
        public void IncreasePerSecond3Upgrade()
        {
            if (Count >= perSecond3UpgradeCost)
            {
                for (int i = 0; i < PerSecondUpgrade3Count; i++)
                {
                    PerSecond += perSecond3;
                }
                perSecond3 *= 2;
                Count -= perSecond3UpgradeCost;
                perSecond3UpgradeCost *= 2;
                increasePerSecond3UpgradeCount++;
            }
        }
    }
}

