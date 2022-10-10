using System.ComponentModel.Composition;

using BBS.Interface;

namespace BBS.Services
{
    [Export(typeof(IUserService))]
    [ExportMetadata("Name", "UserService")]
    public class UserService:IUserService
    {

    }
}