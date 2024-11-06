using System;
using System.Collections.Generic;

namespace FleetManagementAPI.DTO.Response
{
    public class FleetQueryResponse
    {
        public long Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public double Price { get; set; }
    }
}
