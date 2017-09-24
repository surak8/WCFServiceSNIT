using System;
using System.Collections.Generic;

namespace WCFServiceSNIT {
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class SNITService : ISNITService {
        #region fields
        static int _cinstance = 0;
        readonly int _instance = 0;
        //readonly IDictionary<int, SNITLocation> _locations = new Dictionary<int, SNITLocation>();
        //bool _available;
        //readonly string _serverName;
        //readonly string _databaseName;
        //readonly IDictionary<SNITErrorCode, string> _errorMap = new Dictionary<SNITErrorCode, string>();
        #endregion

        #region ctor
        public SNITService() {
            _instance = ++_cinstance;
           
        }
        #endregion ctor

        public bool isAvailable() { return SNITDataSingleton.shared.available ; }
        public void setAvailable(bool yesNo) {   SNITDataSingleton.shared.setAvailable(yesNo ); }

        public SNITErrorCode addSerialNumber(string serialNumber, int locationId) {
            return SNITDataSingleton.shared.addSerialNumber(serialNumber, locationId);
        }

        public string errorDescription(SNITErrorCode errorCode) {
            return SNITDataSingleton.shared.errorDescription(errorCode);
        
        }

        public int addLocation(string locationName, string subLocationName, string empName1, string empName2) {
            return SNITDataSingleton.shared.addLocation(locationName, subLocationName, empName1, empName2);
           
        }

        public void clearSerialNumbers() {
            SNITDataSingleton.shared.clearSerialNumbers();
        }

        public void clearLocations() {
            SNITDataSingleton.shared.clearLocations();
        }

        //public string[] locationNames() {
        //    return SNITDataSingleton.shared.locationNames();
        //}
        public int[] locationIds() { return SNITDataSingleton.shared.locationIds(); }

        public string dataForLocation(int locId,out string subLocationName, out string empName1, out string empName2) {
            return SNITDataSingleton.shared.dataForLocation(locId,out subLocationName, out empName1, out empName2);
        }

        public string serverName() { return SNITDataSingleton.shared.serverName; }

        public string databaseName() { return SNITDataSingleton.shared.databaseName; }

        public SNInfo[] serialNumbers() {
            return SNITDataSingleton.shared.serialNumbers();
        }
    }
}