namespace DddStudy.Domain.Commands.Users
{
    // Name, Address プロパティに setter が必要になるパターン
    // public class UserUpdateCommand
    // {
    //     public UserUpdateCommand(string id)
    //     {
    //         Id = id;
    //     }
    //
    //     public string Id { get; }
    //     public string Name { get; set; }
    //     public string Address { get; set; }
    // }


    // この場合は各プロパティに setter が不要になる
    public class UserUpdateCommand
    {
        public UserUpdateCommand(string id, string name = null, string mailAddress = null)
        {
            Id = id;
            Name = name;
            MailAddress = mailAddress;
        }

        public string Id { get; }
        public string Name { get; }
        public string MailAddress { get; }
    }
}