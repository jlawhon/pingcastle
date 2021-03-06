﻿//
// Copyright (c) Ping Castle. All rights reserved.
// https://www.pingcastle.com
//
// Licensed under the Non-Profit OSL. See LICENSE file in the project root for full license information.
//
using System;
using System.Collections.Generic;
using System.Text;
using PingCastle.Rules;

namespace PingCastle.Healthcheck.Rules
{
	[RuleModel("A-NullSession", RiskRuleCategory.Anomalies, RiskModelCategory.Reconnaissance)]
	[RuleComputation(RuleComputationType.TriggerOnPresence, 10)]
	[RuleBSI("M 2.412")]
    public class HeatlcheckRuleAnomalyNullSession : RuleBase<HealthcheckData>
    {
		protected override int? AnalyzeDataNew(HealthcheckData healthcheckData)
        {
            if (healthcheckData.DomainControllers != null)
            {
                foreach (var DC in healthcheckData.DomainControllers)
                {
					if (DC.HasNullSession)
					{
						AddRawDetail(DC.DCName);
					}
                }
            }
            return null;
        }
    }
}
