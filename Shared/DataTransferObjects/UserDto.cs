﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    //[Serializable]
    public record UserDto { 
        
            public int UserId { get; init; }
            public string Name { get; init; }
            public string Position { get; init; }
          
    };


}
