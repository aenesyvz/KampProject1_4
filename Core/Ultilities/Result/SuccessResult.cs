﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Ultilities.Result
{
    public class SuccessResult:Result
    {
        public SuccessResult(string message):base(true,message)
        {
                
        }
        public SuccessResult() : base(true)
        {

        }
    }
}
