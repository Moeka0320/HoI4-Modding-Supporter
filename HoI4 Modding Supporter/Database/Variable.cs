namespace HoI4_Modding_Supporter.Database
{
    // 変数専用クラス
    class Variable
    {
        // Application Settings
        public string Hoi4dir { get; set; }

        public string Moddir { get; set; }

        // Main
        public string CountryTag { get; set; }

        public string CountryName { get; set; }

        public string N_ViewName { get; set; }

        public string N_EventViewName { get; set; }

        public string N_AliasName { get; set; }

        public string D_ViewName { get; set; }

        public string D_EventViewName { get; set; }

        public string D_AliasName { get; set; }

        public string F_ViewName { get; set; }

        public string F_EventViewName { get; set; }

        public string F_AliasName { get; set; }

        public string C_ViewName { get; set; }

        public string C_EventViewName { get; set; }

        public string C_AliasName { get; set; }

        public string N_FlagBig { get; set; }

        public string N_FlagMed { get; set; }

        public string N_FlagSma { get; set; }

        public string D_FlagBig { get; set; }

        public string D_FlagMed { get; set; }

        public string D_FlagSma { get; set; }

        public string F_FlagBig { get; set; }

        public string F_FlagMed { get; set; }

        public string F_FlagSma { get; set; }

        public string C_FlagBig { get; set; }

        public string C_FlagMed { get; set; }

        public string C_FlagSma { get; set; }

        public string N_PartyAliasName { get; set; }

        public string N_PartyFullName { get; set; }

        public string D_PartyAliasName { get; set; }

        public string D_PartyFullName { get; set; }

        public string F_PartyAliasName { get; set; }

        public string F_PartyFullName { get; set; }

        public string C_PartyAliasName { get; set; }

        public string C_PartyFullName { get; set; }

        public int ColorR { get; set; }

        public int ColorG { get; set; }

        public int ColorB { get; set; }

        public string GraphicalCulture { get; set; }

        public string GraphicalCulture2d { get; set; }

        public int StateIDWithCapital { get; set; }

        public int StudySlot { get; set; }

        public double Stability { get; set; }

        public double WarCoop { get; set; }

        public int PoliticalPower { get; set; }

        public int TransportShip { get; set; }

        public bool DependentCountry { get; set; }

        public string SovereignCountryTag { get; set; }

        public int N_Popularity { get; set; }

        public int D_Popularity { get; set; }

        public int F_Popularity { get; set; }

        public int C_Popularity { get; set; }

        public string StartIdeology { get; set; }

        public int LastElectionYYYY { get; set; }

        public int LastElectionM { get; set; }

        public int LastElectionD { get; set; }

        public string LastElection { get; set; }

        public int ElectionFrequency { get; set; }

        public bool NoElection { get; set; }

        public string ModName { get; set; }

        // NationalLeaderSettings
        public bool CustomLeaderEnabled { get; set; }

        public string LeaderName { get; set; }

        public string LeaderDesc { get; set; }

        public string LeaderPicturePath { get; set; }

        public string LeaderPictureName { get; set; }

        public string LeaderIdeology { get; set; }

        public string WillNotAppear { get; set; }

        // FactionSettings
        public bool FactionCreateEnabled { get; set; }

        public string FactionInternalName { get; set; }

        public string FactionName { get; set; }

        public string[] FactionParticipatingCountries { get; set; }

        // CustomIdeology (配列の順序は customIdeologiesInternalName / customIdeologiesName に準拠)
        /*
            [TABCOUNT - 1, 0] = viewNameTextBox.Text
            [TABCOUNT - 1, 1] = eventViewNameTextBox.Text
            [TABCOUNT - 1, 2] = aliasViewNameTextBox.Text
            [TABCOUNT - 1, 3] = bigFlagPathTextBox.Text
            [TABCOUNT - 1, 4] = mediumFlagPathTextBox.Text
            [TABCOUNT - 1, 5] = smallFlagPathTextBox.Text
            [TABCOUNT - 1, 6] = partyAliasNameTextBox.Text
            [TABCOUNT - 1, 7] = partyFullNameTextBox.Text 
        */

        public string[,] CustomIdeologiesSettings { get; set; }

        public int[] CustomIdeologiesPopularity { get; set; }
    }
}
