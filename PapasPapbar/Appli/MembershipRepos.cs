using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using PapasPapbar.Domain;

namespace PapasPapbar.Appli
{
    public class MembershipRepos
    {
        private Membership membership = new Membership();

        public void InsertMembership(Membership membership)
        {
            membership.AddMembership(membership.MemberName, membership.MemberEmail, membership.SubDate, membership.EndDate);
        }

        public void UpdateMembership(Membership membership)
        {
            membership.UpdateMembership(membership.MemberName, membership.MemberEmail, membership.SubDate, membership.EndDate, membership.MemberNo);
        }

        public void DeleteMembership(int memberNo)
        {
            membership.DeleteMembership(memberNo);
        }
    }
}
