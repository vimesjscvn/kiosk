// ***********************************************************************
// Assembly         : CS.VM
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="TempPatientPostModel.cs" company="CS.VM">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Collections.Generic;
using Newtonsoft.Json;

namespace CS.VM.PostModels
{
    public class SurveyAnswer
    {
        [JsonProperty("question_id")] public string QuestionId { get; set; }

        [JsonProperty("answer")] public string Answer { get; set; }
    }

    public class SurveyPostModel
    {
        [JsonProperty("ip")] public string Ip { get; set; }

        [JsonProperty("answer")] public List<SurveyAnswer> Answer { get; set; }
    }
}