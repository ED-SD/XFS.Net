﻿using System;
using System.Collections.Generic;
using System.Text;

namespace XFSNet
{
    public enum DEVSTATUS: ushort
    {
        WFS_STAT_DEVONLINE = 0,
        WFS_STAT_DEVOFFLINE = 1,
        WFS_STAT_DEVPOWEROFF = 2,
        WFS_STAT_DEVNODEVICE = 3,
        WFS_STAT_DEVHWERROR = 4,
        WFS_STAT_DEVUSERERROR = 5,
        WFS_STAT_DEVBUSY = 6,
        WFS_STAT_DEVFRAUDATTEMPT = 7,
        WFS_STAT_DEVPOTENTIALFRAUD = 8
    }
}
