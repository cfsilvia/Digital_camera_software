using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace NAudio.MediaFoundation
{
    /// <summary>
    /// Interop definitions for MediaFoundation
    /// thanks to Lucian Wischik for the initial work on many of these definitions (also various interfaces)
    /// n.b. the goal is to make as much of this internal as possible, and provide
    /// better .NET APIs using the MediaFoundationApi class instead
    /// </summary>
    public static class MediaFoundationInterop
    {
        /// <summary>
        /// Initializes Microsoft Media Foundation.
        /// </summary>
        [DllImport("mfplat.dll", ExactSpelling = true, PreserveSig = false)]
        public static extern void MFStartup(int version, int dwFlags = 0);

        /// <summary>
        /// Shuts down the Microsoft Media Foundation platform
        /// </summary>
        [DllImport("mfplat.dll", ExactSpelling = true, PreserveSig = false)]
        public static extern void MFShutdown();

        /// <summary>
        /// Creates an empty media type.
        /// </summary>
        [DllImport("mfplat.dll", ExactSpelling = true, PreserveSig = false)]
        internal static extern void MFCreateMediaType(out IMFMediaType ppMFType);
        
        /// <summary>
        /// Creates the sink writer from a URL or byte stream.
        /// </summary>
        [DllImport("mfreadwrite.dll", ExactSpelling = true, PreserveSig = false)]
        public static extern void MFCreateSinkWriterFromURL([In, MarshalAs(UnmanagedType.LPWStr)] string pwszOutputURL,
                                                           [In] IMFByteStream pByteStream, [In] IMFAttributes pAttributes, [Out] out IMFSinkWriter ppSinkWriter);

        /// <summary>
        /// Creates an empty media sample.
        /// </summary>
        [DllImport("mfplat.dll", ExactSpelling = true, PreserveSig = false)]
        internal static extern void MFCreateSample([Out] out IMFSample ppIMFSample);

        /// <summary>
        /// Allocates system memory and creates a media buffer to manage it.
        /// </summary>
        [DllImport("mfplat.dll", ExactSpelling = true, PreserveSig = false)]
        internal static extern void MFCreateMemoryBuffer(
            int cbMaxLength, [Out] out IMFMediaBuffer ppBuffer);

        /// <summary>
        /// Creates an empty attribute store. 
        /// </summary>
        [DllImport("mfplat.dll", ExactSpelling = true, PreserveSig = false)]
        internal static extern void MFCreateAttributes(
            [Out, MarshalAs(UnmanagedType.Interface)] out IMFAttributes ppMFAttributes,
            [In] int cInitialSize);

        /// <summary>
        /// All streams
        /// </summary>
        public const int MF_SOURCE_READER_ALL_STREAMS = unchecked((int)0xFFFFFFFE);
        /// <summary>
        /// First audio stream
        /// </summary>
        public const int MF_SOURCE_READER_FIRST_AUDIO_STREAM = unchecked((int)0xFFFFFFFD);
        /// <summary>
        /// First video stream
        /// </summary>
        public const int MF_SOURCE_READER_FIRST_VIDEO_STREAM = unchecked((int)0xFFFFFFFC);
        /// <summary>
        /// Media source
        /// </summary>
        public const int MF_SOURCE_READER_MEDIASOURCE = unchecked((int)0xFFFFFFFF);
        /// <summary>
        /// Media Foundation SDK Version
        /// </summary>
        public const int MF_SDK_VERSION = 0x2;
        /// <summary>
        /// Media Foundation API Version
        /// </summary>
        public const int MF_API_VERSION = 0x70;
        /// <summary>
        /// Media Foundation Version
        /// </summary>
        public const int MF_VERSION = (MF_SDK_VERSION << 16) | MF_API_VERSION;
        

    }
}
