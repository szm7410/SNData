using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DataAccess
{
    class CommonData
    {
    }
    [DataContract]
    public class UserDetail
    {
        [DataMember(Name = "name")]
        public string Name;

        [DataMember(Name = "userid")]
        public string UserId;

        [DataMember(Name = "email")]
        public string Email;
    }
    [DataContract]
    public class UserDetailList
    {
        [DataMember(Name = "Elementlist")]
        public List<UserDetail> Elementlist;

        [DataMember(Name = "count")]
        public int Count;
    }

    [DataContract]
    public class AppAllowUserResult
    {
        [DataMember(Name = "appName")]
        public string AppName;

        [DataMember(Name = "allowUsers")]
        public List<string> AllowUsers;

        [DataMember(Name = "userCount")]
        public int UserCount;
    }
}
