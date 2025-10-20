// --------------- Copyright (C) RC --------------- //
// STRONG is what happens when you run out of weak! //

using System;

namespace RCFramework.Tools
{
    public static class StringExtensions
    {
        public static bool IsNullOrWhiteSpace(this string self)
        {
            return string.IsNullOrWhiteSpace(self);
        }

        public static bool IsNullOrEmpty(this string self)
        {
            return string.IsNullOrEmpty(self);
        }

        public static bool IsBlank(this string self)
        {
            return self.IsNullOrWhiteSpace() || self.IsNullOrEmpty();
        }

        public static string OrEmpty(this string self)
        {
            return self ?? string.Empty;
        }

        public static string Shorten(this string self, int maxLength)
        {
            if (self.IsBlank()) 
                return self;
            
            return self.Length <= maxLength ? self : self.Substring(0, maxLength);
        }

        public static string Slice(this string self, int startIndex, int endIndex)
        {
            if (self.IsBlank())
            {
                throw new ArgumentNullException(nameof(self), "Value cannot be null or empty.");
            }

            if (startIndex < 0 || startIndex > self.Length - 1)
            {
                throw new ArgumentOutOfRangeException(nameof(startIndex));
            }

            endIndex = endIndex < 0 ? self.Length + endIndex : endIndex;

            if (endIndex < 0 || endIndex < startIndex || endIndex > self.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(endIndex));
            }

            return self.Substring(startIndex, endIndex - startIndex);
        }

        public static int ComputeFNV1aHash(this string self)
        {
            uint hash = 2166136261;

            foreach (char c in self)
            {
                hash = (hash ^ c) * 16777619;
            }
            
            return unchecked((int)hash);
        }
    }
}