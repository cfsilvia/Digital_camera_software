using NAudio.MediaFoundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;

namespace MFTestSharp
{
    class H264Writer
    {
        private IMFSinkWriter _writer;
        private int _streamIndex;

        public H264Writer( string path, TIS.Imaging.FrameType inputType, int fps, int bitrate )
        {
            System.Diagnostics.Debug.Assert(inputType.Subtype == TIS.Imaging.MediaSubtypes.RGB32);

            CreateWriter(path, inputType.Width, inputType.Height, fps, bitrate);
        }

        private void CreateWriter(string path, int width, int height, int fps, int bitrate)
        {
            var MFVideoFormat_RGB32 = new Guid("00000016-0000-0010-8000-00AA00389B71");
            var MFVideoFormat_H264 = new Guid("34363248-0000-0010-8000-00AA00389B71");
            var MF_MT_INTERLACE_MODE = new Guid("e2724bb8-e676-4806-b4b2-a8d6efb44ccd");
            var MFVideoInterlace_Progressive = 2;
            var MF_MT_FRAME_SIZE = new Guid("1652c33d-d6b2-4012-b834-72030849a37d");
            var MF_MT_FRAME_RATE = new Guid("c459a2e8-3d2c-4e44-b132-fee5156c7bb0");
            var MF_MT_PIXEL_ASPECT_RATIO = new Guid("c6376a1e-8d0a-4027-be45-6d9a0ad39bb6");

            MediaFoundationInterop.MFCreateSinkWriterFromURL(path, null, null, out _writer);

            MediaFoundationInterop.MFCreateMediaType(out IMFMediaType outType);
            outType.SetGUID(MediaFoundationAttributes.MF_MT_MAJOR_TYPE, MediaTypes.MFMediaType_Video);
            outType.SetGUID(MediaFoundationAttributes.MF_MT_SUBTYPE, MFVideoFormat_H264);
            outType.SetUINT32(MediaFoundationAttributes.MF_MT_AVG_BITRATE, bitrate);
            outType.SetUINT32(MF_MT_INTERLACE_MODE, MFVideoInterlace_Progressive);
            outType.SetUINT64(MF_MT_FRAME_SIZE, ((long)width) << 32 | (long)height);
            outType.SetUINT64(MF_MT_FRAME_RATE, ((long)fps) << 32 | (long)1);
            outType.SetUINT64(MF_MT_PIXEL_ASPECT_RATIO, ((long)1) << 32 | (long)1);
            _writer.AddStream(outType, out _streamIndex);

            MediaFoundationInterop.MFCreateMediaType(out IMFMediaType inType);
            inType.SetGUID(MediaFoundationAttributes.MF_MT_MAJOR_TYPE, MediaTypes.MFMediaType_Video);
            inType.SetGUID(MediaFoundationAttributes.MF_MT_SUBTYPE, MFVideoFormat_RGB32);
            inType.SetUINT32(MF_MT_INTERLACE_MODE, MFVideoInterlace_Progressive);
            inType.SetUINT64(MF_MT_FRAME_SIZE, ((long)width) << 32 | (long)height);
            inType.SetUINT64(MF_MT_FRAME_RATE, ((long)fps) << 32 | (long)1);
            inType.SetUINT64(MF_MT_PIXEL_ASPECT_RATIO, ((long)1) << 32 | (long)1);
            _writer.SetInputMediaType(_streamIndex, inType, null);
        }


        public void Begin()
        {
            _writer.BeginWriting();
        }

        [System.Runtime.InteropServices.DllImport("mfplat.dll", ExactSpelling = true, PreserveSig = false)]
        private static extern void MFCopyImage(IntPtr pDest, int lDestStride, IntPtr pSrc, int lSrcStride, uint dwWidthInBytes, uint dwLines);

        private void WriteFrame(IntPtr data, int width, int height, long ts, long dt)
        {
            int stride = width * 4;
            int cbBuffer = stride * height;

            MediaFoundationInterop.MFCreateMemoryBuffer(cbBuffer, out IMFMediaBuffer buffer);
                        
            buffer.Lock(out IntPtr ptr, out int maxLength, out int currentLength);
            MFCopyImage(ptr, stride, data, stride, (uint)stride, (uint)height);
            buffer.Unlock();
            buffer.SetCurrentLength(cbBuffer);

            MediaFoundationInterop.MFCreateSample(out IMFSample sample);

            sample.AddBuffer(buffer);

            sample.SetSampleTime(ts);
            sample.SetSampleDuration(dt);

            _writer.WriteSample(_streamIndex, sample);

            System.Runtime.InteropServices.Marshal.ReleaseComObject(sample);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(buffer);
        }

        public void Write( TIS.Imaging.IFrameQueueBuffer buffer )
        {
            long ts = (long)(buffer.FrameMetadata.SampleStartTime * 10000000);
            long dt = (long)((buffer.FrameMetadata.SampleEndTime - buffer.FrameMetadata.SampleStartTime) * 10000000);

            WriteFrame(buffer.GetIntPtr(), buffer.FrameType.Width, buffer.FrameType.Height, ts, dt);
        }

        public void Write(TIS.Imaging.IFrame buffer)
        {
            long ts = (long)(buffer.FrameMetadata.SampleStartTime * 10000000);
            long dt = (long)((buffer.FrameMetadata.SampleEndTime - buffer.FrameMetadata.SampleStartTime) * 10000000);

            WriteFrame(buffer.GetIntPtr(), buffer.FrameType.Width, buffer.FrameType.Height, ts, dt);
        }

        public void End()
        {
            _writer.DoFinalize();
        }
    }
}
