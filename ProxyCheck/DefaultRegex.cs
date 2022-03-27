
using System.Text.RegularExpressions;


namespace ProxyCheck
{
    class DefaultRegex
    {
        public Regex REGEX = new Regex(@"\b(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\:[0-9]{1,5}\b");
    }
}