using System;

namespace WCFServiceSNIT {
    public class SNITLocation : IComparable<SNITLocation> {
        internal SNITLocation(int aLocId, string aLocation, string aSubLocation, string anEmp1, string anEmp2) {
            locationId = aLocId;
            this.location = aLocation;
            this.subLocation = aSubLocation;
            this.employee1 = anEmp1;
            this.employee2 = anEmp2;
        }

        internal void setDeleted(bool yn) {
            isDeleted = yn;
        }



        public int locationId { get; private set; }
        public string location { get; internal set; }
        public string subLocation { get; internal set; }
        public string employee1 { get; internal set; }
        public string employee2 { get; internal set; }
        public bool isDeleted { get; internal set; }

        public int CompareTo(SNITLocation other) {
            // compare location fields only.
            int rc;

            if ((rc = location.CompareTo(other.location)) == 0)
                if ((rc = subLocation.CompareTo(other.subLocation)) == 0)
                    //if ((rc = location.CompareTo(other.location)) == 0)
                    return 0;
            return rc;
        }

        internal void setLocId(int v) { locationId = v; }
    }
}