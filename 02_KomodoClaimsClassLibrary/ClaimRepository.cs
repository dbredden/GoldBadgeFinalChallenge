using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_KomodoClaimsClassLibrary
{
    public class ClaimRepository
    {
        private Queue<Claim> _claimDirectory = new Queue<Claim>();

        // CREATE NEW CLAIM
        public bool AddClaimToDirectory(Claim newClaim)
        {
            int startingCount = _claimDirectory.Count;
            _claimDirectory.Enqueue(newClaim);
            bool wasAdded = _claimDirectory.Count > startingCount ? true : false;
            return wasAdded;
        }

        // READ ALL CLAIMS
        public Queue<Claim> GetAllClaims()
        {
            return _claimDirectory;
        }
        
        // DELETE TOP QUEUE
        public void RemoveClaim()
        {
            _claimDirectory.Dequeue();
        }

        public void IsValid(Claim claim)
        {
            if (claim.DateOfClaim < claim.DateOfIncident)
                claim.DateOfClaim = claim.DateOfIncident;

            TimeSpan difference = claim.DateOfClaim - claim.DateOfIncident;

            if (difference.Days <= 30)
            {
                claim.IsValid = true;
            }
            else
                claim.IsValid = false;
        }
    }
}
