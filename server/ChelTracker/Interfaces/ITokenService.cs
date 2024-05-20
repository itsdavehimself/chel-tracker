using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChelTracker.Models;

namespace ChelTracker.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(User user);
    }
}