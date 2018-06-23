namespace Ditch.Golos.Helpers
{
    public static class VersionHelper
    {
        public static int ToInteger(string version)
        {
            if (string.IsNullOrWhiteSpace(version))
                return -1;

            var mhr = version.Split('.');

            int major, hardfork, release;
            if (mhr.Length != 3 || !int.TryParse(mhr[0], out major) || !int.TryParse(mhr[1], out hardfork) || !int.TryParse(mhr[2], out release))
                return -1;

            var ver = (0 | major) << 8;
            ver = (ver | hardfork) << 16;
            ver = ver | release;
            return ver;
        }

        public static int GetMajor(int version)
        {
            return (version >> 24) & 0x000000FF;
        }

        public static int GetHardfork(int version)
        {
            return (version >> 16) & 0x000000FF;
        }

        public static int GetRelease(int version)
        {
            return version & 0x0000FFFF;
        }
    }
}
