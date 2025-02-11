using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Runtime.InteropServices.ComTypes;

namespace NAudio.MediaFoundation
{
    /// <summary>
    /// Main interface for using Media Foundation with NAudio
    /// </summary>
    public static class MediaFoundationApi
    {
        private static bool initialized;
        
        /// <summary>
        /// initializes MediaFoundation - only needs to be called once per process
        /// </summary>
        public static void Startup()
        {
            if (!initialized)
            {
                var sdkVersion = MediaFoundationInterop.MF_SDK_VERSION;
#if !NETFX_CORE
                var os = Environment.OSVersion;
                if (os.Version.Major == 6 && os.Version.Minor == 0)
                    sdkVersion = 1;
#endif
                MediaFoundationInterop.MFStartup((sdkVersion << 16) | MediaFoundationInterop.MF_API_VERSION, 0);
                initialized = true;
            }
        }

        /// <summary>
        /// uninitializes MediaFoundation
        /// </summary>
        public static void Shutdown()
        {
            if (initialized)
            {
                MediaFoundationInterop.MFShutdown();
                initialized = false;
            }
        }

        /// <summary>
        /// Creates a Media type
        /// </summary>
        public static IMFMediaType CreateMediaType()
        {
            IMFMediaType mediaType;
            MediaFoundationInterop.MFCreateMediaType(out mediaType);
            return mediaType;
        }

        /// <summary>
        /// Creates a memory buffer of the specified size
        /// </summary>
        /// <param name="bufferSize">Memory buffer size in bytes</param>
        /// <returns>The memory buffer</returns>
        public static IMFMediaBuffer CreateMemoryBuffer(int bufferSize)
        {
            IMFMediaBuffer buffer;
            MediaFoundationInterop.MFCreateMemoryBuffer(bufferSize, out buffer);
            return buffer;
        }

        /// <summary>
        /// Creates a sample object
        /// </summary>
        /// <returns>The sample object</returns>
        public static IMFSample CreateSample()
        {
            IMFSample sample;
            MediaFoundationInterop.MFCreateSample(out sample);
            return sample;
        }

        /// <summary>
        /// Creates a new attributes store
        /// </summary>
        /// <param name="initialSize">Initial size</param>
        /// <returns>The attributes store</returns>
        public static IMFAttributes CreateAttributes(int initialSize)
        {
            IMFAttributes attributes;
            MediaFoundationInterop.MFCreateAttributes(out attributes, initialSize);
            return attributes;
        }
    }
}
