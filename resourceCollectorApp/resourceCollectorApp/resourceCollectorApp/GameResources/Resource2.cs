namespace resourceCollectorApp.GameResources
{
    public class Resource2
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
        public double resource2ToRocket { get; set; }
        public double resource2Needed { get; set; }
        public double perSecond1 { get; set; }
        public double perSecond2 { get; set; }
        public double perSecond3 { get; set; }
        public double perSecond1UpgradeCost { get; set; }
        public double perSecond2UpgradeCost { get; set; }
        public double perSecond3UpgradeCost { get; set; }
        public double increasePerSecond1UpgradeCount { get; set; }
        public double increasePerSecond2UpgradeCount { get; set; }
        public double increasePerSecond3UpgradeCount { get; set; }


        public Resource2(double perClick, double perSecond, double count, double perClickUpgradeCost,
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
            resource2ToRocket = 0;
            resource2Needed = 500000000;
            perSecond1 = 5;
            perSecond2 = 10;
            perSecond3 = 15;
            perSecond1UpgradeCost = 350;
            perSecond2UpgradeCost = 650;
            perSecond3UpgradeCost = 950;
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
                PerSecondUpgrade1Cost *= 1.5;
                PerSecondUpgrade1Count++;
            }
        }

        public void IncreasePerSecond2()
        {
            if (Count >= PerSecondUpgrade2Cost)
            {
                Count -= PerSecondUpgrade2Cost;
                PerSecond += perSecond2;
                PerSecondUpgrade2Cost *= 1.75;
                PerSecondUpgrade2Count++;
            }
        }

        public void IncreasePerSecond3()
        {
            if (Count >= PerSecondUpgrade3Cost)
            {
                Count -= PerSecondUpgrade3Cost;
                PerSecond += perSecond3;
                PerSecondUpgrade3Cost *= 2;
                PerSecondUpgrade3Count++;
            }
        }
        public void ContributeToRocket()
        {
            if (resource2ToRocket >= resource2Needed)
            {
                return;
            }

            double remainingNeeded = resource2Needed - resource2ToRocket;

            if (Count >= remainingNeeded)
            {
                resource2ToRocket += remainingNeeded;
                Count -= remainingNeeded;
            }
            else
            {
                resource2ToRocket += Count;
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
