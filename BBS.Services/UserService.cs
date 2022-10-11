using System.ComponentModel.Composition;

using BBS.Interface;
using BBS.Model.ApiEntiy;
using BBS.ORM.DBContent;

namespace BBS.Services
{
    [Export(typeof(IUserService))]
    [ExportMetadata("Name", "UserService")]
    public class UserService:IUserService
    {

        public void Test() {
           
        }
    }
}