﻿using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace ODataOpenIssuesDashboard.StackOverflowAPI
{
    public class CStylePropertyNameContractResolver : CamelCasePropertyNamesContractResolver
    {

        protected override string ResolvePropertyName(string propertyName)
        {
            // converts "CStylePropertyName" to "c_style_property_name"
            propertyName = base.ResolvePropertyName(propertyName); // first turn to camelCase
            StringBuilder sb = new StringBuilder();
            foreach (var ch in propertyName)
            {
                if (char.IsUpper(ch))
                {
                    sb.Append("_");
                    sb.Append(char.ToLower(ch));
                }
                else
                {
                    sb.Append(ch);
                }
            }

            return sb.ToString();
        }

    }
}