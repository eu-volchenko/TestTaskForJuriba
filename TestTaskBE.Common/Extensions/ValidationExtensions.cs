using System;

namespace TestTaskBE.Common.Extensions
{
    public static class ValidationExtensions
    {
        public static void ThrowIfDefault<T>(this T instance, string argumentName) where T : struct
        {
            if (instance.Equals(default(T)))
            {
                throw new ArgumentNullException(argumentName);
            }
        }

        public static void ThrowIfNullOrWhiteSpaceOrEmpty(this string instance, string argumentName)
        {
            if (string.IsNullOrWhiteSpace(instance) || string.IsNullOrEmpty(instance))
            {
                throw new ArgumentNullException(argumentName);
            }
        }

        public static void ThrowIfNull<T>(this T instance, string argumentName) where T : class
        {
            if (instance == null)
            {
                throw new ArgumentNullException(argumentName);
            }
        }
    }
}
