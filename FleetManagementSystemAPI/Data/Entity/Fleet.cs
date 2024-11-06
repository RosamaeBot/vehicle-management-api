using System;
using System.Collections.Generic;

namespace FleetManagementAPI.Data.Entity
{
    public class Fleet : EntityBase
    {
        public long Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public double Price { get; set; }
        public FleetType FleetType { get; set; }
    }

    public class FleetType
    {

        public int Id { get; set; }
        public string FleetName { get; set; }
    }
}

