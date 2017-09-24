using System.ServiceModel;

namespace WCFServiceSNIT {
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface ISNITService {
        [OperationContract]
        bool isAvailable();

        [OperationContract]
        SNITErrorCode addSerialNumber(string serialNumber, int locationId);

        [OperationContract]
        SNInfo[] serialNumbers();

        [OperationContract]
        string errorDescription(SNITErrorCode errorCode);

        [OperationContract]
        int[] locationIds();

        [OperationContract]
        int addLocation(string locationName, string subLocationName, string empName1, string empName2);

        [OperationContract]
        void setAvailable(bool yesNo);

        [OperationContract]
        void clearSerialNumbers();

        [OperationContract]
        void clearLocations();

        //[OperationContract]
        //string[] locationNames();

        [OperationContract]
        string dataForLocation(int locCode, out string subLocationName, out string empName1, out string empName2);

        [OperationContract]
        string serverName();
        [OperationContract]
        string databaseName();
    }

    public class SNInfo {
        internal SNInfo(string anSN, int aLocId) { this.serialNumber = anSN; this.locationId = aLocId; }
        public string serialNumber { get; private set; }
        public int locationId { get; private set; }
    }
}