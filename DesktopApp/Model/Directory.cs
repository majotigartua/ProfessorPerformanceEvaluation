﻿using Newtonsoft.Json;

namespace ProfessorPerformanceEvaluation.Model
{
    public class Directory
    {
        [JsonProperty("idDirectory")]
        public int IdDirectory { get; set; }
        [JsonProperty("idFaculty")]
        public int IdFaculty { get; set; }
        [JsonProperty("idProfessor")]
        public int IdProfessor { get; set; }
    }
}