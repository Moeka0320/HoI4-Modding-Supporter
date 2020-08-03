namespace HoI4_Modding_Supporter
{
    // 変数専用クラス
    class Variable
    {
        // Application Settings
        private static string hoi4dir;
        public string Hoi4dir
        {
            set { hoi4dir = value; }
            get { return hoi4dir; }
        }

        private static string moddir;
        public string Moddir
        {
            set { moddir = value; }
            get { return moddir; }
        }

        // Main
        private static string countryTag;
        public string CountryTag
        {
            set { countryTag = value; }
            get { return countryTag; }
        }

        private static string countryName;
        public string CountryName
        {
            set { countryName = value; }
            get { return countryName; }
        } 

        private static string n_ViewName;
        public string N_ViewName
        {
            set { n_ViewName = value; }
            get { return n_ViewName; }
        }

        private static string n_EventViewName;
        public string N_EventViewName
        {
            set { n_EventViewName = value; }
            get { return n_EventViewName; }
        }

        private static string n_AliasName;
        public string N_AliasName
        {
            set { n_AliasName = value; }
            get { return n_AliasName; }
        }

        private static string d_ViewName;
        public string D_ViewName
        {
            set { d_ViewName = value; }
            get { return d_ViewName; }
        }

        private static string d_EventViewName;
        public string D_EventViewName
        {
            set { d_EventViewName = value; }
            get { return d_EventViewName; }
        }

        private static string d_AliasName;
        public string D_AliasName
        {
            set { d_AliasName = value; }
            get { return d_AliasName; }
        }

        private static string f_ViewName;
        public string F_ViewName
        {
            set { f_ViewName = value; }
            get { return f_ViewName; }
        }

        private static string f_EventViewName;
        public string F_EventViewName
        {
            set { f_EventViewName = value; }
            get { return f_EventViewName; }
        }

        private static string f_AliasName;
        public string F_AliasName
        {
            set { f_AliasName = value; }
            get { return f_AliasName; }
        }

        private static string c_ViewName;
        public string C_ViewName
        {
            set { c_ViewName = value; }
            get { return c_ViewName; }
        }

        private static string c_EventViewName;
        public string C_EventViewName
        {
            set { c_EventViewName = value; }
            get { return c_EventViewName; }
        }

        private static string c_AliasName;
        public string C_AliasName
        {
            set { c_AliasName = value; }
            get { return c_AliasName; }
        }

        private static string n_FlagBig;
        public string N_FlagBig
        {
            set { n_FlagBig = value; }
            get { return n_FlagBig; }
        }

        private static string n_FlagMed;
        public string N_FlagMed
        {
            set { n_FlagMed = value; }
            get { return n_FlagMed; }
        }

        private static string n_FlagSma;
        public string N_FlagSma
        {
            set { n_FlagSma = value; }
            get { return n_FlagSma; }
        }

        private static string d_FlagBig;
        public string D_FlagBig
        {
            set { d_FlagBig = value; }
            get { return d_FlagBig; }
        }

        private static string d_FlagMed;
        public string D_FlagMed
        {
            set { d_FlagMed = value; }
            get { return d_FlagMed; }
        }

        private static string d_FlagSma;
        public string D_FlagSma
        {
            set { d_FlagSma = value; }
            get { return d_FlagSma; }
        }

        private static string f_FlagBig;
        public string F_FlagBig
        {
            set { f_FlagBig = value; }
            get { return f_FlagBig; }
        }

        private static string f_FlagMed;
        public string F_FlagMed
        {
            set { f_FlagMed = value; }
            get { return f_FlagMed; }
        }

        private static string f_FlagSma;
        public string F_FlagSma
        {
            set { f_FlagSma = value; }
            get { return f_FlagSma; }
        }

        private static string c_FlagBig;
        public string C_FlagBig
        {
            set { c_FlagBig = value; }
            get { return c_FlagBig; }
        }

        private static string c_FlagMed;
        public string C_FlagMed
        {
            set { c_FlagMed = value; }
            get { return c_FlagMed; }
        }

        private static string c_FlagSma;
        public string C_FlagSma
        {
            set { c_FlagSma = value; }
            get { return c_FlagSma; }
        }

        private static string n_PartyAliasName;
        public string N_PartyAliasName
        {
            set { n_PartyAliasName = value; }
            get { return n_PartyAliasName; }
        }

        private static string n_PartyFullName;
        public string N_PartyFullName
        {
            set { n_PartyFullName = value; }
            get { return n_PartyFullName; }
        }

        private static string d_PartyAliasName;
        public string D_PartyAliasName
        {
            set { d_PartyAliasName = value; }
            get { return d_PartyAliasName; }
        }

        private static string d_PartyFullName;
        public string D_PartyFullName
        {
            set { d_PartyFullName = value; }
            get { return d_PartyFullName; }
        }

        private static string f_PartyAliasName;
        public string F_PartyAliasName
        {
            set { f_PartyAliasName = value; }
            get { return f_PartyAliasName; }
        }

        private static string f_PartyFullName;
        public string F_PartyFullName
        {
            set { f_PartyFullName = value; }
            get { return f_PartyFullName; }
        }

        private static string c_PartyAliasName;
        public string C_PartyAliasName
        {
            set { c_PartyAliasName = value; }
            get { return c_PartyAliasName; }
        }

        private static string c_PartyFullName;
        public string C_PartyFullName
        {
            set { c_PartyFullName = value; }
            get { return c_PartyFullName; }
        }

        private static int colorR;
        public int ColorR
        {
            set { colorR = value; }
            get { return colorR; }
        }

        private static int colorG;
        public int ColorG
        {
            set { colorG = value; }
            get { return colorG; }
        }

        private static int colorB;
        public int ColorB
        {
            set { colorB = value; }
            get { return colorB; }
        }

        private static string graphicalCulture;
        public string GraphicalCulture
        {
            set { graphicalCulture = value; }
            get { return graphicalCulture; }
        }

        private static string graphicalCulture2d;
        public string GraphicalCulture2d
        {
            set { graphicalCulture2d = value; }
            get { return graphicalCulture2d; }
        }

        private static int stateIDWithCapital;
        public int StateIDWithCapital
        {
            set { stateIDWithCapital = value; }
            get { return stateIDWithCapital; }
        }

        private static int studySlot;
        public int StudySlot
        {
            set { studySlot = value; }
            get { return studySlot; }
        }

        private static double stability;
        public double Stability
        {
            set { stability = value; }
            get { return stability; }
        }

        private static double warCoop;
        public double WarCoop
        {
            set { warCoop = value; }
            get { return warCoop; }
        }

        private static int politicalPower;
        public int PoliticalPower
        {
            set { politicalPower = value; }
            get { return politicalPower; }
        }

        private static int transportShip;
        public int TransportShip
        {
            set { transportShip = value; }
            get { return transportShip; }
        }

        private static bool dependentCountry;
        public bool DependentCountry
        {
            set { dependentCountry = value; }
            get { return dependentCountry; }
        }

        private static string sovereignCountryTag;
        public string SovereignCountryTag
        {
            set { sovereignCountryTag = value; }
            get { return sovereignCountryTag; }
        }

        private static double n_Popularity;
        public double N_Popularity
        {
            set { n_Popularity = value; }
            get { return n_Popularity; }
        }

        private static double d_Popularity;
        public double D_Popularity
        {
            set { d_Popularity = value; }
            get { return d_Popularity; }
        }

        private static double f_Popularity;
        public double F_Popularity
        {
            set { f_Popularity = value; }
            get { return f_Popularity; }
        }

        private static double c_Popularity;
        public double C_Popularity
        {
            set { c_Popularity = value; }
            get { return c_Popularity; }
        }

        private static string startIdeology;
        public string StartIdeology
        {
            set { startIdeology = value; }
            get { return startIdeology; }
        }

        private static int lastElectionYYYY;
        public int LastElectionYYYY
        {
            set { lastElectionYYYY = value; }
            get { return lastElectionYYYY; }
        }

        private static int lastElectionM;
        public int LastElectionM
        {
            set { lastElectionM = value; }
            get { return lastElectionM; }
        }

        private static int lastElectionD;
        public int LastElectionD
        {
            set { lastElectionD = value; }
            get { return lastElectionD; }
        }

        private static string lastElection;
        public string LastElection
        {
            set { lastElection = value; }
            get { return lastElection; }
        }

        private static int electionFrequency;
        public int ElectionFrequency
        {
            set { electionFrequency = value; }
            get { return electionFrequency; }
        }

        private static bool noElection;
        public bool NoElection
        {
            set { noElection = value; }
            get { return noElection; }
        }

        private static string modName;
        public string ModName
        {
            set { modName = value; }
            get { return modName; }
        }

        // NationalLeaderSettings
        private static bool customLeaderEnabled;
        public bool CustomLeaderEnabled
        {
            set { customLeaderEnabled = value; }
            get { return customLeaderEnabled; }
        }

        private static string leaderName;
        public string LeaderName
        {
            set { leaderName = value; }
            get { return leaderName; }
        }

        private static string leaderDesc;
        public string LeaderDesc
        {
            set { leaderDesc = value; }
            get { return leaderDesc; }
        }

        private static string leaderPicturePath;
        public string LeaderPicturePath
        {
            set { leaderPicturePath = value; }
            get { return leaderPicturePath; }
        }

        private static string leaderPictureName;
        public string LeaderPictureName
        {
            set { leaderPictureName = value; }
            get { return leaderPictureName; }
        }

        private static string leaderIdeology;
        public string LeaderIdeology
        {
            set { leaderIdeology = value; }
            get { return leaderIdeology; }
        }

        private static string willNotAppear;
        public string WillNotAppear
        {
            set { willNotAppear = value; }
            get { return willNotAppear; }
        }


    }
}
