﻿using NexusGroup.Admin.Data.Models;
using NexusGroup.Admin.Data.Response;

namespace NexusGroup.Admin.Data.ApiResponse
{
    public class APIR_Candidate
    {
        public class All : _CoreApiR.ApiResponse
        {
            IEnumerable<CandidateResponse> Data { get; set; }
        }
        public class One : _CoreApiR.ApiResponse
        {
            CandidatesModel Data { get; set; }
        }
    }
}
