using System;

namespace FleetManagementAPI.Data.Entity
{
    public class Car : Fleet
    {
        public BodyType BodyType { get; set; }
        public int NumOfDoors { get; set; }
    }


    public class BodyType
    {

        public int Id { get; set; }
        public string BodyName { get; set; }
    }
}
