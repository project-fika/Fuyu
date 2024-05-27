// Copyright (c) 2018-2020, Els_kom org.
// https://github.com/Elskom/
// All rights reserved.
// license: see LICENSE for more details.

namespace Elskom.Generic.Libs
{
    using System;
    using System.IO;

    /// <summary>
    /// Zlib Memory Packing failure error.
    /// </summary>
    [Serializable]
    internal sealed class NotPackableException : IOException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NotPackableException"/> class.
        /// </summary>
        internal NotPackableException()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NotPackableException"/> class.
        /// </summary>
        /// <param name="s">The error string.</param>
        internal NotPackableException(string s)
            : base(s)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NotPackableException"/> class.
        /// </summary>
        /// <param name="s">The error string.</param>
        /// <param name="ex">The Exception that caused this Exception.</param>
        internal NotPackableException(string s, Exception ex)
            : base(s, ex)
        {
        }
    }
}
