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
	[RuleModel("A-NoServicePolicy", RiskRuleCategory.Anomalies, RiskModelCategory.WeakPassword)]
	[RuleComputation(RuleComputationType.TriggerOnPresence, 0)]
    public class HeatlcheckRuleAnomalyServicePolicy : RuleBase<HealthcheckData>
    {
		protected override int? AnalyzeDataNew(HealthcheckData healthcheckData)
        {
            bool servicePolicy = false;
            foreach (GPPSecurityPolicy policy in healthcheckData.GPPPasswordPolicy)
            {
                foreach (GPPSecurityPolicyProperty property in policy.Properties)
                {
                    if (property.Property == "MinimumPasswordLength")
                    {
                        if (property.Value >= 20)
                        {
							servicePolicy = true;
							break;
                        }
                    }
                }
            }
            return (servicePolicy ? 0 : 1);
        }
    }
}
