﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;

namespace XFSNet
{
    public class XFSUtil
    {
        private static Regex regVersion = new Regex(@"^\d\.\d$");
        public static readonly int IntPtrSize = 0;
        static XFSUtil()
        {
            IntPtrSize = Marshal.SizeOf(typeof(IntPtr));
        }
        public static void PtrToStructure<T>(IntPtr ptr, ref T p) where T : struct
        {
            p = (T)Marshal.PtrToStructure(ptr, typeof(T));
        }
        public static int ParseVersionString(string lowVersion, string hightVersion)
        {
            if (regVersion.IsMatch(lowVersion) && regVersion.IsMatch(hightVersion))
            {
                int low = (lowVersion[0] - '0') | ((lowVersion[2] - '0') >> 8);
                int high = (hightVersion[0] - '0') | ((hightVersion[2] - '0') >> 8);
                return high | (low >> 16);
            }
            return -1;
        }
        public static T[] XFSPtrToArray<T>(IntPtr ptr)
        {
            if (ptr != IntPtr.Zero)
            {
                int len = 0;
                for (int i = 0; Marshal.ReadIntPtr(IntPtr.Add(ptr, i)) != IntPtr.Zero; i += IntPtrSize)
                    ++len;
                if (len > 0)
                {
                    T[] arr = new T[len];
                    for (int i = 0; i < len; ++i)
                    {
                        arr[i] = (T)Marshal.PtrToStructure(Marshal.ReadIntPtr(IntPtr.Add(ptr, i * IntPtrSize)), typeof(T));
                    }
                    return arr;
                }
            }
            return new T[0];
        }
    }
}
