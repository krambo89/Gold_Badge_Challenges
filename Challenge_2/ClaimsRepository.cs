using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_2
{
    public class ClaimsRepository
    {
        private readonly Queue<Claims> _claimsDirectory = new Queue<Claims>();

        public void AddClaimsToDirectory(Claims claim)
        {
            _claimsDirectory.Enqueue(claim);
        }

        public Queue<Claims> GetClaimsDirectory()
        {
            return _claimsDirectory;
        }

        public Claims GetClaimsByClaimID(int claimID)
        {
            foreach (Claims item in _claimsDirectory)
            {
                if (item.ClaimID == claimID)
                {
                    return item;
                }
            }

            return null;
        }

        public bool UpdateExistingClaims(int originalClaimID, Claims newClaimID)
        {
            Claims oldClaimID = GetClaimByClaimID(originalClaimID);

            if (oldClaimID !=null)
            {
                oldClaimID.ClaimID = newClaimID.ClaimID;
                oldClaimID.ClaimType = newClaimID.ClaimType;
                oldClaimID.Description = newClaimID.Description;
                oldClaimID.ClaimAmount = newClaimID.ClaimAmount;
                oldClaimID.DateOfIncident = newClaimID.DateOfIncident;
                oldClaimID.DateOfClaim = newClaimID.DateOfClaim;
                oldClaimID.IsValid = newClaimID.IsValid;

                return true;
            }
            else
            {
                return false;
            }
        }
       
        public void DeleteExistingClaim()
        {
             _claimsDirectory.Dequeue();
        }
        private Claims GetClaimByClaimID(int claimID)
        {
            foreach (Claims item in _claimsDirectory)
            {
                if (item.ClaimID == claimID)
                {
                    return item;
                }
            }

            return null;
        }
    }
}
