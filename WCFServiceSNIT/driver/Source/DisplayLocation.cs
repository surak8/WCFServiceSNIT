namespace NSDriver {
    class DisplayLocation {
        //private string emp1;
        //private string emp2;
        //private string locName;
        //private int nLocId;
        //private string sublocName;

        public DisplayLocation(int nLocId, string locName, string sublocName, string emp1, string emp2) {
            this.locId = nLocId;
            this.locationName = locName;
            this.sublocationName = sublocationName;
            this.scannerName = emp1;
            this.checkerName = emp2;
        }

        public int locId { get; private set; }
        public string locationName { get; private set; }
        public string sublocationName { get; private set; }
        public string scannerName { get; private set; }
        public string checkerName { get; private set; }

        public string displayLocation {
            get {
                return locId + " " + locationName;
            }
        }
    }
}