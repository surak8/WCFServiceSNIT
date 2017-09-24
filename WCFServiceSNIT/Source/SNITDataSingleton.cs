using System;
using System.Collections.Generic;

namespace WCFServiceSNIT {
    internal class SNITDataSingleton {

        static SNITDataSingleton _shared = new SNITDataSingleton();
        readonly IDictionary<int, SNITLocation> _locations = new Dictionary<int, SNITLocation>();
        readonly IDictionary<SNITErrorCode, string> _errorMap = new Dictionary<SNITErrorCode, string>();
        readonly IDictionary<string, int> _snMap = new Dictionary<string, int>();

        #region properties
        internal static SNITDataSingleton shared { get { return _shared; } }
        internal bool available { get; private set; }
        internal string serverName { get; set; }
        internal string databaseName { get; set; }
        internal void setAvailable(bool yesNo) { available = yesNo; }
        #endregion

        #region ctor
        SNITDataSingleton() {
            Type aType = typeof(SNITErrorCode);

            foreach (string anEnumName in Enum.GetNames(aType))
                _errorMap.Add(
                    (SNITErrorCode) Enum.Parse(aType, anEnumName),
                    anEnumName);
            serverName = "colt-sql";
            databaseName = "checkweigh_data_dev";
            SNITLocation aloc = new SNITLocation(0, "loc1", "subloc1", "rik", "seb");

            _locations.Add(aloc.locationId, aloc);
        }
        #endregion


        internal SNITErrorCode addSerialNumber(string serialNumber, int locationId) {
            if (_snMap.ContainsKey(serialNumber))
                return SNITErrorCode.AlreadyExists;
            _snMap.Add(serialNumber, locationId);
            return SNITErrorCode.Success;
        }

        internal string errorDescription(SNITErrorCode errorCode) {
            if (_errorMap.ContainsKey(errorCode))
                return _errorMap[errorCode];
            return string.Empty;
        }


        internal int addLocation(string locationName, string subLocationName, string empName1, string empName2) {
            int locNum;
            SNITLocation tmp = new WCFServiceSNIT.SNITLocation(-1, locationName, subLocationName, empName1, empName2);
            IEnumerator<SNITLocation> ie = _locations.Values.GetEnumerator();

            while (ie.MoveNext()) {
                if (ie.Current.CompareTo(tmp) == 0)
                    //return ie.Current.locationId;
                    return -1; // already exists
            }
            tmp.setLocId(locNum = _locations.Count);
            _locations.Add(locNum, tmp);
            return locNum;
        }

        internal   SNInfo[] serialNumbers() {
            List<SNInfo> ret = new List<SNInfo>();

            foreach (var v in this._snMap.Keys)
                ret.Add(new SNInfo(v, _snMap[v]));
            return ret.ToArray();
        }

        internal string dataForLocation(int locId, out string subLocationName, out string empName1, out string empName2) {
            SNITLocation l;

            subLocationName = empName1 = empName2 = null;
            if (_locations.ContainsKey(locId)) {
                l = _locations[locId];
                subLocationName = l.subLocation;
                empName1 = l.employee1;
                empName2 = l.employee2;
                return l.location;
            }
            return null;
        }

        //internal string[] locationNames() {
        //    List<string> tmp = new List<string>();
        //    SNITLocation snitl;

        //    foreach (int locNum in _locations.Keys) {
        //        snitl = _locations[locNum];
        //        tmp.Add(snitl.location + "#" + snitl.subLocation);
        //    }
        //    return tmp.ToArray();
        //}

        internal   int[] locationIds() {
            List<int> tmp = new List<int>();
            SNITLocation snitl;

            foreach (int locNum in _locations.Keys) {
                snitl = _locations[locNum];
                tmp.Add(snitl.locationId);
            }
            return tmp.ToArray();
        }

        internal void clearLocations() {
            _locations.Clear();
        }

        internal void clearSerialNumbers() {
            _snMap.Clear();
        }
    }
}