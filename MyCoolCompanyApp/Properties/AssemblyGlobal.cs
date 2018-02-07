namespace UXDivers.Artina.Player
{
	public static class AssemblyGlobal
	{
		public const string Company = "UXDivers";

		public const string ProductLine = "Gorilla Player";

		public const string Year = "2015";

		public const string VersionBase = "0.9";

		public const string AssemblyVersion = VersionBase + ".0.0";

		public const string Copyright = Company + " - " + Year;

		#if DEBUG
		public const string Configuration = "Debug";
		#elif RELEASE
		public const string Configuration = "Release";
		#else
		public const string Configuration = "Unkown";
		#endif
	}	
}