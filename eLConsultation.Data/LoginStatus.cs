using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eLConsultation.Data
{
    //
    // Summary:
    //     Possible results from a login in attempt
    public enum LoginStatus
    {
        //
        // Summary:
        //     Sign in was successful
        Success = 0,
        //
        // Summary:
        //     User is locked out
        LockedOut = 1,
        //
        // Summary:
        //     Sign in requires email confirmation
        RequireConfirmation = 2,
        //
        // Summary:
        //     Sign in failed
        Failure = 3,
        //
        //Sumary:
        //     Exception
        SystemFailure = -1
    }
}
