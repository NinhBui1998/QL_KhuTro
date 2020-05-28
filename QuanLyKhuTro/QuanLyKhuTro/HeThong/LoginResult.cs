using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhuTro.HeThong
{
   public enum LoginResult
    {
        ///<sumary>
        ///wrong user or pass
        ///</sumary>
        Invalid,
        ///<sumary>
        ///User had been disable
        ///</sumary>
        Disable,
        ///<sumary>
        ///Login success
        ///</sumary>
        Success

    }
}
