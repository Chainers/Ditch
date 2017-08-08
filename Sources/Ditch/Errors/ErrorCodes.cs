namespace Ditch.Errors
{
    public enum ErrorCodes
    {
        Unknown,
        /// <summary>
        /// Connection timed out.
        /// A connection attempt failed because the connected party did not properly respond after a period of time, or the established connection failed because the connected host has failed to respond.
        /// </summary>
        ConnectionTimeoutError = 10060,

        /// <summary>
        /// The request has timed out.
        /// </summary>
        ResponseTimeoutError = 12002
    }
}