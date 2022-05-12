﻿using System.Collections.Generic;


namespace ET
{
	public static class RealmGateAddressHelper
	{
		public static StartSceneConfig GetGate(int zone)
		{
			List<StartSceneConfig> zoneGates = TablesHelp.Instance.Tables.StartSceneConfigCategory.Gates[zone];
			
			int n = RandomHelper.RandomNumber(0, zoneGates.Count);

			return zoneGates[n];
		}
	}
}
